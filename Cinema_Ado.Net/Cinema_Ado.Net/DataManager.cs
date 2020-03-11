using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using Cinema_Ado.Net.Models;
using System.Windows.Forms;

namespace Cinema_Ado.Net
{
    public class DataManager : DbProvider
    {
        public List<Halls> halls { get; set; }
        public List<Places> places { get; set; }
        public List<Category> categories { get; set; }
        public List<AgeRestriction> ages { get; set; }
        public List<Films> films { get; set; }
        public List<Session> sessions { get; set; }
        public List<Tickets> tickets { get; set; }

        public DataManager()
        {
            LoadData();
        }

        public void LoadData()
        {
            halls = new List<Halls>();
            places = new List<Places>();
            categories = new List<Category>();
            ages = new List<AgeRestriction>();
            films = new List<Films>();
            sessions = new List<Session>();
            tickets = new List<Tickets>();
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
                    (int)reader["Id"],
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
                    (int)reader["Id"],
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
                    (int)reader["Id"],
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
                    (int)reader["Id"],
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
                    (DateTime)reader["Date"]
                    );
                tickets.Add(t);
            }
            connection.Close();
            //Sessions
            connection.Open();
            cmd = new SqlCommand(querySessions, connection);
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Session s = new Session(
                    (int)reader["Id"],
                    (int)reader["HallId"],
                    (DateTime)reader["DateTime"],
                    (int)reader["FilmId"]
                    );
                sessions.Add(s);
            }
            connection.Close();
        }
  
        public int GetHall(string name)
        {
            foreach (var dr in halls)
            {
                if (dr.Name.Contains(name))
                {
                    return dr.Id;
                }
            }
            return 0;

        }
        public int GetFilm(string name)
        {
            foreach (var dr in films)
            {
                if (dr.Name.Contains(name))
                {
                    return dr.Id;
                }
            }
            return 0;

        }
        public string GetFilm(int name)
        {
            foreach (var dr in films)
            {
                if (dr.Id==name)
                {
                    return dr.Name;
                }
            }
            return "null";

        }
        public string GetHall(int name)
        {
            foreach (var dr in halls)
            {
                if (dr.Id == name)
                {
                    return dr.Name;
                }
            }
            return "null";

        }

        public string GetCategory(int name)
        {
            foreach (var dr in categories)
            {
                if (dr.Id == name)
                {
                    return dr.Name;
                }
            }
            return "null";

        }

        public string GetAge(int name)
        {
            foreach (var dr in ages)
            {
                if (dr.Id == name)
                {
                    return dr.Age.ToString();
                }
            }
            return "null";

        }
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
            LoadData();
        }
        public void  DelSessionAsync(int Id)
        {
            string query = $"DELETE FROM Session  WHERE Id = @Id";          
            connection.OpenAsync();
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@Id", Id);
                cmd.ExecuteNonQuery();
             
                connection.Close();
                LoadData();
            }
        }


        public async Task AddFilmAsync(Films f)
        {
            string queryAddSession ="insert into  Films(Name, CategoryId, AgeId) VALUES (@Name, @CategoryId, @AgeId)";
            await  connection.OpenAsync();
            using (SqlCommand cmd = new SqlCommand(queryAddSession, connection))
            {
                cmd.Parameters.Add("@Name", SqlDbType.NVarChar).Value = f.Name;
                cmd.Parameters.Add("@CategoryId", SqlDbType.Int).Value = f.CategoryId;
                cmd.Parameters.Add("@AgeId", SqlDbType.Int).Value = f.AgeId;
                cmd.ExecuteNonQuery();
                connection.Close();
                films.Add(f);
                LoadData();
            }
        }

        public async Task AddCategoryAsync(Category f)
        {
            string queryAddSession = "insert into  Category(Name) VALUES (@Name)";
            await connection.OpenAsync();
            using (SqlCommand cmd = new SqlCommand(queryAddSession, connection))
            {
                cmd.Parameters.Add("@Name", SqlDbType.NVarChar).Value = f.Name;

                cmd.ExecuteNonQuery();
                connection.Close();
                categories.Add(f);
                LoadData();
            }
        }

        public async void DeleteFilm(int Id)
        { 
                string? query = $"DELETE FROM Films WHERE Id = @Id";
                await connection.OpenAsync();
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@Id", Id);
                    cmd.ExecuteNonQuery();
                    connection.Close();               
                    LoadData();
                }
        }

        public async void DeleteCategory(string Id)
        {
            string? query = $"DELETE FROM Category WHERE Name = @Id";
            await connection.OpenAsync();
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@Id", Id);
                cmd.ExecuteNonQuery();
                connection.Close();
                LoadData();
            }
        }

        public async void DeleteAge(string Id)
        {
            string? query = $"DELETE FROM AgeRestriction WHERE Age = @Id";
            await connection.OpenAsync();
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@Id", Id);
                cmd.ExecuteNonQuery();
                connection.Close();
                LoadData();
            }
        }

    }
}
