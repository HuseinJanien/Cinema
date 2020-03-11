using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using Cinema_Ado.Net;
using System.Threading.Tasks;
using System.Threading;
using System.IO;
using System.Diagnostics;

namespace LoginApp
{
    public partial class frmLogin : Form
    {
        DataManager dataManager;
        bool visible = false;
        public frmLogin()
        {
            InitializeComponent();
            dataManager = new DataManager();
        }

        private void   btnLogin_ClickAsync(object sender, EventArgs e)
        {
            Task.Run(async () =>
            {
                if (await dataManager.LoginAsync(txtUsername.Text.Trim(), txtPassword.Text.Trim()))
                {
                    this.Visible = false;
                    Application.Run( new Form1(dataManager));
                    Application.Exit();
                }
                else
                {
                    MessageBox.Show("Check your username and password");
                    txtPassword.Text = "";
                    txtUsername.Text = "";
                }
            });

            
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {   
            button1.BackgroundImage =  Image.FromFile(Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName) + @"\Image\" + "eye1.jpg");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (visible)
            {
                button1.BackgroundImage = Image.FromFile(Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName) + @"\Image\" + "eye1.jpg");
                visible = false;
                txtPassword.PasswordChar = '*';
  
            }     
            else
            {
                button1.BackgroundImage = Image.FromFile(Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName) + @"\Image\" + "eye1.png");
                visible = true;
                txtPassword.PasswordChar = new char();
            }
        }
    }
}
