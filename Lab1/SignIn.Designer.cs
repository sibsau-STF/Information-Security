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
			this.label1 = new System.Windows.Forms.Label();
			this.loginBox = new System.Windows.Forms.TextBox();
			this.passwordBox = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.button1 = new System.Windows.Forms.Button();
			this.loginPanel = new System.Windows.Forms.Panel();
			this.warningLabel = new System.Windows.Forms.Label();
			this.loginPanel.SuspendLayout();
			this.SuspendLayout();
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
			// loginBox
			// 
			this.loginBox.Location = new System.Drawing.Point(355, 241);
			this.loginBox.Name = "loginBox";
			this.loginBox.PlaceholderText = "Login";
			this.loginBox.Size = new System.Drawing.Size(184, 27);
			this.loginBox.TabIndex = 1;
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
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(412, 293);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(70, 20);
			this.label2.TabIndex = 3;
			this.label2.Text = "Password";
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
			// loginPanel
			// 
			this.loginPanel.Controls.Add(this.warningLabel);
			this.loginPanel.Controls.Add(this.loginBox);
			this.loginPanel.Controls.Add(this.button1);
			this.loginPanel.Controls.Add(this.label1);
			this.loginPanel.Controls.Add(this.passwordBox);
			this.loginPanel.Controls.Add(this.label2);
			this.loginPanel.Location = new System.Drawing.Point(2, 1);
			this.loginPanel.Name = "loginPanel";
			this.loginPanel.Size = new System.Drawing.Size(947, 644);
			this.loginPanel.TabIndex = 7;
			// 
			// warningLabel
			// 
			this.warningLabel.AutoSize = true;
			this.warningLabel.Location = new System.Drawing.Point(424, 383);
			this.warningLabel.Name = "warningLabel";
			this.warningLabel.Size = new System.Drawing.Size(0, 20);
			this.warningLabel.TabIndex = 7;
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(952, 643);
			this.Controls.Add(this.loginPanel);
			this.Name = "Form1";
			this.Text = "Form1";
			this.loginPanel.ResumeLayout(false);
			this.loginPanel.PerformLayout();
			this.ResumeLayout(false);

			}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox loginBox;
		private System.Windows.Forms.TextBox passwordBox;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Panel loginPanel;
		private System.Windows.Forms.Label warningLabel;
		}
	}

