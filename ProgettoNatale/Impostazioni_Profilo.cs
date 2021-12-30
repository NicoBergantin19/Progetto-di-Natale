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

        }

        private void Back_Click(object sender, EventArgs e)
        {
            Azioni_Elfo azioni_Elfo = new Azioni_Elfo(connection);
            this.Close();
            azioni_Elfo.Show();
        }
    }
}
