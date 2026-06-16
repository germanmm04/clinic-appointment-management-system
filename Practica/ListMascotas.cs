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
    public partial class ListMascotas : Form
    {
        public ListMascotas()
        {
            InitializeComponent();
        }

        private void ListMascotas_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = Gestion.MostrarMascotas();
        }

        private void button1_Click(object sender, EventArgs e) //Mismo funcionamiento que MostrarMascotas()
        {
            List<Mascota> mascotas = new List<Mascota>();
            string filtro = textBox1.Text.Trim();

            using (SqlConnection conexion = BaseDatos.ObtenerConexion())
            {
                string query = "SELECT ID, Nombre, Especie, Raza, Nacimiento, Notas, DNICliente FROM Mascotas WHERE DNICliente LIKE @filtro";

                using (SqlCommand command = new SqlCommand(query, conexion))
                {

                    command.Parameters.AddWithValue("@filtro", "%" + filtro + "%");


                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Mascota mascota = new Mascota
                            {
                                ID = reader.GetInt32(0),
                                Nombre = reader.GetString(1),
                                Especie = reader.GetString(2),
                                Raza = reader.GetString(3),
                                FechaNac = reader.GetDateTime(4),
                                Notas = reader.GetString(5),
                                DNICliente = reader.GetString(6)
                            };
                            mascotas.Add(mascota);
                        }
                    }
                }
            }
            dataGridView1.DataSource = mascotas;
        }
    }
}
