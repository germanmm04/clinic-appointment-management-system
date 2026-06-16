using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Practica
{
    public partial class EditCliente : Form
    {
        public EditCliente()
        {
            InitializeComponent();
        }

        private void EditCliente_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = Gestion.MostrarClientes();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e) //Añadir a los textbox el contenido actual del cliente para modificarlo
        {
            textDni.Text=Convert.ToString(dataGridView1.CurrentRow.Cells["DNI"].Value);
            textNombre.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["Nombre"].Value);
            textApellidos.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["Apellidos"].Value);
            textDireccion.Text=Convert.ToString(dataGridView1.CurrentRow.Cells["Direccion"].Value);
            textTelefono.Text=Convert.ToString(dataGridView1.CurrentRow.Cells["Telefono"].Value);
            textCP.Text=Convert.ToString(dataGridView1.CurrentRow.Cells["CodigoPostal"].Value);
            textLocalidad.Text=Convert.ToString(dataGridView1.CurrentRow.Cells["Localidad"].Value);
            textProvincia.Text=Convert.ToString(dataGridView1.CurrentRow.Cells["Provincia"].Value);
            textCorreoE.Text=Convert.ToString(dataGridView1.CurrentRow.Cells["CorreoElec"].Value);
            textObservaciones.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["Observaciones"].Value);
        }

        private void button1_Click(object sender, EventArgs e)
        {   //Verificacion de que todos los campos obligatorios esten rellenos
            if (textNombre.Text == "" || textApellidos.Text == "" || textDni.Text == "" || textCorreoE.Text == "" || textDireccion.Text == "" || textCP.Text == "" || textLocalidad.Text == "" || textProvincia.Text == "" || textTelefono.Text == "")
            {
                MessageBox.Show("Debes rellenar todos los campos");
            }
            else //Verificacion de que todos los campos esten rellenos con el formato adecuado
            {
                bool validado = true;


                if (textNombre.Text.Any(char.IsDigit))
                {
                    MessageBox.Show("El campo Nombre no puede contener números.");
                    textNombre.Focus();
                    validado = false;
                }
                if (textApellidos.Text.Any(char.IsDigit))
                {
                    MessageBox.Show("El campo Apellidos no puede contener números.");
                    textApellidos.Focus();
                    validado = false;
                }
                if (textLocalidad.Text.Any(char.IsDigit))
                {
                    MessageBox.Show("El campo Localidad no puede contener números.");
                    textLocalidad.Focus();
                    validado = false;
                }
                if (textProvincia.Text.Any(char.IsDigit))
                {
                    MessageBox.Show("El campo Provincia no puede contener números.");
                    textProvincia.Focus();
                    validado = false;
                }
                if (!long.TryParse(textTelefono.Text, out _))
                {
                    MessageBox.Show("El campo Teléfono debe contener solo números.");
                    textTelefono.Focus();
                    validado = false;
                }
                if (!long.TryParse(textCP.Text, out _))
                {
                    MessageBox.Show("El campo Código Postal debe contener solo números.");
                    textCP.Focus();
                    validado = false;
                }
                if (validado)
                {   //Añadir a un objeto cliente todos los nuevos valores
                    Cliente cliente = new Cliente
                    {
                        Dni=textDni.Text.ToUpper(),
                        Nombre = textNombre.Text.ToUpper(),
                        Apellidos = textApellidos.Text.ToUpper(),
                        Direccion = textDireccion.Text.ToUpper(),
                        Telefono = textTelefono.Text,
                        CodigoPostal = textCP.Text,
                        Localidad = textLocalidad.Text.ToUpper(),
                        Provincia = textProvincia.Text.ToUpper(),
                        CorreoElec = textCorreoE.Text,
                        Observaciones = textObservaciones.Text.ToUpper()
                    };


                    int result = Gestion.editarCliente(cliente);

                    if (result > 0)
                    {
                        MessageBox.Show("Cliente modificado exitosamente"); //Mensaje de confirmacion
                    }
                    dataGridView1.DataSource = Gestion.MostrarClientes();
                }
            }
        }
    }
}
