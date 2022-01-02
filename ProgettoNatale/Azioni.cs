using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using Newtonsoft.Json;

namespace ProgettoNatale
{
    public partial class Azioni : Form
    {
        SqlConnection connection;
        public Azioni(SqlConnection conn, string Tipo_Account)
        {
            InitializeComponent();
            connection = conn;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void View_Kids_Click(object sender, EventArgs e) //Inserimento dati dei bambini quando si clicca
        {
            Insert_Kids(connection);
            Bambini bambini = new Bambini(connection, "Amministratore");
            bambini.Show();
            this.Hide();
        }

        private void View_Gifts_Click(object sender, EventArgs e) //Inserimento dati dei regali quando si clicca
        {
            Insert_Gifts(connection);   
            Regali form = new Regali(connection, "Amministratore");
            form.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)  //Apre il form della mappa
        {
            Mappa mappa = new Mappa(connection);
            mappa.Show();
            this.Hide();
        }

        ////////////////////////////////////////////////////////////////Metodi///////////////////////////////////////////////////////////////////////////////

        internal void Insert_Nazioni(SqlConnection connection)  //Inserisce le nazioni nell'apposita tabella da json
        {
            List<Nazioni> Dc = JsonConvert.DeserializeObject<List<Nazioni>>(File.ReadAllText("ListaNazioni.json"));
            foreach (Nazioni dp in Dc)
            {
                string query = $"INSERT INTO Nazioni (Nome, Continente, Fuso_Orario) VALUES ('{dp.Nome}', '{dp.Continente}', '{dp.Fuso_Orario}')";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.ExecuteNonQuery();
            }
        }

        internal void Insert_Kids(SqlConnection connection) //Generazione e inserimento bambini
        {
            List<Nazioni> SecondoMe = JsonConvert.DeserializeObject<List<Nazioni>>(File.ReadAllText("ListaNazioni.json"));
            Random randNazione = new Random();
            SqlDataAdapter sda = new SqlDataAdapter("SELECT COUNT(*) FROM Bambini", connection);
            DataTable dt = new DataTable(); //Crea una tabella virtuale
            sda.Fill(dt);
            //Controllo se la tabella esiste già, se esiste non inserisce i nomi
            if (dt.Rows[0][0].ToString() == "0")
            {
                MessageBox.Show("Sto generando i bambini, aspetta un attimo", "Informazione:", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Insert_Nazioni(connection);
                List<Bambino> Bambini_Sfruttati = new List<Bambino>();
                Random rand = new Random(DateTime.Now.Second);
                RandomName nameGen = new RandomName(rand);
                List<string> Names = nameGen.RandomNames(50000, 0);  //Generazione di nomi e cognomi dei bambini ----> RandomName.cs
                Random rnd = new Random();
                foreach (string name in Names)
                {
                    string[] arrGay = name.Split(' ');  //Divide i nomi dai cognomi 
                    int eta = rnd.Next(1, 9);
                    int bonta = rnd.Next(0, 101);
                    string nazione = SecondoMe[randNazione.Next(SecondoMe.Count)].Nome;
                    string query = $"INSERT INTO Bambini (Nome, Cognome, AGE, Nazione, Bonta) VALUES ('{arrGay[0]}', '{arrGay[1]}', {eta}, '{nazione}', {bonta});";
                    SqlCommand command = new SqlCommand(query, connection);
                    try
                    {
                        command.ExecuteNonQuery();
                    }
                    catch (SqlException error)
                    {
                        MessageBox.Show("Inserimento dei bambini non andato a buon fine: " + error.Message);
                    }
                }
            }
        }

        internal void Insert_Gifts(SqlConnection connection)    //Inserimento regali da json
        {
            SqlDataAdapter sda = new SqlDataAdapter("SELECT COUNT(*) FROM Regali", connection);
            DataTable dt = new DataTable(); //Crea una tabella virtuale
            sda.Fill(dt);
            //Controllo se la tabella esiste già, se esiste non inserisce i nomi
            if (dt.Rows[0][0].ToString() == "0")
            {
                List<Regalo> regali = JsonConvert.DeserializeObject<List<Regalo>>(File.ReadAllText("ListaRegali.json"));
                foreach (Regalo reg in regali)
                {
                    reg.Bonta = Convert.ToInt32(reg.Bonta);
                    SqlCommand cmd = new SqlCommand($"INSERT INTO Regali (Tipo, Categoria, Bonta) VALUES ('{reg.Tipo}', '{reg.Categoria}', {reg.Bonta});", connection);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }

    public class Bambino
    {
        public string Nome;
        public string Cognome;
        public int Eta;
        public string Nazione;
        public int Bonta;
    }

    public class Regalo
    {
        public string Tipo;
        public string Categoria;
        public int Bonta;
    }

    public class Nazioni
    {
        public string Nome;
        public string Continente;
        public string Fuso_Orario;
    }
}
