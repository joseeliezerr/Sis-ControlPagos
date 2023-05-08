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
    public partial class IniciarSesion : Form
    {

        


        // Resto del código


        public IniciarSesion()
        {
            InitializeComponent();
        }

        private void btningresar_Click(object sender, EventArgs e)
        {

            using (SqlConnection cn = Conexion.conectar())
            {
                if (cn.State == ConnectionState.Closed) // Verifica si la conexión está cerrada
                {
                    cn.Open(); // La abre si está cerrada
                }

                try
                {
                    // Realiza las operaciones necesarias
                    string usuario = txtusuario.Text; // Nombre de usuario proporcionado por el usuario
                    string contraseña = txtcontraseña.Text; // Contraseña proporcionada por el usuario
                    SqlCommand command = new SqlCommand("SELECT * FROM usuarios WHERE usuario = @usuario AND contraseña = @contraseña", cn);
                    command.Parameters.AddWithValue("@usuario", usuario);
                    command.Parameters.AddWithValue("@contraseña", contraseña);
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {

                        VentanaPrincipal pantalla = new VentanaPrincipal();
                        pantalla.StartPosition = FormStartPosition.Manual;
                        pantalla.Show();
                        string usuario2 = txtusuario.Text;
                        string permiso = obtenerPermisoUsuario(usuario2);


                       
                    }
                    else
                    {
                        // Las credenciales son inválidas, mostrar un mensaje de error
                        MessageBox.Show("Usuario o contraseña inválidos.");
                    }
                }
                catch (SqlException ex)
                {
                   MessageBox.Show(ex.Message);
                }
                // La conexión se cerrará automáticamente al salir del bloque "using"
            }


        }

        private string obtenerPermisoUsuario(string usuario)
        {
            // Crear la consulta para obtener el permiso del usuario
            string consulta = "SELECT permiso FROM usuarios WHERE usuario = @usuario";

            // Crear un objeto SqlConnection y SqlCommand
            using (SqlConnection cn = Conexion.conectar())
            using (SqlCommand comando = new SqlCommand(consulta, cn))
            {
                // Establecer los parámetros de la consulta
                comando.Parameters.AddWithValue("@usuario", usuario);

                // Verificar si la conexión está abierta
                if (cn.State != ConnectionState.Open)
                {
                    cn.Open();
                }

                // Ejecutar la consulta y obtener el resultado
                VariablesGlobales.permiso = Convert.ToString(comando.ExecuteScalar());

                // Devolver el permiso del usuario
                return VariablesGlobales.permiso;
            }
        }


        private void btnlimpiar_Click(object sender, EventArgs e)
        {
            // Para limpiar el contenido del TextBox "txtusuario"
            txtusuario.Text = "";

            // Para limpiar el contenido del TextBox "txtcontraseña"
            txtcontraseña.Text = "";
        }

        private void btnsalir_Click(object sender, EventArgs e)
        {
            // Cierra el formulario "Form1"
            this.Close();

        }
    }
}
