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
using Newtonsoft.Json;
using System.IO;

namespace ProgettoNatale
{
    public partial class Bambini : Form
    {
        SqlConnection connection;
        string account;
        public Bambini(SqlConnection conn, string Tipo_Account)
        {
            InitializeComponent();
            connection = conn;
            account = Tipo_Account;
        }

        private void Bambini_Load(object sender, EventArgs e)
        {
            Visualizza("SELECT * FROM Bambini");
            if (account == "Amministratore")
                groupBox1.Visible = false;
            else
            {
                groupBox1.Visible = true;
                ComboBox_Add();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (groupBox1.Visible == false)
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

        private void button1_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(textBox1.Text) || String.IsNullOrWhiteSpace(textBox2.Text) || 
                String.IsNullOrWhiteSpace(textBox3.Text) || String.IsNullOrWhiteSpace(comboBox1.Text))
            {
                MessageBox.Show("Manca da inserire qualche dato", "Errore:", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            SqlCommand cmd = new SqlCommand($"INSERT INTO Bambini (Nome, Cognome, AGE, Nazione) VALUES ('{textBox1.Text}', '{textBox2.Text}', {Convert.ToInt32(textBox3.Text)}, '{comboBox1.Text}'", connection);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Bambino inserito correttamente", "Information:", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(textBox1.Text) || String.IsNullOrWhiteSpace(textBox2.Text) ||
                String.IsNullOrWhiteSpace(textBox3.Text) || String.IsNullOrWhiteSpace(comboBox1.Text))
            {
                MessageBox.Show("Manca da inserire qualche dato", "Errore:", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            SqlCommand cmd = new SqlCommand($"DELETE FROM Bambini WHERE Nome = '{textBox1.Text}' AND Cognome = '{textBox2.Text}' AND AGE = {Convert.ToInt32(textBox3.Text)} AND Nazione = '{comboBox1.Text}';");
            cmd.ExecuteNonQuery();
            MessageBox.Show("Bambino eliminato dal database correttamente", "Information:", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        ////////////////////////////////////////////////////////////////METODI/////////////////////////////////////////////////////////////

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

        internal void ComboBox_Add()
        {
            List<Nazioni> nazioni = JsonConvert.DeserializeObject<List<Nazioni>>(File.ReadAllText("ListaNazioni.json"));
            foreach (Nazioni aaa in nazioni)
            {
                comboBox1.Items.Add(aaa.Nome);
            }
        }
    }
}
