using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace MinecraftServerSetup
{
    public class GetServerList
    {
        public List<ServerInfo> Get()
        {
            string currentDirectory = Application.StartupPath.ToString();
            string serversDirectory = string.Format(@"{0}\{1}", currentDirectory, "servers");
            List<ServerInfo> servers = new List<ServerInfo>();
            ServerInfo si = null;
            if (Directory.Exists(serversDirectory))
            {
                string[] settingsFiles = Directory.GetFiles(serversDirectory, "*.set");
                foreach (string settingsFile in settingsFiles)
                {
                    FileInfo fi = new FileInfo(settingsFile);
                    string fileName = fi.Name.ToString();
                    using (StreamReader reader = new StreamReader(settingsFile))
                    {
                        string line = string.Empty;
                        while ((line = reader.ReadLine()) != null)
                        {
                            if (line.Equals("[Server]"))
                            {

                                si = new ServerInfo();
                                si.FileName = fileName;
                            }
                            if (line.StartsWith("Name"))
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
                                servers.Add(si);
                            }
                        }
                    }
                }
            }
            return servers;
        }
    }
}
