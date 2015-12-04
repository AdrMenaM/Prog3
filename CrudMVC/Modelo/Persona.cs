using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Modelo
{
    public class Persona
    {
        private String id;
        private String nombre;
        private String telefono;
        private DateTime fechaNacimiento;

        

        public String Id
        {
            get { return id; }
            set { id = value; }
        }

        public String Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public String Telefono
        {
            get { return telefono; }
            set { telefono = value; }
        }

        public DateTime FechaNacimiento
        {
            get { return fechaNacimiento; }
            set { fechaNacimiento = value; }
        }

        public Persona()
        {
            id = "";
            nombre = "";
            telefono = "";
            fechaNacimiento = new DateTime();
        }
        public Persona(string ID, string Nombre, string Telefono, DateTime FechaNacimiento)
        {
            id = ID;
            nombre = Nombre;
            telefono = Telefono;
            fechaNacimiento = FechaNacimiento;
        }
    }
}
