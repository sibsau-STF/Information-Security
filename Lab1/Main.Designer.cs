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
			this.changePass = new System.Windows.Forms.Button();
			this.logoutButton = new System.Windows.Forms.Button();
			this.nicknameLabel = new System.Windows.Forms.Label();
			this.usersPanel = new System.Windows.Forms.Panel();
			this.addUserButton = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.dataGridView1 = new System.Windows.Forms.DataGridView();
			this.banButton = new System.Windows.Forms.Button();
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
			this.mainPanel.Controls.Add(this.changePass);
			this.mainPanel.Controls.Add(this.logoutButton);
			this.mainPanel.Controls.Add(this.nicknameLabel);
			this.mainPanel.Location = new System.Drawing.Point(3, 3);
			this.mainPanel.Name = "mainPanel";
			this.mainPanel.Size = new System.Drawing.Size(935, 179);
			this.mainPanel.TabIndex = 0;
			// 
			// changePass
			// 
			this.changePass.Location = new System.Drawing.Point(23, 81);
			this.changePass.Name = "changePass";
			this.changePass.Size = new System.Drawing.Size(153, 29);
			this.changePass.TabIndex = 6;
			this.changePass.Text = " Change password";
			this.changePass.UseVisualStyleBackColor = true;
			this.changePass.Click += new System.EventHandler(this.changePass_Click);
			// 
			// logoutButton
			// 
			this.logoutButton.Location = new System.Drawing.Point(23, 130);
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
			this.nicknameLabel.Location = new System.Drawing.Point(23, 36);
			this.nicknameLabel.Name = "nicknameLabel";
			this.nicknameLabel.Size = new System.Drawing.Size(50, 20);
			this.nicknameLabel.TabIndex = 4;
			this.nicknameLabel.Text = "label1";
			// 
			// usersPanel
			// 
			this.usersPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.usersPanel.Controls.Add(this.banButton);
			this.usersPanel.Controls.Add(this.addUserButton);
			this.usersPanel.Controls.Add(this.button2);
			this.usersPanel.Controls.Add(this.dataGridView1);
			this.usersPanel.Dock = System.Windows.Forms.DockStyle.Right;
			this.usersPanel.Location = new System.Drawing.Point(3, 188);
			this.usersPanel.Name = "usersPanel";
			this.usersPanel.Size = new System.Drawing.Size(935, 399);
			this.usersPanel.TabIndex = 1;
			// 
			// addUserButton
			// 
			this.addUserButton.Location = new System.Drawing.Point(179, 349);
			this.addUserButton.Name = "addUserButton";
			this.addUserButton.Size = new System.Drawing.Size(94, 29);
			this.addUserButton.TabIndex = 2;
			this.addUserButton.Text = "Add user";
			this.addUserButton.UseVisualStyleBackColor = true;
			this.addUserButton.Click += new System.EventHandler(this.addUserButton_Click);
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(8, 349);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(153, 29);
			this.button2.TabIndex = 1;
			this.button2.Text = "Save Changes";
			this.button2.UseVisualStyleBackColor = true;
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
			// banButton
			// 
			this.banButton.Location = new System.Drawing.Point(292, 349);
			this.banButton.Name = "banButton";
			this.banButton.Size = new System.Drawing.Size(94, 29);
			this.banButton.TabIndex = 3;
			this.banButton.Text = "Ban User";
			this.banButton.UseVisualStyleBackColor = true;
			this.banButton.Click += new System.EventHandler(this.banButton_Click);
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
		private System.Windows.Forms.Panel usersPanel;
		private System.Windows.Forms.DataGridView dataGridView1;
		private System.Windows.Forms.Label nicknameLabel;
		private System.Windows.Forms.Button logoutButton;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button changePass;
		private System.Windows.Forms.Button addUserButton;
		private System.Windows.Forms.Button banButton;
		}
	}