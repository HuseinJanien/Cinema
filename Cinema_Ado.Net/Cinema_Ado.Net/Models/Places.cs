using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema_Ado.Net.Models
{
    public class Places
    {
        public int Id { get; set; }
        public int Row { get; set; }
        public string Name { get; set; }
        public Places(string Name,int Id, int Row)
        {
            this.Name = Name;
            this.Id = Id;
            this.Row = Row;
        }

        public Places()
        {
        }
    }
}
