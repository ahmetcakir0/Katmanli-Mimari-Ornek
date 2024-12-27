using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer;
namespace DataAccessLayer
{
    public class DataAccess
    {
        private readonly string _connectionString = "server=MBB-01-BIL065-N\\SQLEXPRESS; Initial Catalog=Uye; Integrated Security=SSPI";

        public SqlConnection OpenConnection()
        {
            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();
            return connection;
        }

        public SqlCommand CreateCommand(string query, SqlConnection connection)
        {
            return new SqlCommand(query, connection);
        }
        public void AddUye(string uyeAdi, string uyeSoyadi)
        {
            using (SqlConnection connection = OpenConnection())
            {
                string query = "INSERT INTO Uyeler (Ad, Soyad) VALUES (@Ad, @Soyad)";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Ad", uyeAdi);
                    command.Parameters.AddWithValue("@Soyad", uyeSoyadi);
                    command.ExecuteNonQuery();
                }
            }
        }
        public List<Uyeler> GetUyeler()
        {
            List<Uyeler> uyeler = new List<Uyeler>();
            using (SqlConnection connection = OpenConnection())
            {
                using (SqlCommand command = CreateCommand("SELECT ID, Ad, Soyad FROM Uyeler", connection))
                {
                    using (SqlDataReader dataReader = command.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            Uyeler uye = new Uyeler
                            {
                                UyeID = dataReader["ID"].ToString(),
                                UyeAdi = dataReader["Ad"].ToString(),
                                UyeSoyadi = dataReader["Soyad"].ToString()
                            };
                            uyeler.Add(uye);
                        }
                    }
                }
            }
            return uyeler;
        }
    }
}