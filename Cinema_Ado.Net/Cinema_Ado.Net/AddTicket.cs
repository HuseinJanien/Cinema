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
    public partial class AddTicket : Form
    {
        DataManager DataManager;
        public AddTicket(DataManager DataManager)
        {
            this.DataManager = DataManager;
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var t = Task.Run(async () => {
                try
                {

                    if (comboBox1.SelectedItem == null || comboBox2.SelectedItem == null)
                    {
                        throw new Exception();
                    }
                    await DataManager.AddTicketsAsync(new Tickets()
                    {
                        PlaceId = DataManager.GetPlace(comboBox2.Text),
                        SessionId = int.Parse(comboBox1.Text),
                        DateTime = DateTime.Parse(dateTimePicker2.Value.Date.ToString("yyyy.MM.dd"))
                    }); 

                    this.DialogResult = DialogResult.OK;
                }
                catch (Exception er)
                {
                    MessageBox.Show(er.Message, "Eror", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            });
        }

        private void AddTicket_Load(object sender, EventArgs e)
        {

            comboBox1.Items.Clear();
            comboBox2.Items.Clear();
            foreach (var el in DataManager.sessions)
            {
                comboBox1.Items.Add(el.Id);
            }
            foreach (var el in DataManager.places)
            {
                comboBox2.Items.Add(el.Name);
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
    }
}
