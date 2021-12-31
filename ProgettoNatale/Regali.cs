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
    public partial class Regali : Form
    {
        SqlConnection connection;
        string account;
        public Regali(SqlConnection conn, string Tipo_Account)
        {
            InitializeComponent();
            connection = conn;
            account = Tipo_Account;
        }

        internal void Visualizza(string QuerySql)
        {
            SqlCommand cmd = new SqlCommand(QuerySql, connection);
            SqlDataReader dataReader;
            DataTable dt = new DataTable();
            dataReader = cmd.ExecuteReader();
            dt.Load(dataReader);
            dataGridView1.DataSource = dt;

            dataReader.Close();
        }

        private void Regali_Load(object sender, EventArgs e)    //Controlla con quale tipo di account si è entrati 
        {
            Visualizza("SELECT * FROM Regali");

            if(account == "Amministratore")
                groupBox2.Visible = false;
            else
                groupBox2.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)  //Controlla su quale home tornare
        {
            if (groupBox2.Visible == false)
            {
                Azioni aa = new Azioni(connection, "Amministratore");
                aa.Show();
                this.Hide();
            }
            else
            {
                Azioni_Elfo ae = new Azioni_Elfo(connection, "Lavoratore");
                ae.Show();
                this.Hide();
            }
        }

        private void button3_Click(object sender, EventArgs e)  //Aggiungi regalo
        {
            if (String.IsNullOrWhiteSpace(textBox5.Text) || String.IsNullOrWhiteSpace(textBox6.Text) || String.IsNullOrWhiteSpace(textBox7.Text))
            {
                MessageBox.Show("Manca da inserire qualche dato", "Errore:", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; 
            }
            SqlCommand cmd = new SqlCommand($"INSERT INTO Regali (Tipo, Categoria, Bonta) VALUES ('{textBox5.Text}', '{textBox6.Text}', {Convert.ToInt32(textBox7.Text)});", connection);
            cmd.ExecuteNonQuery();
            MessageBox.Show("L'oggetto è stato inserito correttamente");
            Visualizza("SELECT * FROM Regali");
        }
    }
}
