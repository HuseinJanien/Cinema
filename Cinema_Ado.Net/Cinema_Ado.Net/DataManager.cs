using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using Cinema_Ado.Net.Models;

namespace Cinema_Ado.Net
{
    class DataManager : DbProvider
    {
        public List<Halls> halls;
        List<Places> places;
        List<Category> categories;
        List<AgeRestriction> ages;
        public List<Films> films;
        public List<Session> sessions;
        List<Tickets> tickets;

        public DataManager()
        {
            halls = new List<Halls>();
            places = new List<Places>();
            categories = new List<Category>();
            ages = new List<AgeRestriction>();
            films = new List<Films>();
            sessions = new List<Session>();
            tickets = new List<Tickets>();
        }

        public void LoadData()
        {
            string queryHalls = "SELECT * FROM Halls";
            string queryPlaces = "SELECT * FROM Places";
            string queryCategory = "SELECT * FROM Category";
            string queryAges = "SELECT * FROM AgeRestriction";
            string queryFilms = "SELECT * FROM Films";
            string queryTickets = "SELECT * FROM Tickets";
            string querySessions = "SELECT * FROM Sessions";
            connection.Open();
            SqlCommand cmd = new SqlCommand(queryHalls,connection);
            SqlDataReader reader = cmd.ExecuteReader();

            //Hall
            cmd = new SqlCommand(queryHalls, connection);
            reader = cmd.ExecuteReader();
            while(reader.Read())
            {
                Halls h = new Halls(
                    reader["Name"].ToString()
                    );
                halls.Add(h);
            }
            //Places
            cmd = new SqlCommand( queryPlaces, connection);
            reader = cmd.ExecuteReader();
            while(reader.Read())
            {
                Places p = new Places(
                    (int)reader["HallId"],
                    (int)reader["Row"]
                    );
                places.Add(p);
            }
            //Category
            cmd = new SqlCommand(queryCategory, connection);
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Category c = new Category(
                    reader["Name"].ToString()
                    );
                categories.Add(c);
            }
            //Ages
            cmd = new SqlCommand(queryAges , connection);
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                AgeRestriction a = new AgeRestriction(
                    (int)reader["Age"]
                    );
                ages.Add(a);
            }
            //Films
            cmd = new SqlCommand(queryFilms, connection);
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Films f = new Films(
                    reader["Name"].ToString(),
                    (int)reader["CategoryId"],
                    (int)reader["AgeId"]
                    );
                films.Add(f);
            }
            //Tickets
            cmd = new SqlCommand(queryTickets, connection);
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Tickets t = new Tickets(
                    (int)reader["PlaceId"],
                    (int)reader["SessionId"],
                    (DateTime)reader["Date"]
                    );
                tickets.Add(t);
            }
            //Sessions
            cmd = new SqlCommand(querySessions, connection);
            reader = cmd.ExecuteReader();
            while(reader.Read())
            {
                Session s = new Session(
                    (int)reader["HallId"],
                    (DateTime)reader["DateTime"],
                    (int)reader["FilmId"]
                    );
                sessions.Add(s);
            }
            connection.Close();
        }
        public void AddSession(Session s)
        {
            string queryAddSession =
                "insert into Session (HallId, DateTime, FilmId) VALUES (@hallId, @DateTime, @FilmId)";
            connection.Open();
            SqlCommand cmd = new SqlCommand(queryAddSession, connection);
            //cmd.Parameters.Add();
        }


    }
}
