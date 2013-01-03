namespace WikiMigrator
{
    partial class MainWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.btn_EnumWikis = new System.Windows.Forms.Button();
            this.btn_EnumWikis2 = new System.Windows.Forms.Button();
            this.txt_SiteName = new System.Windows.Forms.TextBox();
            this.txt_SelectedWiki = new System.Windows.Forms.TextBox();
            this.txt_SiteName2 = new System.Windows.Forms.TextBox();
            this.lst_Wikis = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lst_Wikis2 = new System.Windows.Forms.ListBox();
            this.txt_SelectedWiki2 = new System.Windows.Forms.TextBox();
            this.btn_CopyWiki = new System.Windows.Forms.Button();
            this.txt_Status = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnFixWiki2Links = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.txtNumberRows = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txt_Repl1 = new System.Windows.Forms.TextBox();
            this.txt_Repl2 = new System.Windows.Forms.TextBox();
            this.chk_AdvRepl = new System.Windows.Forms.CheckBox();
            this.chkDebugFull = new System.Windows.Forms.CheckBox();
            this.chk_DestLocal = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // btn_EnumWikis
            // 
            this.btn_EnumWikis.Location = new System.Drawing.Point(240, 14);
            this.btn_EnumWikis.Name = "btn_EnumWikis";
            this.btn_EnumWikis.Size = new System.Drawing.Size(75, 23);
            this.btn_EnumWikis.TabIndex = 2;
            this.btn_EnumWikis.Text = "Enum Wikis";
            this.btn_EnumWikis.UseVisualStyleBackColor = true;
            this.btn_EnumWikis.Click += new System.EventHandler(this.btn_EnumWikis_Click);
            // 
            // btn_EnumWikis2
            // 
            this.btn_EnumWikis2.Location = new System.Drawing.Point(240, 189);
            this.btn_EnumWikis2.Name = "btn_EnumWikis2";
            this.btn_EnumWikis2.Size = new System.Drawing.Size(75, 23);
            this.btn_EnumWikis2.TabIndex = 7;
            this.btn_EnumWikis2.Text = "Enum Wikis";
            this.btn_EnumWikis2.UseVisualStyleBackColor = true;
            this.btn_EnumWikis2.Click += new System.EventHandler(this.btn_EnumWikis2_Click);
            // 
            // txt_SiteName
            // 
            this.txt_SiteName.Location = new System.Drawing.Point(59, 14);
            this.txt_SiteName.Name = "txt_SiteName";
            this.txt_SiteName.Size = new System.Drawing.Size(175, 20);
            this.txt_SiteName.TabIndex = 1;
            this.txt_SiteName.Text = "http://mswikis/search12";
            // 
            // txt_SelectedWiki
            // 
            this.txt_SelectedWiki.Location = new System.Drawing.Point(59, 142);
            this.txt_SelectedWiki.Name = "txt_SelectedWiki";
            this.txt_SelectedWiki.Size = new System.Drawing.Size(256, 20);
            this.txt_SelectedWiki.TabIndex = 5;
            this.txt_SelectedWiki.Text = "Wiki Pages";
            // 
            // txt_SiteName2
            // 
            this.txt_SiteName2.Location = new System.Drawing.Point(59, 192);
            this.txt_SiteName2.Name = "txt_SiteName2";
            this.txt_SiteName2.Size = new System.Drawing.Size(175, 20);
            this.txt_SiteName2.TabIndex = 6;
            this.txt_SiteName2.Text = "http://servername/coursedev";
            // 
            // lst_Wikis
            // 
            this.lst_Wikis.FormattingEnabled = true;
            this.lst_Wikis.Location = new System.Drawing.Point(98, 41);
            this.lst_Wikis.Name = "lst_Wikis";
            this.lst_Wikis.Size = new System.Drawing.Size(217, 95);
            this.lst_Wikis.TabIndex = 4;
            this.lst_Wikis.SelectedIndexChanged += new System.EventHandler(this.lst_Wikis_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Server 1:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 145);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Wiki 1:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 194);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Server 2:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 322);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Wiki 2:";
            // 
            // lst_Wikis2
            // 
            this.lst_Wikis2.FormattingEnabled = true;
            this.lst_Wikis2.Location = new System.Drawing.Point(98, 218);
            this.lst_Wikis2.Name = "lst_Wikis2";
            this.lst_Wikis2.Size = new System.Drawing.Size(217, 95);
            this.lst_Wikis2.TabIndex = 11;
            this.lst_Wikis2.SelectedIndexChanged += new System.EventHandler(this.lst_Wikis2_SelectedIndexChanged);
            // 
            // txt_SelectedWiki2
            // 
            this.txt_SelectedWiki2.Location = new System.Drawing.Point(59, 319);
            this.txt_SelectedWiki2.Name = "txt_SelectedWiki2";
            this.txt_SelectedWiki2.Size = new System.Drawing.Size(256, 20);
            this.txt_SelectedWiki2.TabIndex = 13;
            this.txt_SelectedWiki2.Text = "mswikis - search12";
            // 
            // btn_CopyWiki
            // 
            this.btn_CopyWiki.Location = new System.Drawing.Point(39, 363);
            this.btn_CopyWiki.Name = "btn_CopyWiki";
            this.btn_CopyWiki.Size = new System.Drawing.Size(119, 23);
            this.btn_CopyWiki.TabIndex = 14;
            this.btn_CopyWiki.Text = "Copy Wiki 1 -> Wiki 2";
            this.btn_CopyWiki.UseVisualStyleBackColor = true;
            this.btn_CopyWiki.Click += new System.EventHandler(this.btn_CopyWiki_Click);
            // 
            // txt_Status
            // 
            this.txt_Status.Location = new System.Drawing.Point(9, 406);
            this.txt_Status.Multiline = true;
            this.txt_Status.Name = "txt_Status";
            this.txt_Status.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txt_Status.Size = new System.Drawing.Size(305, 86);
            this.txt_Status.TabIndex = 16;
            this.txt_Status.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 391);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "Status:";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.panel1.Location = new System.Drawing.Point(8, 173);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(306, 4);
            this.panel1.TabIndex = 15;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.panel2.Location = new System.Drawing.Point(9, 353);
            this.panel2.Name = "panel2";
            this.panel2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.panel2.Size = new System.Drawing.Size(306, 4);
            this.panel2.TabIndex = 16;
            // 
            // btnFixWiki2Links
            // 
            this.btnFixWiki2Links.Location = new System.Drawing.Point(174, 363);
            this.btnFixWiki2Links.Name = "btnFixWiki2Links";
            this.btnFixWiki2Links.Size = new System.Drawing.Size(119, 23);
            this.btnFixWiki2Links.TabIndex = 15;
            this.btnFixWiki2Links.Text = "Fix Wiki 2 Links";
            this.btnFixWiki2Links.UseVisualStyleBackColor = true;
            this.btnFixWiki2Links.Click += new System.EventHandler(this.btnFixWiki2Links_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.panel3.Location = new System.Drawing.Point(164, 356);
            this.panel3.Name = "panel3";
            this.panel3.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.panel3.Size = new System.Drawing.Size(4, 38);
            this.panel3.TabIndex = 17;
            // 
            // txtNumberRows
            // 
            this.txtNumberRows.Location = new System.Drawing.Point(8, 57);
            this.txtNumberRows.Name = "txtNumberRows";
            this.txtNumberRows.Size = new System.Drawing.Size(81, 20);
            this.txtNumberRows.TabIndex = 3;
            this.txtNumberRows.Text = "999999";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 41);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(37, 13);
            this.label6.TabIndex = 19;
            this.label6.Text = "Rows:";
            // 
            // txt_Repl1
            // 
            this.txt_Repl1.Enabled = false;
            this.txt_Repl1.Location = new System.Drawing.Point(8, 266);
            this.txt_Repl1.Name = "txt_Repl1";
            this.txt_Repl1.Size = new System.Drawing.Size(81, 20);
            this.txt_Repl1.TabIndex = 10;
            // 
            // txt_Repl2
            // 
            this.txt_Repl2.Enabled = false;
            this.txt_Repl2.Location = new System.Drawing.Point(8, 292);
            this.txt_Repl2.Name = "txt_Repl2";
            this.txt_Repl2.Size = new System.Drawing.Size(81, 20);
            this.txt_Repl2.TabIndex = 11;
            // 
            // chk_AdvRepl
            // 
            this.chk_AdvRepl.AutoSize = true;
            this.chk_AdvRepl.Location = new System.Drawing.Point(1, 248);
            this.chk_AdvRepl.Margin = new System.Windows.Forms.Padding(0);
            this.chk_AdvRepl.Name = "chk_AdvRepl";
            this.chk_AdvRepl.Size = new System.Drawing.Size(88, 17);
            this.chk_AdvRepl.TabIndex = 9;
            this.chk_AdvRepl.Text = "Adv Replace";
            this.chk_AdvRepl.UseVisualStyleBackColor = true;
            this.chk_AdvRepl.CheckedChanged += new System.EventHandler(this.chk_AdvRepl_CheckedChanged);
            // 
            // chkDebugFull
            // 
            this.chkDebugFull.AutoSize = true;
            this.chkDebugFull.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.chkDebugFull.Location = new System.Drawing.Point(9, 490);
            this.chkDebugFull.Name = "chkDebugFull";
            this.chkDebugFull.Size = new System.Drawing.Size(145, 17);
            this.chkDebugFull.TabIndex = 20;
            this.chkDebugFull.Text = "Debug Full TraceListener";
            this.chkDebugFull.UseVisualStyleBackColor = true;
            // 
            // chk_DestLocal
            // 
            this.chk_DestLocal.AutoSize = true;
            this.chk_DestLocal.Location = new System.Drawing.Point(1, 231);
            this.chk_DestLocal.Margin = new System.Windows.Forms.Padding(0);
            this.chk_DestLocal.Name = "chk_DestLocal";
            this.chk_DestLocal.Size = new System.Drawing.Size(77, 17);
            this.chk_DestLocal.TabIndex = 8;
            this.chk_DestLocal.Text = "Dest Local";
            this.chk_DestLocal.UseVisualStyleBackColor = true;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(327, 505);
            this.Controls.Add(this.chk_DestLocal);
            this.Controls.Add(this.chk_AdvRepl);
            this.Controls.Add(this.txt_Repl2);
            this.Controls.Add(this.txt_Repl1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtNumberRows);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.btnFixWiki2Links);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txt_Status);
            this.Controls.Add(this.btn_CopyWiki);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lst_Wikis2);
            this.Controls.Add(this.txt_SelectedWiki2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lst_Wikis);
            this.Controls.Add(this.txt_SiteName2);
            this.Controls.Add(this.txt_SelectedWiki);
            this.Controls.Add(this.txt_SiteName);
            this.Controls.Add(this.btn_EnumWikis2);
            this.Controls.Add(this.btn_EnumWikis);
            this.Controls.Add(this.chkDebugFull);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainWindow";
            this.Text = "Wiki Migrator - 0.4";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_EnumWikis;
        private System.Windows.Forms.Button btn_EnumWikis2;
        private System.Windows.Forms.TextBox txt_SiteName;
        private System.Windows.Forms.TextBox txt_SelectedWiki;
        private System.Windows.Forms.TextBox txt_SiteName2;
        private System.Windows.Forms.ListBox lst_Wikis;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListBox lst_Wikis2;
        private System.Windows.Forms.TextBox txt_SelectedWiki2;
        private System.Windows.Forms.Button btn_CopyWiki;
        private System.Windows.Forms.TextBox txt_Status;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnFixWiki2Links;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox txtNumberRows;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txt_Repl1;
        private System.Windows.Forms.TextBox txt_Repl2;
        private System.Windows.Forms.CheckBox chk_AdvRepl;
        private System.Windows.Forms.CheckBox chkDebugFull;
        private System.Windows.Forms.CheckBox chk_DestLocal;
    }
}

