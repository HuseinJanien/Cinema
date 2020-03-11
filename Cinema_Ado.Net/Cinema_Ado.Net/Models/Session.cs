using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema_Ado.Net.Models
{
    public class Session
    {
        public int Id { get; set; }
        public int HallId { get; set; }
        public DateTime DateTime{ get; set; }
        public int FilmId { get; set; }
        public Session(int Id,int HallId, DateTime DatetIme, int FilmId)
        {
            this.Id = Id;
            this.HallId = HallId;
            this.DateTime = DateTime;
            this.FilmId = FilmId;
        }

        public Session()
        {
        }
    }
}
