using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica
{
    public class Citas //Clase citas para establecer los atributos que tendra cada cita
    {
        public int ID { get; set; }
        public DateTime FechaHora { get; set; }
        public string Motivo { get; set; }
        public string Observaciones { get; set; }
        public string DNICliente { get; set; }
        public int MascotasID { get; set; }

        public Citas() { }
        public Citas( int ID, DateTime FechaHora, string Motivo, string Observaciones, string DNICliente, int MascotasID)
        {
            this.ID = ID;
            this.FechaHora = FechaHora;
            this.Motivo = Motivo;
            this.Observaciones = Observaciones;
            this.DNICliente = DNICliente;
            this.MascotasID = MascotasID;
        }
    }
}
