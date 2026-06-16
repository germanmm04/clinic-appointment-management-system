using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica
{
    public class Cliente //Clase cliente para establecer los atributo que tendra cada cliente
    {
        public string Dni { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string CodigoPostal { get; set; }
        public string Localidad { get; set; }
        public string Provincia { get; set; }
        public string CorreoElec { get; set; }
        public string Observaciones { get; set; }

        public Cliente() { }

        public Cliente(string Dni, string Nombre, string Apellidos, string Direccion, string Telefono, string CodigoPostal, string Localidad, string Provincia, string CorreoElec, string Observaciones)
        {
            this.Dni = Dni;
            this.Nombre = Nombre;
            this.Apellidos = Apellidos;
            this.Direccion = Direccion;
            this.Telefono = Telefono;
            this.CodigoPostal = CodigoPostal;
            this.Localidad = Localidad;
            this.Provincia = Provincia;
            this.CorreoElec = CorreoElec;
            this.Observaciones = Observaciones;

        }
    }
}
