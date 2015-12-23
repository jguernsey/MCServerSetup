using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Renci.SshNet;

namespace MinecraftServerSetup
{
    public partial class FrmServerSetup : Form
    {
        public FrmServerSetup()
        {
            InitializeComponent();
        }

        private void ClickedOk(object sender, EventArgs e)
        {
            bool formValid = CheckValidation();
            if(formValid)
            {
                string currentDirectory = Application.StartupPath.ToString();
                string serversDirectory = string.Format(@"{0}\{1}", currentDirectory, "servers");
                string settingsFile = string.Format(@"{0}\{1}.set", serversDirectory, CleanInput(txtName.Text.ToString()));
                if (!Directory.Exists(serversDirectory))
                {
                    Directory.CreateDirectory(serversDirectory);
                }
                if(File.Exists(settingsFile))
                {
                    string backupFile = string.Format(@"{0}.bak", settingsFile);
                    if (File.Exists(backupFile))
                    {
                        File.Delete(backupFile);
                    }
                    File.Move(settingsFile, backupFile);
                }
                WriteSettingsFile(settingsFile);
                this.Close();
            }
            else
            {
                MessageBox.Show("Error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void WriteSettingsFile(string settingsFile)
        {
            using (StreamWriter writer = new StreamWriter(settingsFile, true))
            {
                writer.WriteLine("[Server]");
            }
            PropertyWriter("Name", txtName.Text.ToString(), settingsFile);
            PropertyWriter("Address", txtAddress.Text.ToString(), settingsFile);
            PropertyWriter("Username", txtUsername.Text.ToString(), settingsFile);
            PropertyWriter("Password", txtPassword.Text.ToString(), settingsFile);
            NewServerSetup(settingsFile);
        }
        private void NewServerSetup(string settingsFile)
        {
            ConnectionInfo ci = GetConnectionInfo(settingsFile);
            string password = GetPassword(settingsFile);

            using (SshClient client = new SshClient(ci))
            {
                client.Connect();
                using (var cmd = client.CreateCommand("cd /minecraftServers"))
                {
                    cmd.Execute();
                    if (cmd.Error.Contains("No such file or directory"))
                    {
                        using (var cmd2 = client.CreateCommand(string.Format("echo '{0}' | sudo -kS mkdir -p /minecraftServers", password)))
                        {
                            cmd2.Execute();
                        }
                    }
                    using (var cmd3 = client.CreateCommand("ls -al"))
                    {
                        cmd3.Execute();
                    }
                }
                client.Disconnect();
            }

            using (SftpClient sftp = new SftpClient(ci))
            {
                string fileName = "minecraft_server_1_8_9.jar";
                byte[] file = Properties.Resources.minecraft_server_1_8_9;
                sftp.Connect();
                sftp.ChangeDirectory("/tmp");
                using (MemoryStream stream = new MemoryStream(file))
                {
                    sftp.UploadFile(stream, fileName, true);
                }
                sftp.Disconnect();
            }

            using(SshClient client2 = new SshClient(ci))
            {
                client2.Connect();
                var cmd2 = client2.CreateCommand("cd /tmp");
                cmd2.Execute();
                var cmd3 = client2.CreateCommand(string.Format("echo '{0}' | sudo -kS mv /tmp/minecraft_server_1_8_9.jar /minecraftServers/minecraft_server_1_8_9.jar", password));
                cmd3.Execute();
            }
        }
        private string GetPassword(string settingsFile)
        {
            string line = string.Empty;
            string password = string.Empty;

            using (StreamReader reader = new StreamReader(settingsFile))
            {
                while ((line = reader.ReadLine()) != null)
                {
                    if (line.StartsWith("Password"))
                    {
                        password = line.Substring(line.IndexOf("=") + 1, (line.Length - (line.IndexOf("=") + 1)));
                    }
                }
            }
            return password;
        }
        private ConnectionInfo GetConnectionInfo(string settingsFile)
        {
            string line = string.Empty;
            string address = string.Empty;
            string username = string.Empty;
            string password = string.Empty;

            using (StreamReader reader = new StreamReader(settingsFile))
            {
                while ((line = reader.ReadLine()) != null)
                {
                    if (line.StartsWith("Address"))
                    {
                        address = line.Substring(line.IndexOf("=") + 1, (line.Length - (line.IndexOf("=") + 1)));
                    }
                    if (line.StartsWith("Username"))
                    {
                        username = line.Substring(line.IndexOf("=") + 1, (line.Length - (line.IndexOf("=") + 1)));
                    }
                    if (line.StartsWith("Password"))
                    {
                        password = line.Substring(line.IndexOf("=") + 1, (line.Length - (line.IndexOf("=") + 1)));
                    }
                }
            }
            ConnectionInfo ci = new ConnectionInfo(address, username, new AuthenticationMethod[] { new PasswordAuthenticationMethod(username, password) });
            return ci;
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
        private void PropertyWriter(string property, string value, string file)
        {
            using(StreamWriter writer = new StreamWriter(file, true))
            {
                writer.WriteLine("{0}={1}", property, value);
            }
        }
        private bool CheckValidation()
        {
            bool serverValid = false;
            bool validName = CheckName();
            if (validName)
            {
                bool validAddress = CheckAddress();
                if (validAddress)
                {
                    bool validUsername = CheckUsername();
                    if (validUsername)
                    {
                        bool validPassword = CheckPassword();
                        if (validPassword)
                        {
                            bool validServer = CheckServer();
                            if (validServer)
                            {
                                bool validLogin = CheckLogin();
                                if (validLogin)
                                {
                                    serverValid = true;
                                }
                                else
                                {
                                    serverValid = false;
                                }
                            }
                            else
                            {
                                serverValid = false;
                            }
                        }
                        else
                        {
                            serverValid = false;
                        }
                    }
                    else
                    {
                        serverValid = false;
                    }
                }
                else
                {
                    serverValid = false;
                }
            }
            else
            {
                serverValid = false;
            }
            return serverValid;
        }
        private bool CheckName()
        {
            bool valid = false;
            string name = txtName.Text.ToString();
            if (string.IsNullOrEmpty(name) || name.Length < 1)
            {
                valid = false;
            }
            else
            {
                valid = true;
            }
            return valid;
        }
        private bool CheckAddress()
        {
            bool valid = false;
            try
            {
                string address = txtAddress.Text.ToString();
                string pattern = @"^(([0-9]|[1-9][0-9]|1[0-9]{2}|2[0-4][0-9]|25[0-5])\.){3}([0-9]|[1-9][0-9]|1[0-9]{2}|2[0-4][0-9]|25[0-5])$";
                Regex check = new Regex(pattern);
                if(string.IsNullOrEmpty(address) || address.Length <= 0 || address.Length > 15)
                {
                    valid = false;
                }
                else if(check.IsMatch(address))
                {
                    valid = true;
                }
                else
                {
                    valid = false;
                }
            }
            catch(Exception ex)
            {
                valid = false;
            }
            return valid;
        }
        private bool CheckUsername()
        {
            bool valid = false;
            string username = txtUsername.Text.ToString();
            if(string.IsNullOrEmpty(username) || username.Length < 1)
            {
                valid = false;
            }
            else
            {
                valid = true;
            }
            return valid;
        }
        private bool CheckPassword()
        {
            bool valid = false;
            string password = txtPassword.Text.ToString();
            if (string.IsNullOrEmpty(password) || password.Length < 1)
            {
                valid = false;
            }
            else
            {
                valid = true;
            }
            return valid;
        }
        private bool CheckServer()
        {
            bool valid = false;
            Ping pingSender = new Ping();
            IPAddress address;
            IPAddress.TryParse(txtAddress.Text.ToString(), out address);
            PingReply reply = pingSender.Send(address);
            if(reply.Status == IPStatus.Success)
            {
                valid = true;
            }
            else
            {
                valid = false;
            }
            return valid;
        }
        private bool CheckLogin()
        {
            bool valid = true;
            return valid;
        }
        private void ClickedCancel(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
