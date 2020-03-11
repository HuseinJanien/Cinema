using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema_Ado.Net.Models
{
    class Session
    {
        public int HallId { get; set; }
        public DateTime DateTime{ get; set; }
        public int FilmId { get; set; }
        public Session(int HallId, DateTime DatetIme, int FilmId)
        {
            this.HallId = HallId;
            this.DateTime = DateTime;
            this.FilmId = FilmId;
        }

    }
}
