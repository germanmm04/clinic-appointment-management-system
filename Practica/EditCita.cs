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
    public partial class EditCita : Form
    {
        public EditCita()
        {
            InitializeComponent();
            FechaHora.MinDate = DateTime.Now; //La fecha y hora de la cita no puede ser anterior a la fecha actual
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textDNI.Text == "" || textMotivo.Text == "") //Verificacion de que todos los campos obligatorios esten rellenos
            {
                MessageBox.Show("Debes rellenar todos los campos");
            }
            else
            {
                    //Agregar a un nuevo objeto cita todos los valores de la cita
                    Citas cita = new Citas();
                    cita.ID=Convert.ToInt32(textID.Text);
                    cita.FechaHora = FechaHora.Value;
                    cita.DNICliente = textDNI.Text.ToUpper();
                    cita.Motivo = textMotivo.Text.ToUpper();
                    cita.Observaciones = textObservaciones.Text.ToUpper();

                    int result = Gestion.editCita(cita);
                    if (result > 0)
                    {
                        MessageBox.Show("Cita modificada exitosamente"); //Mensaje de confirmacion
                    }
                    dataGridView1.DataSource = Gestion.MostrarCitas();
                
            }

            
        }

        private void EditCita_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = Gestion.MostrarCitas();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            textID.Text=Convert.ToString(dataGridView1.CurrentRow.Cells["ID"].Value);
            textDNI.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["DNICliente"].Value);
            textMotivo.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["Motivo"].Value);
            textObservaciones.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["Observaciones"].Value);
            FechaHora.Value = DateTime.Now;
        }
    }
}
