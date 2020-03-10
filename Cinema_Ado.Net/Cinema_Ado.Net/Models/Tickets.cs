using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema_Ado.Net.Models
{
    public class Tickets
    {
        public int PlaceId { get; set; }
        public int SessionId { get; set; }
        public DateTime DateTime { get; set; }
        public Tickets(int PlaceId, int SessionId, DateTime DateTime)
        {
            this.PlaceId = PlaceId;
            this.SessionId = SessionId;
            this.DateTime = DateTime;
        }
    }
}
