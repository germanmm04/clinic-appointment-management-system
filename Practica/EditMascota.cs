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
    public partial class EditMascota : Form
    {
        public EditMascota()
        {
            InitializeComponent();
            FechaNac.MaxDate = DateTime.Now;
        }

        private void EditMascota_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = Gestion.MostrarMascotas(); //Mostrar las mascotas registradas en el DataGridView
        }

        private void button1_Click(object sender, EventArgs e) //Mismo funcionamiento que EditCliente
        {
            if (textCliente.Text == "" || textEspecie.Text == "" || textNombre.Text == "" || textRaza.Text == "")
            {
                MessageBox.Show("Debes rellenar todos los campos");
            }
            else
            {
                bool validado = true;

                if (textNombre.Text.Any(char.IsDigit))
                {
                    MessageBox.Show("El campo Nombre no puede contener números.");
                    textNombre.Focus();
                    validado = false;
                }
                if (textEspecie.Text.Any(char.IsDigit))
                {
                    MessageBox.Show("El campo Especie no puede contener números");
                    textEspecie.Focus();
                    validado = false;
                }
                if (textRaza.Text.Any(char.IsDigit))
                {
                    MessageBox.Show("El campo Raza no puede contener números");
                    textRaza.Focus();
                    validado = false;
                }

                if (validado)
                {
                    try
                    {
                        Mascota mascota = new Mascota();

                        mascota.ID = Convert.ToInt32(textID.Text);
                        mascota.Nombre = textNombre.Text.ToUpper();
                        mascota.Especie = textEspecie.Text.ToUpper();
                        mascota.Raza = textRaza.Text.ToUpper();
                        mascota.FechaNac = FechaNac.Value;
                        mascota.DNICliente = textCliente.Text.ToUpper();
                        mascota.Notas = textNotas.Text.ToUpper();


                        int result = Gestion.editMascota(mascota);

                        if (result > 0)
                        {
                            MessageBox.Show("Mascota modificada exitosamente");
                            dataGridView1.DataSource = Gestion.MostrarMascotas();
                        }
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show("No se puede añadir la mascota debido a que no se encuentra un cliente con ese DNI");
                    }
                }
            }  
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e) 
        {
            textID.Text =Convert.ToString(dataGridView1.CurrentRow.Cells["ID"].Value);
            textNombre.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["Nombre"].Value);
            textEspecie.Text=Convert.ToString(dataGridView1.CurrentRow.Cells["Especie"].Value);
            textRaza.Text=Convert.ToString(dataGridView1.CurrentRow.Cells["Raza"].Value);
            FechaNac.Value=Convert.ToDateTime(dataGridView1.CurrentRow.Cells["FechaNac"].Value);
            textCliente.Text=Convert.ToString(dataGridView1.CurrentRow.Cells["DNICliente"].Value);
            textNotas.Text=Convert.ToString(dataGridView1.CurrentRow.Cells["Notas"].Value);
            
        }
    }
}
