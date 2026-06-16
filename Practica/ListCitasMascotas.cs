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
    public partial class ListCitasMascotas : Form
    {
        public ListCitasMascotas()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) //Mismo funcionamiento que MostrarCitas()
        {
            List<Citas> citas = new List<Citas>();
            string filtro = textBox1.Text;

            using (SqlConnection conexion = BaseDatos.ObtenerConexion())
            {
                string query = "SELECT Fecha, Motivo, Observaciones, DNICliente, MascotasID FROM Citas WHERE MascotasID LIKE @filtro";

                using (SqlCommand command = new SqlCommand(query, conexion))
                {

                    command.Parameters.AddWithValue("@filtro", "%" + filtro + "%");


                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {

                            Citas cita = new Citas
                            {
                                FechaHora = reader.GetDateTime(0),
                                Motivo = reader.GetString(1),
                                Observaciones = reader.GetString(2),
                                DNICliente = reader.GetString(3),
                                MascotasID = reader.GetInt32(4)
                            };
                            citas.Add(cita);
                        }
                    }
                }
            }
            dataGridView1.DataSource = citas;
            textBox1.Text = "";
        }

        private void ListCitasMascotas_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = Gestion.MostrarCitas();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells["MascotasID"].Value.ToString();
        }
    }
}
