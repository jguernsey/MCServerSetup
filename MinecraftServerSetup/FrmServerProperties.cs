using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Renci.SshNet;

namespace MinecraftServerSetup
{
    public partial class FrmServerProperties : Form
    {
        private ServerInfo serverInfo;
        public ServerInfo ServerDetails
        {
            get { return serverInfo; }
            set { serverInfo = value; }
        }
        public FrmServerProperties()
        {
            InitializeComponent();
        }

        private void LoadedServerProperties(object sender, EventArgs e)
        {
            LoadDefaults();
        }

        private void LoadDefaults()
        {
            txtLevelName.Text = string.Empty;
            txtMessage.Text = string.Empty;
            txtLevelSeed.Text = string.Empty;
            cboAllowNether.SelectedIndex = 1;
            cboAllowFlight.SelectedIndex = 0;
            cboAnnounceAchievements.SelectedIndex = 1;
            cboDifficulty.SelectedIndex = 2;
            cboEnableQuery.SelectedIndex = 0;
            cboEnableRcon.SelectedIndex = 0;
            cboEnableCommand.SelectedIndex = 0;
            cboForceGameMode.SelectedIndex = 0;
            cboGameMode.SelectedIndex = 1;
            cboGenerateStructures.SelectedIndex = 1;
            txtGeneratorSettings.Text = string.Empty;
            cboHardcore.SelectedIndex = 0;
            cboLevelType.SelectedIndex = 1;
            txtMaxWorldSize.Value = 29999984;
            txtMaxBuild.Value = 256;
            txtMaxPlayers.Value = 20;
            txtMaxTickTime.Value = 60000;
            txtCompression.Value = 256;
            cboOnlineMode.SelectedIndex = 1;
            cboOperatorLevel.SelectedIndex = 5;
            txtPlayerTimeout.Value = 0;
            cboPvp.SelectedIndex = 1;
            txtQueryPort.Value = 25565;
            txtRconPassword.Text = string.Empty;
            txtRconPort.Value = 25575;
            txtResourcePack.Text = string.Empty;
            txtResourcePackHash.Text = string.Empty;
            txtServerAddress.Text = string.Empty;
            cboSnooper.SelectedIndex = 1;
            cboSpawnAnimals.SelectedIndex = 1;
            cboSpawnMonsters.SelectedIndex = 1;
            cboSpawnNpcs.SelectedIndex = 1;
            cboUseNativeTransport.SelectedIndex = 1;
            txtViewDistance.Value = 10;
            cboWhiteList.SelectedIndex = 0;
        }

        private void ClickedCancel(object sender, EventArgs e)
        {

        }

