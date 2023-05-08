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
    public partial class FicheroPago : Form
    {
        public FicheroPago()
        {
            InitializeComponent();
        }

        private void FicheroPago_Load(object sender, EventArgs e)
        {
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.ReadOnly = true;
            mostrarDatos();
        }
        void mostrarDatos()
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
                    SqlCommand command = new SqlCommand("SELECT id, nombre, apellido, cargo, sueldo_bruto, horas_extras, seguro, adelanto_sueldo, sueldo_neto FROM pagoempleado", cn);
                    SqlDataReader reader = command.ExecuteReader();

                    // Carga los datos en el DataGridView "datagridview1"
                    DataTable dt = new DataTable();
                    dt.Load(reader);
                    dataGridView1.DataSource = dt;
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                // La conexión se cerrará automáticamente al salir del bloque "using"
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (SqlConnection cn = Conexion.conectar())
            {
                if (cn.State == ConnectionState.Closed)
                {
                    cn.Open();
                }

                try
                {
                    
                            SqlCommand command = new SqlCommand("INSERT INTO pagoempleado ( nombre, apellido, cargo, sueldo_bruto, horas_extras, seguro, adelanto_sueldo, sueldo_neto) VALUES ( @nombre, @apellido, @cargo, @sueldo_bruto, @horas_extras, @seguro, @adelanto_sueldo, @sueldo_neto)", cn);
                            command.Parameters.AddWithValue("@nombre", txtnombre.Text);
                            command.Parameters.AddWithValue("@apellido", txtapellido.Text);
                            command.Parameters.AddWithValue("@cargo", txtcargo.Text);
                            command.Parameters.AddWithValue("@sueldo_bruto", txtcargo.Text);
                            command.Parameters.AddWithValue("@horas_extras", txtmontohoraextra.Text);
                            command.Parameters.AddWithValue("@seguro", txtseguromed.Text);
                            command.Parameters.AddWithValue("@adelanto_sueldo", txtadelantosueldo.Text);
                            command.Parameters.AddWithValue("@sueldo_neto", txtsueldoneto.Text);
                            command.ExecuteNonQuery();
                       
                    

                    MessageBox.Show("Registros guardados con éxito.");
                    mostrarDatos();
                    limpiar();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }


        }
      

        void limpiar()
        {
            txtnombre.Text = "";
            txtapellido.Text = "";
            txtcargo.Text = "";
            txtsaldobruto.Text = "";
            txtmontohoraextra.Text = "";
            txtseguromed.Text = "";
            txtadelantosueldo.Text = "";
            txtsueldoneto.Text = "";
        }
        private void buscarCodigo(string codigo)
        {
            using (SqlConnection cn = Conexion.conectar())
            {
                if (cn.State == ConnectionState.Closed)
                {
                    cn.Open();
                }

                try
                {
                    SqlCommand command;

                    if (string.IsNullOrEmpty(codigo))
                    {
                        command = new SqlCommand("SELECT * FROM pagoempleado", cn);
                    }
                    else
                    {
                        command = new SqlCommand("SELECT * FROM pagoempleado WHERE id = @id", cn);
                        command.Parameters.AddWithValue("@id", codigo);
                    }

                    SqlDataReader reader = command.ExecuteReader();

                    DataTable dataTable = new DataTable();
                    dataTable.Load(reader);
                    dataGridView1.DataSource = dataTable;

                    // Mostrar un mensaje si no se encontraron resultados
                    if (dataTable.Rows.Count == 0)
                    {
                        MessageBox.Show("No se encontraron resultados.");
                    }

                    limpiar();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }




        private void button3_Click(object sender, EventArgs e)
        {
            using (SqlConnection cn = Conexion.conectar())
            {
                if (cn.State == ConnectionState.Closed)
                {
                    cn.Open();
                }

                try
                {
                    // Obtener el ID del registro a eliminar
                    int id = Convert.ToInt32(txtId.Text);

                    // Crear la consulta SQL para eliminar el registro
                    string query = "DELETE FROM pagoempleado WHERE id = @id";

                    // Crear el comando SQL y agregar los parámetros necesarios
                    SqlCommand command = new SqlCommand(query, cn);
                    command.Parameters.AddWithValue("@id", id);

                    // Ejecutar el comando SQL y obtener el número de filas afectadas
                    int result = command.ExecuteNonQuery();

                    if (result > 0)
                    {
                        MessageBox.Show("Registro eliminado con éxito.");
                        mostrarDatos();
                        limpiar();
                    }
                    else
                    {
                        MessageBox.Show("No se pudo eliminar el registro.");
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                // Obtener los valores de las celdas y mostrarlos en los campos correspondientes
                txtId.Text = row.Cells["id"].Value.ToString();
                txtnombre.Text = row.Cells["nombre"].Value.ToString();
                txtapellido.Text = row.Cells["apellido"].Value.ToString();
                txtcargo.Text = row.Cells["cargo"].Value.ToString();
                txtsaldobruto.Text = row.Cells["sueldo_bruto"].Value.ToString();
                txtmontohoraextra.Text = row.Cells["horas_extras"].Value.ToString();
                txtseguromed.Text = row.Cells["seguro"].Value.ToString();
                txtadelantosueldo.Text = row.Cells["adelanto_sueldo"].Value.ToString();
                txtsueldoneto.Text = row.Cells["sueldo_neto"].Value.ToString();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        private void btnbuscar_Click(object sender, EventArgs e)
        {
            // Obtener el valor a buscar desde el campo txtBuscar
            string valorABuscar = txtlb.Text.Trim();

            using (SqlConnection cn = Conexion.conectar())
            {
                if (cn.State == ConnectionState.Closed)
                {
                    cn.Open();
                }

                // Preparar la consulta a la base de datos
                string consulta = "SELECT nombre, apellido, cargo, Salario FROM empleados WHERE cedula = @valorABuscar OR nombre LIKE @nombre";
                SqlCommand comando = new SqlCommand(consulta, cn);
                comando.Parameters.AddWithValue("@valorABuscar", valorABuscar);
                comando.Parameters.AddWithValue("@nombre", "%" + valorABuscar + "%");

                try
                {
                    // Ejecutar la consulta y obtener los datos del empleado
                    SqlDataReader reader = comando.ExecuteReader();
                    if (reader.Read())
                    {
                        // Si se encontró el empleado, rellenar los campos correspondientes
                        txtnombre.Text = reader["nombre"].ToString();
                        txtapellido.Text = reader["apellido"].ToString();
                        txtcargo.Text = reader["cargo"].ToString();
                        txtsaldobruto.Text = reader["Salario"].ToString();
                    }
                    else
                    {
                        // Si no se encontró el empleado, mostrar un mensaje al usuario
                        MessageBox.Show("No se encontró ningún empleado con esa cédula o nombre.");
                    }
                }
                catch (Exception ex)
                {
                    // Mostrar un mensaje de error si ocurre alguna excepción
                    MessageBox.Show("Ocurrió un error al buscar el empleado: " + ex.Message);
                }
                finally
                {
                    // Cerrar la conexión a la base de datos si está abierta
                    if (cn.State == ConnectionState.Open)
                    {
                        cn.Close();
                    }
                }
            }



        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Obtener la referencia de la ventana anterior
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

        private void btncalcular_Click(object sender, EventArgs e)
        {
            // Obtener los valores del salario bruto, horas extras, asignaciones, seguro y adelanto de sueldo
            decimal salarioBruto = decimal.Parse(txtsaldobruto.Text);
            decimal horasExtras = decimal.Parse(txtmontohoraextra.Text);
            decimal asignaciones = decimal.Parse(txttotalasignaciones.Text);
            decimal seguro = decimal.Parse(txtseguromed.Text);
            decimal adelantoSueldo = decimal.Parse(txtadelantosueldo.Text);

            // Calcular el salario bruto incluyendo las horas extras y las asignaciones
            decimal salarioBrutoConExtras = salarioBruto + horasExtras + asignaciones;

            // Calcular el total de deducciones restando el seguro y el adelanto de sueldo del salario bruto
            decimal totalDeducciones = seguro + adelantoSueldo;
            txttotaldeducciones.Text = totalDeducciones.ToString();

            // Calcular el salario neto restando el total de deducciones del salario bruto más las horas extras y las asignaciones
            decimal salarioNeto = salarioBrutoConExtras - totalDeducciones;

            // Asignar el salario neto al campo correspondiente
            txtsueldoneto.Text = salarioNeto.ToString();


        }

        private void txtadelantosueldo_TextChanged(object sender, EventArgs e)
        {
            // Obtener los valores del salario bruto, horas extras, asignaciones, seguro y adelanto de sueldo
            decimal salarioBruto = 0;
            decimal.TryParse(txtsaldobruto.Text, out salarioBruto);

            decimal horasExtras = 0;
            decimal.TryParse(txtmontohoraextra.Text, out horasExtras);

            decimal asignaciones = 0;
            decimal.TryParse(txttotalasignaciones.Text, out asignaciones);

            decimal seguro = 0;
            decimal.TryParse(txtseguromed.Text, out seguro);

            decimal adelantoSueldo = 0;
            decimal.TryParse(txtadelantosueldo.Text, out adelantoSueldo);

            // Calcular el salario bruto incluyendo las horas extras y las asignaciones
            decimal salarioBrutoConExtras = salarioBruto + horasExtras + asignaciones;

            // Calcular el total de deducciones restando el seguro y el adelanto de sueldo del salario bruto
            decimal totalDeducciones = seguro + adelantoSueldo;
            txttotaldeducciones.Text = totalDeducciones.ToString();

            // Calcular el salario neto restando el total de deducciones del salario bruto más las horas extras y las asignaciones
            decimal salarioNeto = salarioBrutoConExtras - totalDeducciones;

            // Asignar el salario neto al campo correspondiente
            txtsueldoneto.Text = salarioNeto.ToString();

        }

        private void btnNuevo(object sender, EventArgs e)
        {
            limpiar();
        }
    }

}
