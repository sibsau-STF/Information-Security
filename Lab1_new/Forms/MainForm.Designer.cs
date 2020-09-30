namespace Lab_1
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.userDataGridView = new System.Windows.Forms.DataGridView();
            this.idCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.userCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.passCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.constCol = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.lockCol = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.changePassStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.addUserStripButton = new System.Windows.Forms.ToolStripButton();
            this.lockStripButton = new System.Windows.Forms.ToolStripButton();
            this.constStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.infoStripButton = new System.Windows.Forms.ToolStripDropDownButton();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.userDataGridView)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // userDataGridView
            // 
            this.userDataGridView.AllowUserToAddRows = false;
            this.userDataGridView.AllowUserToDeleteRows = false;
            this.userDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.userDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idCol,
            this.userCol,
            this.passCol,
            this.constCol,
            this.lockCol});
            this.userDataGridView.Location = new System.Drawing.Point(29, 48);
            this.userDataGridView.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.userDataGridView.MultiSelect = false;
            this.userDataGridView.Name = "userDataGridView";
            this.userDataGridView.RowHeadersVisible = false;
            this.userDataGridView.RowTemplate.Height = 24;
            this.userDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.userDataGridView.Size = new System.Drawing.Size(804, 366);
            this.userDataGridView.TabIndex = 0;
            // 
            // idCol
            // 
            this.idCol.HeaderText = "ID";
            this.idCol.Name = "idCol";
            this.idCol.ReadOnly = true;
            this.idCol.Width = 50;
            // 
            // userCol
            // 
            this.userCol.HeaderText = "Логин";
            this.userCol.Name = "userCol";
            this.userCol.ReadOnly = true;
            this.userCol.Width = 150;
            // 
            // passCol
            // 
            this.passCol.HeaderText = "Пароль";
            this.passCol.Name = "passCol";
            this.passCol.ReadOnly = true;
            this.passCol.Width = 150;
            // 
            // constCol
            // 
            this.constCol.HeaderText = "Ограничение";
            this.constCol.Name = "constCol";
            this.constCol.ReadOnly = true;
            this.constCol.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.constCol.Width = 150;
            // 
            // lockCol
            // 
            this.lockCol.HeaderText = "Заблокировано";
            this.lockCol.Name = "lockCol";
            this.lockCol.ReadOnly = true;
            this.lockCol.Width = 150;
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.changePassStripButton,
            this.toolStripSeparator1,
            this.addUserStripButton,
            this.lockStripButton,
            this.constStripButton,
            this.toolStripSeparator2,
            this.infoStripButton});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(865, 27);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // changePassStripButton
            // 
            this.changePassStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.changePassStripButton.Image = ((System.Drawing.Image)(resources.GetObject("changePassStripButton.Image")));
            this.changePassStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.changePassStripButton.Name = "changePassStripButton";
            this.changePassStripButton.Size = new System.Drawing.Size(137, 24);
            this.changePassStripButton.Text = "Изменить пароль";
            this.changePassStripButton.Click += new System.EventHandler(this.changePassStripButton_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 27);
            // 
            // addUserStripButton
            // 
            this.addUserStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.addUserStripButton.Image = ((System.Drawing.Image)(resources.GetObject("addUserStripButton.Image")));
            this.addUserStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.addUserStripButton.Name = "addUserStripButton";
            this.addUserStripButton.Size = new System.Drawing.Size(193, 24);
            this.addUserStripButton.Text = "Добавить учётную запись";
            this.addUserStripButton.Click += new System.EventHandler(this.addUserStripButton_Click);
            // 
            // lockStripButton
            // 
            this.lockStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.lockStripButton.Image = ((System.Drawing.Image)(resources.GetObject("lockStripButton.Image")));
            this.lockStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.lockStripButton.Name = "lockStripButton";
            this.lockStripButton.Size = new System.Drawing.Size(238, 24);
            this.lockStripButton.Text = "Заблокировать/Разблокировать";
            this.lockStripButton.Click += new System.EventHandler(this.lockStripButton_Click);
            // 
            // constStripButton
            // 
            this.constStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.constStripButton.Image = ((System.Drawing.Image)(resources.GetObject("constStripButton.Image")));
            this.constStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.constStripButton.Name = "constStripButton";
            this.constStripButton.Size = new System.Drawing.Size(162, 24);
            this.constStripButton.Text = "Ограничение пароля";
            this.constStripButton.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 27);
            // 
            // infoStripButton
            // 
            this.infoStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.infoStripButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.infoStripButton.Image = ((System.Drawing.Image)(resources.GetObject("infoStripButton.Image")));
            this.infoStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.infoStripButton.Name = "infoStripButton";
            this.infoStripButton.Size = new System.Drawing.Size(81, 24);
            this.infoStripButton.Text = "Справка";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(216, 26);
            this.aboutToolStripMenuItem.Text = "О программе";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(865, 542);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.userDataGridView);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.userDataGridView)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton changePassStripButton;
        private System.Windows.Forms.ToolStripButton addUserStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton lockStripButton;
        private System.Windows.Forms.ToolStripButton constStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripDropDownButton infoStripButton;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.DataGridView userDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn idCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn userCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn passCol;
        private System.Windows.Forms.DataGridViewCheckBoxColumn constCol;
        private System.Windows.Forms.DataGridViewCheckBoxColumn lockCol;
    }
}