        private void ClickedSave(object sender, EventArgs e)
        {
            string serverName = txtLevelName.Text.ToString();
            string currentDirectory = Application.StartupPath.ToString();
            string tempFile = string.Format(@"{0}\server.properties", currentDirectory);
            using(StreamWriter writer = new StreamWriter(tempFile))
            {
                writer.WriteLine("#Minecraft server properties");
                writer.WriteLine("#{0} {1} {2} {3:00}:{4:00}:{5:00} CST {6}", DateTime.Now.DayOfWeek.ToString(), DateTime.Now.Month.ToString(), DateTime.Now.Day.ToString(), DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second, DateTime.Now.Year);
                writer.WriteLine(string.Format("allow-flight={0}", cboAllowFlight.SelectedItem.ToString().ToLower()));
                writer.WriteLine(string.Format("allow-nether={0}", cboAllowNether.SelectedItem.ToString().ToLower()));
                writer.WriteLine(string.Format("announce-player-achievements={0}", cboAnnounceAchievements.SelectedItem.ToString().ToLower()));
                writer.WriteLine(string.Format("difficulty={0}", (cboDifficulty.SelectedIndex - 1).ToString().ToLower()));
                writer.WriteLine(string.Format("enable-query={0}", cboEnableQuery.SelectedItem.ToString().ToLower()));
                writer.WriteLine(string.Format("enable-rcon={0}", cboEnableRcon.SelectedItem.ToString().ToLower()));
                writer.WriteLine(string.Format("enable-command-block={0}", cboEnableCommand.SelectedItem.ToString().ToLower()));
                writer.WriteLine(string.Format("force-gamemode={0}", cboForceGameMode.SelectedItem.ToString().ToLower()));
                writer.WriteLine(string.Format("gamemode={0}", (cboGameMode.SelectedIndex - 1).ToString().ToLower()));
                writer.WriteLine(string.Format("generate-structures={0}", cboGenerateStructures.SelectedItem.ToString().ToLower()));
                writer.WriteLine(string.Format("generator-settings={0}", txtGeneratorSettings.Text.ToString().ToLower()));
                writer.WriteLine(string.Format("hardcore={0}", cboHardcore.SelectedItem.ToString().ToLower()));
                writer.WriteLine(string.Format("level-name={0}", txtLevelName.Text.ToString()));
                writer.WriteLine(string.Format("level-seed={0}", txtLevelSeed.Text.ToString()));
                writer.WriteLine(string.Format("level-type={0}", cboLevelType.SelectedItem.ToString().ToUpper()));
                writer.WriteLine(string.Format("max-build-height={0}", txtMaxBuild.Value.ToString().ToLower()));
                writer.WriteLine(string.Format("max-players={0}", txtMaxPlayers.Value.ToString().ToLower()));
                writer.WriteLine(string.Format("max-tick-time={0}", txtMaxTickTime.Value.ToString().ToLower()));
                writer.WriteLine(string.Format("max-world-size={0}", txtMaxWorldSize.Value.ToString().ToLower()));
                writer.WriteLine(string.Format("motd={0}", txtMessage.Text.ToString()));
                writer.WriteLine(string.Format("network-compression-threshold={0}", txtCompression.Value.ToString().ToLower()));
                writer.WriteLine(string.Format("online-mode={0}", cboOnlineMode.SelectedItem.ToString().ToLower()));
                writer.WriteLine(string.Format("op-permission-level={0}", (cboOperatorLevel.SelectedIndex - 1).ToString().ToLower()));
                writer.WriteLine(string.Format("player-idle-timeout={0}", txtPlayerTimeout.Value.ToString().ToLower()));
                writer.WriteLine(string.Format("pvp={0}", cboPvp.SelectedItem.ToString().ToLower()));
                writer.WriteLine(string.Format("query.port={0}", txtQueryPort.Value.ToString().ToLower()));
                writer.WriteLine(string.Format("rcon.password={0}", txtRconPassword.Text.ToString().ToLower()));
                writer.WriteLine(string.Format("rcon.port={0}", txtRconPort.Value.ToString().ToLower()));
                writer.WriteLine(string.Format("resource-pack={0}", txtResourcePack.Text.ToString().ToLower()));
                writer.WriteLine(string.Format("resource-pack-hash={0}", txtResourcePackHash.Text.ToString().ToLower()));
                writer.WriteLine(string.Format("server-ip={0}", txtServerAddress.Text.ToString().ToLower()));
                writer.WriteLine(string.Format("server-port={0}", txtServerPort.Value.ToString().ToLower()));
                writer.WriteLine(string.Format("snooper-enabled={0}", cboSnooper.SelectedItem.ToString().ToLower()));
                writer.WriteLine(string.Format("spawn-animals={0}", cboSpawnAnimals.SelectedItem.ToString().ToLower()));
                writer.WriteLine(string.Format("spawn-monsters={0}", cboSpawnMonsters.SelectedItem.ToString().ToLower()));
                writer.WriteLine(string.Format("spawn-npcs={0}", cboSpawnNpcs.SelectedItem.ToString().ToLower()));
                writer.WriteLine(string.Format("spawn-protection={0}", txtSpawnProtection.Value.ToString().ToLower()));
                writer.WriteLine(string.Format("use-native-transport={0}", cboUseNativeTransport.SelectedItem.ToString().ToLower()));
                writer.WriteLine(string.Format("view-distance={0}", txtViewDistance.Value.ToString().ToLower()));
                writer.WriteLine(string.Format("white-list={0}", cboWhiteList.SelectedItem.ToString().ToLower()));
            }

            string eulaFile = string.Format(@"{0}\eula.txt", currentDirectory);
            using(StreamWriter writerB = new StreamWriter(eulaFile))
            {
                writerB.WriteLine("#By changing the setting below to TRUE you are indicating your agreement to our EULA (https://account.mojang.com/documents/minecraft_eula)");
                writerB.WriteLine("#{0} {1} {2} {3:00}:{4:00}:{5:00} CST {6}", DateTime.Now.DayOfWeek.ToString(), DateTime.Now.Month.ToString(), DateTime.Now.Day.ToString(), DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second, DateTime.Now.Year);
                writerB.WriteLine("eula=true");
            }

            string bannedIps = string.Format(@"{0}\banned-ips.json", currentDirectory);
            using(StreamWriter writerC = new StreamWriter(bannedIps))
            {
                writerC.WriteLine("[]");
            }
            string bannedPlayers = string.Format(@"{0}\banned-players.json", currentDirectory);
            using (StreamWriter writerC = new StreamWriter(bannedPlayers))
            {
                writerC.WriteLine("[]");
            }
            string ops = string.Format(@"{0}\ops.json", currentDirectory);
            using (StreamWriter writerC = new StreamWriter(ops))
            {
                writerC.WriteLine("[]");
            }
            string usercache = string.Format(@"{0}\usercache.json", currentDirectory);
            using (StreamWriter writerC = new StreamWriter(usercache))
            {
                writerC.WriteLine("[]");
            }
            string whitelist = string.Format(@"{0}\whitelist.json", currentDirectory);
            using(StreamWriter writerC = new StreamWriter(whitelist))
            {
                writerC.WriteLine("[]");
            }


            string cd = Application.StartupPath.ToString();
            string serversDirectory = string.Format(@"{0}\{1}", cd, "servers");
            string sn = CleanInput(serverInfo.ServerName);
            string settingsFile = string.Format(@"{0}\{1}.set", serversDirectory, sn);
            BuildServer(settingsFile, CleanInput(serverName));
            this.Close();
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
        private void BuildServer(string settingsFile, string serverName)
        {
            ConnectionInfo ci = GetConnectionInfo(settingsFile);
            string password = GetPassword(settingsFile);

            using (SshClient client = new SshClient(ci))
            {
                client.Connect();
                using (var cmd = client.CreateCommand(string.Format("echo '{0}' | sudo -kS mkdir -p /minecraftServers/{1}", password, serverName)))
                {
                    cmd.Execute();
                }
                using(var cmd2 = client.CreateCommand(string.Format("echo '{0} | sudo -kS cp /minecraftServers/minecraft_server_1_8_9.jar /minecraftServers/{1}/minecraft_server_1_8_9.jar", password, serverName)))
                {
                    cmd2.Execute();
                }
            }

            string currentDirectory = Application.StartupPath.ToString();

            string tempFile = string.Format(@"{0}\server.properties", currentDirectory);
            string tempTarget = "server.properties";

            string eulaFile = string.Format(@"{0}\eula.txt", currentDirectory);
            string eulaTarget = "eula.txt";

            string bannedIps = string.Format(@"{0}\banned-ips.json", currentDirectory);
            string ipsTarget = "banned-ips.json";

            string bannedPlayers = string.Format(@"{0}\banned-players.json", currentDirectory);
            string playersTarget = "banned-players.json";

            string ops = string.Format(@"{0}\ops.json", currentDirectory);
            string opsTarget = "ops.json";

            string usercache = string.Format(@"{0}\usercache.json", currentDirectory);
            string userTarget = "usercache.json";

            string whitelist = string.Format(@"{0}\whitelist.json", currentDirectory);
            string whiteTarget = "whitelist.json";

            UploadFile(ci, tempFile, tempTarget, password, serverName);
            UploadFile(ci, eulaFile, eulaTarget, password, serverName);
            UploadFile(ci, bannedIps, ipsTarget, password, serverName);
            UploadFile(ci, bannedPlayers, playersTarget, password, serverName);
            UploadFile(ci, ops, opsTarget, password, serverName);
            UploadFile(ci, usercache, userTarget, password, serverName);
            UploadFile(ci, whitelist, whiteTarget, password, serverName);
            CopyServerFile(serverName, ci, password);
        }
        private void UploadFile(ConnectionInfo ci, string sourceFile, string targetFile, string password, string serverName)
        {
            using(SftpClient client = new SftpClient(ci))
            {
                client.Connect();
                client.ChangeDirectory("/tmp");
                using(var uplfileStream = File.OpenRead(sourceFile))
                {
                    client.UploadFile(uplfileStream, targetFile, true);
                }
                client.Disconnect();
            }
            string target = string.Format("/minecraftServers/{0}/{1}", serverName, targetFile);
            using(SshClient ssh = new SshClient(ci))
            {
                ssh.Connect();
                using(var cmd = ssh.CreateCommand(string.Format("echo '{0}' | cp /tmp/{1} {2}", password, targetFile, target)))
                {
                    cmd.Execute();
                }
                ssh.Disconnect();
            }
        }
        private void CopyServerFile(string serverName, ConnectionInfo ci, string password)
        {
            using(SshClient client = new SshClient(ci))
            {
                client.Connect();
                using(var cmd = client.CreateCommand(string.Format("echo '{0}' | cp /minecraftServers/minecraft_server_1_8_9.jar /minecraftServers/{1}/minecraft_server_1_8_9.jar", password, serverName)))
                {
                    cmd.Execute();
                }
                client.Disconnect();
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
    }
}
