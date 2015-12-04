using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Modelo
{
    public class PersonaDAO
    {
        private Persona objPersona;
        private String NPath, NomArchEnt, NomArchSal;
        private List<Persona> ListaPersona = new List<Persona>();
        ArchivoPlano archivo = new ArchivoPlano();//@"../../../../Modelo/bin/Debug/Resources/Personas.xml"

        public List<Persona> ListaPersonas
        {
            get { return ListaPersona; }
            set { ListaPersona = value; }
        }


        public void abrirArchivoEnt()
        {
            // Se define un cuadro de dialogo para apertura de archivos:
            OpenFileDialog ofd = new OpenFileDialog();
            // se establece un filtro:
            ofd.Filter = "Todos | *.*| Archivos XML | *.xml| Archivos de texto | *.txt";
            // Se fija por omisión los archivos txt:
            ofd.FilterIndex = 2;
            // Se establece como a este como directorio inicial:
            ofd.InitialDirectory = NPath;
            // Se abre el cuadro de diálogo para lectura:
            if (ofd.ShowDialog() == DialogResult.OK)
                // Se atrapan errores:
                try
                {
                    // Obtener el nombre del archivo de entrada:
                    NomArchEnt = ofd.FileName;
                    //stLectura = new StreamReader(NomArchEnt);
                    archivo = new ArchivoPlano(NomArchEnt);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
        }

        // Metodo para abrir un cuadro de dialogo para guardar como e inicializar stEscritura
        public void abrirArchivoSal()
        {
            // Se define un cuadro de dialogo para apertura de archivos:
            SaveFileDialog sfd = new SaveFileDialog();
            // se establece un filtro:
            sfd.Filter = "Archivos XML | *.xml| Archivo de texto | *.txt";
            // Se fija por omisión los archivos txt:
            sfd.FilterIndex = 1;
            // Se establece como a este como directorio inicial:
            sfd.InitialDirectory = NPath;
            // Se abre el cuadro de diálogo para guardar como:
            if (sfd.ShowDialog() == DialogResult.OK)
                // Se atrapan errores:
                try
                {
                    // Obtener el nombre del archivo de salida:
                    NomArchSal = sfd.FileName;
                    //stEscritura = new StreamWriter(NomArchSal);
                    archivo = new ArchivoPlano(NomArchSal);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
        }

        public List<Persona> abrirArchivo()
        {
            ListaPersona = archivo.Deserializar();
            return ListaPersona;
        }

        
        public void insertar(String id, String nombre, String telefono, String fechaNacimiento)
        {
            try
            {
                String[] fecha = fechaNacimiento.Split('/');
                DateTime fechaNac = new DateTime(int.Parse(fecha[2]), int.Parse(fecha[1]), int.Parse(fecha[0]));
                objPersona = new Persona(id, nombre, telefono, fechaNac);
                ListaPersona.Add(objPersona);
                archivo.Serializar(ListaPersona);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        public bool eliminar(int index)
        {
            bool op=false;

            try
            {
                ListaPersona.RemoveAt(index);
                archivo.Serializar(ListaPersona);
                op = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                op = false;
            }

            return op;
        }

        public bool actualizar(String id, String nombre, String telefono, String fechaNacimiento, int index)
        {
            bool op = false;
            String[] fecha = fechaNacimiento.Split('/');
            DateTime fechaNac = new DateTime(int.Parse(fecha[2]), int.Parse(fecha[1]), int.Parse(fecha[0]));
            objPersona = new Persona(id, nombre, telefono, fechaNac);
            try
            {
                ListaPersona.RemoveAt(index);
                ListaPersona.Insert(index, objPersona);
                archivo.Serializar(ListaPersona);
                op = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                op = false;
            }

            return op;
        }



        
    }

}
