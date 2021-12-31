﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;
using System.Security.Cryptography;

namespace ProgettoNatale
{
    public partial class Form1 : Form
    {
        SqlConnection connectionDatabase = new SqlConnection("Data Source=.;Integrated Security=True");
        SqlConnection connectionTabelle = new SqlConnection("Data Source=.;Initial Catalog=Natale;Integrated Security=True");
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Quando si preme il bottone "Accedi" viene creato il Databse "Natale" con 
        /// le varie tabelle utili
        /// </summary>
        private void button1_Click(object sender, EventArgs e)
        {
            if (connectionTabelle.State != ConnectionState.Open)
            {
                try
                {
                    connectionTabelle.Open();
                }
                catch (SqlException error)
                {
                    MessageBox.Show(error.ToString());
                }
            }

            //Controllo esistenza account nel database
            string query = "SELECT ID_Account FROM Account;";
            SqlCommand cmd = new SqlCommand(query, connectionTabelle);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows == false)
            {
                dr.Close();
                cmd.Cancel();
                MessageBox.Show("Non è presente nessun tipo di account\n\tCrea il tuo account");
                return;
            }
            else
            {
                dr.Close();
                cmd.Cancel();

                //Operazioni principali dell'accesso 
                try
                {
                    Check_Account(connectionTabelle);
                    Nations_Table(connectionTabelle);
                    Kids_Table(connectionTabelle);
                    Gifts_Table(connectionTabelle);
                }
                catch (SqlException error)
                {
                    MessageBox.Show(error.ToString());
                }
            }
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

        internal void Check_Account(SqlConnection connection)
        {
            string passCrip = Crittografia(textBox2.Text);
            //Attraverso la select cerca nella tabella i dati inseriti dall'utente
            SqlDataAdapter sda = new SqlDataAdapter($"SELECT Tipo_Account FROM Account WHERE Username= '{textBox1.Text}' AND Password='{passCrip}'", connection);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count == 1)
            {
                switch (dt.Rows[0]["Tipo_Account"].ToString())
                {
                    case "Amministratore":
                        this.Hide();
                        Azioni aa = new Azioni(connectionTabelle, "Amministratore");
                        aa.Show();
                        break;

                    case "Lavoratore":
                        this.Hide();
                        Azioni_Elfo ae = new Azioni_Elfo(connectionTabelle, "Lavoratore");
                        ae.Show();
                        break;
                }
            }
            else
            {
                MessageBox.Show("Username o password non valido", "Error:", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        internal void Gifts_Table(SqlConnection connection)
        {
            string query = @"SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Regali';"; //query per vedere se esiste una tabella chiamata "Regali"
                                                                                                    //se il reader restituisce delle righe vuol dire che esiste
            SqlCommand controllo = new SqlCommand(query, connection);
            SqlDataReader reader = controllo.ExecuteReader();
            if (reader.HasRows == false)    //Controllo esistenza tabella
            {
                reader.Close();
                controllo.Cancel();
                string tab_regali = "CREATE TABLE Regali(ID_Regalo int IDENTITY(1,1), Tipo varchar(MAX) NOT NULL, Categoria varchar(MAX), Bonta int, PRIMARY KEY(ID_Regalo));"; //query creazione tabella
                SqlCommand cmd = new SqlCommand(tab_regali, connection);
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (SqlException error)
                {
                    MessageBox.Show("Errore nel generare la tabella nazioni: " + error.ToString());
                }
            }
            else
                reader.Close();
        }

        internal void Nations_Table(SqlConnection connection)   //Creazione della tabella "Nazioni" 
        {
            string query = @"SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Nazioni';"; //query per vedere se esiste una tabella chiamata "Nazioni"
                                                                                                     //se il reader restituisce delle righe vuol dire che esiste
            SqlCommand controllo = new SqlCommand(query, connection);
            SqlDataReader reader = controllo.ExecuteReader();
            if (reader.HasRows == false)    //Controllo esistenza tabella
            {
                reader.Close();
                controllo.Cancel();
                string tab_nazioni = "CREATE TABLE Nazioni(ID_Nazione int IDENTITY(1,1), Nome varchar(MAX) NOT NULL, Continente varchar(30) NOT NULL, Fuso_Orario varchar(30) NOT NULL, PRIMARY KEY(ID_Nazione));"; //query creazione tabella
                SqlCommand cmd = new SqlCommand(tab_nazioni, connection);
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (SqlException error)
                {
                    MessageBox.Show("Errore nel generare la tabella nazioni: " + error.ToString());
                }
            }
            else
                reader.Close();
        }

        internal void Kids_Table(SqlConnection connection)  //Creazione della tabella "Bambini" 
        {
            string query = "SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Bambini';";
            SqlCommand controllo = new SqlCommand(query, connection);
            SqlDataReader reader = controllo.ExecuteReader();
            if (reader.HasRows == false)
            {
                reader.Close();
                controllo.Cancel();
                string tab_bambini = "CREATE TABLE Bambini(ID_Bambino int IDENTITY(1,1), Nome varchar(30) NOT NULL,Cognome varchar(30) NOT NULL,AGE int NOT NULL, Nazione varchar(30), Bonta int NOT NULL, PRIMARY KEY(ID_Bambino));";
                SqlCommand cmd = new SqlCommand(tab_bambini, connection);
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (SqlException error)
                {
                    MessageBox.Show("Errore nel generare la tabella dei Bambini: " + error.ToString());
                }
            }
            else
                reader.Close();
        }

        internal void Account_Table()
        {
            try
            {
                connectionTabelle.Open();
            }
            catch (SqlException error)
            {
                MessageBox.Show("Errore nell'istanziare la connessione per la tabella degli account: " + error.ToString());
            }

            string query = "SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Account';";
            SqlCommand controllo = new SqlCommand(query, connectionTabelle);
            SqlDataReader reader = controllo.ExecuteReader();
            if (reader.HasRows == false)
            {
                reader.Close();
                controllo.Cancel();
                string tab_account = "CREATE TABLE Account(ID_Account int IDENTITY(1,1), Username varchar(MAX) NOT NULL,Password varchar(MAX) NOT NULL, Tipo_Account varchar(20) NOT NULL,  PRIMARY KEY(ID_Account));";
                SqlCommand cmd = new SqlCommand(tab_account, connectionTabelle);
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (SqlException error)
                {
                    MessageBox.Show("Errore nel generare la tabella degli Account: " + error.ToString());
                }
            }
            else
                reader.Close();

            connectionTabelle.Close();
        }

        /// <summary>
        /// Quando il form "Accedi" si apre viene creato il database 
        /// in automatico 
        /// </summary>
        private void Form1_Load(object sender, EventArgs e)
        {
            //Connessione al database master
            try
            {
                connectionDatabase.Open();
            }
            catch (SqlException error)
            {
                MessageBox.Show(error.ToString());
            }
            //Viene controllato se il database Natale esiste e se non esiste lo crea
            string query = "IF NOT EXISTS(SELECT * FROM sys.databases where name = 'Natale') CREATE DATABASE Natale";
            SqlCommand cmd = new SqlCommand(query, connectionDatabase);
            try
            {
                cmd.ExecuteNonQuery();
                connectionDatabase.Close();
            }
            catch (SqlException error)
            {
                MessageBox.Show("Errore nel generare il database: " + error.ToString());
            }

            Account_Table();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Creazione_Account creazione_Account = new Creazione_Account(connectionTabelle);
            creazione_Account.Show();
        }
    }
}
