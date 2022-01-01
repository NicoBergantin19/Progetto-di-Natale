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
        public Consegne(SqlConnection conn)
        {
            InitializeComponent();
            connection = conn;
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

        }


        //////////////////////////////////METODI///////////////////////////////////////////////////////
        internal void Assegna_Regalo()
        {
            string query = "SELECT "
        }

    }
}
