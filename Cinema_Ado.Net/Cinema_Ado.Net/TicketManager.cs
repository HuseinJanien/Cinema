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
    public partial class TicketManager : Form
    {
        DataManager DataManager;
        public TicketManager(DataManager DataManager)
        {
            this.DataManager = DataManager;
            InitializeComponent();
        }
        public string GetPlace(int name)
        {
            foreach (var dr in DataManager.places)
            {
                if (dr.Id == name)
                {
                    return dr.Name+'/'+ dr.Row.ToString();
                }
            }
            return "null";

        }

        private void TicketManager_Load(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            foreach (var el in DataManager.tickets)
            {
                var el2 = listView1.Items.Add(el.Id.ToString());
                el2.SubItems.Add(el.DateTime.ToString());
                el2.SubItems.Add(el.SessionId.ToString());
                el2.SubItems.Add(GetPlace(el.PlaceId));
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int selected = int.Parse(listView1.FocusedItem.SubItems[0].Text);
                DataManager.DeleteTicket(selected);
                TicketManager_Load(sender, e);
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message, "Ошыбка удаления!");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AddTicket form3 = new AddTicket(DataManager);
            if (DialogResult.OK == form3.ShowDialog())
            {
                TicketManager_Load(sender, e);
            }
        }
    }
}
