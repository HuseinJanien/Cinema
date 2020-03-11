using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema_Ado.Net.Models
{
    public class Category
    {
        public string Name { get; set; }
        public Category(string Name)
        {
            this.Name = Name;
        }

        public Category()
        {
        }
    }
}
