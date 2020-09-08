namespace Lab1
	{
	partial class Main
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
			this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
			this.mainPanel = new System.Windows.Forms.Panel();
			this.statusLabel = new System.Windows.Forms.Label();
			this.logoutButton = new System.Windows.Forms.Button();
			this.nicknameLabel = new System.Windows.Forms.Label();
			this.changePassButton = new System.Windows.Forms.Button();
			this.repeatPassBox = new System.Windows.Forms.TextBox();
			this.oldPassBox = new System.Windows.Forms.TextBox();
			this.newPassBox = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.usersPanel = new System.Windows.Forms.Panel();
			this.button2 = new System.Windows.Forms.Button();
			this.dataGridView1 = new System.Windows.Forms.DataGridView();
			this.flowLayoutPanel1.SuspendLayout();
			this.mainPanel.SuspendLayout();
			this.usersPanel.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
			this.SuspendLayout();
			// 
			// flowLayoutPanel1
			// 
			this.flowLayoutPanel1.Controls.Add(this.mainPanel);
			this.flowLayoutPanel1.Controls.Add(this.usersPanel);
			this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
			this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
			this.flowLayoutPanel1.Name = "flowLayoutPanel1";
			this.flowLayoutPanel1.Size = new System.Drawing.Size(1026, 605);
			this.flowLayoutPanel1.TabIndex = 8;
			// 
			// mainPanel
			// 
			this.mainPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.mainPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.mainPanel.Controls.Add(this.statusLabel);
			this.mainPanel.Controls.Add(this.logoutButton);
			this.mainPanel.Controls.Add(this.nicknameLabel);
			this.mainPanel.Controls.Add(this.changePassButton);
			this.mainPanel.Controls.Add(this.repeatPassBox);
			this.mainPanel.Controls.Add(this.oldPassBox);
			this.mainPanel.Controls.Add(this.newPassBox);
			this.mainPanel.Controls.Add(this.label3);
			this.mainPanel.Location = new System.Drawing.Point(3, 3);
			this.mainPanel.Name = "mainPanel";
			this.mainPanel.Size = new System.Drawing.Size(935, 179);
			this.mainPanel.TabIndex = 0;
			// 
			// statusLabel
			// 
			this.statusLabel.AutoSize = true;
			this.statusLabel.ForeColor = System.Drawing.Color.DarkRed;
			this.statusLabel.Location = new System.Drawing.Point(299, 131);
			this.statusLabel.Name = "statusLabel";
			this.statusLabel.Size = new System.Drawing.Size(0, 20);
			this.statusLabel.TabIndex = 6;
			// 
			// logoutButton
			// 
			this.logoutButton.Location = new System.Drawing.Point(646, 89);
			this.logoutButton.Name = "logoutButton";
			this.logoutButton.Size = new System.Drawing.Size(94, 29);
			this.logoutButton.TabIndex = 5;
			this.logoutButton.Text = "LogOut";
			this.logoutButton.UseVisualStyleBackColor = true;
			this.logoutButton.Click += new System.EventHandler(this.logoutButton_Click);
			// 
			// nicknameLabel
			// 
			this.nicknameLabel.AutoSize = true;
			this.nicknameLabel.Location = new System.Drawing.Point(646, 50);
			this.nicknameLabel.Name = "nicknameLabel";
			this.nicknameLabel.Size = new System.Drawing.Size(50, 20);
			this.nicknameLabel.TabIndex = 4;
			this.nicknameLabel.Text = "label1";
			// 
			// changePassButton
			// 
			this.changePassButton.Location = new System.Drawing.Point(313, 53);
			this.changePassButton.Name = "changePassButton";
			this.changePassButton.Size = new System.Drawing.Size(109, 41);
			this.changePassButton.TabIndex = 2;
			this.changePassButton.TabStop = false;
			this.changePassButton.Text = "Confirm";
			this.changePassButton.UseVisualStyleBackColor = true;
			this.changePassButton.Click += new System.EventHandler(this.changePassButton_Click);
			// 
			// repeatPassBox
			// 
			this.repeatPassBox.Location = new System.Drawing.Point(24, 145);
			this.repeatPassBox.Name = "repeatPassBox";
			this.repeatPassBox.PasswordChar = '*';
			this.repeatPassBox.PlaceholderText = "Repeat password";
			this.repeatPassBox.Size = new System.Drawing.Size(250, 27);
			this.repeatPassBox.TabIndex = 3;
			// 
			// oldPassBox
			// 
			this.oldPassBox.Location = new System.Drawing.Point(24, 53);
			this.oldPassBox.Name = "oldPassBox";
			this.oldPassBox.PasswordChar = '*';
			this.oldPassBox.PlaceholderText = "Old password";
			this.oldPassBox.Size = new System.Drawing.Size(250, 27);
			this.oldPassBox.TabIndex = 1;
			// 
			// newPassBox
			// 
			this.newPassBox.Location = new System.Drawing.Point(24, 99);
			this.newPassBox.Name = "newPassBox";
			this.newPassBox.PasswordChar = '*';
			this.newPassBox.PlaceholderText = "New password";
			this.newPassBox.Size = new System.Drawing.Size(250, 27);
			this.newPassBox.TabIndex = 2;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(24, 19);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(124, 20);
			this.label3.TabIndex = 0;
			this.label3.Text = "Change Password";
			// 
			// usersPanel
			// 
			this.usersPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.usersPanel.Controls.Add(this.button2);
			this.usersPanel.Controls.Add(this.dataGridView1);
			this.usersPanel.Dock = System.Windows.Forms.DockStyle.Right;
			this.usersPanel.Location = new System.Drawing.Point(3, 188);
			this.usersPanel.Name = "usersPanel";
			this.usersPanel.Size = new System.Drawing.Size(935, 399);
			this.usersPanel.TabIndex = 1;
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(8, 349);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(153, 29);
			this.button2.TabIndex = 1;
			this.button2.Text = "Save Changes";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// dataGridView1
			// 
			this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView1.Location = new System.Drawing.Point(0, 0);
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.RowHeadersWidth = 51;
			this.dataGridView1.Size = new System.Drawing.Size(933, 329);
			this.dataGridView1.TabIndex = 0;
			this.dataGridView1.Text = "dataGridView1";
			// 
			// Main
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1026, 605);
			this.Controls.Add(this.flowLayoutPanel1);
			this.Name = "Main";
			this.Text = "Main";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Main_FormClosed);
			this.flowLayoutPanel1.ResumeLayout(false);
			this.mainPanel.ResumeLayout(false);
			this.mainPanel.PerformLayout();
			this.usersPanel.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
			this.ResumeLayout(false);

			}

		#endregion

		private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
		private System.Windows.Forms.Panel mainPanel;
		private System.Windows.Forms.TextBox oldPassBox;
		private System.Windows.Forms.TextBox newPassBox;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Panel usersPanel;
		private System.Windows.Forms.Button changePassButton;
		private System.Windows.Forms.DataGridView dataGridView1;
		private System.Windows.Forms.Label nicknameLabel;
		private System.Windows.Forms.Button logoutButton;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Label statusLabel;
		private System.Windows.Forms.TextBox repeatPassBox;
		}
	}