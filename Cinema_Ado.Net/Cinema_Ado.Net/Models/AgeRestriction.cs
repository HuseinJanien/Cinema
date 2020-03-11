using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema_Ado.Net.Models
{
    public class AgeRestriction
    {
        public int Age { get; set; }
        public int Id { get;  set; }

        public AgeRestriction(int Id,int Age)
        {
            this.Id = Id;
            this.Age = Age;
        }
    }
}
