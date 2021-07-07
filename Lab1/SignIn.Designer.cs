namespace Lab1
	{
	partial class SignIn
		{
		/// <summary>
		///  Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		///  Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose (bool disposing)
			{
			if ( disposing && ( components != null ) )
				{
				components.Dispose();
				}
			base.Dispose(disposing);
			}

		#region Windows Form Designer generated code

		/// <summary>
		///  Required method for Designer support - do not modify
		///  the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent ()
			{
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.AboutProgram = new System.Windows.Forms.ToolStripMenuItem();
			this.label2 = new System.Windows.Forms.Label();
			this.passwordBox = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.button1 = new System.Windows.Forms.Button();
			this.loginBox = new System.Windows.Forms.TextBox();
			this.warningLabel = new System.Windows.Forms.Label();
			this.loginPanel = new System.Windows.Forms.Panel();
			this.repeatBox = new System.Windows.Forms.TextBox();
			this.menuStrip1.SuspendLayout();
			this.loginPanel.SuspendLayout();
			this.SuspendLayout();
			// 
			// menuStrip1
			// 
			this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(947, 28);
			this.menuStrip1.TabIndex = 8;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// toolStripMenuItem1
			// 
			this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AboutProgram});
			this.toolStripMenuItem1.Name = "toolStripMenuItem1";
			this.toolStripMenuItem1.Size = new System.Drawing.Size(81, 24);
			this.toolStripMenuItem1.Text = "Справка";
			// 
			// AboutProgram
			// 
			this.AboutProgram.Name = "AboutProgram";
			this.AboutProgram.Size = new System.Drawing.Size(187, 26);
			this.AboutProgram.Text = "О программе";
			this.AboutProgram.Click += new System.EventHandler(this.AboutProgram_Click);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(412, 293);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(70, 20);
			this.label2.TabIndex = 3;
			this.label2.Text = "Password";
			// 
			// passwordBox
			// 
			this.passwordBox.Location = new System.Drawing.Point(355, 338);
			this.passwordBox.Name = "passwordBox";
			this.passwordBox.PasswordChar = '*';
			this.passwordBox.PlaceholderText = "Password";
			this.passwordBox.Size = new System.Drawing.Size(184, 27);
			this.passwordBox.TabIndex = 2;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(424, 196);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(46, 20);
			this.label1.TabIndex = 0;
			this.label1.Text = "Login";
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(394, 451);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(110, 45);
			this.button1.TabIndex = 6;
			this.button1.Text = "Login";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// loginBox
			// 
			this.loginBox.Location = new System.Drawing.Point(355, 241);
			this.loginBox.Name = "loginBox";
			this.loginBox.PlaceholderText = "Login";
			this.loginBox.Size = new System.Drawing.Size(184, 27);
			this.loginBox.TabIndex = 1;
			// 
			// warningLabel
			// 
			this.warningLabel.AutoSize = true;
			this.warningLabel.Location = new System.Drawing.Point(350, 405);
			this.warningLabel.Name = "warningLabel";
			this.warningLabel.Size = new System.Drawing.Size(0, 20);
			this.warningLabel.TabIndex = 7;
			// 
			// loginPanel
			// 
			this.loginPanel.Controls.Add(this.repeatBox);
			this.loginPanel.Controls.Add(this.warningLabel);
			this.loginPanel.Controls.Add(this.loginBox);
			this.loginPanel.Controls.Add(this.button1);
			this.loginPanel.Controls.Add(this.label1);
			this.loginPanel.Controls.Add(this.passwordBox);
			this.loginPanel.Controls.Add(this.label2);
			this.loginPanel.Controls.Add(this.menuStrip1);
			this.loginPanel.Location = new System.Drawing.Point(2, 1);
			this.loginPanel.Name = "loginPanel";
			this.loginPanel.Size = new System.Drawing.Size(947, 644);
			this.loginPanel.TabIndex = 7;
			// 
			// repeatBox
			// 
			this.repeatBox.Enabled = false;
			this.repeatBox.Location = new System.Drawing.Point(355, 383);
			this.repeatBox.Name = "repeatBox";
			this.repeatBox.PasswordChar = '*';
			this.repeatBox.PlaceholderText = "Repeat Password";
			this.repeatBox.Size = new System.Drawing.Size(185, 27);
			this.repeatBox.TabIndex = 9;
			// 
			// SignIn
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(952, 643);
			this.Controls.Add(this.loginPanel);
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "SignIn";
			this.Text = "Sign In";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SignIn_FormClosing);
			this.Load += new System.EventHandler(this.SignIn_Load);
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.loginPanel.ResumeLayout(false);
			this.loginPanel.PerformLayout();
			this.ResumeLayout(false);

			}

		#endregion

		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem AboutProgram;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox passwordBox;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.TextBox loginBox;
		private System.Windows.Forms.Label warningLabel;
		private System.Windows.Forms.Panel loginPanel;
		private System.Windows.Forms.TextBox repeatBox;
		}
	}

