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
            string query = "SELECT ID_Bambino, Bonta FROM Bambini LEFT JOIN Assegnazione ON Bambini.ID_Bambino = Assegnazione.Bambino";
            SqlCommand cmd = new SqlCommand(query, connection);    
            SqlDataReader reader = cmd.ExecuteReader();

            List<BambinoRegalo> Inserimento;
            List<Bambino> ID_Bambino = new List<Bambino>();
            while (reader.Read())
                ID_Bambino.Add(new Bambino { ID = Convert.ToInt32(reader["ID_Bambino"]), Bonta = Convert.ToInt32(reader["Bonta"])});
            
            reader.Close();

            query = "SELECT ID_Regalo, Bonta FROM Regali WHERE Categoria != 'Speciale' AND Categoria != 'Carbone'";
            SqlCommand sqlCommand = new SqlCommand(query, connection);
            reader = sqlCommand.ExecuteReader();
            List<Regalo> Regali = new List<Regalo>();
            while (reader.Read()) 
                Regali.Add(new Regalo {ID = Convert.ToInt32(reader["ID_Regalo"]), Bonta = Convert.ToInt32(reader["Bonta"])});
            
            reader.Close();

           

            query = "SELECT ID_Regalo, Bonta FROM Regali WHERE Categoria = 'Speciale'";
            SqlCommand aaaa = new SqlCommand(query, connection);
            reader = aaaa.ExecuteReader();
            List<Regalo> Peluche = new List<Regalo>();
            while (reader.Read())
                Peluche.Add(new Regalo { ID = Convert.ToInt32(reader["ID_Regalo"]), Bonta = Convert.ToInt32(reader["Bonta"]) });

            reader.Close();

            //Lista Carbone
            query = "SELECT ID_Regalo, Bonta FROM Regali WHERE Categoria = 'Carbone'";
            SqlCommand bbbbb = new SqlCommand(query, connection);
            reader = bbbbb.ExecuteReader();
            List<Regalo> Carbone = new List<Regalo>();

            while (reader.Read())
                Carbone.Add(new Regalo { ID = Convert.ToInt32(reader["ID_Regalo"]), Bonta = Convert.ToInt32(reader["Bonta"]) });

            reader.Close();


            string ins_Regali;
            List<BambinoRegalo> DaInserire;
            List<Regalo> Regali_Assegnabili;
            Random rnd = new Random();

            foreach (Bambino bambino in ID_Bambino)
            {
                DaInserire = new List<BambinoRegalo>();
                Regali_Assegnabili = Regali.FindAll(x => x.Bonta <= bambino.Bonta);
                ins_Regali = "INSERT INTO Assegnazione (Bambino, Regalo) VALUES";                
                               
                Regali_Assegnabili = Regali_Assegnabili.OrderBy(x => rnd.Next()).ToList();               

                switch (bambino.Bonta)
                {
                    case int num when num == 100:
                        for (int i = 0; i < 3; i++)
                        {
                            DaInserire.Add(new BambinoRegalo {Bambino_Assegnato = bambino.ID, Regalo_Assegnato = Regali_Assegnabili[i].ID});
                        }
                        DaInserire.Add(new BambinoRegalo { Bambino_Assegnato = bambino.ID, Regalo_Assegnato = Peluche[0].ID });
                        break;

                    case int num when num >= 70 & num < 100:
                        for (int i = 0; i < 3; i++)
                        {
                            DaInserire.Add(new BambinoRegalo { Bambino_Assegnato = bambino.ID, Regalo_Assegnato = Regali_Assegnabili[i].ID });
                        }
                        break;

                    case int num when num >= 40 & num < 70:
                        for (int i = 0; i < 2; i++)
                        {
                            DaInserire.Add(new BambinoRegalo { Bambino_Assegnato = bambino.ID, Regalo_Assegnato = Regali_Assegnabili[i].ID });
                        }
                        break;

                    case int num when num > 10 & num < 40:
                            DaInserire.Add(new BambinoRegalo { Bambino_Assegnato = bambino.ID, Regalo_Assegnato = Regali_Assegnabili[0].ID });
                        break;

                    case int num when num <= 10:
                            DaInserire.Add(new BambinoRegalo { Bambino_Assegnato = bambino.ID, Regalo_Assegnato = Carbone[0].ID });
                        break;
                }
                ins_Regali += string.Join(",", DaInserire);
                SqlCommand command = new SqlCommand(ins_Regali, connection);
                command.ExecuteNonQuery();
            }
        }
    }
   
    class BambinoRegalo
    {
        public int Bambino_Assegnato;
        public int Regalo_Assegnato;
        public override string ToString()
        {
            return $"('{Bambino_Assegnato}','{Regalo_Assegnato}')";
        }
    }
}
