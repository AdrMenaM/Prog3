using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using CrudMVC; //Vista
using Modelo;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;




namespace Control
{
    public class ControladorCRUD   //Controlador
    {
        
        //private frmCrudMVC objCrud = new frmCrudMVC();
        private PersonaDAO objPersonaDAO = new PersonaDAO();
 
        //public ControladorCRUD(PersonaDAO p, frmCrudMVC vista)
        //{
        //    objCrud = vista;
        //    objPersonaDAO = p;
        //    //objCrud.btnSave.ad
        //    //objCrud.btnSave.Click += delegate(System.Object o, System.EventArgs e)
        //    //{
        //    //    MessageBox.Show("Eureka!");
        //    //};

            
        //}



        //public void EventHandler(EventArgs e)
        //{
        //    if(e.Equals(objCrud.btnSave)){
        //        MessageBox.Show("Eureka!");
        //    }
        //}

        public void abrir()
        {
            objPersonaDAO.abrirArchivoEnt();
        }

        public void mostrarDatosArchivo(DataGridView dgvPersonas)
        {
            List<Persona> Lista = new List<Persona>();
            Lista = objPersonaDAO.abrirArchivo();
            dgvPersonas.DataSource = null;
            dgvPersonas.DataSource = Lista;
        }

        public void mostrarDatos(DataGridView dgvPersonas)
        {
            dgvPersonas.DataSource = null;
            dgvPersonas.DataSource = objPersonaDAO.ListaPersonas;
        }

        public void guardarPersona(TextBox txtId,TextBox txtNombre, TextBox txtTelefono, TextBox txtFecha, DataGridView dgvPersonas)
        {
            if (objPersonaDAO.ListaPersonas.Count == 0)
            {
                objPersonaDAO.abrirArchivoSal();
            }
            
            objPersonaDAO.insertar(txtId.Text, txtNombre.Text, txtTelefono.Text, txtFecha.Text);
            mostrarDatos(dgvPersonas);            
        }

        public void nuevo(TextBox txtId, TextBox txtNombre, TextBox txtTelefono, TextBox txtFecha, DateTimePicker dTimePicker)
        {
            txtId.Enabled = true;
            txtNombre.Enabled = true;
            txtTelefono.Enabled = true;
            txtFecha.Enabled = true;
            dTimePicker.Enabled = true;
            txtId.Text = "";
            txtNombre.Text = "";
            txtTelefono.Text = "";
            txtFecha.Text = "";
            txtId.Focus();
        }

        public void eliminarPersona(DataGridView dgvPersonas)
        {
            objPersonaDAO.eliminar(dgvPersonas.CurrentRow.Index);
            mostrarDatos(dgvPersonas);
        }

        public void actualizarPersona(TextBox txtId, TextBox txtNombre, TextBox txtTelefono, TextBox txtFecha, DataGridView dgvPersonas)
        {
            try
            {
                bool verif;
                verif = objPersonaDAO.actualizar(txtId.Text, txtNombre.Text, txtTelefono.Text, txtFecha.Text, dgvPersonas.CurrentRow.Index);
                if (!verif)
                    MessageBox.Show("No se pudo actualizar");
                mostrarDatos(dgvPersonas);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }



    }
}
