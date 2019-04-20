using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fine
{
    public partial class Form1 : Form
    {
        SqlConnection sqlConnection;
        public Form1()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            if (dateTimePicker1.Text != "" && dateTimePicker2.Text != "" && dateTimePicker2.Text != "" && textBox5.Text != "" && textBox3.Text != "" && comboBox1.SelectedValue != "")
            {
                SqlCommand command1 = new SqlCommand("INSERT INTO  [fine] (data_fine,type_nar,Raz_fine,Id_avto, Time) VALUES(@data_fine,@type_nar,@Raz_fine,@Id_avto,@Time)", sqlConnection);
                command1.Parameters.AddWithValue("data_fine", dateTimePicker1.Value);
                command1.Parameters.AddWithValue("Time", dateTimePicker2.Value);
                command1.Parameters.AddWithValue("type_nar", textBox5.Text);
                command1.Parameters.AddWithValue("Raz_fine", textBox3.Text);
                command1.Parameters.AddWithValue("Id_avto", comboBox1.SelectedValue);
                await command1.ExecuteNonQueryAsync();
                MessageBox.Show("Вы оформили штраф",
      "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Вы не заполнели один из полей",
        "Предуприждение", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "fineDataSet.Avto". При необходимости она может быть перемещена или удалена.
            this.avtoTableAdapter.Fill(this.fineDataSet.Avto);
            String connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\10150320\source\repos\Fine\Fine\fine.mdf;Integrated Security=True;Connect Timeout=30";
            sqlConnection = new SqlConnection(connectionString);
            await sqlConnection.OpenAsync();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
