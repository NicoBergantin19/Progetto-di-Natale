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

        private void radioEuropa_CheckedChanged(object sender, EventArgs e)
        {
            if (radioEuropa.Checked)
            {

            }
        }
    }
}
