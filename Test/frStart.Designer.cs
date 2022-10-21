namespace Test
{
    partial class frStart
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
			this.treeView1 = new System.Windows.Forms.TreeView();
			this.comboBox1 = new System.Windows.Forms.ComboBox();
			this.cbHost = new System.Windows.Forms.ComboBox();
			this.tbPassword = new System.Windows.Forms.TextBox();
			this.tbUser = new System.Windows.Forms.TextBox();
			this.btConnect = new System.Windows.Forms.Button();
			this.cbDataBase = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.btDisConnect = new System.Windows.Forms.Button();
			this.lbState = new System.Windows.Forms.Label();
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
			this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
			this.btnFunc_list = new System.Windows.Forms.Button();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.listBox1 = new System.Windows.Forms.ListBox();
			this.txtPort = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.statusStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// treeView1
			// 
			this.treeView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.treeView1.Location = new System.Drawing.Point(12, 102);
			this.treeView1.Name = "treeView1";
			this.treeView1.Size = new System.Drawing.Size(855, 291);
			this.treeView1.TabIndex = 0;
			this.treeView1.TabStop = false;
			this.treeView1.BeforeSelect += new System.Windows.Forms.TreeViewCancelEventHandler(this.treeView1_BeforeSelect);
			// 
			// comboBox1
			// 
			this.comboBox1.FormattingEnabled = true;
			this.comboBox1.Location = new System.Drawing.Point(12, 75);
			this.comboBox1.Name = "comboBox1";
			this.comboBox1.Size = new System.Drawing.Size(120, 21);
			this.comboBox1.TabIndex = 6;
			this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
			// 
			// cbHost
			// 
			this.cbHost.FormattingEnabled = true;
			this.cbHost.Items.AddRange(new object[] {
            "localhost",
            "bag.metrosg.ru",
            "sur-astm01.ogk.energo.local",
            "uchet.asuscomm.com"});
			this.cbHost.Location = new System.Drawing.Point(11, 25);
			this.cbHost.Name = "cbHost";
			this.cbHost.Size = new System.Drawing.Size(214, 21);
			this.cbHost.TabIndex = 1;
			// 
			// tbPassword
			// 
			this.tbPassword.Location = new System.Drawing.Point(588, 25);
			this.tbPassword.Name = "tbPassword";
			this.tbPassword.PasswordChar = '*';
			this.tbPassword.Size = new System.Drawing.Size(123, 20);
			this.tbPassword.TabIndex = 4;
			// 
			// tbUser
			// 
			this.tbUser.Location = new System.Drawing.Point(464, 25);
			this.tbUser.Name = "tbUser";
			this.tbUser.Size = new System.Drawing.Size(123, 20);
			this.tbUser.TabIndex = 3;
			this.tbUser.Text = "IvanovDU";
			// 
			// btConnect
			// 
			this.btConnect.Location = new System.Drawing.Point(723, 24);
			this.btConnect.Name = "btConnect";
			this.btConnect.Size = new System.Drawing.Size(77, 23);
			this.btConnect.TabIndex = 5;
			this.btConnect.Text = "Подключить";
			this.btConnect.UseVisualStyleBackColor = true;
			this.btConnect.Click += new System.EventHandler(this.btConnect_Click);
			// 
			// cbDataBase
			// 
			this.cbDataBase.FormattingEnabled = true;
			this.cbDataBase.Items.AddRange(new object[] {
            "Uchet"});
			this.cbDataBase.Location = new System.Drawing.Point(336, 25);
			this.cbDataBase.Name = "cbDataBase";
			this.cbDataBase.Size = new System.Drawing.Size(121, 21);
			this.cbDataBase.TabIndex = 2;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(13, 5);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(47, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Сервер:";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(333, 5);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(75, 13);
			this.label2.TabIndex = 0;
			this.label2.Text = "База данных:";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(464, 5);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(83, 13);
			this.label3.TabIndex = 0;
			this.label3.Text = "Пользователь:";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(590, 5);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(48, 13);
			this.label4.TabIndex = 0;
			this.label4.Text = "Пароль:";
			// 
			// btDisConnect
			// 
			this.btDisConnect.Location = new System.Drawing.Point(723, 53);
			this.btDisConnect.Name = "btDisConnect";
			this.btDisConnect.Size = new System.Drawing.Size(77, 23);
			this.btDisConnect.TabIndex = 7;
			this.btDisConnect.Text = "Отключить";
			this.btDisConnect.UseVisualStyleBackColor = true;
			this.btDisConnect.Click += new System.EventHandler(this.btDisConnect_Click);
			// 
			// lbState
			// 
			this.lbState.AutoSize = true;
			this.lbState.Location = new System.Drawing.Point(492, 55);
			this.lbState.Name = "lbState";
			this.lbState.Size = new System.Drawing.Size(71, 13);
			this.lbState.TabIndex = 8;
			this.lbState.Text = "Статус: none";
			// 
			// statusStrip1
			// 
			this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel2});
			this.statusStrip1.Location = new System.Drawing.Point(0, 702);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Size = new System.Drawing.Size(882, 22);
			this.statusStrip1.TabIndex = 9;
			this.statusStrip1.Text = "statusStrip1";
			// 
			// toolStripStatusLabel1
			// 
			this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
			this.toolStripStatusLabel1.Size = new System.Drawing.Size(87, 17);
			this.toolStripStatusLabel1.Text = "Пользователь:";
			// 
			// toolStripStatusLabel2
			// 
			this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
			this.toolStripStatusLabel2.Size = new System.Drawing.Size(25, 17);
			this.toolStripStatusLabel2.Text = "нет";
			// 
			// btnFunc_list
			// 
			this.btnFunc_list.Location = new System.Drawing.Point(495, 75);
			this.btnFunc_list.Name = "btnFunc_list";
			this.btnFunc_list.Size = new System.Drawing.Size(117, 23);
			this.btnFunc_list.TabIndex = 10;
			this.btnFunc_list.Text = "Список функций";
			this.btnFunc_list.UseVisualStyleBackColor = true;
			this.btnFunc_list.Click += new System.EventHandler(this.btnFunc_list_Click);
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(139, 75);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(279, 20);
			this.textBox1.TabIndex = 11;
			// 
			// listBox1
			// 
			this.listBox1.FormattingEnabled = true;
			this.listBox1.Location = new System.Drawing.Point(11, 409);
			this.listBox1.Name = "listBox1";
			this.listBox1.Size = new System.Drawing.Size(682, 277);
			this.listBox1.TabIndex = 12;
			// 
			// txtPort
			// 
			this.txtPort.Location = new System.Drawing.Point(226, 25);
			this.txtPort.Name = "txtPort";
			this.txtPort.Size = new System.Drawing.Size(108, 20);
			this.txtPort.TabIndex = 13;
			this.txtPort.Text = "5999";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(223, 5);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(35, 13);
			this.label5.TabIndex = 14;
			this.label5.Text = "Порт:";
			this.label5.Click += new System.EventHandler(this.label5_Click);
			// 
			// frStart
			// 
			this.AcceptButton = this.btConnect;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(882, 724);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.txtPort);
			this.Controls.Add(this.listBox1);
			this.Controls.Add(this.textBox1);
			this.Controls.Add(this.btnFunc_list);
			this.Controls.Add(this.statusStrip1);
			this.Controls.Add(this.lbState);
			this.Controls.Add(this.btDisConnect);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.cbDataBase);
			this.Controls.Add(this.btConnect);
			this.Controls.Add(this.tbUser);
			this.Controls.Add(this.tbPassword);
			this.Controls.Add(this.cbHost);
			this.Controls.Add(this.comboBox1);
			this.Controls.Add(this.treeView1);
			this.Name = "frStart";
			this.Text = "Form1";
			this.statusStrip1.ResumeLayout(false);
			this.statusStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ComboBox cbHost;
        private System.Windows.Forms.TextBox tbPassword;
        private System.Windows.Forms.TextBox tbUser;
        private System.Windows.Forms.Button btConnect;
        private System.Windows.Forms.ComboBox cbDataBase;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btDisConnect;
        private System.Windows.Forms.Label lbState;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.Button btnFunc_list;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.Label label5;
    }
}

