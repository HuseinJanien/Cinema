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
        public List<Places> places;
        public List<Category> categories;
        public List<AgeRestriction> ages;
        public List<Films> films;
        public List<Session> sessions;
        public List<Tickets> tickets;

        public DataManager()
        {
            halls = new List<Halls>();
            places = new List<Places>();
            categories = new List<Category>();
            ages = new List<AgeRestriction>();
            films = new List<Films>();
            sessions = new List<Session>();
            tickets = new List<Tickets>();
            LoadData();
        }

        public void LoadData()
        {
            string queryHalls = "SELECT * FROM Halls";
            string queryPlaces = "SELECT * FROM Plases";
            string queryCategory = "SELECT * FROM Category";
            string queryAges = "SELECT * FROM AgeRestriction";
            string queryFilms = "SELECT * FROM Films";
            string queryTickets = "SELECT * FROM Tickets";
            string querySessions = "SELECT * FROM Session";
            
            SqlCommand cmd;
            SqlDataReader reader;

            //Hall
            connection.Open();
            cmd = new SqlCommand(queryHalls, connection);
            reader = cmd.ExecuteReader();
            while(reader.Read())
            {
                Halls h = new Halls(
                    reader["Name"].ToString()
                    );
                halls.Add(h);
            }
            connection.Close();
            //Places
            connection.Open();
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
            connection.Close();
            //Category
            connection.Open();
            cmd = new SqlCommand(queryCategory, connection);
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Category c = new Category(
                    reader["Name"].ToString()
                    );
                categories.Add(c);
            }
            connection.Close();
            //Ages
            connection.Open();
            cmd = new SqlCommand(queryAges , connection);
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                AgeRestriction a = new AgeRestriction(
                    (int)reader["Age"]
                    );
                ages.Add(a);
            }
            connection.Close();
            //Films
            connection.Open();
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
            connection.Close();
            //Tickets
            connection.Open();
            cmd = new SqlCommand(queryTickets, connection);
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Tickets t = new Tickets(
                    (int)reader["PlaceId"],
                    (int)reader["SessionId"],
                    (DateTime)reader["DateTime"]
                    );
                tickets.Add(t);
            }
            connection.Close();
            //Sessions
            connection.Open();
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
        //Session
        public void AddSession(Session s)
        {
            string queryAddSession =
                "insert into Session (HallId, DateTime, FilmId) VALUES (@HallId, @DateTime, @FilmId)";
            connection.Open();
            SqlCommand cmd = new SqlCommand(queryAddSession, connection);
            cmd.Parameters.Add("@HallId", SqlDbType.Int).Value = s.HallId;
            cmd.Parameters.Add("@DateTime", SqlDbType.DateTime).Value = s.DateTime;
            cmd.Parameters.Add("@FilmId", SqlDbType.Int).Value = s.FilmId;
            cmd.ExecuteNonQuery();
            connection.Close();
            sessions.Add(s);
        }
        public void DelSession(int hallId)
        {
            string queryDelSession =
                 "DELETE Session from Session  where HallId = @HallId";
            connection.Open();
            SqlCommand cmd = new SqlCommand(queryDelSession, connection);
            cmd.Parameters.Add("@HallId", SqlDbType.Int).Value = hallId;
            cmd.ExecuteNonQuery();
            connection.Close();

            //Session session;
            //session = sessions.FirstOrDefault(c => c.HallId = hallId); 
            //sessions.Remove(session);
        }
    }
}
