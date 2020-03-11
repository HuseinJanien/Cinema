using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema_Ado.Net.Models
{
    public class Tickets
    {
        public int Id { get; set; }
        public int PlaceId { get; set; }
        public int SessionId { get; set; }
        public DateTime DateTime { get; set; }
        public Tickets(int Id,int PlaceId, int SessionId, DateTime DateTime)
        {
            this.Id = Id;
            this.PlaceId = PlaceId;
            this.SessionId = SessionId;
            this.DateTime = DateTime;
        }

        public Tickets()
        {
        }
    }
}
