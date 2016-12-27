namespace jdautomate
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.accounts = new System.Windows.Forms.TabPage();
            this.listView1 = new System.Windows.Forms.ListView();
            this.N = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.email = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.password = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.registered = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.gmailGenerator = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.inputTXTBox = new System.Windows.Forms.TextBox();
            this.browseInputTXT = new System.Windows.Forms.Button();
            this.fromTXT = new System.Windows.Forms.CheckBox();
            this.randomCheck = new System.Windows.Forms.CheckBox();
            this.passwordText = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.makeButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.fileNameText = new System.Windows.Forms.TextBox();
            this.fileBrowseButton = new System.Windows.Forms.Button();
            this.countText = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.emailText = new System.Windows.Forms.TextBox();
            this.registration = new System.Windows.Forms.TabPage();
            this.listViewRegister = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.registerButton = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.openButton = new System.Windows.Forms.Button();
            this.login = new System.Windows.Forms.TabPage();
            this.label15 = new System.Windows.Forms.Label();
            this.numericUpgrades = new System.Windows.Forms.NumericUpDown();
            this.label14 = new System.Windows.Forms.Label();
            this.numericLaps = new System.Windows.Forms.NumericUpDown();
            this.label12 = new System.Windows.Forms.Label();
            this.upgradeInputFile = new System.Windows.Forms.TextBox();
            this.upgradeInputButton = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.upgradeOutputFile = new System.Windows.Forms.TextBox();
            this.upgradeOutputButton = new System.Windows.Forms.Button();
            this.upgradeButton = new System.Windows.Forms.Button();
            this.Readconfirms = new System.Windows.Forms.TabPage();
            this.urlToFindTextBox = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.readGmailButton = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.confirmPathTextBox = new System.Windows.Forms.TextBox();
            this.gmailPassTextBox = new System.Windows.Forms.TextBox();
            this.gmailEmailTextBox = new System.Windows.Forms.TextBox();
            this.ConfirmRegistration = new System.Windows.Forms.TabPage();
            this.confirmButton = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.inputFileConfirmTextBox = new System.Windows.Forms.TextBox();
            this.consoleBox = new System.Windows.Forms.ListBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusText = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.cancelButton = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1.SuspendLayout();
            this.accounts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.countText)).BeginInit();
            this.registration.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.login.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpgrades)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericLaps)).BeginInit();
            this.Readconfirms.SuspendLayout();
            this.ConfirmRegistration.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.accounts);
            this.tabControl1.Controls.Add(this.registration);
            this.tabControl1.Controls.Add(this.login);
            this.tabControl1.Controls.Add(this.Readconfirms);
            this.tabControl1.Controls.Add(this.ConfirmRegistration);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(846, 255);
            this.tabControl1.TabIndex = 0;
            // 
            // accounts
            // 
            this.accounts.Controls.Add(this.listView1);
            this.accounts.Controls.Add(this.gmailGenerator);
            this.accounts.Controls.Add(this.label11);
            this.accounts.Controls.Add(this.inputTXTBox);
            this.accounts.Controls.Add(this.browseInputTXT);
            this.accounts.Controls.Add(this.fromTXT);
            this.accounts.Controls.Add(this.randomCheck);
            this.accounts.Controls.Add(this.passwordText);
            this.accounts.Controls.Add(this.label4);
            this.accounts.Controls.Add(this.makeButton);
            this.accounts.Controls.Add(this.label3);
            this.accounts.Controls.Add(this.fileNameText);
            this.accounts.Controls.Add(this.fileBrowseButton);
            this.accounts.Controls.Add(this.countText);
            this.accounts.Controls.Add(this.label2);
            this.accounts.Controls.Add(this.label1);
            this.accounts.Controls.Add(this.emailText);
            this.accounts.Location = new System.Drawing.Point(4, 22);
            this.accounts.Name = "accounts";
            this.accounts.Padding = new System.Windows.Forms.Padding(3);
            this.accounts.Size = new System.Drawing.Size(838, 229);
            this.accounts.TabIndex = 0;
            this.accounts.Text = "Account generation";
            this.accounts.UseVisualStyleBackColor = true;
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.N,
            this.email,
            this.password,
            this.registered});
            this.listView1.FullRowSelect = true;
            this.listView1.GridLines = true;
            this.listView1.Location = new System.Drawing.Point(425, 23);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(410, 184);
            this.listView1.TabIndex = 3;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // N
            // 
            this.N.Text = "n";
            this.N.Width = 63;
            // 
            // email
            // 
            this.email.Text = "email";
            this.email.Width = 289;
            // 
            // password
            // 
            this.password.Text = "password";
            this.password.Width = 153;
            // 
            // registered
            // 
            this.registered.Text = "registered";
            // 
            // gmailGenerator
            // 
            this.gmailGenerator.Location = new System.Drawing.Point(156, 255);
            this.gmailGenerator.Name = "gmailGenerator";
            this.gmailGenerator.Size = new System.Drawing.Size(96, 44);
            this.gmailGenerator.TabIndex = 17;
            this.gmailGenerator.Text = "New Gmail";
            this.gmailGenerator.UseVisualStyleBackColor = true;
            this.gmailGenerator.Click += new System.EventHandler(this.gmailGenerator_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(10, 89);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(55, 13);
            this.label11.TabIndex = 16;
            this.label11.Text = "Input TXT";
            // 
            // inputTXTBox
            // 
            this.inputTXTBox.Enabled = false;
            this.inputTXTBox.Location = new System.Drawing.Point(71, 85);
            this.inputTXTBox.Name = "inputTXTBox";
            this.inputTXTBox.Size = new System.Drawing.Size(265, 20);
            this.inputTXTBox.TabIndex = 15;
            // 
            // browseInputTXT
            // 
            this.browseInputTXT.Enabled = false;
            this.browseInputTXT.Location = new System.Drawing.Point(342, 83);
            this.browseInputTXT.Name = "browseInputTXT";
            this.browseInputTXT.Size = new System.Drawing.Size(75, 23);
            this.browseInputTXT.TabIndex = 14;
            this.browseInputTXT.Text = "browse";
            this.browseInputTXT.UseVisualStyleBackColor = true;
            this.browseInputTXT.Click += new System.EventHandler(this.browseInputTXT_Click);
            // 
            // fromTXT
            // 
            this.fromTXT.AutoSize = true;
            this.fromTXT.Location = new System.Drawing.Point(342, 33);
            this.fromTXT.Name = "fromTXT";
            this.fromTXT.Size = new System.Drawing.Size(89, 17);
            this.fromTXT.TabIndex = 13;
            this.fromTXT.Text = "From TXT file";
            this.fromTXT.UseVisualStyleBackColor = true;
            this.fromTXT.CheckedChanged += new System.EventHandler(this.fromTXT_CheckedChanged);
            // 
            // randomCheck
            // 
            this.randomCheck.AutoSize = true;
            this.randomCheck.Location = new System.Drawing.Point(240, 141);
            this.randomCheck.Name = "randomCheck";
            this.randomCheck.Size = new System.Drawing.Size(66, 17);
            this.randomCheck.TabIndex = 12;
            this.randomCheck.Text = "Random";
            this.randomCheck.UseVisualStyleBackColor = true;
            this.randomCheck.CheckedChanged += new System.EventHandler(this.randomCheck_CheckedChanged);
            // 
            // passwordText
            // 
            this.passwordText.Location = new System.Drawing.Point(70, 139);
            this.passwordText.Name = "passwordText";
            this.passwordText.Size = new System.Drawing.Size(163, 20);
            this.passwordText.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 144);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Password";
            // 
            // makeButton
            // 
            this.makeButton.Location = new System.Drawing.Point(71, 165);
            this.makeButton.Name = "makeButton";
            this.makeButton.Size = new System.Drawing.Size(181, 42);
            this.makeButton.TabIndex = 8;
            this.makeButton.Text = "Make";
            this.makeButton.UseVisualStyleBackColor = true;
            this.makeButton.Click += new System.EventHandler(this.makeButton_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 115);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Output XML";
            // 
            // fileNameText
            // 
            this.fileNameText.Location = new System.Drawing.Point(70, 112);
            this.fileNameText.Name = "fileNameText";
            this.fileNameText.Size = new System.Drawing.Size(265, 20);
            this.fileNameText.TabIndex = 6;
            // 
            // fileBrowseButton
            // 
            this.fileBrowseButton.Location = new System.Drawing.Point(341, 111);
            this.fileBrowseButton.Name = "fileBrowseButton";
            this.fileBrowseButton.Size = new System.Drawing.Size(75, 23);
            this.fileBrowseButton.TabIndex = 5;
            this.fileBrowseButton.Text = "browse";
            this.fileBrowseButton.UseVisualStyleBackColor = true;
            this.fileBrowseButton.Click += new System.EventHandler(this.fileBrowseButton_Click);
            // 
            // countText
            // 
            this.countText.Location = new System.Drawing.Point(71, 59);
            this.countText.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.countText.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.countText.Name = "countText";
            this.countText.Size = new System.Drawing.Size(120, 20);
            this.countText.TabIndex = 4;
            this.countText.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Max Count";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Base email";
            // 
            // emailText
            // 
            this.emailText.Location = new System.Drawing.Point(70, 30);
            this.emailText.Name = "emailText";
            this.emailText.Size = new System.Drawing.Size(265, 20);
            this.emailText.TabIndex = 0;
            // 
            // registration
            // 
            this.registration.Controls.Add(this.listViewRegister);
            this.registration.Controls.Add(this.registerButton);
            this.registration.Controls.Add(this.label5);
            this.registration.Controls.Add(this.numericUpDown1);
            this.registration.Controls.Add(this.openButton);
            this.registration.Location = new System.Drawing.Point(4, 22);
            this.registration.Name = "registration";
            this.registration.Padding = new System.Windows.Forms.Padding(3);
            this.registration.Size = new System.Drawing.Size(838, 229);
            this.registration.TabIndex = 1;
            this.registration.Text = "Registration";
            this.registration.UseVisualStyleBackColor = true;
            // 
            // listViewRegister
            // 
            this.listViewRegister.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.listViewRegister.GridLines = true;
            this.listViewRegister.Location = new System.Drawing.Point(211, 6);
            this.listViewRegister.Name = "listViewRegister";
            this.listViewRegister.Size = new System.Drawing.Size(610, 217);
            this.listViewRegister.TabIndex = 10;
            this.listViewRegister.UseCompatibleStateImageBehavior = false;
            this.listViewRegister.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "n";
            this.columnHeader1.Width = 63;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "email";
            this.columnHeader2.Width = 289;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "password";
            this.columnHeader3.Width = 153;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "registered";
            // 
            // registerButton
            // 
            this.registerButton.Location = new System.Drawing.Point(64, 103);
            this.registerButton.Name = "registerButton";
            this.registerButton.Size = new System.Drawing.Size(105, 34);
            this.registerButton.TabIndex = 3;
            this.registerButton.Text = "Register";
            this.registerButton.UseVisualStyleBackColor = true;
            this.registerButton.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 79);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Start num";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(64, 76);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(105, 20);
            this.numericUpDown1.TabIndex = 1;
            this.numericUpDown1.Tag = "";
            // 
            // openButton
            // 
            this.openButton.Location = new System.Drawing.Point(64, 28);
            this.openButton.Name = "openButton";
            this.openButton.Size = new System.Drawing.Size(105, 42);
            this.openButton.TabIndex = 0;
            this.openButton.Text = "Browse File";
            this.openButton.UseVisualStyleBackColor = true;
            this.openButton.Click += new System.EventHandler(this.openButton_Click);
            // 
            // login
            // 
            this.login.Controls.Add(this.label15);
            this.login.Controls.Add(this.numericUpgrades);
            this.login.Controls.Add(this.label14);
            this.login.Controls.Add(this.numericLaps);
            this.login.Controls.Add(this.label12);
            this.login.Controls.Add(this.upgradeInputFile);
            this.login.Controls.Add(this.upgradeInputButton);
            this.login.Controls.Add(this.label13);
            this.login.Controls.Add(this.upgradeOutputFile);
            this.login.Controls.Add(this.upgradeOutputButton);
            this.login.Controls.Add(this.upgradeButton);
            this.login.Location = new System.Drawing.Point(4, 22);
            this.login.Name = "login";
            this.login.Size = new System.Drawing.Size(838, 229);
            this.login.TabIndex = 2;
            this.login.Text = "MultiLogin";
            this.login.UseVisualStyleBackColor = true;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(179, 79);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(74, 13);
            this.label15.TabIndex = 26;
            this.label15.Text = "Max upgrades";
            // 
            // numericUpgrades
            // 
            this.numericUpgrades.Location = new System.Drawing.Point(259, 77);
            this.numericUpgrades.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.numericUpgrades.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpgrades.Name = "numericUpgrades";
            this.numericUpgrades.Size = new System.Drawing.Size(66, 20);
            this.numericUpgrades.TabIndex = 25;
            this.numericUpgrades.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(20, 80);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(49, 13);
            this.label14.TabIndex = 24;
            this.label14.Text = "Max laps";
            // 
            // numericLaps
            // 
            this.numericLaps.Location = new System.Drawing.Point(75, 78);
            this.numericLaps.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.numericLaps.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericLaps.Name = "numericLaps";
            this.numericLaps.Size = new System.Drawing.Size(63, 20);
            this.numericLaps.TabIndex = 23;
            this.numericLaps.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(15, 28);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(56, 13);
            this.label12.TabIndex = 22;
            this.label12.Text = "Input XML";
            // 
            // upgradeInputFile
            // 
            this.upgradeInputFile.Location = new System.Drawing.Point(76, 24);
            this.upgradeInputFile.Name = "upgradeInputFile";
            this.upgradeInputFile.Size = new System.Drawing.Size(265, 20);
            this.upgradeInputFile.TabIndex = 21;
            // 
            // upgradeInputButton
            // 
            this.upgradeInputButton.Location = new System.Drawing.Point(347, 22);
            this.upgradeInputButton.Name = "upgradeInputButton";
            this.upgradeInputButton.Size = new System.Drawing.Size(75, 23);
            this.upgradeInputButton.TabIndex = 20;
            this.upgradeInputButton.Text = "browse";
            this.upgradeInputButton.UseVisualStyleBackColor = true;
            this.upgradeInputButton.Click += new System.EventHandler(this.upgradeInputButton_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(9, 54);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(63, 13);
            this.label13.TabIndex = 19;
            this.label13.Text = "Output TXT";
            // 
            // upgradeOutputFile
            // 
            this.upgradeOutputFile.Location = new System.Drawing.Point(75, 51);
            this.upgradeOutputFile.Name = "upgradeOutputFile";
            this.upgradeOutputFile.Size = new System.Drawing.Size(265, 20);
            this.upgradeOutputFile.TabIndex = 18;
            // 
            // upgradeOutputButton
            // 
            this.upgradeOutputButton.Location = new System.Drawing.Point(346, 50);
            this.upgradeOutputButton.Name = "upgradeOutputButton";
            this.upgradeOutputButton.Size = new System.Drawing.Size(75, 23);
            this.upgradeOutputButton.TabIndex = 17;
            this.upgradeOutputButton.Text = "browse";
            this.upgradeOutputButton.UseVisualStyleBackColor = true;
            this.upgradeOutputButton.Click += new System.EventHandler(this.upgradeOutputButton_Click);
            // 
            // upgradeButton
            // 
            this.upgradeButton.Location = new System.Drawing.Point(94, 110);
            this.upgradeButton.Name = "upgradeButton";
            this.upgradeButton.Size = new System.Drawing.Size(153, 61);
            this.upgradeButton.TabIndex = 0;
            this.upgradeButton.Text = "Upgrade All";
            this.upgradeButton.UseVisualStyleBackColor = true;
            this.upgradeButton.Click += new System.EventHandler(this.button3_Click_1);
            // 
            // Readconfirms
            // 
            this.Readconfirms.Controls.Add(this.urlToFindTextBox);
            this.Readconfirms.Controls.Add(this.label9);
            this.Readconfirms.Controls.Add(this.readGmailButton);
            this.Readconfirms.Controls.Add(this.label8);
            this.Readconfirms.Controls.Add(this.label7);
            this.Readconfirms.Controls.Add(this.label6);
            this.Readconfirms.Controls.Add(this.confirmPathTextBox);
            this.Readconfirms.Controls.Add(this.gmailPassTextBox);
            this.Readconfirms.Controls.Add(this.gmailEmailTextBox);
            this.Readconfirms.Location = new System.Drawing.Point(4, 22);
            this.Readconfirms.Name = "Readconfirms";
            this.Readconfirms.Size = new System.Drawing.Size(838, 229);
            this.Readconfirms.TabIndex = 4;
            this.Readconfirms.Text = "Read confirm emails";
            this.Readconfirms.UseVisualStyleBackColor = true;
            // 
            // urlToFindTextBox
            // 
            this.urlToFindTextBox.Location = new System.Drawing.Point(94, 111);
            this.urlToFindTextBox.Name = "urlToFindTextBox";
            this.urlToFindTextBox.Size = new System.Drawing.Size(239, 20);
            this.urlToFindTextBox.TabIndex = 8;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(26, 114);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(61, 13);
            this.label9.TabIndex = 7;
            this.label9.Text = "URL to find";
            // 
            // readGmailButton
            // 
            this.readGmailButton.Location = new System.Drawing.Point(148, 140);
            this.readGmailButton.Name = "readGmailButton";
            this.readGmailButton.Size = new System.Drawing.Size(101, 43);
            this.readGmailButton.TabIndex = 6;
            this.readGmailButton.Text = "GO!";
            this.readGmailButton.UseVisualStyleBackColor = true;
            this.readGmailButton.Click += new System.EventHandler(this.goGmailConnect_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(55, 30);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(36, 13);
            this.label8.TabIndex = 5;
            this.label8.Text = "Gmail ";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(35, 57);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 13);
            this.label7.TabIndex = 4;
            this.label7.Text = "Password";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(32, 84);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 13);
            this.label6.TabIndex = 3;
            this.label6.Text = "Output file";
            // 
            // confirmPathTextBox
            // 
            this.confirmPathTextBox.Location = new System.Drawing.Point(94, 81);
            this.confirmPathTextBox.Name = "confirmPathTextBox";
            this.confirmPathTextBox.Size = new System.Drawing.Size(239, 20);
            this.confirmPathTextBox.TabIndex = 2;
            this.confirmPathTextBox.Text = "links.txt";
            // 
            // gmailPassTextBox
            // 
            this.gmailPassTextBox.Location = new System.Drawing.Point(94, 54);
            this.gmailPassTextBox.Name = "gmailPassTextBox";
            this.gmailPassTextBox.Size = new System.Drawing.Size(239, 20);
            this.gmailPassTextBox.TabIndex = 1;
            // 
            // gmailEmailTextBox
            // 
            this.gmailEmailTextBox.Location = new System.Drawing.Point(94, 27);
            this.gmailEmailTextBox.Name = "gmailEmailTextBox";
            this.gmailEmailTextBox.Size = new System.Drawing.Size(239, 20);
            this.gmailEmailTextBox.TabIndex = 0;
            // 
            // ConfirmRegistration
            // 
            this.ConfirmRegistration.Controls.Add(this.confirmButton);
            this.ConfirmRegistration.Controls.Add(this.label10);
            this.ConfirmRegistration.Controls.Add(this.inputFileConfirmTextBox);
            this.ConfirmRegistration.Location = new System.Drawing.Point(4, 22);
            this.ConfirmRegistration.Name = "ConfirmRegistration";
            this.ConfirmRegistration.Size = new System.Drawing.Size(838, 229);
            this.ConfirmRegistration.TabIndex = 3;
            this.ConfirmRegistration.Text = "Confirm registration";
            this.ConfirmRegistration.UseVisualStyleBackColor = true;
            // 
            // confirmButton
            // 
            this.confirmButton.Location = new System.Drawing.Point(138, 55);
            this.confirmButton.Name = "confirmButton";
            this.confirmButton.Size = new System.Drawing.Size(138, 44);
            this.confirmButton.TabIndex = 2;
            this.confirmButton.Text = "GO!";
            this.confirmButton.UseVisualStyleBackColor = true;
            this.confirmButton.Click += new System.EventHandler(this.goConfirmButton_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(39, 32);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(47, 13);
            this.label10.TabIndex = 1;
            this.label10.Text = "Input file";
            // 
            // inputFileConfirmTextBox
            // 
            this.inputFileConfirmTextBox.Location = new System.Drawing.Point(86, 29);
            this.inputFileConfirmTextBox.Name = "inputFileConfirmTextBox";
            this.inputFileConfirmTextBox.Size = new System.Drawing.Size(265, 20);
            this.inputFileConfirmTextBox.TabIndex = 0;
            this.inputFileConfirmTextBox.Text = "links.txt";
            // 
            // consoleBox
            // 
            this.consoleBox.FormattingEnabled = true;
            this.consoleBox.Location = new System.Drawing.Point(12, 273);
            this.consoleBox.Name = "consoleBox";
            this.consoleBox.Size = new System.Drawing.Size(842, 134);
            this.consoleBox.TabIndex = 1;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.statusText,
            this.toolStripProgressBar1,
            this.toolStripDropDownButton1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 413);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(863, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(42, 17);
            this.toolStripStatusLabel1.Text = "Status:";
            // 
            // statusText
            // 
            this.statusText.AutoSize = false;
            this.statusText.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.statusText.Name = "statusText";
            this.statusText.Size = new System.Drawing.Size(500, 17);
            // 
            // toolStripProgressBar1
            // 
            this.toolStripProgressBar1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripProgressBar1.Name = "toolStripProgressBar1";
            this.toolStripProgressBar1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.toolStripProgressBar1.Size = new System.Drawing.Size(250, 16);
            this.toolStripProgressBar1.Step = 1;
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cancelButton});
            this.toolStripDropDownButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton1.Image")));
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(44, 20);
            this.toolStripDropDownButton1.Text = "Stop";
            this.toolStripDropDownButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            // 
            // cancelButton
            // 
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(152, 22);
            this.cancelButton.Text = "Stop all";
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(863, 435);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.consoleBox);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.tabControl1.ResumeLayout(false);
            this.accounts.ResumeLayout(false);
            this.accounts.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.countText)).EndInit();
            this.registration.ResumeLayout(false);
            this.registration.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.login.ResumeLayout(false);
            this.login.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpgrades)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericLaps)).EndInit();
            this.Readconfirms.ResumeLayout(false);
            this.Readconfirms.PerformLayout();
            this.ConfirmRegistration.ResumeLayout(false);
            this.ConfirmRegistration.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage accounts;
        private System.Windows.Forms.CheckBox randomCheck;
        private System.Windows.Forms.TextBox passwordText;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader N;
        private System.Windows.Forms.ColumnHeader email;
        private System.Windows.Forms.ColumnHeader password;
        private System.Windows.Forms.ColumnHeader registered;
        private System.Windows.Forms.Button makeButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox fileNameText;
        private System.Windows.Forms.Button fileBrowseButton;
        private System.Windows.Forms.NumericUpDown countText;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox emailText;
        private System.Windows.Forms.TabPage registration;
        private System.Windows.Forms.TabPage login;
        private System.Windows.Forms.Button openButton;
        private System.Windows.Forms.ListView listViewRegister;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.Button registerButton;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.TabPage Readconfirms;
        private System.Windows.Forms.TextBox urlToFindTextBox;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button readGmailButton;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox confirmPathTextBox;
        private System.Windows.Forms.TextBox gmailPassTextBox;
        private System.Windows.Forms.TextBox gmailEmailTextBox;
        private System.Windows.Forms.TabPage ConfirmRegistration;
        private System.Windows.Forms.Button confirmButton;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox inputFileConfirmTextBox;
        private System.Windows.Forms.ListBox consoleBox;
        private System.Windows.Forms.Button upgradeButton;
        private System.Windows.Forms.CheckBox fromTXT;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox inputTXTBox;
        private System.Windows.Forms.Button browseInputTXT;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox upgradeInputFile;
        private System.Windows.Forms.Button upgradeInputButton;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox upgradeOutputFile;
        private System.Windows.Forms.Button upgradeOutputButton;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel statusText;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.NumericUpDown numericLaps;
        private System.Windows.Forms.Button gmailGenerator;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.NumericUpDown numericUpgrades;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripMenuItem cancelButton;
        //private System.Windows.Forms.Button button3;
    }
}

