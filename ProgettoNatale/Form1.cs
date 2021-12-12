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
using System.Data;

namespace ProgettoNatale
{
    public partial class Form1 : Form
    {
        SqlConnection connection;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            connection = new SqlConnection("Data Source=DESKTOP-0JNBS50;Initial Catalog=Natale;Integrated Security=True");
            try
            {
                connection.Open();
                Nations_Table(connection);
                Kids_Table(connection);
                MessageBox.Show("Connessione eseguita correttamente","", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (SqlException error)
            {
                MessageBox.Show(error.ToString());
            }
        }
        internal void Nations_Table(SqlConnection connection)
        {
            string query = @"SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Nazioni';";
            SqlCommand controllo = new SqlCommand(query, connection);
            SqlDataReader reader = controllo.ExecuteReader();
            if (reader.HasRows == false)
            {
                reader.Close();
                controllo.Cancel();
                string tab_nazioni = "CREATE TABLE Nazioni(ID int IDENTITY(1,1), Nome varchar(30) NOT NULL, Continente varchar(30), Fuso_Orario datetime, PRIMARY KEY(ID));";
                SqlCommand cmd = new SqlCommand(tab_nazioni, connection);
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (SqlException error)
                {
                    MessageBox.Show("Errore nel generare la tabella nazioni: " + error.ToString());
                }
            }
            else
                reader.Close();                   
        }

        internal void Kids_Table(SqlConnection connection)
        {
            string query = "SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Bambini';";
            SqlCommand controllo = new SqlCommand(query, connection);
            SqlDataReader reader = controllo.ExecuteReader();
            if (reader.HasRows == false)
            {
                reader.Close();
                controllo.Cancel();
                string tab_nazioni = "CREATE TABLE Bambini(ID int IDENTITY(1,1), Nome varchar(30) NOT NULL,Cognome varchar(30) NOT NULL, Nazione varchar(30), Bonta int PRIMARY KEY(ID));";
                SqlCommand cmd = new SqlCommand(tab_nazioni, connection);
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (SqlException error)
                {
                    MessageBox.Show("Errore nel generare la tabella nazioni: " + error.ToString());
                }
            }
            else
                reader.Close();
        }

        internal void Insert_Nations(SqlConnection connection)
        {
            string insert_nations = "INSERT INTO Nazioni (ID, Nome, Continente, Fuso_Orario) VALUES "
        }
    }
}
