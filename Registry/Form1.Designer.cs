using System.Windows.Forms;

namespace Registry
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.addNewButton = new System.Windows.Forms.Button();
            this.createComputerButton = new System.Windows.Forms.Button();
            this.componentComboBox = new System.Windows.Forms.ComboBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.exitButton = new System.Windows.Forms.Button();
            this.minimizeButton = new System.Windows.Forms.Button();
            this.facebookButton = new System.Windows.Forms.Button();
            this.twitterButton = new System.Windows.Forms.Button();
            this.instagramButton = new System.Windows.Forms.Button();
            this.topPanel = new System.Windows.Forms.Panel();
            this.menuPanel = new System.Windows.Forms.Panel();
            this.everythingButton = new System.Windows.Forms.Button();
            this.computersButton = new System.Windows.Forms.Button();
            this.videocardsButton = new System.Windows.Forms.Button();
            this.storagesButton = new System.Windows.Forms.Button();
            this.memoriesButton = new System.Windows.Forms.Button();
            this.processorsButton = new System.Windows.Forms.Button();
            this.powerSuppliesButton = new System.Windows.Forms.Button();
            this.motherboardsButton = new System.Windows.Forms.Button();
            this.coolersButton = new System.Windows.Forms.Button();
            this.casesButton = new System.Windows.Forms.Button();
            this.separatorPanel = new System.Windows.Forms.Panel();
            this.componentLabel = new System.Windows.Forms.Label();
            this.sortByLabel = new System.Windows.Forms.Label();
            this.sortByComboBox = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textSearchTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.serialSearchTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.productSearchTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.manufacturerSearchTextBox = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.userLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.menuPanel.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(150, 310);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(817, 300);
            this.flowLayoutPanel1.TabIndex = 21;
            // 
            // addNewButton
            // 
            this.addNewButton.BackColor = System.Drawing.SystemColors.Control;
            this.addNewButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addNewButton.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addNewButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.addNewButton.Location = new System.Drawing.Point(190, 19);
            this.addNewButton.Name = "addNewButton";
            this.addNewButton.Size = new System.Drawing.Size(120, 37);
            this.addNewButton.TabIndex = 16;
            this.addNewButton.Text = "Add new";
            this.addNewButton.UseVisualStyleBackColor = false;
            this.addNewButton.Click += new System.EventHandler(this.button2_Click);
            // 
            // createComputerButton
            // 
            this.createComputerButton.BackColor = System.Drawing.SystemColors.Control;
            this.createComputerButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.createComputerButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.createComputerButton.Location = new System.Drawing.Point(12, 31);
            this.createComputerButton.Name = "createComputerButton";
            this.createComputerButton.Size = new System.Drawing.Size(97, 57);
            this.createComputerButton.TabIndex = 18;
            this.createComputerButton.Text = "Create computer";
            this.createComputerButton.UseVisualStyleBackColor = false;
            this.createComputerButton.Click += new System.EventHandler(this.CreateComputerButton_Click);
            // 
            // componentComboBox
            // 
            this.componentComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.componentComboBox.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.componentComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.componentComboBox.FormattingEnabled = true;
            this.componentComboBox.Location = new System.Drawing.Point(190, 62);
            this.componentComboBox.Name = "componentComboBox";
            this.componentComboBox.Size = new System.Drawing.Size(120, 24);
            this.componentComboBox.TabIndex = 17;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::Registry.Properties.Resources.logo_420px;
            this.pictureBox1.Location = new System.Drawing.Point(424, 17);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(268, 49);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 11;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PictureBox1_MouseDown);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // exitButton
            // 
            this.exitButton.FlatAppearance.BorderSize = 0;
            this.exitButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.exitButton.Image = global::Registry.Properties.Resources.exit_logo_32px;
            this.exitButton.Location = new System.Drawing.Point(915, 16);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(40, 40);
            this.exitButton.TabIndex = 22;
            this.toolTip.SetToolTip(this.exitButton, "Exit");
            this.exitButton.UseVisualStyleBackColor = true;
            this.exitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // minimizeButton
            // 
            this.minimizeButton.FlatAppearance.BorderSize = 0;
            this.minimizeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.minimizeButton.Image = ((System.Drawing.Image)(resources.GetObject("minimizeButton.Image")));
            this.minimizeButton.Location = new System.Drawing.Point(871, 16);
            this.minimizeButton.Name = "minimizeButton";
            this.minimizeButton.Size = new System.Drawing.Size(40, 40);
            this.minimizeButton.TabIndex = 23;
            this.toolTip.SetToolTip(this.minimizeButton, "Minimize");
            this.minimizeButton.UseVisualStyleBackColor = true;
            this.minimizeButton.Click += new System.EventHandler(this.MinimizeButton_Click);
            // 
            // facebookButton
            // 
            this.facebookButton.FlatAppearance.BorderSize = 0;
            this.facebookButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.facebookButton.Image = global::Registry.Properties.Resources.facebook;
            this.facebookButton.Location = new System.Drawing.Point(156, 16);
            this.facebookButton.Name = "facebookButton";
            this.facebookButton.Size = new System.Drawing.Size(40, 40);
            this.facebookButton.TabIndex = 25;
            this.toolTip.SetToolTip(this.facebookButton, "Facebook");
            this.facebookButton.UseVisualStyleBackColor = true;
            this.facebookButton.MouseEnter += new System.EventHandler(this.FacebookButton_MouseEnter);
            this.facebookButton.MouseLeave += new System.EventHandler(this.FacebookButton_MouseLeave);
            // 
            // twitterButton
            // 
            this.twitterButton.FlatAppearance.BorderSize = 0;
            this.twitterButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.twitterButton.Image = global::Registry.Properties.Resources.twitter;
            this.twitterButton.Location = new System.Drawing.Point(254, 16);
            this.twitterButton.Name = "twitterButton";
            this.twitterButton.Size = new System.Drawing.Size(40, 40);
            this.twitterButton.TabIndex = 27;
            this.toolTip.SetToolTip(this.twitterButton, "Twitter");
            this.twitterButton.UseVisualStyleBackColor = true;
            this.twitterButton.MouseEnter += new System.EventHandler(this.TwitterButton_MouseEnter);
            this.twitterButton.MouseLeave += new System.EventHandler(this.TwitterButton_MouseLeave);
            // 
            // instagramButton
            // 
            this.instagramButton.FlatAppearance.BorderSize = 0;
            this.instagramButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.instagramButton.Image = global::Registry.Properties.Resources.instagram;
            this.instagramButton.Location = new System.Drawing.Point(205, 16);
            this.instagramButton.Name = "instagramButton";
            this.instagramButton.Size = new System.Drawing.Size(40, 40);
            this.instagramButton.TabIndex = 26;
            this.toolTip.SetToolTip(this.instagramButton, "Instagram");
            this.instagramButton.UseVisualStyleBackColor = true;
            this.instagramButton.MouseEnter += new System.EventHandler(this.InstagramButton_MouseEnter);
            this.instagramButton.MouseLeave += new System.EventHandler(this.InstagramButton_MouseLeave);
            // 
            // topPanel
            // 
            this.topPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(153)))), ((int)(((byte)(92)))));
            this.topPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.topPanel.Location = new System.Drawing.Point(0, 0);
            this.topPanel.Name = "topPanel";
            this.topPanel.Size = new System.Drawing.Size(967, 10);
            this.topPanel.TabIndex = 19;
            this.topPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TopPanel_MouseDown);
            // 
            // menuPanel
            // 
            this.menuPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(255)))), ((int)(((byte)(254)))));
            this.menuPanel.Controls.Add(this.everythingButton);
            this.menuPanel.Controls.Add(this.computersButton);
            this.menuPanel.Controls.Add(this.videocardsButton);
            this.menuPanel.Controls.Add(this.storagesButton);
            this.menuPanel.Controls.Add(this.memoriesButton);
            this.menuPanel.Controls.Add(this.processorsButton);
            this.menuPanel.Controls.Add(this.powerSuppliesButton);
            this.menuPanel.Controls.Add(this.motherboardsButton);
            this.menuPanel.Controls.Add(this.coolersButton);
            this.menuPanel.Controls.Add(this.casesButton);
            this.menuPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.menuPanel.Location = new System.Drawing.Point(0, 10);
            this.menuPanel.Name = "menuPanel";
            this.menuPanel.Size = new System.Drawing.Size(150, 600);
            this.menuPanel.TabIndex = 16;
            // 
            // everythingButton
            // 
            this.everythingButton.FlatAppearance.BorderSize = 0;
            this.everythingButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.everythingButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.everythingButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(153)))), ((int)(((byte)(92)))));
            this.everythingButton.Image = global::Registry.Properties.Resources.everything_50px;
            this.everythingButton.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.everythingButton.Location = new System.Drawing.Point(0, 0);
            this.everythingButton.Name = "everythingButton";
            this.everythingButton.Size = new System.Drawing.Size(150, 60);
            this.everythingButton.TabIndex = 1;
            this.everythingButton.Text = "Everything";
            this.everythingButton.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.everythingButton.UseVisualStyleBackColor = true;
            this.everythingButton.Click += new System.EventHandler(this.EverythingButton_Click);
            // 
            // computersButton
            // 
            this.computersButton.FlatAppearance.BorderSize = 0;
            this.computersButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.computersButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.computersButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(153)))), ((int)(((byte)(92)))));
            this.computersButton.Image = global::Registry.Properties.Resources.desktop_computer_50px;
            this.computersButton.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.computersButton.Location = new System.Drawing.Point(0, 540);
            this.computersButton.Name = "computersButton";
            this.computersButton.Size = new System.Drawing.Size(150, 60);
            this.computersButton.TabIndex = 10;
            this.computersButton.Text = "Computers";
            this.computersButton.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.computersButton.UseVisualStyleBackColor = true;
            this.computersButton.Click += new System.EventHandler(this.ComputerButton_Click);
            // 
            // videocardsButton
            // 
            this.videocardsButton.FlatAppearance.BorderSize = 0;
            this.videocardsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.videocardsButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.videocardsButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(153)))), ((int)(((byte)(92)))));
            this.videocardsButton.Image = global::Registry.Properties.Resources.video_card_50px;
            this.videocardsButton.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.videocardsButton.Location = new System.Drawing.Point(0, 480);
            this.videocardsButton.Name = "videocardsButton";
            this.videocardsButton.Size = new System.Drawing.Size(150, 60);
            this.videocardsButton.TabIndex = 9;
            this.videocardsButton.Text = "Video-\r\ncards";
            this.videocardsButton.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.videocardsButton.UseVisualStyleBackColor = true;
            this.videocardsButton.Click += new System.EventHandler(this.VideocardsButton_Click);
            // 
            // storagesButton
            // 
            this.storagesButton.FlatAppearance.BorderSize = 0;
            this.storagesButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.storagesButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.storagesButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(153)))), ((int)(((byte)(92)))));
            this.storagesButton.Image = global::Registry.Properties.Resources.hard_drive_50px;
            this.storagesButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.storagesButton.Location = new System.Drawing.Point(0, 420);
            this.storagesButton.Name = "storagesButton";
            this.storagesButton.Size = new System.Drawing.Size(150, 60);
            this.storagesButton.TabIndex = 8;
            this.storagesButton.Text = "Storages";
            this.storagesButton.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.storagesButton.UseVisualStyleBackColor = true;
            this.storagesButton.Click += new System.EventHandler(this.StoragesButton_Click);
            // 
            // memoriesButton
            // 
            this.memoriesButton.FlatAppearance.BorderSize = 0;
            this.memoriesButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.memoriesButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.memoriesButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(153)))), ((int)(((byte)(92)))));
            this.memoriesButton.Image = global::Registry.Properties.Resources.ram_50px;
            this.memoriesButton.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.memoriesButton.Location = new System.Drawing.Point(0, 360);
            this.memoriesButton.Name = "memoriesButton";
            this.memoriesButton.Size = new System.Drawing.Size(150, 60);
            this.memoriesButton.TabIndex = 7;
            this.memoriesButton.Text = "Memories";
            this.memoriesButton.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.memoriesButton.UseVisualStyleBackColor = true;
            this.memoriesButton.Click += new System.EventHandler(this.MemoriesButton_Click);
            // 
            // processorsButton
            // 
            this.processorsButton.FlatAppearance.BorderSize = 0;
            this.processorsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.processorsButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.processorsButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(153)))), ((int)(((byte)(92)))));
            this.processorsButton.Image = global::Registry.Properties.Resources.cpu_50px;
            this.processorsButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.processorsButton.Location = new System.Drawing.Point(0, 300);
            this.processorsButton.Name = "processorsButton";
            this.processorsButton.Size = new System.Drawing.Size(150, 60);
            this.processorsButton.TabIndex = 6;
            this.processorsButton.Text = "CPUs";
            this.processorsButton.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.processorsButton.UseVisualStyleBackColor = true;
            this.processorsButton.Click += new System.EventHandler(this.ProcessorsButton_Click);
            // 
            // powerSuppliesButton
            // 
            this.powerSuppliesButton.FlatAppearance.BorderSize = 0;
            this.powerSuppliesButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.powerSuppliesButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.powerSuppliesButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(153)))), ((int)(((byte)(92)))));
            this.powerSuppliesButton.Image = global::Registry.Properties.Resources.power_50px;
            this.powerSuppliesButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.powerSuppliesButton.Location = new System.Drawing.Point(0, 240);
            this.powerSuppliesButton.Name = "powerSuppliesButton";
            this.powerSuppliesButton.Size = new System.Drawing.Size(150, 60);
            this.powerSuppliesButton.TabIndex = 5;
            this.powerSuppliesButton.Text = "Power-\r\nsupplies";
            this.powerSuppliesButton.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.powerSuppliesButton.UseVisualStyleBackColor = true;
            this.powerSuppliesButton.Click += new System.EventHandler(this.PowerSuppliesButton_Click);
            // 
            // motherboardsButton
            // 
            this.motherboardsButton.FlatAppearance.BorderSize = 0;
            this.motherboardsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.motherboardsButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.motherboardsButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(153)))), ((int)(((byte)(92)))));
            this.motherboardsButton.Image = global::Registry.Properties.Resources.motherboard_50px;
            this.motherboardsButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.motherboardsButton.Location = new System.Drawing.Point(0, 180);
            this.motherboardsButton.Name = "motherboardsButton";
            this.motherboardsButton.Size = new System.Drawing.Size(150, 60);
            this.motherboardsButton.TabIndex = 4;
            this.motherboardsButton.Text = "Mother-\r\nboards";
            this.motherboardsButton.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.motherboardsButton.UseVisualStyleBackColor = true;
            this.motherboardsButton.Click += new System.EventHandler(this.MotherboardsButton_Click);
            // 
            // coolersButton
            // 
            this.coolersButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.coolersButton.FlatAppearance.BorderSize = 0;
            this.coolersButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.coolersButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.coolersButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(153)))), ((int)(((byte)(92)))));
            this.coolersButton.Image = global::Registry.Properties.Resources.cooling_fan_50px;
            this.coolersButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.coolersButton.Location = new System.Drawing.Point(0, 120);
            this.coolersButton.Name = "coolersButton";
            this.coolersButton.Size = new System.Drawing.Size(150, 60);
            this.coolersButton.TabIndex = 3;
            this.coolersButton.Text = "Coolers";
            this.coolersButton.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.coolersButton.UseVisualStyleBackColor = true;
            this.coolersButton.Click += new System.EventHandler(this.CoolersButton_Click);
            // 
            // casesButton
            // 
            this.casesButton.FlatAppearance.BorderSize = 0;
            this.casesButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.casesButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.casesButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(153)))), ((int)(((byte)(92)))));
            this.casesButton.Image = global::Registry.Properties.Resources.case_50px;
            this.casesButton.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.casesButton.Location = new System.Drawing.Point(0, 60);
            this.casesButton.Name = "casesButton";
            this.casesButton.Size = new System.Drawing.Size(150, 60);
            this.casesButton.TabIndex = 2;
            this.casesButton.Text = "Cases";
            this.casesButton.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.casesButton.UseVisualStyleBackColor = true;
            this.casesButton.Click += new System.EventHandler(this.CasesButton_Click);
            // 
            // separatorPanel
            // 
            this.separatorPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(145)))), ((int)(((byte)(230)))));
            this.separatorPanel.Location = new System.Drawing.Point(150, 304);
            this.separatorPanel.Name = "separatorPanel";
            this.separatorPanel.Size = new System.Drawing.Size(817, 6);
            this.separatorPanel.TabIndex = 20;
            // 
            // componentLabel
            // 
            this.componentLabel.BackColor = System.Drawing.Color.Transparent;
            this.componentLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.componentLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(47)))), ((int)(((byte)(54)))));
            this.componentLabel.Location = new System.Drawing.Point(420, 279);
            this.componentLabel.Name = "componentLabel";
            this.componentLabel.Size = new System.Drawing.Size(320, 19);
            this.componentLabel.TabIndex = 18;
            this.componentLabel.Text = "Components";
            this.componentLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // sortByLabel
            // 
            this.sortByLabel.AutoSize = true;
            this.sortByLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.sortByLabel.Location = new System.Drawing.Point(763, 252);
            this.sortByLabel.Name = "sortByLabel";
            this.sortByLabel.Size = new System.Drawing.Size(66, 20);
            this.sortByLabel.TabIndex = 19;
            this.sortByLabel.Text = "Sort by";
            // 
            // sortByComboBox
            // 
            this.sortByComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.sortByComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.sortByComboBox.FormattingEnabled = true;
            this.sortByComboBox.Location = new System.Drawing.Point(767, 274);
            this.sortByComboBox.Name = "sortByComboBox";
            this.sortByComboBox.Size = new System.Drawing.Size(182, 24);
            this.sortByComboBox.TabIndex = 12;
            this.sortByComboBox.SelectedIndexChanged += new System.EventHandler(this.SortByComboBox_SelectedIndexChanged);
            this.sortByComboBox.Click += new System.EventHandler(this.SortByComboBox_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textSearchTextBox);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.serialSearchTextBox);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.productSearchTextBox);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.manufacturerSearchTextBox);
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.groupBox1.Location = new System.Drawing.Point(169, 72);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(786, 99);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            // 
            // textSearchTextBox
            // 
            this.textSearchTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.textSearchTextBox.Location = new System.Drawing.Point(598, 57);
            this.textSearchTextBox.Name = "textSearchTextBox";
            this.textSearchTextBox.Size = new System.Drawing.Size(159, 23);
            this.textSearchTextBox.TabIndex = 28;
            this.textSearchTextBox.TextChanged += new System.EventHandler(this.TextSearchTextBox_TextChanged);
            this.textSearchTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextSearchTextBox_KeyDown);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(6, -3);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(85, 20);
            this.label5.TabIndex = 22;
            this.label5.Text = "Search in";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(406, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 20);
            this.label1.TabIndex = 27;
            this.label1.Text = "Serial number";
            // 
            // serialSearchTextBox
            // 
            this.serialSearchTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.serialSearchTextBox.Location = new System.Drawing.Point(410, 57);
            this.serialSearchTextBox.Name = "serialSearchTextBox";
            this.serialSearchTextBox.Size = new System.Drawing.Size(159, 23);
            this.serialSearchTextBox.TabIndex = 26;
            this.serialSearchTextBox.TextChanged += new System.EventHandler(this.SerialSearchTextBox_TextChanged);
            this.serialSearchTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SerialSearchTextBox_KeyDown);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(594, 35);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 20);
            this.label4.TabIndex = 25;
            this.label4.Text = "In text";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(6, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(133, 20);
            this.label3.TabIndex = 24;
            this.label3.Text = "Product\'s name";
            // 
            // productSearchTextBox
            // 
            this.productSearchTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.productSearchTextBox.Location = new System.Drawing.Point(10, 57);
            this.productSearchTextBox.Name = "productSearchTextBox";
            this.productSearchTextBox.Size = new System.Drawing.Size(158, 23);
            this.productSearchTextBox.TabIndex = 13;
            this.productSearchTextBox.TextChanged += new System.EventHandler(this.ProductSearchTextBox_TextChanged);
            this.productSearchTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ProductSearchTextBox_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(199, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(116, 20);
            this.label2.TabIndex = 22;
            this.label2.Text = "Manufacturer";
            // 
            // manufacturerSearchTextBox
            // 
            this.manufacturerSearchTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.manufacturerSearchTextBox.Location = new System.Drawing.Point(203, 57);
            this.manufacturerSearchTextBox.Name = "manufacturerSearchTextBox";
            this.manufacturerSearchTextBox.Size = new System.Drawing.Size(164, 23);
            this.manufacturerSearchTextBox.TabIndex = 14;
            this.manufacturerSearchTextBox.TextChanged += new System.EventHandler(this.ManufacturerSearchTextBox_TextChanged);
            this.manufacturerSearchTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ManufacturerSearchTextBox_KeyDown);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.createComputerButton);
            this.groupBox2.Controls.Add(this.addNewButton);
            this.groupBox2.Controls.Add(this.componentComboBox);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.groupBox2.Location = new System.Drawing.Point(169, 177);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(316, 94);
            this.groupBox2.TabIndex = 24;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Actions";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(300, 49);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(80, 17);
            this.checkBox1.TabIndex = 28;
            this.checkBox1.Text = "checkBox1";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.CheckBox1_CheckedChanged);
            // 
            // userLabel
            // 
            this.userLabel.AutoSize = true;
            this.userLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.userLabel.Location = new System.Drawing.Point(868, 59);
            this.userLabel.Name = "userLabel";
            this.userLabel.Size = new System.Drawing.Size(33, 13);
            this.userLabel.TabIndex = 29;
            this.userLabel.Text = "User";
            // 
            // Form1
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(967, 610);
            this.Controls.Add(this.userLabel);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.twitterButton);
            this.Controls.Add(this.instagramButton);
            this.Controls.Add(this.facebookButton);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.minimizeButton);
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.componentLabel);
            this.Controls.Add(this.separatorPanel);
            this.Controls.Add(this.menuPanel);
            this.Controls.Add(this.topPanel);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.sortByLabel);
            this.Controls.Add(this.sortByComboBox);
            this.Controls.Add(this.flowLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.menuPanel.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button addNewButton;
        private System.Windows.Forms.Button createComputerButton;
        private System.Windows.Forms.ComboBox componentComboBox;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolTip toolTip;
        private Panel topPanel;
        private Button casesButton;
        private Button coolersButton;
        private Button motherboardsButton;
        private Button powerSuppliesButton;
        private Button memoriesButton;
        private Button processorsButton;
        private Button storagesButton;
        private Button videocardsButton;
        private Button everythingButton;
        private Panel separatorPanel;
        private Label componentLabel;
        private Label sortByLabel;
        private ComboBox sortByComboBox;
        private GroupBox groupBox1;
        private Label label2;
        private TextBox manufacturerSearchTextBox;
        private Label label3;
        private TextBox productSearchTextBox;
        private Label label4;
        private Panel menuPanel;
        private Label label1;
        private TextBox serialSearchTextBox;
        private Label label5;
        private Button exitButton;
        private Button minimizeButton;
        private GroupBox groupBox2;
        private Button facebookButton;
        private Button twitterButton;
        private Button computersButton;
        private CheckBox checkBox1;
        private Button instagramButton;
        private TextBox textSearchTextBox;
        private Label userLabel;
    }
}

