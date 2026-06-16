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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Practica
{
    public partial class EliminarCita : Form
    {
        public EliminarCita()
        {
            InitializeComponent();
        }

        private void EliminarCita_Load(object sender, EventArgs e)
        {

            dataGridView1.DataSource = Gestion.MostrarCitas(); //Cargar en el DataGridView todas las citas
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Mensaje de confirmacion al intentar eliminar una cita
            DialogResult result = MessageBox.Show("Estás a punto de eliminar una cita, ¿estás seguro?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                int retorna = 0;
                string filtro = textBox1.Text;
                using (SqlConnection conexion = BaseDatos.ObtenerConexion())
                {
                    //Consulta para eliminar la cita seleccionada
                    string query = @"DELETE FROM Citas WHERE ID LIKE @filtro";

                    SqlCommand command = new SqlCommand(query, conexion);

                    command.Parameters.AddWithValue("@filtro", "%" + filtro + "%");
                    retorna = command.ExecuteNonQuery();
                }
                if(retorna > 0)
                {
                    MessageBox.Show("Cita eliminada exitosamente"); //Mensaje de confirmacion
                    dataGridView1.DataSource = Gestion.MostrarCitas();
                    textBox1.Text=string.Empty;
                }
                
            }
        }

            

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells["ID"].Value.ToString(); //Colocar en el textbox el ID de la cita seleccionada
        }
    }
}
