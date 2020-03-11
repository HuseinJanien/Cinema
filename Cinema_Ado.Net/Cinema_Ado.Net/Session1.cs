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
        DataManager dm;

        public Session1(DataManager dataManager)
        {
            dm = dataManager;
            InitializeComponent();
            LoadHall();
            LoadFilm();
            LoadSessions();
        }

        public void LoadSessions()
        {
            listView1.Items.Clear();
            foreach (var session in dm.sessions)
            {
                var el=listView1.Items.Add(session.Id.ToString());
                el.SubItems.Add(dm.GetHall( session.HallId));
                el.SubItems.Add(dm.GetFilm( session.FilmId));
                el.SubItems.Add(session.DateTime.ToString());
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dm.AddSession(new Session()
            {
                HallId = dm.GetHall(comboBox1.Text),
                DateTime = Convert.ToDateTime(textBox2.Text),
                FilmId = dm.GetFilm(comboBox2.Text)
            }); ;
            LoadSessions();
        }

        private void del_SessionBtn_Click(object sender, EventArgs e)
        {
            dm.DelSessionAsync(int.Parse(listView1.FocusedItem.SubItems[0].Text)); 
            LoadSessions();
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


        private void button1_Click_1(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void Session1_Load(object sender, EventArgs e)
        {

        }
    }
}
