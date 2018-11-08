namespace KonicaMinoltaDriverInstaller
{
    partial class MainMenu
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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.labelPrinter = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.textBoxIP = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBoxprintername = new System.Windows.Forms.TextBox();
            this.labelprintername = new System.Windows.Forms.Label();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label2 = new System.Windows.Forms.Label();
            this.buttoninstallport = new System.Windows.Forms.Button();
            this.radiolpr = new System.Windows.Forms.RadioButton();
            this.radioraw = new System.Windows.Forms.RadioButton();
            this.textBoxqname = new System.Windows.Forms.TextBox();
            this.labelqname = new System.Windows.Forms.Label();
            this.textBoxportno = new System.Windows.Forms.TextBox();
            this.textBoxhostaddress = new System.Windows.Forms.TextBox();
            this.labelportno = new System.Windows.Forms.Label();
            this.labelhostaddress = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(137, 116);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(80, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Install";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.buttonInstallClick);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(144, 170);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(80, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "Exit";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.Exit);
            // 
            // labelPrinter
            // 
            this.labelPrinter.AutoSize = true;
            this.labelPrinter.Location = new System.Drawing.Point(50, 13);
            this.labelPrinter.Name = "labelPrinter";
            this.labelPrinter.Size = new System.Drawing.Size(29, 13);
            this.labelPrinter.TabIndex = 2;
            this.labelPrinter.Text = "MFP";
            // 
            // comboBox1
            // 
            this.comboBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "bizhub C227",
            "bizhub C258",
            "bizhub C308",
            "bizhub 227",
            "bizhub 308",
            "bizhub 3320",
            "bizhub 4020",
            "bizhub 4050",
            "bizhub 4750",
            "bizhub C224"});
            this.comboBox1.Location = new System.Drawing.Point(88, 10);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(117, 21);
            this.comboBox1.TabIndex = 3;
            this.comboBox1.Tag = "";
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // textBoxIP
            // 
            this.textBoxIP.Location = new System.Drawing.Point(88, 62);
            this.textBoxIP.Name = "textBoxIP";
            this.textBoxIP.Size = new System.Drawing.Size(117, 20);
            this.textBoxIP.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "IP address";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Location = new System.Drawing.Point(3, 3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(228, 168);
            this.tabControl1.TabIndex = 6;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.textBox1);
            this.tabPage2.Controls.Add(this.textBoxprintername);
            this.tabPage2.Controls.Add(this.labelprintername);
            this.tabPage2.Controls.Add(this.button1);
            this.tabPage2.Controls.Add(this.textBoxIP);
            this.tabPage2.Controls.Add(this.labelPrinter);
            this.tabPage2.Controls.Add(this.comboBox1);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(220, 142);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Driver";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(-4, 163);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 8;
            this.textBox1.Visible = false;
            // 
            // textBoxprintername
            // 
            this.textBoxprintername.Location = new System.Drawing.Point(88, 36);
            this.textBoxprintername.Name = "textBoxprintername";
            this.textBoxprintername.Size = new System.Drawing.Size(117, 20);
            this.textBoxprintername.TabIndex = 7;
            // 
            // labelprintername
            // 
            this.labelprintername.AutoSize = true;
            this.labelprintername.Location = new System.Drawing.Point(14, 39);
            this.labelprintername.Name = "labelprintername";
            this.labelprintername.Size = new System.Drawing.Size(68, 13);
            this.labelprintername.TabIndex = 6;
            this.labelprintername.Text = "Printer Name";
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.buttoninstallport);
            this.tabPage1.Controls.Add(this.radiolpr);
            this.tabPage1.Controls.Add(this.radioraw);
            this.tabPage1.Controls.Add(this.textBoxqname);
            this.tabPage1.Controls.Add(this.labelqname);
            this.tabPage1.Controls.Add(this.textBoxportno);
            this.tabPage1.Controls.Add(this.textBoxhostaddress);
            this.tabPage1.Controls.Add(this.labelportno);
            this.tabPage1.Controls.Add(this.labelhostaddress);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(220, 142);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Ports";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 88);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Protocol";
            // 
            // buttoninstallport
            // 
            this.buttoninstallport.Location = new System.Drawing.Point(137, 116);
            this.buttoninstallport.Name = "buttoninstallport";
            this.buttoninstallport.Size = new System.Drawing.Size(80, 23);
            this.buttoninstallport.TabIndex = 7;
            this.buttoninstallport.Text = "Install";
            this.buttoninstallport.UseVisualStyleBackColor = true;
            this.buttoninstallport.Click += new System.EventHandler(this.buttoninstallport_Click);
            // 
            // radiolpr
            // 
            this.radiolpr.AutoSize = true;
            this.radiolpr.Location = new System.Drawing.Point(159, 88);
            this.radiolpr.Name = "radiolpr";
            this.radiolpr.Size = new System.Drawing.Size(46, 17);
            this.radiolpr.TabIndex = 9;
            this.radiolpr.Text = "LPR";
            this.radiolpr.UseVisualStyleBackColor = true;
            this.radiolpr.CheckedChanged += new System.EventHandler(this.radiolpr_CheckedChanged);
            // 
            // radioraw
            // 
            this.radioraw.AutoSize = true;
            this.radioraw.Checked = true;
            this.radioraw.Location = new System.Drawing.Point(88, 88);
            this.radioraw.Name = "radioraw";
            this.radioraw.Size = new System.Drawing.Size(51, 17);
            this.radioraw.TabIndex = 8;
            this.radioraw.TabStop = true;
            this.radioraw.Text = "RAW";
            this.radioraw.UseVisualStyleBackColor = true;
            this.radioraw.CheckedChanged += new System.EventHandler(this.radioraw_CheckedChanged);
            // 
            // textBoxqname
            // 
            this.textBoxqname.Location = new System.Drawing.Point(88, 62);
            this.textBoxqname.Name = "textBoxqname";
            this.textBoxqname.Size = new System.Drawing.Size(117, 20);
            this.textBoxqname.TabIndex = 7;
            // 
            // labelqname
            // 
            this.labelqname.AutoSize = true;
            this.labelqname.Location = new System.Drawing.Point(13, 64);
            this.labelqname.Name = "labelqname";
            this.labelqname.Size = new System.Drawing.Size(70, 13);
            this.labelqname.TabIndex = 6;
            this.labelqname.Text = "Queue Name";
            // 
            // textBoxportno
            // 
            this.textBoxportno.Location = new System.Drawing.Point(88, 36);
            this.textBoxportno.Name = "textBoxportno";
            this.textBoxportno.Size = new System.Drawing.Size(117, 20);
            this.textBoxportno.TabIndex = 5;
            this.textBoxportno.Text = "9100";
            // 
            // textBoxhostaddress
            // 
            this.textBoxhostaddress.Location = new System.Drawing.Point(88, 10);
            this.textBoxhostaddress.Name = "textBoxhostaddress";
            this.textBoxhostaddress.Size = new System.Drawing.Size(117, 20);
            this.textBoxhostaddress.TabIndex = 4;
            // 
            // labelportno
            // 
            this.labelportno.AutoSize = true;
            this.labelportno.Location = new System.Drawing.Point(13, 39);
            this.labelportno.Name = "labelportno";
            this.labelportno.Size = new System.Drawing.Size(66, 13);
            this.labelportno.TabIndex = 3;
            this.labelportno.Text = "Port Number";
            // 
            // labelhostaddress
            // 
            this.labelhostaddress.AutoSize = true;
            this.labelhostaddress.Location = new System.Drawing.Point(13, 13);
            this.labelhostaddress.Name = "labelhostaddress";
            this.labelhostaddress.Size = new System.Drawing.Size(69, 13);
            this.labelhostaddress.TabIndex = 2;
            this.labelhostaddress.Text = "Host address";
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(232, 196);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.button2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "MainMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Konica Minolta Driver Installer";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label labelPrinter;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.TextBox textBoxIP;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label labelportno;
        private System.Windows.Forms.Label labelhostaddress;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.RadioButton radiolpr;
        private System.Windows.Forms.RadioButton radioraw;
        private System.Windows.Forms.TextBox textBoxqname;
        private System.Windows.Forms.Label labelqname;
        private System.Windows.Forms.TextBox textBoxportno;
        private System.Windows.Forms.TextBox textBoxhostaddress;
        private System.Windows.Forms.Button buttoninstallport;
        private System.Windows.Forms.TextBox textBoxprintername;
        private System.Windows.Forms.Label labelprintername;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1;

    }
}

