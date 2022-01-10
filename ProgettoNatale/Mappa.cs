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
    public partial class Mappa : Form
    {
        SqlConnection connection;
        public Mappa(SqlConnection conn)
        {
            InitializeComponent();
            connection = conn;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Azioni aa = new Azioni(connection, "Amministratore");
            aa.Show();
            this.Hide();
        }

        private void Mappa_Load(object sender, EventArgs e)
        {

        }

        private void radioEuropa_Click(object sender, EventArgs e)
        {
            MostraContinente("Europe");
        }

        private void radioAfrica_Click(object sender, EventArgs e)
        {
            MostraContinente("Africa");
        }

        private void radioAsia_Click(object sender, EventArgs e)
        {
            MostraContinente("Asia");
        }

        private void radioOceania_Click(object sender, EventArgs e)
        {
            MostraContinente("Oceania");
        }       

        internal void MostraContinente(string continente)
        {
            Consegne consegne = new Consegne(connection, continente);
            consegne.Show();
        }

        private void radioAmerica_Click_1(object sender, EventArgs e)
        {
            MostraContinente("North America");
        }

        private void radioSUUU_Click(object sender, EventArgs e)
        {
            MostraContinente("South America");
        }

        private void radioAntartica_Click(object sender, EventArgs e)
        {
            MostraContinente("Antarctica");
        }
    }
}
