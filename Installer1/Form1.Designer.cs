namespace Installer1
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
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.openBtn = new System.Windows.Forms.Button();
			this.installBtn = new System.Windows.Forms.Button();
			this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
			this.closeBtn = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(21, 75);
			this.textBox1.Name = "textBox1";
			this.textBox1.ReadOnly = true;
			this.textBox1.Size = new System.Drawing.Size(419, 27);
			this.textBox1.TabIndex = 0;
			this.textBox1.Text = "C:\\Program Files (x86)\\Frolov\\";
			// 
			// openBtn
			// 
			this.openBtn.Location = new System.Drawing.Point(446, 75);
			this.openBtn.Name = "openBtn";
			this.openBtn.Size = new System.Drawing.Size(94, 29);
			this.openBtn.TabIndex = 1;
			this.openBtn.Text = "open";
			this.openBtn.UseVisualStyleBackColor = true;
			this.openBtn.Click += new System.EventHandler(this.openBtn_Click);
			// 
			// installBtn
			// 
			this.installBtn.Location = new System.Drawing.Point(420, 154);
			this.installBtn.Name = "installBtn";
			this.installBtn.Size = new System.Drawing.Size(115, 44);
			this.installBtn.TabIndex = 2;
			this.installBtn.Text = "Install";
			this.installBtn.UseVisualStyleBackColor = true;
			this.installBtn.Click += new System.EventHandler(this.installBtn_Click_1);
			// 
			// closeBtn
			// 
			this.closeBtn.Location = new System.Drawing.Point(279, 154);
			this.closeBtn.Name = "closeBtn";
			this.closeBtn.Size = new System.Drawing.Size(115, 44);
			this.closeBtn.TabIndex = 2;
			this.closeBtn.Text = "Close";
			this.closeBtn.UseVisualStyleBackColor = true;
			this.closeBtn.Click += new System.EventHandler(this.closeBtn_Click_1);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(547, 209);
			this.Controls.Add(this.closeBtn);
			this.Controls.Add(this.installBtn);
			this.Controls.Add(this.openBtn);
			this.Controls.Add(this.textBox1);
			this.Name = "Form1";
			this.Text = "Installer";
			this.ResumeLayout(false);
			this.PerformLayout();

			}

		#endregion

		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Button openBtn;
		private System.Windows.Forms.Button installBtn;
		private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
		private System.Windows.Forms.Button closeBtn;
		}
	}

