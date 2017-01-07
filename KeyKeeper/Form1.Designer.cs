namespace KeyKeeper
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.WorkDate = new System.Windows.Forms.DateTimePicker();
            this.button1 = new System.Windows.Forms.Button();
            this.GMailPass = new System.Windows.Forms.MaskedTextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.GMailLogin = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.ClientSecret = new System.Windows.Forms.MaskedTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.ClientID = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.LicenceType = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.USBBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(1, -1);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(427, 328);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.WorkDate);
            this.tabPage1.Controls.Add(this.button1);
            this.tabPage1.Controls.Add(this.GMailPass);
            this.tabPage1.Controls.Add(this.label9);
            this.tabPage1.Controls.Add(this.GMailLogin);
            this.tabPage1.Controls.Add(this.label8);
            this.tabPage1.Controls.Add(this.ClientSecret);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.ClientID);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.LicenceType);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.USBBox);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(419, 302);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Создание ключа";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // WorkDate
            // 
            this.WorkDate.Location = new System.Drawing.Point(98, 96);
            this.WorkDate.Name = "WorkDate";
            this.WorkDate.Size = new System.Drawing.Size(164, 20);
            this.WorkDate.TabIndex = 16;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(298, 240);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(84, 46);
            this.button1.TabIndex = 15;
            this.button1.Text = "СОЗДАТЬ";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // GMailPass
            // 
            this.GMailPass.Location = new System.Drawing.Point(98, 266);
            this.GMailPass.Name = "GMailPass";
            this.GMailPass.PasswordChar = '*';
            this.GMailPass.PromptChar = '-';
            this.GMailPass.Size = new System.Drawing.Size(194, 20);
            this.GMailPass.TabIndex = 13;
            this.GMailPass.UseSystemPasswordChar = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(13, 266);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(82, 13);
            this.label9.TabIndex = 14;
            this.label9.Text = "Gmail Password";
            // 
            // GMailLogin
            // 
            this.GMailLogin.Location = new System.Drawing.Point(98, 240);
            this.GMailLogin.Name = "GMailLogin";
            this.GMailLogin.Size = new System.Drawing.Size(194, 20);
            this.GMailLogin.TabIndex = 11;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(13, 243);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(62, 13);
            this.label8.TabIndex = 12;
            this.label8.Text = "Gmail Login";
            // 
            // ClientSecret
            // 
            this.ClientSecret.Location = new System.Drawing.Point(98, 214);
            this.ClientSecret.Name = "ClientSecret";
            this.ClientSecret.PasswordChar = '*';
            this.ClientSecret.PromptChar = '-';
            this.ClientSecret.Size = new System.Drawing.Size(284, 20);
            this.ClientSecret.TabIndex = 5;
            this.ClientSecret.UseSystemPasswordChar = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(13, 214);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(67, 13);
            this.label7.TabIndex = 10;
            this.label7.Text = "Client Secret";
            // 
            // ClientID
            // 
            this.ClientID.Location = new System.Drawing.Point(98, 185);
            this.ClientID.Name = "ClientID";
            this.ClientID.Size = new System.Drawing.Size(284, 20);
            this.ClientID.TabIndex = 4;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(13, 188);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "Client ID";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 154);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(90, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Профиль Google";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 99);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Срок действия";
            // 
            // LicenceType
            // 
            this.LicenceType.FormattingEnabled = true;
            this.LicenceType.Items.AddRange(new object[] {
            "Professional",
            "Обычная"});
            this.LicenceType.Location = new System.Drawing.Point(98, 69);
            this.LicenceType.Name = "LicenceType";
            this.LicenceType.Size = new System.Drawing.Size(121, 21);
            this.LicenceType.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Версия";
            // 
            // USBBox
            // 
            this.USBBox.FormattingEnabled = true;
            this.USBBox.Location = new System.Drawing.Point(98, 42);
            this.USBBox.Name = "USBBox";
            this.USBBox.Size = new System.Drawing.Size(284, 21);
            this.USBBox.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "USB Flash";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Информация о ключе";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.richTextBox1);
            this.tabPage2.Controls.Add(this.button2);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(419, 302);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Проверка ключа";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(8, 37);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(405, 256);
            this.richTextBox1.TabIndex = 1;
            this.richTextBox1.Text = "";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(8, 7);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(183, 23);
            this.button2.TabIndex = 0;
            this.button2.Text = "Открыть ключ";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(433, 326);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form1";
            this.Text = "Key Keeper";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TextBox ClientID;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox LicenceType;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox USBBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MaskedTextBox GMailPass;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox GMailLogin;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.MaskedTextBox ClientSecret;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DateTimePicker WorkDate;
    }
}

