using DolgozatPatika.Models;
using MySql.Data.MySqlClient;

namespace DolgozatPatika.Services
{
    public class GyogyszerService
    {
        public List<Gyogyszer> GetAllGyogyszer()
        {
            List<Gyogyszer> GyogyszerList = new List<Gyogyszer>();
            try
            {
                string connectionString = "SERVER = localhost;" +
                              "DATABASE= patika;" +
                              "UID = root;" +
                              "PASSWORD =;";
                MySqlConnection conn = new MySqlConnection();
                conn.ConnectionString = connectionString;
                conn.Open();
                string sql = "SELECT * FROM gyogyszer";
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = sql;
                cmd.Connection = conn;
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Gyogyszer GyogyszerTemp = new Gyogyszer();
                    GyogyszerTemp.Id = reader.GetInt32("Id");
                    GyogyszerTemp.Nev = reader.GetString("Nev");
                    GyogyszerTemp.Hatoanyag = reader.GetString("Hatoanyag");
                    GyogyszerTemp.Venykoteles = reader.GetBoolean("Venykoteles");
                    GyogyszerTemp.kepnev = reader.GetString("kepnev");
                    GyogyszerList.Add(GyogyszerTemp);
                }
                conn.Close();
                return GyogyszerList;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Hiba az adatok lekérésekor: " + ex.Message);
                return GyogyszerList;
            }
        }


        public Gyogyszer GetByIdGogyszer(int id)
        {
            Gyogyszer result = new Gyogyszer();
            try
            {
                string connectionString = "SERVER = localhost;" +
                              "DATABASE= patika;" +
                              "UID = root;" +
                              "PASSWORD =;";
                MySqlConnection conn = new MySqlConnection();
                conn.ConnectionString = connectionString;
                conn.Open();
                string sql = "SELECT * FROM gyogyszer WHERE Id = @id";
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = sql;
                cmd.Connection = conn;
                cmd.Parameters.AddWithValue("@id", id);
                MySqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    //A beolvasott adatok 
                    result.Id = reader.GetInt32("Id");
                    result.Nev = reader.GetString("Nev");
                    result.Hatoanyag = reader.GetString("Hatoanyag");
                    result.Venykoteles = reader.GetBoolean("Venykoteles");
                    result.kepnev = reader.GetString("kepnev");

                }
                else
                {
                    Console.WriteLine("Nincs ilyen azonosítóval rendelkező vásárló!");
                }

                conn.Close();
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Hiba történt az adatok lekérdezése során: " + ex.Message);
                return result;
            }
        }
    }
}
