namespace Lab1
	{
	partial class AddUser
		{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
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
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent ()
			{
			this.loginBox = new System.Windows.Forms.TextBox();
			this.restrictBox = new System.Windows.Forms.CheckBox();
			this.bannedBox = new System.Windows.Forms.CheckBox();
			this.ruleCombo = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.confirmBox = new System.Windows.Forms.Button();
			this.statusLabel = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// loginBox
			// 
			this.loginBox.Location = new System.Drawing.Point(180, 133);
			this.loginBox.Name = "loginBox";
			this.loginBox.PlaceholderText = "Login";
			this.loginBox.Size = new System.Drawing.Size(125, 27);
			this.loginBox.TabIndex = 0;
			// 
			// restrictBox
			// 
			this.restrictBox.AutoSize = true;
			this.restrictBox.Location = new System.Drawing.Point(180, 187);
			this.restrictBox.Name = "restrictBox";
			this.restrictBox.Size = new System.Drawing.Size(147, 24);
			this.restrictBox.TabIndex = 1;
			this.restrictBox.Text = "Restrict password";
			this.restrictBox.UseVisualStyleBackColor = true;
			// 
			// bannedBox
			// 
			this.bannedBox.AutoSize = true;
			this.bannedBox.Location = new System.Drawing.Point(180, 238);
			this.bannedBox.Name = "bannedBox";
			this.bannedBox.Size = new System.Drawing.Size(81, 24);
			this.bannedBox.TabIndex = 2;
			this.bannedBox.Text = "Banned";
			this.bannedBox.UseVisualStyleBackColor = true;
			// 
			// ruleCombo
			// 
			this.ruleCombo.FormattingEnabled = true;
			this.ruleCombo.Items.AddRange(new object[] {
            "User",
            "Admin"});
			this.ruleCombo.Location = new System.Drawing.Point(237, 286);
			this.ruleCombo.Name = "ruleCombo";
			this.ruleCombo.Size = new System.Drawing.Size(151, 28);
			this.ruleCombo.TabIndex = 4;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(186, 81);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(94, 20);
			this.label1.TabIndex = 5;
			this.label1.Text = "Register user";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(180, 289);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(38, 20);
			this.label2.TabIndex = 6;
			this.label2.Text = "Rule";
			// 
			// confirmBox
			// 
			this.confirmBox.Location = new System.Drawing.Point(186, 365);
			this.confirmBox.Name = "confirmBox";
			this.confirmBox.Size = new System.Drawing.Size(94, 29);
			this.confirmBox.TabIndex = 7;
			this.confirmBox.Text = "Confirm";
			this.confirmBox.UseVisualStyleBackColor = true;
			this.confirmBox.Click += new System.EventHandler(this.confirmBox_Click);
			// 
			// statusLabel
			// 
			this.statusLabel.AutoSize = true;
			this.statusLabel.Location = new System.Drawing.Point(180, 331);
			this.statusLabel.Name = "statusLabel";
			this.statusLabel.Size = new System.Drawing.Size(0, 20);
			this.statusLabel.TabIndex = 8;
			// 
			// AddUser
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(567, 428);
			this.Controls.Add(this.statusLabel);
			this.Controls.Add(this.confirmBox);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.ruleCombo);
			this.Controls.Add(this.bannedBox);
			this.Controls.Add(this.restrictBox);
			this.Controls.Add(this.loginBox);
			this.Name = "AddUser";
			this.Text = "Add new user";
			this.ResumeLayout(false);
			this.PerformLayout();

			}

		#endregion

		private System.Windows.Forms.TextBox loginBox;
		private System.Windows.Forms.CheckBox restrictBox;
		private System.Windows.Forms.CheckBox bannedBox;
		private System.Windows.Forms.ComboBox ruleCombo;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button confirmBox;
		private System.Windows.Forms.Label statusLabel;
		}
	}