using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1;
using MySql.Data.MySqlClient;

namespace Ayudantia
{
    public partial class Ventana2 : Form
    {
        public Ventana2()
        {
            InitializeComponent();
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "yyyy-MM-dd";
            dateTimePicker2.Format = DateTimePickerFormat.Custom;
            dateTimePicker2.CustomFormat = "yyyy-MM-dd";
            MostrarDatos1();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void Datos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void MostrarDatos1()
        {
            ConexMySQL conex = new ConexMySQL();

            conex.open();

            DataTable dt = new DataTable();

            MySqlDataAdapter adapt = new MySqlDataAdapter("Select * from reserva;", conex.getConexion());

            adapt.Fill(dt);
            Datos.DataSource = dt;

            conex.close();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string query = "insert into reserva (fecha_inicio,fecha_final,Precio,Cliente_rut) VALUES(@valor1 ,@valor2,@valor3,@valor4)";

            ConexMySQL conex = new ConexMySQL();
            conex.open();
            MySqlCommand cmd = new MySqlCommand(query, conex.getConexion());

            cmd.Parameters.AddWithValue("@valor1", dateTimePicker1.Value);
            cmd.Parameters.AddWithValue("@valor2", dateTimePicker2.Value);
            cmd.Parameters.AddWithValue("@valor3", numericUpDown2.Value);
            cmd.Parameters.AddWithValue("@valor4", textBox2.Text);
            


            cmd.ExecuteNonQuery();
            conex.close();

            MostrarDatos1();
            MessageBox.Show("Se ingresaron los datos");











        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            string query = "Delete from reserva where id_reserva = @valor;";

            ConexMySQL conex = new ConexMySQL();

            conex.open();

            MySqlCommand cmd = new MySqlCommand(query, conex.getConexion());

            MySqlCommand cmd2 = new MySqlCommand("Select id_reserva From reserva Where id_reserva = @valorAux", conex.getConexion());

            cmd2.Parameters.AddWithValue("@valorAux", numericUpDown1.Value);

            cmd.Parameters.AddWithValue("@valor", numericUpDown1.Value);

            string me = cmd2.ExecuteScalar().ToString();
            int rut = Int16.Parse(me);

            if (rut == numericUpDown1.Value)
            {
                cmd.ExecuteNonQuery();


                MessageBox.Show("Se a eliminado La reserva correctamente");

                MostrarDatos1();
            }
            else
            {
                MessageBox.Show("La Reserva no existe como para eliminarse");
            }
            conex.close();












        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
