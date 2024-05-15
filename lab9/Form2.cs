using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab9
{
    public partial class Form2 : Form
    {
        string connectionS;
        public Form2()
        {
            InitializeComponent();
        }
        public Form2(string conString)
        {
            InitializeComponent();
            connectionS = conString;
            ReadData();
        }
        public void ReadData()
        {
            using (SqlConnection connection = new SqlConnection(connectionS))
            {
                string query = "SELECT* FROM [dbo].[Tabela]";
                SqlCommand command = new SqlCommand(query, connection);
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        int userId = reader.GetInt32(0); // Assuming Id is the first column
                        string nazwisko_imie = reader.GetString(1);
                        string semestr_rok = reader.GetString(2);
                        string kierunek_stopien = reader.GetString(3);
                        string data = reader.GetString(4);
                        string przedmiot = reader.GetString(5);
                        string punkty = reader.GetString(6);
                        string prowadzacy = reader.GetString(7);
                        string uzasadnienie = reader.GetString(8);
                        string data_podpis = reader.GetString(9);
                        string sklad1 = reader.GetString(10);
                        string sklad2 = reader.GetString(11);
                        string sklad3 = reader.GetString(12);
                        string data_decyzji = reader.GetString(13);
                        string pieczatka_podpis = reader.GetString(14);
                        string numer_albumu = reader.GetString(15);
                        dataGridView1.Rows.Add(new object[] { nazwisko_imie, semestr_rok, kierunek_stopien, data, przedmiot, punkty, prowadzacy, uzasadnienie, data_podpis, sklad1, sklad2, sklad3, data_decyzji, pieczatka_podpis, numer_albumu });
                    }
                    reader.Close();
                    connection.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }
        }
    }
}
