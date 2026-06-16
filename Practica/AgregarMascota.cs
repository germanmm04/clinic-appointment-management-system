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
    public partial class AgregarMascota : Form
    {
        public AgregarMascota()
        {
            InitializeComponent();
            FechaNac.MaxDate = DateTime.Now;
        }

        private void button1_Click(object sender, EventArgs e) //Mismo funcionamiento que AgregarCita
        {
            if(textCliente.Text=="" || textEspecie.Text=="" || textNombre.Text=="" || textRaza.Text == "")
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

                        mascota.Nombre = textNombre.Text.ToUpper();
                        mascota.Especie = textEspecie.Text.ToUpper();
                        mascota.Raza = textRaza.Text.ToUpper();
                        mascota.FechaNac = FechaNac.Value;
                        mascota.DNICliente = textCliente.Text.ToUpper();
                        mascota.Notas = textNotas.Text.ToUpper();


                        int result = Gestion.AgregarMascota(mascota);

                        if (result > 0)
                        {
                            MessageBox.Show("Mascota registrada exitosamente");
                            this.Close();
                        }
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show("No se puede añadir la mascota debido a que no se encuentra un cliente con ese DNI");
                    }
                }
            }

            
        }
    }
}
