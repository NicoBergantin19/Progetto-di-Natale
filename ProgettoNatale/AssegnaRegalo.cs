using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace ProgettoNatale
{
    public class AssegnaRegalo
    {
        public void Assegna(SqlConnection connection)
        {
            string query = "SELECT Cognome FROM Bambini LEFT JOIN Assegnazione ON Bambini.Cognome = Assegnazione.Bambino";
            SqlCommand cmd = new SqlCommand(query, connection);    
            SqlDataReader reader = cmd.ExecuteReader();
            List<Bambino> bimbi;
            List<Assegnazione> assegnazione = new List<Assegnazione>();

            while (reader.Read())
            {
                assegnazione.Add(new Assegnazione { Bambino = reader["Cognome"].ToString() });
            }
        }
    }
    public class Assegnazione
    {
        public string Bambino;
        public int ID_Regalo;
    }
}
