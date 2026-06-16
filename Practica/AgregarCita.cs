using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace Practica
{
    public partial class AgregarCita : Form
    {
        public AgregarCita()
        {
            InitializeComponent();
            FechaHora.MinDate = DateTime.Now; //La fecha y hora de la cita no puede ser anterior a la actual
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textDNI.Text=="" || textMascota.Text=="" || textMotivo.Text == "") //Verificar que todos los campos obligatorios esten rellenos
            {
                MessageBox.Show("Debes rellenar todos los campos");
            }
            else //Verificacion de que todos los campos contengan el formato adecuado
            {
                bool validado = true;

                if (!long.TryParse(textMascota.Text, out _))
                {
                    MessageBox.Show("El campo Mascota ID debe contener solo números.");
                    textMascota.Focus();
                    validado = false;
                }

                if (validado)
                {
                    try
                    {
                        Citas citas = new Citas();
                        //Agregar todos los valores de los textbox al objeto citas 
                        citas.FechaHora = FechaHora.Value;
                        citas.DNICliente = textDNI.Text.ToUpper();
                        citas.Observaciones = textObservaciones.Text.ToUpper();
                        citas.Motivo = textMotivo.Text.ToUpper();
                        citas.MascotasID = Convert.ToInt32(textMascota.Text);

                        int result = Gestion.AgregarCita(citas); //Agregar el objeto cita a la BD

                        if (result > 0)
                        {
                            MessageBox.Show("Cita registrada exitosamente"); //Mensaje de confirmacion
                            this.Close();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Introduce un ID válido");
                    }
                }
            }
        }
    }
}
