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



        }
    }
}
