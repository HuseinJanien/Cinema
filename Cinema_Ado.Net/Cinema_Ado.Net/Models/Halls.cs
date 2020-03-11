using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema_Ado.Net.Models
{
    public class Halls
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Halls(int Id,string Name)
        {
            this.Id = Id;
            this.Name = Name;
        }
    }
}
