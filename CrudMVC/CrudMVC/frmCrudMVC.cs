using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Control;

namespace CrudMVC
{
    public partial class frmCrudMVC : Form
    {
        ControladorCRUD control = new ControladorCRUD();
        
        public frmCrudMVC()
        {
            InitializeComponent();
        }

        private void btnCalendario_Click(object sender, EventArgs e)
        {
        }

        private void dTimePicker_ValueChanged(object sender, EventArgs e)
        {
            txtFechaNacimiento.Text = dTimePicker.Value.Day.ToString() + "/" + dTimePicker.Value.Month.ToString() + "/" + dTimePicker.Value.Year.ToString();
        }

        private void frmCrudMVC_Load(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            control.guardarPersona(txtId, txtNombre, txtTelefono, txtFechaNacimiento, DGVPersona);
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            control.abrir();
            control.mostrarDatosArchivo(DGVPersona);
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            control.nuevo(txtId, txtNombre, txtTelefono, txtFechaNacimiento,dTimePicker);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            control.eliminarPersona(DGVPersona);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            control.actualizarPersona(txtId, txtNombre, txtTelefono, txtFechaNacimiento, DGVPersona);
        }
    }
}
