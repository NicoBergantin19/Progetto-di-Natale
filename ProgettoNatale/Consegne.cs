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

namespace ProgettoNatale
{
    public partial class Consegne : Form
    {
        SqlConnection connection;
        string continente;
        public Consegne(SqlConnection conn, string cont)
        {
            InitializeComponent();
            connection = conn;
            continente = cont;
        }

        private void button3_Click(object sender, EventArgs e)  //Home
        {
            Azioni aa = new Azioni(connection, "Amministratore");
            aa.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)  //Mappa
        {
            Mappa mappa = new Mappa(connection);
            mappa.Show();
            this.Hide();
        }

        private void Consegne_Load(object sender, EventArgs e)
        {
            Controllo(connection);
            DividiContinente(continente);
        }


        //////////////////////////////////METODI///////////////////////////////////////////////////////
        internal void Controllo(SqlConnection connection)
        {
            SqlDataAdapter sda = new SqlDataAdapter("SELECT COUNT(*) FROM Assegnazione", connection);
            DataTable dt = new DataTable(); //Crea una tabella virtuale
            sda.Fill(dt);
            //Controllo se la tabella esiste già, se esiste non inserisce i dati
            if (dt.Rows[0][0].ToString() == "0")
            {
                MessageBox.Show("Sto assegnando i regali ai bambini", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                AssegnaRegalo assegnazione = new AssegnaRegalo();
                assegnazione.Assegna(connection);
                this.Hide();
            }
        }

        internal void DividiContinente(string continente)
        {
            string query = $@"SELECT Assegnazione.ID_Assegnazione, Assegnazione.Bambino, Assegnazione.Regalo FROM Nazioni
                            INNER JOIN Bambini ON Nazioni.Codice = Bambini.Nazione AND Nazioni.Continente = '{continente}'
                            INNER JOIN Assegnazione ON Assegnazione.Bambino = Bambini.ID_Bambino";

            SqlCommand cmd = new SqlCommand(query, connection);
            SqlDataReader dataReader;
            DataTable dt = new DataTable();
            dataReader = cmd.ExecuteReader();
            dt.Load(dataReader);
            dataGridView1.DataSource = dt;

            dataReader.Close();
        }
    }
}
