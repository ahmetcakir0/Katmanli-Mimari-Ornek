
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using EntityLayer;
using DataAccessLayer;

namespace BusinessLayer
{
    public class Business
    {
        private readonly DataAccess dataAccess;

        public Business()
        {
            dataAccess = new DataAccess();
        }
        public void AddUye(string uyeAdi, string uyeSoyadi)
        {
            if (string.IsNullOrWhiteSpace(uyeAdi) || string.IsNullOrWhiteSpace(uyeSoyadi))
            {
                throw new ArgumentException("Üye adı ve soyadı boş olamaz.");
            }

            dataAccess.AddUye(uyeAdi, uyeSoyadi);
        }
        public List<Uyeler> GetUyeler()
        {
            List<Uyeler> uyeler = dataAccess.GetUyeler();

            uyeler = uyeler.Where(u => !string.IsNullOrEmpty(u.UyeAdi)).ToList();

            return uyeler;
        }
    }
}
