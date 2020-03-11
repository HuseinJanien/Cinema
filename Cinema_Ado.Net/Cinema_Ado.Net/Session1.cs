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
            LoadHall();
            LoadFilm();
            LoadSessions();
        }
        public void LoadSessions()
        {
            listBox3.Items.Clear();
            foreach (var session in dm.sessions)
            {
                listBox3.Items.Add(session.DateTime);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dm.AddSession(new Cinema_Ado.Net.Models.Session()
            {
                HallId = comboBox1.SelectedIndex + 1,
                DateTime = Convert.ToDateTime(textBox2.Text),
                FilmId = comboBox2.SelectedIndex + 1
            });
            this.DialogResult = DialogResult.OK;
            LoadSessions();

            ////int hallId = Convert.ToInt32(comboBox1.SelectedItem.ToString());
            //int hallId = Convert.ToInt32(comboBox1.SelectedItem.ToString());
            //DateTime datetime = Convert.ToDateTime(textBox2.Text);
            //int film = Convert.ToInt32(comboBox2.SelectedItem.ToString());
            //Session s = new Session(hallId, datetime, film);
            //dm.AddSession(s);
        }

        private void del_SessionBtn_Click(object sender, EventArgs e)
        {
            
        }
        
        private void LoadHall()
        {

            var halls = dm.halls.ToList();
            comboBox1.Items.Clear();
            foreach(var hall in halls)
            {
                comboBox1.Items.Add(hall.Name);
            }
        }
        private void LoadFilm()
        {
            var films = dm.films.ToList();
            comboBox2.Items.Clear();
            foreach (var film in films)
            {
                comboBox2.Items.Add(film.Name);
            }
        }

        private void Session1_Load(object sender, EventArgs e)
        {
            
        }
    }
}
