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
using System.Security.Cryptography;

namespace ProgettoNatale
{
    public partial class Creazione_Account : Form
    {
        SqlConnection connection;
        public Creazione_Account(SqlConnection conn)
        {
            InitializeComponent();
            connection = conn;
        }

        internal static string Crittografia(string text)
        {
            var crypt = new SHA256Managed();
            var hash = new StringBuilder();
            byte[] crypto = crypt.ComputeHash(Encoding.UTF8.GetBytes(text));
            
            foreach (byte theByte in crypto)
                hash.Append(theByte.ToString("x2"));

            return hash.ToString();
        }

        private void Crea_Account_Click(object sender, EventArgs e)
        {
            string tipoAccount = "";
            if (connection.State != ConnectionState.Open)
                connection.Open();

            if (radioBabbo.Checked)
                tipoAccount = "Amministratore";
            else if (radioElfo.Checked)
                tipoAccount = "Lavoratore";
            if (!radioBabbo.Checked && !radioElfo.Checked)
            {
                MessageBox.Show("Non è stato inserito il tipo di account");
                return;
            }
            string passCritt = Crittografia(textBox2.Text);
            string query = $"INSERT INTO Account (Username, Password, Tipo_Account) VALUES ('{textBox1.Text}', '{passCritt}', '{tipoAccount}')";
            SqlCommand cmd = new SqlCommand(query, connection);
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (SqlException error)
            {
                MessageBox.Show(error.ToString());
            }

            if (connection.State == ConnectionState.Open)
                connection.Close();

            //Ritorna alla schermata di accesso 
            this.Hide();
        }

        private void radioBabbo_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
