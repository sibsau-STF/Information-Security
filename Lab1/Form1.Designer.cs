namespace Lab1
	{
	partial class Form1
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
			this.label3 = new System.Windows.Forms.Label();
			this.repeatBox = new System.Windows.Forms.TextBox();
			this.button1 = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(173, 110);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(46, 20);
			this.label1.TabIndex = 0;
			this.label1.Text = "Login";
			// 
			// loginBox
			// 
			this.loginBox.Location = new System.Drawing.Point(173, 133);
			this.loginBox.Name = "loginBox";
			this.loginBox.PlaceholderText = "Login";
			this.loginBox.Size = new System.Drawing.Size(125, 27);
			this.loginBox.TabIndex = 1;
			// 
			// passwordBox
			// 
			this.passwordBox.Location = new System.Drawing.Point(173, 233);
			this.passwordBox.Name = "passwordBox";
			this.passwordBox.PasswordChar = '*';
			this.passwordBox.PlaceholderText = "Password";
			this.passwordBox.Size = new System.Drawing.Size(125, 27);
			this.passwordBox.TabIndex = 2;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(173, 198);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(70, 20);
			this.label2.TabIndex = 3;
			this.label2.Text = "Password";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(378, 198);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(50, 20);
			this.label3.TabIndex = 4;
			this.label3.Text = "label3";
			// 
			// repeatBox
			// 
			this.repeatBox.Location = new System.Drawing.Point(378, 233);
			this.repeatBox.Name = "repeatBox";
			this.repeatBox.PasswordChar = '*';
			this.repeatBox.PlaceholderText = "Repeat password";
			this.repeatBox.Size = new System.Drawing.Size(125, 27);
			this.repeatBox.TabIndex = 5;
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(320, 319);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(94, 29);
			this.button1.TabIndex = 6;
			this.button1.Text = "button1";
			this.button1.UseVisualStyleBackColor = true;
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(853, 476);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.repeatBox);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.passwordBox);
			this.Controls.Add(this.loginBox);
			this.Controls.Add(this.label1);
			this.Name = "Form1";
			this.Text = "Form1";
			this.ResumeLayout(false);
			this.PerformLayout();

			}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox loginBox;
		private System.Windows.Forms.TextBox passwordBox;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox repeatBox;
		private System.Windows.Forms.Button button1;
		}
	}

