using Cinema_Ado.Net.Models;
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
    public partial class PlaceManager : Form
    {
        DataManager dm;
        public PlaceManager(DataManager dm)
        {
            this.dm = dm;
            InitializeComponent();
        }

        private void PlaceManager_Load(object sender, EventArgs e)
        {

            listView1.Items.Clear();
            foreach (var el in dm.places)
            {
                var el2 = listView1.Items.Add(el.Id.ToString());
                el2.SubItems.Add(el.Name);
                el2.SubItems.Add(el.Row.ToString());
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AddPlace form3 = new AddPlace(dm);
            if (DialogResult.OK == form3.ShowDialog())
            {
                PlaceManager_Load(sender,e);
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                int selected = int.Parse(listView1.FocusedItem.SubItems[0].Text);
                dm.DeletePlace(selected);
                PlaceManager_Load(sender, e);
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message,"Ошыбка удаления!");
            }
        }
    }
}
