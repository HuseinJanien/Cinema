using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cinema_Ado.Net
{
    public partial class Form1 : Form
    {
        private DataManager dataManager;
        public Form1()
        {
            this.dataManager = new DataManager();
            InitializeComponent();
           
        }

        string? GetCatId(int id)
        {
            return comboBox1?.Items[id]?.ToString();
            return null;
        }

        string? GetAgeId(int id)
        {
            return comboBox2?.Items[id ]?.ToString();
            return null;
        }
        private void Init()
        {


            listView1.Items.Clear();
            comboBox1.Items.Clear();
            comboBox2.Items.Clear();
            comboBox1.Items.Add("All");
            comboBox2.Items.Add("All");
            foreach (var el in dataManager.categories)
            {
                comboBox1.Items.Add(el.Name);
            }
            foreach (var el in dataManager.ages)
            {
                comboBox2.Items.Add(el.Age);
            }
            foreach (var el in dataManager.films)
            {
                var item = listView1.Items.Add(el.Id.ToString());
                item.SubItems.Add(el.Name.ToString());
                item.SubItems.Add(GetCatId(el.CategoryId).ToString());
                item.SubItems.Add(GetAgeId(el.AgeId).ToString());

            }
            if (comboBox1.Items.Count > 0)
            {
                comboBox1.SelectedIndex = 0;
            }
            if (comboBox2.Items.Count > 0)
            {
                comboBox2.SelectedIndex = 0;
            }

        }
        private void button1_Click(object sender, EventArgs e)
        {
            Films1 form3 = new Films1(dataManager);
            if (DialogResult.OK == form3.ShowDialog())
            {
                Init();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Init();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int selected = int.Parse(listView1.FocusedItem.SubItems[0].Text);
            dataManager.DeleteFilm(selected);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            CategoryAdd form3 = new CategoryAdd(dataManager);
            if (DialogResult.OK == form3.ShowDialog())
            {
                Init();
            }
        }
    }
}
