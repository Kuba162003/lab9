using System;
using System.Data;
using Microsoft.Data.SqlClient;
using static System.ComponentModel.Design.ObjectSelectorEditor;

namespace lab9
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=master;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
        public void ReadData()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT* FROM Users";
                SqlCommand command = new SqlCommand(query, connection);
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        int userId = reader.GetInt32(0); // Assuming Id is the first column
                        string userName = reader.GetString(1); // Assuming Name is the second column
                        Console.WriteLine($"User Id: {userId}, Name: {userName}");
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }
        }

        public void WriteData(string nazwisko_imie, string semestr_rok, string kierunek_stopien, string data, string przedmiot, string punkty, string prowadzacy, string uzasadnienie, string data_podpis, string sklad1, string sklad2, string sklad3, string data_decyzji, string pieczatka_podpis, string numer_albumu)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO [dbo].[Table] (nazwisko_imie, semestr_rok, kierunek_stopien, data, przedmiot, punkty, prowadzacy, uzasadnienie, data_podpis, sklad1, sklad2, sklad3, data_decyzji, pieczatka_podpis, numer_albumu) VALUES (@nazwisko_imie, @semestr_rok, @kierunek_stopien, @data, @przedmiot, @punkty, @prowadzacy, @uzasadnienie, @data_podpis, @sklad1, @sklad2, @sklad3, @data_decyzji, @pieczatka_podpis, @numer_albumu)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@nazwisko_imie", nazwisko_imie);
                command.Parameters.AddWithValue("@semestr_rok", semestr_rok);
                command.Parameters.AddWithValue("@kierunek_stopien", kierunek_stopien);
                command.Parameters.AddWithValue("@data", data);
                command.Parameters.AddWithValue("@przedmiot", przedmiot);
                command.Parameters.AddWithValue("@punkty", punkty);
                command.Parameters.AddWithValue("@prowadzacy", prowadzacy);
                command.Parameters.AddWithValue("@uzasadnienie", uzasadnienie);
                command.Parameters.AddWithValue("@data_podpis", data_podpis);
                command.Parameters.AddWithValue("@sklad1", sklad1);
                command.Parameters.AddWithValue("@sklad2", sklad2);
                command.Parameters.AddWithValue("@sklad3", sklad3);
                command.Parameters.AddWithValue("@data_decyzji", data_decyzji);
                command.Parameters.AddWithValue("@pieczatka_podpis", pieczatka_podpis);
                command.Parameters.AddWithValue("@numer_albumu", numer_albumu);
                try
                {
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    Console.WriteLine($"{rowsAffected} row(s) inserted.");
                    connection.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }
        }





        private void button1_Click(object sender, EventArgs e)
        {
            WriteData(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text, textBox6.Text, textBox7.Text, textBox8.Text, textBox9.Text, textBox10.Text, textBox11.Text, textBox12.Text, textBox13.Text, textBox14.Text, textBox15.Text);
            this.Close();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
