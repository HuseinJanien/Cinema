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
    public partial class CategoryAdd : Form
    {
        DataManager DataManager;
        public CategoryAdd(DataManager dataManager)
        {
            this.DataManager = dataManager;
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
        IEnumerable<Category> queryable2()
        {
            foreach (var dr in DataManager.categories)
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
                        throw new Exception("Please enter text");
                    }
                    if ( queryable2().ToArray().Length > 0)
                    {
                        throw new Exception("Is exist");
                    }
                    await DataManager.AddCategoryAsync(new Category() { Name=textBox1.Text});         
                    this.DialogResult = DialogResult.OK;
                }
                catch (Exception er)
                {
                    MessageBox.Show(er.Message, "Eror", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            });
        }

        private void CategoryAdd_Load(object sender, EventArgs e)
        {

        }
    }
}
