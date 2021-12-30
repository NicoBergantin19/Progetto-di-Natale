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
    public partial class Azioni_Elfo : Form
    {
        SqlConnection connection;
        public Azioni_Elfo(SqlConnection conn)
        {
            InitializeComponent();
            connection = conn;
        }

        private void View_Kids_Click(object sender, EventArgs e)
        {

        }
    }
}
