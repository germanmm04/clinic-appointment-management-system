using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica
{
    public class Mascota //Clase mascota para establecer todos los atributos que tendra cada mascota
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public string Especie { get; set; }
        public string Raza { get; set; }
        public DateTime FechaNac { get; set; }
        public string Notas { get; set; }
        public string DNICliente { get; set; }

        public Mascota() { }

        public Mascota(int ID, string Nombre, string Especie, string Raza, DateTime FechaNac, string Notas, string dNICliente)
        {
            this.ID = ID;
            this.Nombre = Nombre;
            this.Especie = Especie;
            this.Raza = Raza;
            this.FechaNac = FechaNac;
            this.Notas = Notas;
            this.DNICliente = dNICliente;
        }
    }
}
