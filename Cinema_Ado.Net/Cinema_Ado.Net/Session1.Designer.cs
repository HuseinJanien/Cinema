namespace Cinema_Ado.Net
{
    partial class Session1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
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
        private void InitializeComponent()
        {
            this.add_SessionBtn = new System.Windows.Forms.Button();
            this.del_SessionBtn = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.Hall = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.listBox3 = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // add_SessionBtn
            // 
            this.add_SessionBtn.Location = new System.Drawing.Point(6, 223);
            this.add_SessionBtn.Name = "add_SessionBtn";
            this.add_SessionBtn.Size = new System.Drawing.Size(100, 23);
            this.add_SessionBtn.TabIndex = 0;
            this.add_SessionBtn.Text = "Add Session";
            this.add_SessionBtn.UseVisualStyleBackColor = true;
            this.add_SessionBtn.Click += new System.EventHandler(this.button1_Click);
            // 
            // del_SessionBtn
            // 
            this.del_SessionBtn.Location = new System.Drawing.Point(340, 223);
            this.del_SessionBtn.Name = "del_SessionBtn";
            this.del_SessionBtn.Size = new System.Drawing.Size(100, 23);
            this.del_SessionBtn.TabIndex = 1;
            this.del_SessionBtn.Text = "Delete Session";
            this.del_SessionBtn.UseVisualStyleBackColor = true;
            this.del_SessionBtn.Click += new System.EventHandler(this.del_SessionBtn_Click);
            // 
            // Hall
            // 
            this.Hall.AutoSize = true;
            this.Hall.Location = new System.Drawing.Point(24, 32);
            this.Hall.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Hall.Name = "Hall";
            this.Hall.Size = new System.Drawing.Size(28, 13);
            this.Hall.TabIndex = 6;
            this.Hall.Text = "Hall:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(188, 32);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Date/Time:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(362, 32);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(28, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Film:";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(190, 58);
            this.textBox2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(52, 20);
            this.textBox2.TabIndex = 4;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(26, 58);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(62, 21);
            this.comboBox1.TabIndex = 10;
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(364, 58);
            this.comboBox2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(62, 21);
            this.comboBox2.TabIndex = 11;
            // 
            // listBox3
            // 
            this.listBox3.FormattingEnabled = true;
            this.listBox3.Location = new System.Drawing.Point(6, 97);
            this.listBox3.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.listBox3.Name = "listBox3";
            this.listBox3.Size = new System.Drawing.Size(454, 121);
            this.listBox3.TabIndex = 12;
            // 
            // Session1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(468, 265);
            this.Controls.Add(this.listBox3);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Hall);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.del_SessionBtn);
            this.Controls.Add(this.add_SessionBtn);
            this.Name = "Session1";
            this.Text = "Session";
            this.Load += new System.EventHandler(this.Session1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button add_SessionBtn;
        private System.Windows.Forms.Button del_SessionBtn;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Label Hall;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.ListBox listBox3;
    }
}