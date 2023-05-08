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
    public partial class FicheroPersona : Form
    {
        //  private string permiso;
        public FicheroPersona()
        {
            InitializeComponent();
        }

        private void FicheroPersona_Load(object sender, EventArgs e)
        {
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.ReadOnly = true;
            cargarDatos();
        }

        void cargarDatos()
        {
            // Establecer la conexión a la base de datos
            SqlConnection cn = Conexion.conectar();
            // MessageBox.Show("Conexion Exitosa");

            // Crear la consulta para seleccionar todos los registros de la tabla "empleados"
            string consulta = "SELECT * FROM usuarios";

            // Crear un adaptador de datos y ejecutar la consulta
            SqlDataAdapter adaptador = new SqlDataAdapter(consulta, cn);
            DataTable tablaPersona = new DataTable();
            adaptador.Fill(tablaPersona);

            // Asignar la tabla de empleados al control DataGridView
            dataGridView1.DataSource = tablaPersona;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Obtener la fila seleccionada
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];

                // Mostrar los valores de las columnas seleccionadas en los campos correspondientes
                txtId.Text = row.Cells["id"].Value.ToString();
                txtUsuario.Text = row.Cells["usuario"].Value.ToString();
                txtContraseña.Text = row.Cells["contraseña"].Value.ToString();
                comboBox1.Text = row.Cells["permiso"].Value.ToString();
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
        void LimpiarCampos()
        {
            txtUsuario.Text = "";
            txtContraseña.Text = "";
            comboBox1.Text = "";
        }

        private void btnguardar_Click(object sender, EventArgs e)
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

                // Crear la consulta para insertar un registro en la tabla "usuarios"
                string consulta = "INSERT INTO usuarios (usuario, contraseña, permiso) VALUES (@usuario, @contraseña, @permiso)";

                // Crear un objeto SqlCommand y establecer los parámetros
                SqlCommand comando = new SqlCommand(consulta, cn);
                comando.Parameters.AddWithValue("@usuario", txtUsuario.Text);
                comando.Parameters.AddWithValue("@contraseña", txtContraseña.Text);
                comando.Parameters.AddWithValue("@permiso", comboBox1.Text);

                // Ejecutar la consulta
                comando.ExecuteNonQuery();

                // Mostrar un mensaje de éxito
                MessageBox.Show("Registro guardado con éxito.");
                LimpiarCampos();
                cargarDatos();
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

        private void btneliminar1_Click(object sender, EventArgs e)
        {
            // Crear la conexión a la base de datos
            using (SqlConnection cn = Conexion.conectar())
            {
                if (cn.State == ConnectionState.Closed) // Verifica si la conexión está cerrada
                {
                    cn.Open(); // La abre si está cerrada
                }

                // Obtener la fila seleccionada
                DataGridViewRow row = dataGridView1.SelectedRows[0];

                // Obtener el valor de la columna "id" de la fila seleccionada
                int id = Convert.ToInt32(row.Cells["id"].Value);

                // Crear la consulta para modificar el registro
                string consulta = "UPDATE usuarios SET usuario = @usuario, contraseña = @contraseña, permiso = @permiso WHERE id = @id";

                // Crear un objeto SqlCommand y establecer los parámetros
                SqlCommand comando = new SqlCommand(consulta, cn);
                comando.Parameters.AddWithValue("@usuario", txtUsuario.Text);
                comando.Parameters.AddWithValue("@contraseña", txtContraseña.Text);
                comando.Parameters.AddWithValue("@permiso", comboBox1.Text);
                comando.Parameters.AddWithValue("@id", id);

                // Ejecutar la consulta
                comando.ExecuteNonQuery();

                // Mostrar un mensaje de éxito
                MessageBox.Show("Registro modificado con éxito.");

                // Actualizar el DataGridView
                cargarDatos();
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Crear la conexión a la base de datos
            using (SqlConnection cn = Conexion.conectar())
            {
                if (cn.State == ConnectionState.Closed) // Verifica si la conexión está cerrada
                {
                    cn.Open(); // La abre si está cerrada
                }

                // Obtener la fila seleccionada
                DataGridViewRow row = dataGridView1.SelectedRows[0];

                // Obtener el valor de la columna "id" de la fila seleccionada
                int id = Convert.ToInt32(row.Cells["id"].Value);

                // Mostrar un mensaje de confirmación al usuario
                DialogResult result = MessageBox.Show("¿Está seguro de que desea eliminar este registro?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    // Crear la consulta para eliminar el registro
                    string consulta = "DELETE FROM usuarios WHERE id = @id";

                    // Crear un objeto SqlCommand y establecer los parámetros
                    SqlCommand comando = new SqlCommand(consulta, cn);
                    comando.Parameters.AddWithValue("@id", id);

                    // Ejecutar la consulta
                    comando.ExecuteNonQuery();

                    // Mostrar un mensaje de éxito
                    MessageBox.Show("Registro eliminado con éxito.");
                    txtUsuario.Text = "";
                    txtId.Text = "";
                    txtContraseña.Text = "";
                    comboBox1.SelectedIndex = -1;
                    // Asegurarse de que el foco se establezca en la primera caja de texto
                    txtUsuario.Focus();

                    // Actualizar el DataGridView
                    cargarDatos();
                }
            }

        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtUsuario.Text = "";
            txtId.Text = "";
            txtContraseña.Text = "";
            comboBox1.SelectedIndex = -1;
            // Asegurarse de que el foco se establezca en la primera caja de texto
            txtUsuario.Focus();
        }
    }
}
