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

namespace Practica
{
    public partial class EliminarCliente : Form
    {
        public EliminarCliente()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) //Mismo funcionamiento que EliminarCita
        {
            DialogResult result = MessageBox.Show("Estás a punto de eliminar un cliente, ¿estás seguro?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    int retorna = 0;
                    string filtro = textBox1.Text;
                    using (SqlConnection conexion = BaseDatos.ObtenerConexion())
                    {

                        string query = @"DELETE FROM Clientes WHERE DNI LIKE @filtro";

                        SqlCommand command = new SqlCommand(query, conexion);

                        command.Parameters.AddWithValue("@filtro", "%" + filtro + "%");
                        retorna = command.ExecuteNonQuery();
                    }
                    if (retorna > 0)
                    {
                        MessageBox.Show("Cliente eliminado exitosamente");
                        dataGridView1.DataSource = Gestion.MostrarClientes();
                        textBox1.Text=string.Empty;
                    }
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se puede eliminar el cliente ya que tiene mascotas o citas asociadas");
                }
            }        
        }

        private void EliminarCliente_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = Gestion.MostrarClientes();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells["DNI"].Value.ToString();
        }
    }
}
