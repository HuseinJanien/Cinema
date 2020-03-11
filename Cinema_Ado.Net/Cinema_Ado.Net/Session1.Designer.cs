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
            this.change_SessionBtn = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // add_SessionBtn
            // 
            this.add_SessionBtn.Location = new System.Drawing.Point(12, 302);
            this.add_SessionBtn.Name = "add_SessionBtn";
            this.add_SessionBtn.Size = new System.Drawing.Size(100, 23);
            this.add_SessionBtn.TabIndex = 0;
            this.add_SessionBtn.Text = "Add Session";
            this.add_SessionBtn.UseVisualStyleBackColor = true;
            this.add_SessionBtn.Click += new System.EventHandler(this.button1_Click);
            // 
            // del_SessionBtn
            // 
            this.del_SessionBtn.Location = new System.Drawing.Point(181, 302);
            this.del_SessionBtn.Name = "del_SessionBtn";
            this.del_SessionBtn.Size = new System.Drawing.Size(100, 23);
            this.del_SessionBtn.TabIndex = 1;
            this.del_SessionBtn.Text = "Delete Session";
            this.del_SessionBtn.UseVisualStyleBackColor = true;
            this.del_SessionBtn.Click += new System.EventHandler(this.del_SessionBtn_Click);
            // 
            // change_SessionBtn
            // 
            this.change_SessionBtn.Location = new System.Drawing.Point(356, 302);
            this.change_SessionBtn.Name = "change_SessionBtn";
            this.change_SessionBtn.Size = new System.Drawing.Size(100, 23);
            this.change_SessionBtn.TabIndex = 2;
            this.change_SessionBtn.Text = "Change Session";
            this.change_SessionBtn.UseVisualStyleBackColor = true;
            this.change_SessionBtn.Click += new System.EventHandler(this.change_SessionBtn_Click);
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.listView1.Location = new System.Drawing.Point(12, 84);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(444, 212);
            this.listView1.TabIndex = 3;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Hall:";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Date/Time";
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Film:";
            this.columnHeader3.Width = 133;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(12, 42);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 4;
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(171, 42);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(121, 21);
            this.comboBox2.TabIndex = 5;
            // 
            // comboBox3
            // 
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Location = new System.Drawing.Point(319, 42);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(121, 21);
            this.comboBox3.TabIndex = 6;
            // 
            // Session1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(468, 337);
            this.Controls.Add(this.comboBox3);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.change_SessionBtn);
            this.Controls.Add(this.del_SessionBtn);
            this.Controls.Add(this.add_SessionBtn);
            this.Name = "Session1";
            this.Text = "Session";
            this.Load += new System.EventHandler(this.Session1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button add_SessionBtn;
        private System.Windows.Forms.Button del_SessionBtn;
        private System.Windows.Forms.Button change_SessionBtn;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.ComboBox comboBox3;
    }
}