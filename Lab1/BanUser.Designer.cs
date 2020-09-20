namespace Lab1
	{
	partial class BanUser
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
			this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
			this.applyButton = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// checkedListBox1
			// 
			this.checkedListBox1.FormattingEnabled = true;
			this.checkedListBox1.Location = new System.Drawing.Point(47, 63);
			this.checkedListBox1.Name = "checkedListBox1";
			this.checkedListBox1.Size = new System.Drawing.Size(150, 114);
			this.checkedListBox1.TabIndex = 0;
			// 
			// applyButton
			// 
			this.applyButton.Location = new System.Drawing.Point(166, 218);
			this.applyButton.Name = "applyButton";
			this.applyButton.Size = new System.Drawing.Size(94, 29);
			this.applyButton.TabIndex = 1;
			this.applyButton.Text = "Apply";
			this.applyButton.UseVisualStyleBackColor = true;
			this.applyButton.Click += new System.EventHandler(this.applyButton_Click);
			// 
			// BanUser
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(414, 340);
			this.Controls.Add(this.applyButton);
			this.Controls.Add(this.checkedListBox1);
			this.Name = "BanUser";
			this.Text = "BanUser";
			this.ResumeLayout(false);

			}

		#endregion

		private System.Windows.Forms.CheckedListBox checkedListBox1;
		private System.Windows.Forms.Button applyButton;
		}
	}