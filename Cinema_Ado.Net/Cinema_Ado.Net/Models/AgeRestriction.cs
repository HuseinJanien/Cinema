using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema_Ado.Net.Models
{
    class AgeRestriction
    {
        public int Age { get; set; }
        public AgeRestriction(int Age)
        {
            this.Age = Age;
        }
    }
}
