namespace Lab1
	{
	partial class ChangePassword
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
			this.label1 = new System.Windows.Forms.Label();
			this.oldPassBox = new System.Windows.Forms.TextBox();
			this.newPassBox = new System.Windows.Forms.TextBox();
			this.repeatPassBox = new System.Windows.Forms.TextBox();
			this.button1 = new System.Windows.Forms.Button();
			this.statusLabel = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(200, 81);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(124, 20);
			this.label1.TabIndex = 0;
			this.label1.Text = "Change Password";
			// 
			// oldPassBox
			// 
			this.oldPassBox.Location = new System.Drawing.Point(137, 115);
			this.oldPassBox.Name = "oldPassBox";
			this.oldPassBox.PasswordChar = '*';
			this.oldPassBox.PlaceholderText = "Old password";
			this.oldPassBox.Size = new System.Drawing.Size(250, 27);
			this.oldPassBox.TabIndex = 1;
			// 
			// newPassBox
			// 
			this.newPassBox.Location = new System.Drawing.Point(137, 161);
			this.newPassBox.Name = "newPassBox";
			this.newPassBox.PasswordChar = '*';
			this.newPassBox.PlaceholderText = "New password";
			this.newPassBox.Size = new System.Drawing.Size(250, 27);
			this.newPassBox.TabIndex = 2;
			// 
			// repeatPassBox
			// 
			this.repeatPassBox.Location = new System.Drawing.Point(137, 207);
			this.repeatPassBox.Name = "repeatPassBox";
			this.repeatPassBox.PasswordChar = '*';
			this.repeatPassBox.PlaceholderText = "Repeat password";
			this.repeatPassBox.Size = new System.Drawing.Size(250, 27);
			this.repeatPassBox.TabIndex = 3;
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(208, 282);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(109, 41);
			this.button1.TabIndex = 2;
			this.button1.TabStop = false;
			this.button1.Text = "Confirm";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.changePassButton_Click);
			// 
			// statusLabel
			// 
			this.statusLabel.AutoSize = true;
			this.statusLabel.ForeColor = System.Drawing.Color.DarkRed;
			this.statusLabel.Location = new System.Drawing.Point(137, 257);
			this.statusLabel.Name = "statusLabel";
			this.statusLabel.Size = new System.Drawing.Size(0, 20);
			this.statusLabel.TabIndex = 6;
			// 
			// ChangePassword
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(527, 404);
			this.Controls.Add(this.statusLabel);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.repeatPassBox);
			this.Controls.Add(this.newPassBox);
			this.Controls.Add(this.oldPassBox);
			this.Controls.Add(this.label1);
			this.Name = "ChangePassword";
			this.Text = "Change user password";
			this.ResumeLayout(false);
			this.PerformLayout();

			}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox oldPassBox;
		private System.Windows.Forms.TextBox newPassBox;
		private System.Windows.Forms.TextBox repeatPassBox;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Label statusLabel;
		}
	}