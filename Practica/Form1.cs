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
    public partial class Inicio : Form
    {
        public Inicio()
        {
            InitializeComponent();
        }
        //Apertura de todos los formularios
        private void agregarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AgregarCliente agregarCliente = new AgregarCliente();
            agregarCliente.ShowDialog();
        }

        private void editarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditCliente editCliente = new EditCliente();
            editCliente.ShowDialog();
        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EliminarCliente eliminarCliente = new EliminarCliente();
            eliminarCliente.ShowDialog();
        }

        private void agregarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            AgregarMascota agregarMascota = new AgregarMascota();
            agregarMascota.ShowDialog();
        }

        private void editarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            EditMascota editMascota = new EditMascota();
            editMascota.ShowDialog();
        }

        private void eliminarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            EliminarMascota eliminarMascota = new EliminarMascota();
            eliminarMascota.ShowDialog();
        }

        private void agregarToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            AgregarCita agregarCita = new AgregarCita();
            agregarCita.ShowDialog();
        }

        private void editarToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            EditCita editCita = new EditCita();
            editCita.ShowDialog();
        }

        private void eliminarToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            EliminarCita eliminarCita = new EliminarCita();
            eliminarCita.ShowDialog();
        }

        private void verMascotasToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void listaClientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ListaClientes listaClientes = new ListaClientes();
            listaClientes.ShowDialog();
        }

        private void consultarCitasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ListCitasMascotas listCitasMascotas = new ListCitasMascotas();
            listCitasMascotas.ShowDialog();
        }

        private void consultarCitasToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ListCitas citas = new ListCitas();
            citas.ShowDialog();
        }

        private void consultarMascotasToolStripMenuItem_Click(object sender, EventArgs e)
        {
           ListMascotas listMascotas = new ListMascotas();
            listMascotas.ShowDialog();
        }

        private void Inicio_Load(object sender, EventArgs e)
        {

        }
    }
}
