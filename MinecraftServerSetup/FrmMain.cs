using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Renci.SshNet;

namespace MinecraftServerSetup
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void LoadedFrmMain(object sender, EventArgs e)
        {
            LoadSettings();
        }

        private void LoadSettings()
        {
            GetServerList gsl = new GetServerList();
            List<ServerInfo> servers = new List<ServerInfo>();
            servers = gsl.Get();
            if(servers != null)
            {
                cboServer.Items.Clear();
                cboServer.Items.Add("--- Select A Server ---");
                foreach (ServerInfo si in servers)
                {
                    cboServer.Items.Add(si.ServerName.ToString());
                }
                cboServer.SelectedIndex = 0;
            }
            else
            {
                DialogResult result = MessageBox.Show("You have not setup any servers to create Minecraft servers on.\nWould you like to set up a server now?", "Server Setup Missing", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    FrmServerSetup fss = new FrmServerSetup();
                    fss.ShowDialog();
                }
            }
        }
        private void ClickedAddServer(object sender, EventArgs e)
        {
            FrmServerSetup fss = new FrmServerSetup();
            fss.ShowDialog();
            LoadSettings();
        }

        private ServerInfo GetServerInfo()
        {
            string currentDirectory = Application.StartupPath.ToString();
            string serversDirectory = string.Format(@"{0}\{1}", currentDirectory, "servers");
            string serverName = CleanInput(cboServer.SelectedItem.ToString());
            string settingsFile = string.Format(@"{0}\{1}.set", serversDirectory, serverName);

            string line = string.Empty;
            ServerInfo si = new ServerInfo();

            using (StreamReader reader = new StreamReader(settingsFile))
            {
                while ((line = reader.ReadLine()) != null)
                {
                    if(line.StartsWith("Name"))
                    {
                        si.ServerName = line.Substring(line.IndexOf("=") + 1, (line.Length - (line.IndexOf("=") + 1)));
                    }
                    if (line.StartsWith("Address"))
                    {
                        si.IpAddress = line.Substring(line.IndexOf("=") + 1, (line.Length - (line.IndexOf("=") + 1)));
                    }
                    if (line.StartsWith("Username"))
                    {
                        si.Username = line.Substring(line.IndexOf("=") + 1, (line.Length - (line.IndexOf("=") + 1)));
                    }
                    if (line.StartsWith("Password"))
                    {
                        si.Password = line.Substring(line.IndexOf("=") + 1, (line.Length - (line.IndexOf("=") + 1)));
                    }
                }
            }
            return si;
        }
        private void ClickedEditServer(object sender, EventArgs e)
        {

        }

        private void ClickedStartServer(object sender, EventArgs e)
        {
            ServerInfo si = new ServerInfo();
            si = GetServerInfo();
            string serverName = lstWorlds.SelectedItem.ToString();

            string startCommand = string.Format(@"echo '{0}' | sudo -kS java -Xmx1024M -Xms1024M -jar /minecraftServers/{1}/minecraft_server_1_8_9.jar nogui", si.Password, serverName);
            ConnectionInfo ci = new ConnectionInfo(si.IpAddress, si.Username, new AuthenticationMethod[] { new PasswordAuthenticationMethod(si.Username, si.Password) });
            using(SshClient client = new SshClient(ci))
            {
                client.Connect();
                using(var cmd = client.CreateCommand(startCommand))
                {
                    cmd.Execute();
                }
                client.Disconnect();
            }
        }

        private void ClickedStopServer(object sender, EventArgs e)
        {

        }

        private void ClickedRunCommand(object sender, EventArgs e)
        {

        }

        private void ClickedEditWorld(object sender, EventArgs e)
        {
            ServerInfo si = new ServerInfo();
            si = GetServerInfo();

            FrmServerProperties fsp = new FrmServerProperties();
            fsp.ServerDetails = si;
            fsp.ShowDialog();
        }

        private void ServerIndexChanged(object sender, EventArgs e)
        {
            if(cboServer.SelectedIndex > 0)
            {
                string serverName = cboServer.SelectedItem.ToString();
                string currentDirectory = Application.StartupPath.ToString();
                string serversDirectory = string.Format(@"{0}\{1}", currentDirectory, "servers");
                string settingsFile = string.Format(@"{0}\{1}.set", serversDirectory, CleanInput(serverName));
                string line = string.Empty;
                string address = string.Empty;
                string username = string.Empty;
                string password = string.Empty;

                using(StreamReader reader = new StreamReader(settingsFile))
                {
                    while((line = reader.ReadLine()) != null)
                    {
                        if(line.StartsWith("Address"))
                        {
                            address = line.Substring(line.IndexOf("=") + 1, (line.Length - (line.IndexOf("=") + 1)));
                        }
                        if(line.StartsWith("Username"))
                        {
                            username = line.Substring(line.IndexOf("=") + 1, (line.Length - (line.IndexOf("=") + 1)));
                        }
                        if(line.StartsWith("Password"))
                        {
                            password = line.Substring(line.IndexOf("=") + 1, (line.Length - (line.IndexOf("=") + 1)));
                        }
                    }
                }
                ConnectionInfo ci = new ConnectionInfo(address, username, new AuthenticationMethod[] { new PasswordAuthenticationMethod(username, password) });
                using(SshClient client = new SshClient(ci))
                {
                    client.Connect();
                    using(var cmd = client.CreateCommand("cd /minecraftServers"))
                    {
                        cmd.Execute();
                        if (cmd.Error.Contains("No such file or directory"))
                        {
                            using(var cmd2 = client.CreateCommand(string.Format("echo '{0}' | sudo -kS mkdir -p /minecraftServers", password)))
                            {
                                cmd2.Execute();
                            }
                        }
                        using(var cmd3 = client.CreateCommand("ls -al"))
                        {
                            cmd3.Execute();
                        }
                    }
                    client.Disconnect();
                }
                using(SftpClient sftp = new SftpClient(ci))
                {
                    string fileName = "minecraft_server_1_8_9.jar";
                    byte[] file = Properties.Resources.minecraft_server_1_8_9;
                    sftp.Connect();
                    sftp.ChangeDirectory("/minecraftServers");
                    using(MemoryStream stream = new MemoryStream(file))
                    {
                        sftp.UploadFile(stream, fileName, true);
                    }
                    sftp.Disconnect();
                }
                string folders = string.Empty;
                using(SshClient ssh = new SshClient(ci))
                {
                    ssh.Connect();
                    using(var cmd = ssh.CreateCommand("cd /minecraftServers/ && ls -d */"))
                    {
                        cmd.Execute();
                        folders = cmd.Result.ToString();
                    }
                    ssh.Disconnect();
                }
                string[] stuff = folders.Split('\n');
                foreach(string svr in stuff)
                {
                    lstWorlds.Items.Add(svr.Replace("/", string.Empty));
                }
            }
        }
        private string CleanInput(string strIn)
        {
            try
            {
                string value = Regex.Replace(strIn, @"[^\w\.@-]", "", RegexOptions.None, TimeSpan.FromSeconds(1.5));
                return value.Replace(" ", string.Empty);
            }
            catch (RegexMatchTimeoutException)
            {
                return String.Empty;
            }
        }

        private void ClickedAddMinecraftServer(object sender, EventArgs e)
        {
            ServerInfo si = new ServerInfo();
            si = GetServerInfo();

            FrmServerProperties fsp = new FrmServerProperties();
            fsp.ServerDetails = si;
            fsp.ShowDialog();
        }
    }
}
