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
    public partial class pantalla2 : Form
    {
        public pantalla2()
        {
            InitializeComponent();
            MostrarDatos1();
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void MostrarDatos1()
        {
            ConexMySQL conex = new ConexMySQL();

            conex.open();

            DataTable dt = new DataTable();

            MySqlDataAdapter adapt = new MySqlDataAdapter("Select * from automovil;", conex.getConexion());

            adapt.Fill(dt);
            Datos.DataSource = dt;

            conex.close();
        }




        private void button1_Click(object sender, EventArgs e)
        {
            string query = "INSERT INTO automovil VALUES(@valor1 ,@valor2,@valor3,@valor4,@valor5,@valor6,@valor7,@valor8)";

            ConexMySQL conex = new ConexMySQL();
            conex.open();
            MySqlCommand cmd = new MySqlCommand(query, conex.getConexion());

            cmd.Parameters.AddWithValue("@valor1", t.Text);
            cmd.Parameters.AddWithValue("@valor2", numericUpDown4.Value);
            cmd.Parameters.AddWithValue("@valor3", t2.Text);
            cmd.Parameters.AddWithValue("@valor4", textBox2.Text);
            cmd.Parameters.AddWithValue("@valor5", numericUpDown3.Value);
            cmd.Parameters.AddWithValue("@valor6", textBox1.Text);
            cmd.Parameters.AddWithValue("@valor7", numericUpDown1.Value);
            cmd.Parameters.AddWithValue("@valor8", numericUpDown2.Value);


            cmd.ExecuteNonQuery();
            conex.close();

            MostrarDatos1();
            MessageBox.Show("Se ingresaron los datos");







        }

        private void t_TextChanged(object sender, EventArgs e)
        {

        }

        private void numericUpDown4_ValueChanged(object sender, EventArgs e)
        {

        }

        private void t2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

            string query = "Delete from automovil where Patente = @valor;";

            ConexMySQL conex = new ConexMySQL();

            conex.open();

            MySqlCommand cmd = new MySqlCommand(query, conex.getConexion());

            MySqlCommand cmd2 = new MySqlCommand("Select Patente From automovil Where Patente = @valorAux", conex.getConexion());

            cmd2.Parameters.AddWithValue("@valorAux", textBox3.Text);

            cmd.Parameters.AddWithValue("@valor", textBox3.Text);


            string Patente = cmd2.ExecuteScalar().ToString();

            if (Patente == textBox3.Text)
            {
                cmd.ExecuteNonQuery();


                MessageBox.Show("Se a eliminado el automovil correctamente");

                MostrarDatos1();
            }
            else
            {
                MessageBox.Show("La Patente no existe como para eliminarse");
            }
            conex.close();













        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
