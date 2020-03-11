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
    public partial class Films1 : Form
    {
        private DataManager Data;
        public Films1(DataManager Data)
        {
            this.Data = Data;
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
        IEnumerable<Films> queryable2()
        {
            foreach (var dr in Data.films)
            {
                if (dr.Name.Contains(textBox1.Text))
                {
                    yield return dr;
                }
            }
        }
        private void  button1_ClickAsync(object sender, EventArgs e)
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
                    if (comboBox1.SelectedItem == null || comboBox2.SelectedItem == null)
                    {
                        throw new Exception();
                    }
                    await Data.AddFilmAsync(new Films()
                    {
                        Name = textBox1.Text,
                        CategoryId = comboBox1.SelectedIndex,
                        AgeId = comboBox2.SelectedIndex
                    });
                    this.DialogResult = DialogResult.OK;
                }
                catch (Exception er)
                {
                    MessageBox.Show(er.Message, "Eror", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            });
           
        }

        private void Films1_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            comboBox2.Items.Clear();
            textBox1.Clear();
            foreach (var el in Data.categories)
            {
                comboBox1.Items.Add(el.Name);
            }
            foreach (var el in Data.categories)
            {
                comboBox2.Items.Add(el.Name);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
