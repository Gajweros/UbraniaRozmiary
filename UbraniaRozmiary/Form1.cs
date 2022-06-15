using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SQLite;
namespace UbraniaRozmiary
{
    public partial class Form1 : Form
    {


        SQLiteConnection m_dbConnection;

        public Form1()
        {
            InitializeComponent();

            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            textBox1.Visible = false;
            zaladujRodzajeUbran();

        }

        private void Form1_Load(object sender, EventArgs e)
        {

            if (System.IO.File.Exists("dane.sqlite") == false)
            {
                utworzBazeDanych();
                polaczZBaza();
                utworzTabele();

            }

            numericUpDown1.TextChanged += new EventHandler(numericUpDown1_TextChanged);


        }








        void utworzBazeDanych()
        {
            SQLiteConnection.CreateFile("dane.sqlite");
        }


        void polaczZBaza()
        {
            m_dbConnection = new SQLiteConnection("Data Source=dane.sqlite;Version=3;");
            m_dbConnection.Open();
        }

 
        void utworzTabele()
        {




            string sql = "create table adiddas(id INTEGER  PRIMARY KEY, Rozmiar varchar(10),  Koszulki INTEGER, Bluzy INTEGER,  Spodnie INTEGER )";
            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            command.ExecuteNonQuery();

            sql = "create table nike(id INTEGER  PRIMARY KEY, Rozmiar varchar(10),  Koszulki INTEGER, Bluzy INTEGER,  Spodnie INTEGER )";
            command = new SQLiteCommand(sql, m_dbConnection);
            command.ExecuteNonQuery();



            sql = "insert into adiddas(id, Rozmiar, Koszulki, Bluzy, Spodnie ) values (NULL, 'XS', '164', '164', '164')";
            command = new SQLiteCommand(sql, m_dbConnection);
            command.ExecuteNonQuery();
           
            sql = "insert into adiddas(id, Rozmiar, Koszulki, Bluzy, Spodnie ) values (NULL, 'S', '170', '170', '170')";
            command = new SQLiteCommand(sql, m_dbConnection);
            command.ExecuteNonQuery();

            sql = "insert into adiddas(id, Rozmiar, Koszulki, Bluzy, Spodnie ) values (NULL, 'M', '176', '176', '176')";
            command = new SQLiteCommand(sql, m_dbConnection);
            command.ExecuteNonQuery();
           
            sql = "insert into adiddas(id, Rozmiar, Koszulki, Bluzy, Spodnie ) values (NULL, 'L', '182', '182', '182')";
            command = new SQLiteCommand(sql, m_dbConnection);
            command.ExecuteNonQuery();
           
            sql = "insert into adiddas(id, Rozmiar, Koszulki, Bluzy, Spodnie ) values (NULL, 'XL', '188', '188', '188')";
            command = new SQLiteCommand(sql, m_dbConnection);
            command.ExecuteNonQuery();
          
            sql = "insert into adiddas(id, Rozmiar, Koszulki, Bluzy, Spodnie ) values (NULL, 'XXL', '192', '192', '192')";
            command = new SQLiteCommand(sql,  m_dbConnection);
            command.ExecuteNonQuery();

            sql = "insert into nike(id, Rozmiar, Koszulki, Bluzy, Spodnie ) values (NULL, 'XS', '168', '168', '168')";
            command = new SQLiteCommand(sql, m_dbConnection);
            command.ExecuteNonQuery();

            sql = "insert into nike(id, Rozmiar, Koszulki, Bluzy, Spodnie ) values(NULL, 'S', 173, 173, 173)";
            command = new SQLiteCommand(sql, m_dbConnection);
            command.ExecuteNonQuery();
            
            sql = "insert into nike(id, Rozmiar, Koszulki, Bluzy, Spodnie ) values(NULL, 'M', 178, 178, 178)";
            command = new SQLiteCommand(sql, m_dbConnection);
            command.ExecuteNonQuery();
            
            sql = "insert into nike(id, Rozmiar, Koszulki, Bluzy, Spodnie ) values(NULL, 'L', 183, 183, 183)";
            command = new SQLiteCommand(sql, m_dbConnection);
            command.ExecuteNonQuery();
            
            sql = "insert into nike(id, Rozmiar, Koszulki, Bluzy, Spodnie ) values(NULL, 'XL', 188, 188, 188)";
            command = new SQLiteCommand(sql, m_dbConnection);
            command.ExecuteNonQuery();
            
            sql = "insert into nike(id, Rozmiar, Koszulki, Bluzy, Spodnie ) values(NULL, 'XXL',  193, 193, 193)";
            command = new SQLiteCommand(sql,  m_dbConnection);
            command.ExecuteNonQuery();     
            
            
            command.Dispose();
            command = null;







            m_dbConnection.Close();

        }



        private void zaladujRodzajeUbran()
        {


            comboBox1.Items.Add("Koszulki");
            comboBox1.Items.Add("Bluzy");
            comboBox1.Items.Add("Spodnie");
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
           // wyszukaj();

        }








        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            wyszukaj();
        }





        void numericUpDown1_TextChanged(object sender, EventArgs e)
        {
            wyszukaj();
        }









        private void wyszukaj()
        {


            int wzrost = Convert.ToInt32(numericUpDown1.Value);

            string wybrane_ubranie = "" + comboBox1.Text;
            if (!wybrane_ubranie.Equals(""))
            {


                polaczZBaza();


                string query1 = "";
                string query2 = "";

                string rozmiar1 = "";
                string rozmiar2 = "";

                query1 = "SELECT  Rozmiar from adiddas where " + wybrane_ubranie + "='" + wzrost + "' ";
                query2 = "SELECT  Rozmiar from nike where " + wybrane_ubranie + "='" + wzrost + "' ";


                SQLiteCommand command1 = new SQLiteCommand(query1, m_dbConnection);
                SQLiteDataReader reader1 = command1.ExecuteReader();

                int lp = 1;



                while (reader1.Read())
                {

                    rozmiar1 = "" + reader1["Rozmiar"];


                }
                reader1.Close();
                reader1.Dispose();
                reader1 = null;



                command1 = new SQLiteCommand(query2, m_dbConnection);
                reader1 = command1.ExecuteReader();





                while (reader1.Read())
                {

                    rozmiar2 = "" + reader1["Rozmiar"];


                }
                reader1.Close();
                reader1.Dispose();
                reader1 = null;



                command1.Dispose();
                command1 = null;



                m_dbConnection.Close();
                m_dbConnection.Dispose();
                m_dbConnection = null;

                string wynik = "";

                if (!rozmiar2.Equals(""))
                {
                    wynik = "Nike: " + rozmiar2 + Environment.NewLine;

                }
                if (!rozmiar1.Equals(""))
                {
                    wynik += "Adidas: " + rozmiar1 + Environment.NewLine;

                }

                if (!wynik.Equals(""))
                {

                    wynik = "Dla Twojego wzrostu odpowiednie będzie ubranie o rozmiarze:" + Environment.NewLine + wynik; ;


                    MessageBox.Show(wynik);
                    textBox1.Visible = true;
                }
                else
                {
                    textBox1.Visible = false;


                }


                textBox1.Text = wynik;


            }
            else
            {
                textBox1.Visible = false;
                MessageBox.Show("Wybierz rodzaj ubrania!");

            }


        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
