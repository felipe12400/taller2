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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            MostrarDatos1();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void MostrarDatos1()
        {
            ConexMySQL conex = new ConexMySQL();

            conex.open();

            DataTable dt = new DataTable();

            MySqlDataAdapter adapt = new MySqlDataAdapter("Select * from cliente;", conex.getConexion());

            adapt.Fill(dt);
            Datos.DataSource = dt;

            conex.close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string query = "INSERT INTO cliente VALUES(@valor1 ,@valor2,@valor3,@valor4,@valor5,@valor6)";

            ConexMySQL conex = new ConexMySQL();
            conex.open();
            MySqlCommand cmd = new MySqlCommand(query, conex.getConexion());

            cmd.Parameters.AddWithValue("@valor1", t.Text);
            cmd.Parameters.AddWithValue("@valor2", t2.Text);
            cmd.Parameters.AddWithValue("@valor3", textBox1.Text);
            cmd.Parameters.AddWithValue("@valor4", numericUpDown1.Value);
            cmd.Parameters.AddWithValue("@valor5", numericUpDown2.Value);
            cmd.Parameters.AddWithValue("@valor6", textBox2.Text);


            cmd.ExecuteNonQuery();
            conex.close();

            MostrarDatos1();
            MessageBox.Show("Se ingresaron los datos");
           
        }

        private void t_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void t2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Ventana2 f = new Ventana2();
            f.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string query = "Delete from cliente where rut = @valor;";

            ConexMySQL conex = new ConexMySQL();

            conex.open();

            MySqlCommand cmd = new MySqlCommand(query, conex.getConexion());

            MySqlCommand cmd2 = new MySqlCommand("Select rut From cliente Where rut = @valorAux", conex.getConexion());
            
            cmd2.Parameters.AddWithValue("@valorAux", textBox3.Text);

            cmd.Parameters.AddWithValue("@valor", textBox3.Text);

     
            string rut = cmd2.ExecuteScalar().ToString();

            if (rut == textBox3.Text)
            {
                cmd.ExecuteNonQuery();


                MessageBox.Show("Se a eliminado el alumno correctamente");
              
                MostrarDatos1();
            }
            else
            {
                MessageBox.Show("El rut no existe como para eliminarse");
            }
            conex.close();



            
            
        }

        private void Datos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            pantalla2 auto = new pantalla2();
            auto.Show();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
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

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
