namespace MinecraftServerSetup
{
    partial class FrmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnWhiteList = new System.Windows.Forms.Button();
            this.btnProperties = new System.Windows.Forms.Button();
            this.btnOperators = new System.Windows.Forms.Button();
            this.btnBannedPlayers = new System.Windows.Forms.Button();
            this.btnBannedAddresses = new System.Windows.Forms.Button();
            this.lstWorlds = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cboServer = new System.Windows.Forms.ComboBox();
            this.btnDeleteMinecraftServer = new System.Windows.Forms.Button();
            this.btnAddMinecraftServer = new System.Windows.Forms.Button();
            this.btnEditWorld = new System.Windows.Forms.Button();
            this.btnRunCommand = new System.Windows.Forms.Button();
            this.btnStopServer = new System.Windows.Forms.Button();
            this.btnStartServer = new System.Windows.Forms.Button();
            this.btnEditServer = new System.Windows.Forms.Button();
            this.btnAddServer = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.btnDeleteMinecraftServer);
            this.panel1.Controls.Add(this.btnAddMinecraftServer);
            this.panel1.Controls.Add(this.btnEditWorld);
            this.panel1.Controls.Add(this.btnWhiteList);
            this.panel1.Controls.Add(this.btnProperties);
            this.panel1.Controls.Add(this.btnOperators);
            this.panel1.Controls.Add(this.btnBannedPlayers);
            this.panel1.Controls.Add(this.btnBannedAddresses);
            this.panel1.Controls.Add(this.lstWorlds);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.btnRunCommand);
            this.panel1.Controls.Add(this.btnStopServer);
            this.panel1.Controls.Add(this.btnStartServer);
            this.panel1.Controls.Add(this.btnEditServer);
            this.panel1.Controls.Add(this.btnAddServer);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.cboServer);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(426, 297);
            this.panel1.TabIndex = 0;
            // 
            // btnWhiteList
            // 
            this.btnWhiteList.Location = new System.Drawing.Point(264, 152);
            this.btnWhiteList.Name = "btnWhiteList";
            this.btnWhiteList.Size = new System.Drawing.Size(150, 23);
            this.btnWhiteList.TabIndex = 13;
            this.btnWhiteList.Text = "White List";
            this.btnWhiteList.UseVisualStyleBackColor = true;
            // 
            // btnProperties
            // 
            this.btnProperties.Location = new System.Drawing.Point(264, 123);
            this.btnProperties.Name = "btnProperties";
            this.btnProperties.Size = new System.Drawing.Size(150, 23);
            this.btnProperties.TabIndex = 12;
            this.btnProperties.Text = "Server Properties";
            this.btnProperties.UseVisualStyleBackColor = true;
            // 
            // btnOperators
            // 
            this.btnOperators.Location = new System.Drawing.Point(264, 94);
            this.btnOperators.Name = "btnOperators";
            this.btnOperators.Size = new System.Drawing.Size(150, 23);
            this.btnOperators.TabIndex = 11;
            this.btnOperators.Text = "Operators";
            this.btnOperators.UseVisualStyleBackColor = true;
            // 
            // btnBannedPlayers
            // 
            this.btnBannedPlayers.Location = new System.Drawing.Point(264, 65);
            this.btnBannedPlayers.Name = "btnBannedPlayers";
            this.btnBannedPlayers.Size = new System.Drawing.Size(150, 23);
            this.btnBannedPlayers.TabIndex = 10;
            this.btnBannedPlayers.Text = "Banned Players";
            this.btnBannedPlayers.UseVisualStyleBackColor = true;
            // 
            // btnBannedAddresses
            // 
            this.btnBannedAddresses.Location = new System.Drawing.Point(264, 36);
            this.btnBannedAddresses.Name = "btnBannedAddresses";
            this.btnBannedAddresses.Size = new System.Drawing.Size(150, 23);
            this.btnBannedAddresses.TabIndex = 9;
            this.btnBannedAddresses.Text = "Banned IP Addresses";
            this.btnBannedAddresses.UseVisualStyleBackColor = true;
            // 
            // lstWorlds
            // 
            this.lstWorlds.FormattingEnabled = true;
            this.lstWorlds.ItemHeight = 15;
            this.lstWorlds.Location = new System.Drawing.Point(60, 36);
            this.lstWorlds.Name = "lstWorlds";
            this.lstWorlds.Size = new System.Drawing.Size(198, 199);
            this.lstWorlds.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(2, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 15);
            this.label2.TabIndex = 7;
            this.label2.Text = "Worlds:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(5, 11);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Server: ";
            // 
            // cboServer
            // 
            this.cboServer.FormattingEnabled = true;
            this.cboServer.Location = new System.Drawing.Point(60, 8);
            this.cboServer.Margin = new System.Windows.Forms.Padding(2);
            this.cboServer.Name = "cboServer";
            this.cboServer.Size = new System.Drawing.Size(200, 23);
            this.cboServer.TabIndex = 0;
            this.cboServer.SelectedIndexChanged += new System.EventHandler(this.ServerIndexChanged);
            // 
            // btnDeleteMinecraftServer
            // 
            this.btnDeleteMinecraftServer.BackgroundImage = global::MinecraftServerSetup.Properties.Resources.ieframe_1_41755;
            this.btnDeleteMinecraftServer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnDeleteMinecraftServer.Location = new System.Drawing.Point(60, 240);
            this.btnDeleteMinecraftServer.Margin = new System.Windows.Forms.Padding(2);
            this.btnDeleteMinecraftServer.Name = "btnDeleteMinecraftServer";
            this.btnDeleteMinecraftServer.Size = new System.Drawing.Size(23, 23);
            this.btnDeleteMinecraftServer.TabIndex = 16;
            this.btnDeleteMinecraftServer.UseVisualStyleBackColor = true;
            // 
            // btnAddMinecraftServer
            // 
            this.btnAddMinecraftServer.BackgroundImage = global::MinecraftServerSetup.Properties.Resources.LMIGuardianDll_145;
            this.btnAddMinecraftServer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAddMinecraftServer.Location = new System.Drawing.Point(235, 240);
            this.btnAddMinecraftServer.Margin = new System.Windows.Forms.Padding(2);
            this.btnAddMinecraftServer.Name = "btnAddMinecraftServer";
            this.btnAddMinecraftServer.Size = new System.Drawing.Size(23, 23);
            this.btnAddMinecraftServer.TabIndex = 15;
            this.btnAddMinecraftServer.UseVisualStyleBackColor = true;
            this.btnAddMinecraftServer.Click += new System.EventHandler(this.ClickedAddMinecraftServer);
            // 
            // btnEditWorld
            // 
            this.btnEditWorld.BackgroundImage = global::MinecraftServerSetup.Properties.Resources.osmadminicon_100;
            this.btnEditWorld.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnEditWorld.Location = new System.Drawing.Point(345, 180);
            this.btnEditWorld.Margin = new System.Windows.Forms.Padding(2);
            this.btnEditWorld.Name = "btnEditWorld";
            this.btnEditWorld.Size = new System.Drawing.Size(23, 23);
            this.btnEditWorld.TabIndex = 14;
            this.btnEditWorld.UseVisualStyleBackColor = true;
            this.btnEditWorld.Click += new System.EventHandler(this.ClickedEditWorld);
            // 
            // btnRunCommand
            // 
            this.btnRunCommand.BackgroundImage = global::MinecraftServerSetup.Properties.Resources.powershell_1_MSH_MAIN;
            this.btnRunCommand.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnRunCommand.Location = new System.Drawing.Point(318, 180);
            this.btnRunCommand.Margin = new System.Windows.Forms.Padding(2);
            this.btnRunCommand.Name = "btnRunCommand";
            this.btnRunCommand.Size = new System.Drawing.Size(23, 23);
            this.btnRunCommand.TabIndex = 6;
            this.btnRunCommand.UseVisualStyleBackColor = true;
            this.btnRunCommand.Click += new System.EventHandler(this.ClickedRunCommand);
            // 
            // btnStopServer
            // 
            this.btnStopServer.BackgroundImage = global::MinecraftServerSetup.Properties.Resources.GPIcons_1_ENDED_STOPPED_006;
            this.btnStopServer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnStopServer.Location = new System.Drawing.Point(291, 180);
            this.btnStopServer.Margin = new System.Windows.Forms.Padding(2);
            this.btnStopServer.Name = "btnStopServer";
            this.btnStopServer.Size = new System.Drawing.Size(23, 23);
            this.btnStopServer.TabIndex = 5;
            this.btnStopServer.UseVisualStyleBackColor = true;
            this.btnStopServer.Click += new System.EventHandler(this.ClickedStopServer);
            // 
            // btnStartServer
            // 
            this.btnStartServer.BackgroundImage = global::MinecraftServerSetup.Properties.Resources.vmapputil_12900;
            this.btnStartServer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnStartServer.Location = new System.Drawing.Point(264, 180);
            this.btnStartServer.Margin = new System.Windows.Forms.Padding(2);
            this.btnStartServer.Name = "btnStartServer";
            this.btnStartServer.Size = new System.Drawing.Size(23, 23);
            this.btnStartServer.TabIndex = 4;
            this.btnStartServer.UseVisualStyleBackColor = true;
            this.btnStartServer.Click += new System.EventHandler(this.ClickedStartServer);
            // 
            // btnEditServer
            // 
            this.btnEditServer.BackgroundImage = global::MinecraftServerSetup.Properties.Resources.osmadminicon_100;
            this.btnEditServer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnEditServer.Location = new System.Drawing.Point(291, 7);
            this.btnEditServer.Margin = new System.Windows.Forms.Padding(2);
            this.btnEditServer.Name = "btnEditServer";
            this.btnEditServer.Size = new System.Drawing.Size(23, 23);
            this.btnEditServer.TabIndex = 3;
            this.btnEditServer.UseVisualStyleBackColor = true;
            this.btnEditServer.Click += new System.EventHandler(this.ClickedEditServer);
            // 
            // btnAddServer
            // 
            this.btnAddServer.BackgroundImage = global::MinecraftServerSetup.Properties.Resources.LMIGuardianDll_145;
            this.btnAddServer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAddServer.Location = new System.Drawing.Point(264, 7);
            this.btnAddServer.Margin = new System.Windows.Forms.Padding(2);
            this.btnAddServer.Name = "btnAddServer";
            this.btnAddServer.Size = new System.Drawing.Size(23, 23);
            this.btnAddServer.TabIndex = 2;
            this.btnAddServer.UseVisualStyleBackColor = true;
            this.btnAddServer.Click += new System.EventHandler(this.ClickedAddServer);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(426, 297);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("MPlantin", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Black;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Minecraft Server Editor";
            this.Load += new System.EventHandler(this.LoadedFrmMain);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboServer;
        private System.Windows.Forms.Button btnAddServer;
        private System.Windows.Forms.Button btnStopServer;
        private System.Windows.Forms.Button btnStartServer;
        private System.Windows.Forms.Button btnEditServer;
        private System.Windows.Forms.Button btnRunCommand;
        private System.Windows.Forms.Button btnWhiteList;
        private System.Windows.Forms.Button btnProperties;
        private System.Windows.Forms.Button btnOperators;
        private System.Windows.Forms.Button btnBannedPlayers;
        private System.Windows.Forms.Button btnBannedAddresses;
        private System.Windows.Forms.ListBox lstWorlds;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnEditWorld;
        private System.Windows.Forms.Button btnDeleteMinecraftServer;
        private System.Windows.Forms.Button btnAddMinecraftServer;
    }
}

