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
    public partial class Bambini : Form
    {
        SqlConnection connection;
        public Bambini(SqlConnection conn)
        {
            InitializeComponent();
            connection = conn;
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
        internal void Inserimento_Bambini()
        {

        }
        private void Bambini_Load(object sender, EventArgs e)
        {
            Visualizza("SELECT * FROM Bambini");
        }
    }
}
