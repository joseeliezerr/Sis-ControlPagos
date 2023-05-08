using Microsoft.Reporting.WinForms;
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

namespace Sis_ControlPagos.Reportes.Pagos
{
    public partial class ReportePagos : Form
    {
        public ReportePagos()
        {
            InitializeComponent();
        }

        private void ReporteEmpleados_Load(object sender, EventArgs e)
        {

            // Establecer la conexión a la base de datos
            SqlConnection cn = Conexion.conectar();

            // Consulta SQL para obtener los datos
            string consulta = "SELECT * FROM pagoempleado";

            // Crear un adaptador de datos
            SqlDataAdapter da = new SqlDataAdapter(consulta, cn);

            // Crear un conjunto de datos
            DataSet ds = new DataSet();

            // Llenar el conjunto de datos con los datos del adaptador
            da.Fill(ds, "tabla");

            // Establecer el origen de datos del ReportViewer
            ReportDataSource rds = new ReportDataSource("DataSet2", ds.Tables[0]);
            this.reportViewer1.LocalReport.DataSources.Clear();
            this.reportViewer1.LocalReport.DataSources.Add(rds);

            // Establecer la ruta del archivo de informe
            this.reportViewer1.LocalReport.ReportPath = "C:\\Users\\Eliezer Rivera\\source\\repos\\Sis ControlPagos\\Sis ControlPagos\\Reportes\\Pagos\\ReportePagos.rdlc";


            // Actualizar el ReportViewer
            this.reportViewer1.RefreshReport();
        }
    }
}
