namespace GmailRead
{
    partial class MainWnd
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
            this.m_txtGmail = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.m_txtPassword = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.m_txtlogs = new System.Windows.Forms.RichTextBox();
            this.m_btnStart = new System.Windows.Forms.Button();
            this.m_btnClose = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.m_txtXlsFilePath = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.m_btnReset = new System.Windows.Forms.Button();
            this.m_btnXlsOpen = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.m_numEAPort = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.m_OpenXLSDialog = new System.Windows.Forms.OpenFileDialog();
            this.m_Timer = new System.Windows.Forms.Timer(this.components);
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.m_listEmailTitleCount = new System.Windows.Forms.ListBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_numEAPort)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_txtGmail
            // 
            this.m_txtGmail.Location = new System.Drawing.Point(106, 19);
            this.m_txtGmail.Name = "m_txtGmail";
            this.m_txtGmail.Size = new System.Drawing.Size(147, 20);
            this.m_txtGmail.TabIndex = 0;
            this.m_txtGmail.Text = "tonyvn.001@gmail.com";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Gmail Address :";
            // 
            // m_txtPassword
            // 
            this.m_txtPassword.Location = new System.Drawing.Point(381, 19);
            this.m_txtPassword.Name = "m_txtPassword";
            this.m_txtPassword.PasswordChar = '*';
            this.m_txtPassword.Size = new System.Drawing.Size(211, 20);
            this.m_txtPassword.TabIndex = 0;
            this.m_txtPassword.Text = "dangmien";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(287, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Gmail Password :";
            // 
            // m_txtlogs
            // 
            this.m_txtlogs.BackColor = System.Drawing.Color.Black;
            this.m_txtlogs.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_txtlogs.ForeColor = System.Drawing.Color.White;
            this.m_txtlogs.Location = new System.Drawing.Point(12, 204);
            this.m_txtlogs.Name = "m_txtlogs";
            this.m_txtlogs.ReadOnly = true;
            this.m_txtlogs.Size = new System.Drawing.Size(609, 520);
            this.m_txtlogs.TabIndex = 2;
            this.m_txtlogs.Text = "";
            this.m_txtlogs.WordWrap = false;
            // 
            // m_btnStart
            // 
            this.m_btnStart.BackColor = System.Drawing.Color.Maroon;
            this.m_btnStart.Enabled = false;
            this.m_btnStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_btnStart.Location = new System.Drawing.Point(439, 24);
            this.m_btnStart.Name = "m_btnStart";
            this.m_btnStart.Size = new System.Drawing.Size(75, 23);
            this.m_btnStart.TabIndex = 3;
            this.m_btnStart.Text = "START";
            this.m_btnStart.UseVisualStyleBackColor = false;
            this.m_btnStart.Click += new System.EventHandler(this.m_btnStart_Click);
            // 
            // m_btnClose
            // 
            this.m_btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.m_btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_btnClose.Location = new System.Drawing.Point(520, 24);
            this.m_btnClose.Name = "m_btnClose";
            this.m_btnClose.Size = new System.Drawing.Size(75, 23);
            this.m_btnClose.TabIndex = 3;
            this.m_btnClose.Text = "CLOSE";
            this.m_btnClose.UseVisualStyleBackColor = false;
            this.m_btnClose.Click += new System.EventHandler(this.m_btnClose_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.m_txtPassword);
            this.groupBox1.Controls.Add(this.m_txtGmail);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(609, 58);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "GMAIL SETTING";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.m_txtXlsFilePath);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.m_btnXlsOpen);
            this.groupBox2.ForeColor = System.Drawing.Color.White;
            this.groupBox2.Location = new System.Drawing.Point(12, 76);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(609, 58);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "SELECT XLS FILE";
            // 
            // m_txtXlsFilePath
            // 
            this.m_txtXlsFilePath.Location = new System.Drawing.Point(97, 21);
            this.m_txtXlsFilePath.Name = "m_txtXlsFilePath";
            this.m_txtXlsFilePath.ReadOnly = true;
            this.m_txtXlsFilePath.Size = new System.Drawing.Size(417, 20);
            this.m_txtXlsFilePath.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "File Path :";
            // 
            // m_btnReset
            // 
            this.m_btnReset.BackColor = System.Drawing.Color.Green;
            this.m_btnReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_btnReset.Location = new System.Drawing.Point(6, 685);
            this.m_btnReset.Name = "m_btnReset";
            this.m_btnReset.Size = new System.Drawing.Size(192, 23);
            this.m_btnReset.TabIndex = 3;
            this.m_btnReset.Text = "RESET SELETED MAIL COUNT";
            this.m_btnReset.UseVisualStyleBackColor = false;
            this.m_btnReset.Click += new System.EventHandler(this.m_btnReset_Click);
            // 
            // m_btnXlsOpen
            // 
            this.m_btnXlsOpen.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.m_btnXlsOpen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_btnXlsOpen.Location = new System.Drawing.Point(520, 20);
            this.m_btnXlsOpen.Name = "m_btnXlsOpen";
            this.m_btnXlsOpen.Size = new System.Drawing.Size(75, 23);
            this.m_btnXlsOpen.TabIndex = 3;
            this.m_btnXlsOpen.Text = "OPEN";
            this.m_btnXlsOpen.UseVisualStyleBackColor = false;
            this.m_btnXlsOpen.Click += new System.EventHandler(this.m_btnXlsOpen_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.m_numEAPort);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.m_btnStart);
            this.groupBox3.Controls.Add(this.m_btnClose);
            this.groupBox3.ForeColor = System.Drawing.Color.White;
            this.groupBox3.Location = new System.Drawing.Point(12, 140);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(609, 58);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "INPUT EA PORT NUMBER";
            // 
            // m_numEAPort
            // 
            this.m_numEAPort.Location = new System.Drawing.Point(97, 25);
            this.m_numEAPort.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.m_numEAPort.Name = "m_numEAPort";
            this.m_numEAPort.Size = new System.Drawing.Size(120, 20);
            this.m_numEAPort.TabIndex = 4;
            this.m_numEAPort.Value = new decimal(new int[] {
            8222,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(19, 29);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Port Number :";
            // 
            // m_OpenXLSDialog
            // 
            this.m_OpenXLSDialog.Filter = "xls files (*.xls)|*.xls|All files (*.*)|*.*";
            // 
            // m_Timer
            // 
            this.m_Timer.Interval = 10000;
            this.m_Timer.Tick += new System.EventHandler(this.m_Timer_Tick);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.m_listEmailTitleCount);
            this.groupBox4.Controls.Add(this.m_btnReset);
            this.groupBox4.Location = new System.Drawing.Point(627, 12);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(203, 712);
            this.groupBox4.TabIndex = 5;
            this.groupBox4.TabStop = false;
            // 
            // m_listEmailTitleCount
            // 
            this.m_listEmailTitleCount.FormattingEnabled = true;
            this.m_listEmailTitleCount.Location = new System.Drawing.Point(6, 12);
            this.m_listEmailTitleCount.Name = "m_listEmailTitleCount";
            this.m_listEmailTitleCount.Size = new System.Drawing.Size(191, 667);
            this.m_listEmailTitleCount.TabIndex = 0;
            // 
            // MainWnd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(839, 736);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.m_txtlogs);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainWnd";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GmailReader";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_numEAPort)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox m_txtGmail;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox m_txtPassword;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox m_txtlogs;
        private System.Windows.Forms.Button m_btnStart;
        private System.Windows.Forms.Button m_btnClose;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox m_txtXlsFilePath;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button m_btnXlsOpen;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.NumericUpDown m_numEAPort;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.OpenFileDialog m_OpenXLSDialog;
        private System.Windows.Forms.Timer m_Timer;
        private System.Windows.Forms.Button m_btnReset;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.ListBox m_listEmailTitleCount;
    }
}

