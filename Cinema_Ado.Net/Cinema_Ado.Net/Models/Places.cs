using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema_Ado.Net.Models
{
    public class Places
    {
        public int HallId { get; set; }
        public int Row { get; set; }
        public Places(int HallId, int Row)
        {
            this.HallId = HallId;
            this.Row = Row;
        }

    }
}
