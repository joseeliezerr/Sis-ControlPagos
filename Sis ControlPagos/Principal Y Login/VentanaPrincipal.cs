using Sis_ControlPagos.Consultas;
using Sis_ControlPagos.Reportes;
using Sis_ControlPagos.Reportes.Pagos;
using Sis_ControlPagos.Reportes.Usuarios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sis_ControlPagos
{
    public partial class VentanaPrincipal : Form
    {
        public VentanaPrincipal()
        {
            InitializeComponent();
        }

        private void crearempleadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            FicheroEmpleado empleados = new FicheroEmpleado();
            empleados.Show();
        }

        private void crearpagoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FicheroPago pago = new FicheroPago();
            pago.Show();
        }

       







        private void ficheroUsuarioToolStripMenuItem_Click(object sender, EventArgs e)

        {
            string permiso = VariablesGlobales.permiso;

            if (string.IsNullOrEmpty(permiso))
            {
                MessageBox.Show("No se pudo obtener el permiso del usuario.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (permiso == "USUARIO")
            {
                MessageBox.Show("No tiene permiso para abrir esta ventana.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                // Abrir la ventana restringida
                FicheroPersona Persona = new FicheroPersona();
                Persona.Show();
            }

        }

        private void empleadosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Hide();
            ConsultaEmpleados empleados = new ConsultaEmpleados();
            empleados.Show();
        }

        private void pagoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Hide();
            ConsultaPagos Pagos = new ConsultaPagos();
            Pagos.Show();
        }

        private void consultaUsuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string permiso = VariablesGlobales.permiso;

            if (string.IsNullOrEmpty(permiso))
            {
                MessageBox.Show("No se pudo obtener el permiso del usuario.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (permiso == "USUARIO")
            {
                MessageBox.Show("No tiene permiso para abrir esta ventana.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                this.Hide();
                ConsultaUsuarios Usuarios = new ConsultaUsuarios();
                Usuarios.Show();
            }
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void empleadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            ReporteEmpleadoscs empleados = new ReporteEmpleadoscs();
            empleados.Show();
        }

        private void pagosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            ReportePagos Pagos = new ReportePagos();
            Pagos.Show();
        }

        private void reportedeUsuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string permiso = VariablesGlobales.permiso;

            if (string.IsNullOrEmpty(permiso))
            {
                MessageBox.Show("No se pudo obtener el permiso del usuario.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (permiso == "USUARIO")
            {
                MessageBox.Show("No tiene permiso para abrir esta ventana.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                this.Hide();
                ReporteUsuarios Usuarios = new ReporteUsuarios();
                Usuarios.Show();
            }
        }
    }
}
