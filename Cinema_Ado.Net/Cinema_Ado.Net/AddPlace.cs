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
    public partial class AddPlace : Form
    {
        DataManager dm;
        public AddPlace(DataManager dm)
        {
            this.dm = dm;
            InitializeComponent();
        }
        IEnumerable<Places> queryable2()
        {
            foreach (var dr in dm.places)
            {
                if (dr.Name.Contains(textBox1.Text))
                {
                    yield return dr;
                }
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            var t = Task.Run(async () => {
                try
                {
                    if (textBox1.Text.Length == 0)
                    {
                        throw new Exception();
                    }
                    if (queryable2().ToArray().Length > 0)
                    {
                        throw new Exception();
                    }
                    await dm.AddPlaceAsync(new Places()
                    {
                        Name = textBox1.Text,
                        Row = int.Parse(numericUpDown1.Value.ToString())

                    }); ;

                    this.DialogResult = DialogResult.OK;
                }
                catch (Exception er)
                {
                    MessageBox.Show(er.Message, "Eror", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            });
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void AddPlace_Load(object sender, EventArgs e)
        {

        }
    }
}
