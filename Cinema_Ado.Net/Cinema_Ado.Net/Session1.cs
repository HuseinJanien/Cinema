using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Cinema_Ado.Net.Models;

namespace Cinema_Ado.Net
{
    public partial class Session1 : Form
    {
        DataManager dm = new DataManager();

        public Session1()
        {
            InitializeComponent();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //add
            //dialogres..
            

        }

        private void del_SessionBtn_Click(object sender, EventArgs e)
        {

        }

        private void change_SessionBtn_Click(object sender, EventArgs e)
        { }

        private void LoadSessions()
        {
            listView1.Items.Clear();
            
        }
        private void LoadHall()
        {

            var halls = dm.halls.ToList();
            comboBox1.Items.Clear();
            foreach(var hall in halls)
            {
                comboBox1.Items.Add(hall);
            }
            comboBox1.DisplayMember = "Name";
        }
        private void LoadDate()
        {

            //var halls = dm.halls.ToList();
            //comboBox1.Items.Clear();
            //foreach (var hall in halls)
            //{
            //    comboBox1.Items.Add(hall);
            //}
            //comboBox1.DisplayMember = "Name";
        }
        private void LoadFilm()
        {
            var films = dm.halls.ToList();
            comboBox3.Items.Clear();
            foreach (var film in films)
            {
                comboBox3.Items.Add(film);
            }
            comboBox3.DisplayMember = "Name";
        }

        private void Session1_Load(object sender, EventArgs e)
        {
            LoadSessions();
        }
    }
}
