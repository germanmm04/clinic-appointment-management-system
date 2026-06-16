using Microsoft.Win32;
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
    public partial class AgregarCliente : Form
    {
        public AgregarCliente()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) //Mismo funcionamiento que el formulario AgregarCita
        {
            if(textNombre.Text == "" || textApellidos.Text == "" || textCorreoE.Text=="" || textDni.Text=="" || textDireccion.Text =="" || textCP.Text == "" || textLocalidad.Text =="" || textProvincia.Text =="" || textTelefono.Text == "")
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
                {
                    Cliente cliente = new Cliente
                    {
                        Dni = textDni.Text.ToUpper(),
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


                    int result = Gestion.AgregarCliente(cliente);

                    if (result > 0)
                    {
                        MessageBox.Show("Cliente registrado exitosamente");
                        this.Close();
                    }
                }
            }
        }
    }
}
