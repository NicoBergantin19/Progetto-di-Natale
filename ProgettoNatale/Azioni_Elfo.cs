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
            Azioni azioni = new Azioni(connection);
            azioni.Insert_Kids(connection);

            Bambini bambini = new Bambini(connection);
            this.Hide();
            bambini.Show();
        }

        private void View_Gifts_Click(object sender, EventArgs e)
        {
            Azioni azioni = new Azioni(connection);
            azioni.Insert_Gifts(connection);

            Regali regali = new Regali(connection);
            this.Hide();
            regali.Show();
        }

        private void Impostazioni_Profilo_Click(object sender, EventArgs e)
        {
            Impostazioni_Profilo button = new Impostazioni_Profilo(connection);
            this.Hide();
            button.Show();
        }
    }
}
