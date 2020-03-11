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
    public class Login
    {
        public Login(int Id, string username, string password)
        {
            this.Id = Id;
            this.username = username;
            this.password = password;
        }

        public int Id { get; set; }
        public string username { get; set; }
        public string password { get; set; }
    }

    public class DataManager : DbProvider
    {
        public List<Halls> halls { get; set; }
        public List<Places> places { get; set; }
        public List<Category> categories { get; set; }
        public List<AgeRestriction> ages { get; set; }
        public List<Films> films { get; set; }
        public List<Session> sessions { get; set; }
        public List<Tickets> tickets { get; set; }
        public List<Login> Logins { get; set; }
        public async ValueTask<bool> LoginAsync(string username, string password)
        {
            return await  Task.Run(async () => { 
                         Logins = new List<Login>();
            SqlCommand cmd;
            SqlDataReader reader;
            await connection.OpenAsync();
            string query = "select * from tbl_Login";
            cmd = new SqlCommand(query, connection);
            reader = cmd.ExecuteReader();
            while (await reader.ReadAsync())
            {
                Login h = new Login(
                    (int)reader["Id"],
                    reader["username"].ToString(),
                    reader["password"].ToString()
                    );
                Logins.Add(h);
            }
            connection.Close(); 
            
                foreach(var el in Logins)
                {
                    if(el.password==password && el.username==username)
                    {
                        return true;                   
                    }
                }
                return false;

            });

        }
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
                    (string)reader["Name"],
                    (int)reader["Id"],
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
                    (int)reader["Id"],
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

        public int GetPlace(string name)
        {
            foreach (var dr in places)
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
        public async Task AddTicketsAsync(Tickets f)
        {
            string queryAddSession = "insert into  Tickets(Date, PlaceId, SessionId) VALUES (@Date, @PlaceId, @SessionId)";
            await connection.OpenAsync();
            using (SqlCommand cmd = new SqlCommand(queryAddSession, connection))
            {
                cmd.Parameters.Add("@Date", SqlDbType.DateTime).Value = f.DateTime;
                cmd.Parameters.Add("@PlaceId", SqlDbType.Int).Value = f.PlaceId;
                cmd.Parameters.Add("@SessionId", SqlDbType.Int).Value = f.SessionId;
                cmd.ExecuteNonQuery();
                connection.Close();
                tickets.Add(f);
                LoadData();
            }
        }

        public async Task AddPlaceAsync(Places f)
        {
            string queryAddSession = "insert into  Plases(Name, Row) VALUES (@Name, @Row)";
            await connection.OpenAsync();
            using (SqlCommand cmd = new SqlCommand(queryAddSession, connection))
            {
                cmd.Parameters.Add("@Name", SqlDbType.NVarChar).Value = f.Name;
                cmd.Parameters.Add("@Row", SqlDbType.Int).Value = f.Row;
                cmd.ExecuteNonQuery();
                connection.Close();
                places.Add(f);
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

        public async void DeletePlace(int Id)
        {
            string? query = $"DELETE FROM Plases WHERE Id = @Id";
            await connection.OpenAsync();
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@Id", Id);
                cmd.ExecuteNonQuery();
                connection.Close();
                LoadData();
            }
        }
        public async void DeleteTicket(int Id)
        {
            string? query = $"DELETE FROM Tickets WHERE Id = @Id";
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
