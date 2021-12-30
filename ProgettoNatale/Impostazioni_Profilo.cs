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
    public partial class Impostazioni_Profilo : Form
    {
        SqlConnection connection;
        public Impostazioni_Profilo(SqlConnection conn)
        {
            InitializeComponent();
            connection = conn;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(textBox4.Text) || String.IsNullOrWhiteSpace(textBox2.Text))
            {
                MessageBox.Show("\tInserisci una nuova password\n\tSe non la vuoi cambiare riscrivila");
                return;
            }
            if (String.IsNullOrWhiteSpace(textBox1.Text) || String.IsNullOrWhiteSpace(textBox3.Text))
            {
                MessageBox.Show("\tInserisci un nuovo username\n\tSe non lo vuoi cambiare riscrivilo");
                return;
            }
            string passcrip = Crittografia(textBox2.Text);
            string nuovapass = Crittografia(textBox4.Text);
            SqlCommand cmd = new SqlCommand($"UPDATE Account SET Username = '{textBox3.Text}', Password = '{nuovapass}' WHERE Username = '{textBox1.Text}' AND Password = '{passcrip}'", connection);
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (SqlException error)
            {
                MessageBox.Show(error.Message);
            }

            Azioni_Elfo azioni_Elfo = new Azioni_Elfo(connection);
            azioni_Elfo.Show();
            this.Hide();
        }

        private void Back_Click(object sender, EventArgs e)
        {
            Azioni_Elfo azioni_Elfo = new Azioni_Elfo(connection);
            this.Close();
            azioni_Elfo.Show();
        }

        internal static string Crittografia(string text)    //Va a crittografare una stringa 
        {
            var crypt = new SHA256Managed();
            var hash = new StringBuilder();
            byte[] crypto = crypt.ComputeHash(Encoding.UTF8.GetBytes(text));

            foreach (byte theByte in crypto)
                hash.Append(theByte.ToString("x2"));

            return hash.ToString();
        }
    }
}
