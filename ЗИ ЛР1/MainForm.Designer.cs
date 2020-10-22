namespace ЗИ_ЛР1
{
	partial class MainForm
	{
		/// <summary>
		/// Обязательная переменная конструктора.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Освободить все используемые ресурсы.
		/// </summary>
		/// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Код, автоматически созданный конструктором форм Windows

		/// <summary>
		/// Требуемый метод для поддержки конструктора — не изменяйте 
		/// содержимое этого метода с помощью редактора кода.
		/// </summary>
		private void InitializeComponent()
		{
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.выйтиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.справкаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.сведенияОПрограммеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.label1 = new System.Windows.Forms.Label();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.textBox3 = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.button1 = new System.Windows.Forms.Button();
			this.panel1 = new System.Windows.Forms.Panel();
			this.label5 = new System.Windows.Forms.Label();
			this.dataGridView1 = new System.Windows.Forms.DataGridView();
			this.button2 = new System.Windows.Forms.Button();
			this.button3 = new System.Windows.Forms.Button();
			this.panel2 = new System.Windows.Forms.Panel();
			this.textBox4 = new System.Windows.Forms.TextBox();
			this.checkBox1 = new System.Windows.Forms.CheckBox();
			this.menuStrip1.SuspendLayout();
			this.panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
			this.panel2.SuspendLayout();
			this.SuspendLayout();
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.выйтиToolStripMenuItem,
            this.справкаToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(887, 24);
			this.menuStrip1.TabIndex = 0;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// выйтиToolStripMenuItem
			// 
			this.выйтиToolStripMenuItem.Name = "выйтиToolStripMenuItem";
			this.выйтиToolStripMenuItem.Size = new System.Drawing.Size(54, 20);
			this.выйтиToolStripMenuItem.Text = "Выйти";
			this.выйтиToolStripMenuItem.Click += new System.EventHandler(this.выйтиToolStripMenuItem_Click);
			// 
			// справкаToolStripMenuItem
			// 
			this.справкаToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.сведенияОПрограммеToolStripMenuItem});
			this.справкаToolStripMenuItem.Name = "справкаToolStripMenuItem";
			this.справкаToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
			this.справкаToolStripMenuItem.Text = "Справка";
			// 
			// сведенияОПрограммеToolStripMenuItem
			// 
			this.сведенияОПрограммеToolStripMenuItem.Name = "сведенияОПрограммеToolStripMenuItem";
			this.сведенияОПрограммеToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
			this.сведенияОПрограммеToolStripMenuItem.Text = "Сведения о программе";
			this.сведенияОПрограммеToolStripMenuItem.Click += new System.EventHandler(this.сведенияОПрограммеToolStripMenuItem_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
			this.label1.Location = new System.Drawing.Point(14, 19);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(87, 24);
			this.label1.TabIndex = 1;
			this.label1.Text = "Привет, ";
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(15, 95);
			this.textBox1.Name = "textBox1";
			this.textBox1.PasswordChar = '*';
			this.textBox1.Size = new System.Drawing.Size(165, 20);
			this.textBox1.TabIndex = 2;
			// 
			// textBox2
			// 
			this.textBox2.Location = new System.Drawing.Point(15, 143);
			this.textBox2.Name = "textBox2";
			this.textBox2.PasswordChar = '*';
			this.textBox2.Size = new System.Drawing.Size(165, 20);
			this.textBox2.TabIndex = 3;
			// 
			// textBox3
			// 
			this.textBox3.Location = new System.Drawing.Point(15, 192);
			this.textBox3.Name = "textBox3";
			this.textBox3.PasswordChar = '*';
			this.textBox3.Size = new System.Drawing.Size(165, 20);
			this.textBox3.TabIndex = 4;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(15, 76);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(84, 13);
			this.label2.TabIndex = 5;
			this.label2.Text = "Старый пароль";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(15, 127);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(80, 13);
			this.label3.TabIndex = 6;
			this.label3.Text = "Новый пароль";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(15, 176);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(121, 13);
			this.label4.TabIndex = 7;
			this.label4.Text = "Повтор нового пароля";
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(15, 229);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(165, 23);
			this.button1.TabIndex = 8;
			this.button1.Text = "Сменить пароль";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// panel1
			// 
			this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel1.Controls.Add(this.label5);
			this.panel1.Controls.Add(this.textBox1);
			this.panel1.Controls.Add(this.label1);
			this.panel1.Controls.Add(this.button1);
			this.panel1.Controls.Add(this.label4);
			this.panel1.Controls.Add(this.textBox2);
			this.panel1.Controls.Add(this.label3);
			this.panel1.Controls.Add(this.textBox3);
			this.panel1.Controls.Add(this.label2);
			this.panel1.Location = new System.Drawing.Point(12, 27);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(201, 275);
			this.panel1.TabIndex = 9;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(15, 54);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(41, 13);
			this.label5.TabIndex = 9;
			this.label5.Text = "Статус";
			// 
			// dataGridView1
			// 
			this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView1.Location = new System.Drawing.Point(10, 3);
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.Size = new System.Drawing.Size(549, 275);
			this.dataGridView1.TabIndex = 10;
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(169, 289);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(151, 23);
			this.button2.TabIndex = 11;
			this.button2.Text = "Добавить пользователя";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(414, 287);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(145, 23);
			this.button3.TabIndex = 12;
			this.button3.Text = "Удалить пользователя";
			this.button3.UseVisualStyleBackColor = true;
			this.button3.Click += new System.EventHandler(this.button3_Click);
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.checkBox1);
			this.panel2.Controls.Add(this.textBox4);
			this.panel2.Controls.Add(this.dataGridView1);
			this.panel2.Controls.Add(this.button2);
			this.panel2.Controls.Add(this.button3);
			this.panel2.Location = new System.Drawing.Point(304, 27);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(562, 345);
			this.panel2.TabIndex = 13;
			// 
			// textBox4
			// 
			this.textBox4.Location = new System.Drawing.Point(10, 290);
			this.textBox4.Name = "textBox4";
			this.textBox4.Size = new System.Drawing.Size(153, 20);
			this.textBox4.TabIndex = 13;
			// 
			// checkBox1
			// 
			this.checkBox1.AutoSize = true;
			this.checkBox1.Location = new System.Drawing.Point(10, 318);
			this.checkBox1.Name = "checkBox1";
			this.checkBox1.Size = new System.Drawing.Size(202, 17);
			this.checkBox1.TabIndex = 14;
			this.checkBox1.Text = "Проверка пароля на соответствие";
			this.checkBox1.UseVisualStyleBackColor = true;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(887, 450);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.menuStrip1);
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "MainForm";
			this.Text = "Form1";
			this.Load += new System.EventHandler(this.MainForm_Load);
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
			this.panel2.ResumeLayout(false);
			this.panel2.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem выйтиToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem справкаToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem сведенияОПрограммеToolStripMenuItem;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.TextBox textBox2;
		private System.Windows.Forms.TextBox textBox3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.DataGridView dataGridView1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.TextBox textBox4;
		private System.Windows.Forms.CheckBox checkBox1;
	}
}

