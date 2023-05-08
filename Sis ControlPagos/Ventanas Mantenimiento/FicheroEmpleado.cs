using Sis_ControlPagos;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Sis_ControlPagos
{
    public partial class FicheroEmpleado : Form
    {
        public FicheroEmpleado()
        {
            InitializeComponent();
        }

        private void FicheroEmpleado_Load(object sender, EventArgs e)
        {
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.ReadOnly = true;
            cargarDatosEmpleados();



        }
        void cargarDatosEmpleados()
        {
            // Establecer la conexión a la base de datos
            SqlConnection cn = Conexion.conectar();
            // MessageBox.Show("Conexion Exitosa");

            // Crear la consulta para seleccionar todos los registros de la tabla "empleados"
            string consulta = "SELECT * FROM empleados";

            // Crear un adaptador de datos y ejecutar la consulta
            SqlDataAdapter adaptador = new SqlDataAdapter(consulta, cn);
            DataTable tablaEmpleados = new DataTable();
            adaptador.Fill(tablaEmpleados);

            // Asignar la tabla de empleados al control DataGridView
            dataGridView1.DataSource = tablaEmpleados;
        }

        private void btnCrearEmpleado_Click(object sender, EventArgs e)
        {
            SqlConnection cn = null;
            try
            {
                // Verificar si la conexión ya está abierta
                cn = Conexion.conectar();
                if (cn.State == ConnectionState.Closed)
                {
                    cn.Open();
                }

                // Crear la consulta para insertar un registro en la tabla "empleado"
                string consulta = "INSERT INTO empleados ( Nombre, Apellido, Direecion, Telefono, FechaIngreso, Cargo, Departamento, Salario, Cedula) VALUES ( @nombre, @apellido, @direccion, @telefono, @fechaIngreso, @cargo, @departamento, @salario, @cedula)";

                // Crear un objeto SqlCommand y establecer los parámetros
                SqlCommand comando = new SqlCommand(consulta, cn);
                //  comando.Parameters.AddWithValue("@codigo", txtcondigoempleado.Text);
                comando.Parameters.AddWithValue("@nombre", txtnombre.Text);
                comando.Parameters.AddWithValue("@apellido", txtapellido.Text);
                comando.Parameters.AddWithValue("@direccion", txtdireccion.Text);
                comando.Parameters.AddWithValue("@telefono", txttelefono.Text);
                comando.Parameters.AddWithValue("@fechaIngreso", dtpingreso.Value);
                comando.Parameters.AddWithValue("@cargo", txtcargo.Text);
                comando.Parameters.AddWithValue("@departamento", txtdepartamento.Text);
                comando.Parameters.AddWithValue("@salario", txtsalario.Text);
                comando.Parameters.AddWithValue("@cedula", txtcedula.Text);

                // Ejecutar la consulta
                comando.ExecuteNonQuery();

                // Mostrar un mensaje de éxito
                MessageBox.Show("Registro guardado con éxito.");
                cargarDatosEmpleados();
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                // Manejar la excepción
                MessageBox.Show("Error al guardar el registro: " + ex.Message);
            }
            finally
            {
                // Cerrar la conexión
                if (cn != null && cn.State != ConnectionState.Closed)
                {
                    cn.Close();
                }
            }


        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Verificar si se ha seleccionado una fila en el DataGrid
            if (e.RowIndex >= 0)
            {
                // Obtener la fila seleccionada
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];

                // Mostrar los valores de las columnas seleccionadas en los campos correspondientes
                txtcondigoempleado.Text = row.Cells["codigo"].Value.ToString();
                txtnombre.Text = row.Cells["Nombre"].Value.ToString();
                txtapellido.Text = row.Cells["Apellido"].Value.ToString();
                txtdireccion.Text = row.Cells["Direecion"].Value.ToString();
                txttelefono.Text = row.Cells["Telefono"].Value.ToString();
                dtpingreso.Text = row.Cells["FechaIngreso"].Value.ToString();
                txtcargo.Text = row.Cells["Cargo"].Value.ToString();
                txtdepartamento.Text = row.Cells["Departamento"].Value.ToString();
                txtsalario.Text = row.Cells["Salario"].Value.ToString();
                txtcedula.Text = row.Cells["Cedula"].Value.ToString();
            }
        }

        private void btnactualizar_Click(object sender, EventArgs e)
        {
            SqlConnection cn = null;
            try
            {
                // Verificar si la conexión ya está abierta
                cn = Conexion.conectar();
                if (cn.State == ConnectionState.Closed)
                {
                    cn.Open();
                }

                // Crear la consulta para actualizar un registro en la tabla "empleados"
                string consulta = "UPDATE empleados SET Nombre=@nombre, Apellido=@apellido, Direecion=@direccion, Telefono=@telefono, FechaIngreso=@fechaIngreso, Cargo=@cargo, Departamento=@departamento, Salario=@salario, Cedula=@cedula WHERE codigo=@codigo";

                // Crear un objeto SqlCommand y establecer los parámetros
                SqlCommand comando = new SqlCommand(consulta, cn);
                comando.Parameters.AddWithValue("@codigo", txtcondigoempleado.Text);
                comando.Parameters.AddWithValue("@nombre", txtnombre.Text);
                comando.Parameters.AddWithValue("@apellido", txtapellido.Text);
                comando.Parameters.AddWithValue("@direccion", txtdireccion.Text);
                comando.Parameters.AddWithValue("@telefono", txttelefono.Text);
                comando.Parameters.AddWithValue("@fechaIngreso", dtpingreso.Value);
                comando.Parameters.AddWithValue("@cargo", txtcargo.Text);
                comando.Parameters.AddWithValue("@departamento", txtdepartamento.Text);
                comando.Parameters.AddWithValue("@salario", txtsalario.Text);
                comando.Parameters.AddWithValue("@cedula", txtcedula.Text);

                // Ejecutar la consulta
                comando.ExecuteNonQuery();

                // Mostrar un mensaje de éxito
                MessageBox.Show("Registro actualizado con éxito.");
                cargarDatosEmpleados();
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                // Manejar la excepción
                MessageBox.Show("Error al actualizar el registro: " + ex.Message);
            }
            finally
            {
                // Cerrar la conexión
                if (cn != null && cn.State != ConnectionState.Closed)
                {
                    cn.Close();
                }
            }

        }

        private void btneliminar_Click(object sender, EventArgs e)
        {
            SqlConnection cn = null;
            try
            {
                // Verificar si la conexión ya está abierta
                cn = Conexion.conectar();
                if (cn.State == ConnectionState.Closed)
                {
                    cn.Open();
                }

                // Crear la consulta para eliminar un registro de la tabla "empleados"
                string consulta = "DELETE FROM empleados WHERE codigo=@codigo";

                // Crear un objeto SqlCommand y establecer los parámetros
                SqlCommand comando = new SqlCommand(consulta, cn);
                comando.Parameters.AddWithValue("@codigo", txtcondigoempleado.Text);

                // Ejecutar la consulta
                comando.ExecuteNonQuery();

                // Mostrar un mensaje de éxito
                MessageBox.Show("Registro eliminado con éxito.");
                cargarDatosEmpleados();
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                // Manejar la excepción
                MessageBox.Show("Error al eliminar el registro: " + ex.Message);
            }
            finally
            {
                // Cerrar la conexión
                if (cn != null && cn.State != ConnectionState.Closed)
                {
                    cn.Close();
                }
            }
        }

        private void btnnuevo_Click(object sender, EventArgs e)
        {
           LimpiarCampos();
        }
        void LimpiarCampos()
        {
            txtcondigoempleado.Clear();
            txtnombre.Clear();
            txtapellido.Clear();
            txtdireccion.Clear();
            txttelefono.Clear();
            dtpingreso.Value = DateTime.Now; // o cualquier otra fecha por defecto
            txtcargo.Clear();
            txtdepartamento.Clear();
            txtsalario.Clear();
            txtcedula.Clear();
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
    }
}
