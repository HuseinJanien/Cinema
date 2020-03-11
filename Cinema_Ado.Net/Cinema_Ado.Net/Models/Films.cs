using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema_Ado.Net.Models
{
    public class Films
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public int AgeId { get; set; }
        public Films()
        {

        }
        public Films(int Id,string Name, int CategoryId, int AgeId)
        {
            this.Name = Name;
            this.CategoryId = CategoryId;
            this.AgeId = AgeId;
        }
    }
}
