using OfficeOpenXml;
using PdfSharp;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace Sis_ControlPagos.Consultas
{
    public partial class ConsultaEmpleados : Form
    {
        public ConsultaEmpleados()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void ConsultaEmpleados_Load(object sender, EventArgs e)
        {
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.ReadOnly = true;

            cargarDatosEmpleados();
        }
        void cargarDatosEmpleados()
        {
            // Establecer la conexión a la base de datos
            SqlConnection cn = Conexion.conectar();
           

            // Crear la consulta para seleccionar todos los registros de la tabla "empleados"
            string consulta = "SELECT * FROM empleados";

            // Crear un adaptador de datos y ejecutar la consulta
            SqlDataAdapter adaptador = new SqlDataAdapter(consulta, cn);
            DataTable tablaEmpleados = new DataTable();
            adaptador.Fill(tablaEmpleados);

            // Asignar la tabla de empleados al control DataGridView
            dataGridView1.DataSource = tablaEmpleados;
        }

        private void txtBuscar_Click(object sender, EventArgs e)
        {
            // Obtener el valor del campo de búsqueda
            string nombre = txtlb.Text;

            // Crear la consulta para buscar por el nombre en la tabla empleados
            string consulta = "";

            if (string.IsNullOrEmpty(nombre))
            {
                consulta = "SELECT * FROM empleados";
            }
            else
            {
                consulta = "SELECT * FROM empleados WHERE Nombre LIKE '%" + nombre + "%'";
            }

            // Crear un objeto SqlConnection y SqlCommand
            using (SqlConnection cn = Conexion.conectar())
            {
                // Verificar si la conexión ya está abierta
                if (cn.State == ConnectionState.Closed)
                {
                    cn.Open();
                }

                try
                {
                    // Crear un objeto SqlCommand con la consulta y los parámetros
                    using (SqlCommand comando = new SqlCommand(consulta, cn))
                    {
                        // Crear un objeto SqlDataAdapter y DataTable
                        SqlDataAdapter adaptador = new SqlDataAdapter(comando);
                        DataTable tabla = new DataTable();

                        // Llenar la DataTable con los resultados de la consulta
                        adaptador.Fill(tabla);

                        // Asignar la DataTable al DataSource del DataGridView
                        dataGridView1.DataSource = tabla;

                        // Mostrar un mensaje si no se encontraron resultados
                        if (tabla.Rows.Count == 0)
                        {
                            MessageBox.Show("No se encontraron resultados.");
                        }
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }







        }


        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Obtener la ventana principal actual
            VentanaPrincipal ventanaPrincipal = Application.OpenForms.OfType<VentanaPrincipal>().FirstOrDefault();

            if (ventanaPrincipal != null)
            {
                // Mostrar la ventana principal
                ventanaPrincipal.Show();
            }
            else
            {
                // Crear y mostrar la ventana principal si aún no existe
                ventanaPrincipal = new VentanaPrincipal();
                ventanaPrincipal.Show();
            }

            // Ocultar la ventana actual
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PdfDocument pdf = new PdfDocument();
            PdfPage pagina = pdf.AddPage();
            pagina.Orientation = PageOrientation.Landscape;
            XGraphics graficos = XGraphics.FromPdfPage(pagina);
            XRect rectangulo = new XRect(0, 0, pagina.Width.Point, pagina.Height.Point);
            graficos.TranslateTransform(10, 10);

            // Calcular el ancho y la altura de cada celda
            int anchoCelda = Convert.ToInt32(Math.Floor((pagina.Width.Point - 20) / dataGridView1.Columns.Count)); // Ancho de celda ajustado al ancho de la página
            double alturaCelda = dataGridView1.RowTemplate.Height + 5; // Altura de celda con un poco más de espacio

            // Crear un objeto Point con las coordenadas iniciales de dibujo
            Point puntoInicial = new Point(10, 10);

            // Imprimir los encabezados del DataGridView en el objeto XGraphics
            for (int columna = 0; columna < dataGridView1.Columns.Count; columna++)
            {
                string encabezado = dataGridView1.Columns[columna].HeaderText;
                XStringFormat formatoCentrado = new XStringFormat();
                formatoCentrado.Alignment = XStringAlignment.Center;
                formatoCentrado.LineAlignment = XLineAlignment.Center;
                XFont font = new XFont("Arial", 10, XFontStyle.Bold);

                graficos.DrawString(encabezado, font, XBrushes.Black, new XRect(puntoInicial.X + (columna * anchoCelda), puntoInicial.Y, anchoCelda, alturaCelda), formatoCentrado);

                // Añadir bordes al encabezado
                graficos.DrawRectangle(XPens.Black, new XRect(puntoInicial.X + (columna * anchoCelda), puntoInicial.Y, anchoCelda, alturaCelda));
            }

            // Imprimir los datos del DataGridView en el objeto XGraphics
            for (int fila = 0; fila < dataGridView1.Rows.Count; fila++)
            {
                for (int columna = 0; columna < dataGridView1.Columns.Count; columna++)
                {
                    object valorCelda = dataGridView1.Rows[fila].Cells[columna].Value;
                    string textoCelda = (valorCelda != null) ? valorCelda.ToString() : "";

                    // Calcular las coordenadas de la celda
                    double x = puntoInicial.X + (columna * anchoCelda);
                    double y = puntoInicial.Y + ((fila + 1) * alturaCelda);

                    // Imprimir el valor de la celda centrado en la celda
                    XStringFormat formatoCentrado = new XStringFormat();
                    formatoCentrado.Alignment = XStringAlignment.Center;
                    formatoCentrado.LineAlignment = XLineAlignment.Center;
                    XFont font = new XFont("Arial", 10, XFontStyle.Regular);

                    graficos.DrawString(textoCelda, font, XBrushes.Black, new XRect(x, y, anchoCelda, alturaCelda), formatoCentrado);

                    // Añadir bordes a la celda
                    graficos.DrawRectangle(XPens.Black, new XRect(x, y, anchoCelda, alturaCelda));
                }
            }

            // Guardar el archivo PDF en disco
            SaveFileDialog dialogo = new SaveFileDialog();
            dialogo.Filter = "Archivos PDF (*.pdf)|*.pdf";
            dialogo.Title = "Guardar archivo PDF";
            dialogo.FileName = "empleados.pdf";

            if (dialogo.ShowDialog() == DialogResult.OK)
            {
                pdf.Save(dialogo.FileName);
                MessageBox.Show("El archivo PDF se guardó correctamente");
            }

        }
    }


        }

