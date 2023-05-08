namespace Sis_ControlPagos
{
    partial class VentanaPrincipal
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VentanaPrincipal));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.mantenimientoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.crearempleadoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.crearpagoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ficheroUsuarioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reportesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.empleadosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pagosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reportedeUsuarioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.consultasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.empleadosToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.pagoToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.consultaUsuarioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.White;
            this.menuStrip1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("menuStrip1.BackgroundImage")));
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mantenimientoToolStripMenuItem,
            this.reportesToolStripMenuItem,
            this.consultasToolStripMenuItem,
            this.salirToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1289, 28);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // mantenimientoToolStripMenuItem
            // 
            this.mantenimientoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.crearempleadoToolStripMenuItem,
            this.crearpagoToolStripMenuItem,
            this.ficheroUsuarioToolStripMenuItem});
            this.mantenimientoToolStripMenuItem.Name = "mantenimientoToolStripMenuItem";
            this.mantenimientoToolStripMenuItem.Size = new System.Drawing.Size(124, 24);
            this.mantenimientoToolStripMenuItem.Text = "Mantenimiento";
            // 
            // crearempleadoToolStripMenuItem
            // 
            this.crearempleadoToolStripMenuItem.BackColor = System.Drawing.Color.Transparent;
            this.crearempleadoToolStripMenuItem.Name = "crearempleadoToolStripMenuItem";
            this.crearempleadoToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.crearempleadoToolStripMenuItem.Text = "Ficheros Empleados";
            this.crearempleadoToolStripMenuItem.Click += new System.EventHandler(this.crearempleadoToolStripMenuItem_Click);
            // 
            // crearpagoToolStripMenuItem
            // 
            this.crearpagoToolStripMenuItem.Name = "crearpagoToolStripMenuItem";
            this.crearpagoToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.crearpagoToolStripMenuItem.Text = "Ficheros Pago";
            this.crearpagoToolStripMenuItem.Click += new System.EventHandler(this.crearpagoToolStripMenuItem_Click);
            // 
            // ficheroUsuarioToolStripMenuItem
            // 
            this.ficheroUsuarioToolStripMenuItem.BackColor = System.Drawing.Color.Transparent;
            this.ficheroUsuarioToolStripMenuItem.Name = "ficheroUsuarioToolStripMenuItem";
            this.ficheroUsuarioToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.ficheroUsuarioToolStripMenuItem.Text = "Fichero Usuario";
            this.ficheroUsuarioToolStripMenuItem.Click += new System.EventHandler(this.ficheroUsuarioToolStripMenuItem_Click);
            // 
            // reportesToolStripMenuItem
            // 
            this.reportesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.empleadosToolStripMenuItem,
            this.pagosToolStripMenuItem,
            this.reportedeUsuarioToolStripMenuItem});
            this.reportesToolStripMenuItem.Name = "reportesToolStripMenuItem";
            this.reportesToolStripMenuItem.Size = new System.Drawing.Size(82, 24);
            this.reportesToolStripMenuItem.Text = "Reportes";
            // 
            // empleadosToolStripMenuItem
            // 
            this.empleadosToolStripMenuItem.Name = "empleadosToolStripMenuItem";
            this.empleadosToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.empleadosToolStripMenuItem.Text = "Reporte Empleado";
            this.empleadosToolStripMenuItem.Click += new System.EventHandler(this.empleadosToolStripMenuItem_Click);
            // 
            // pagosToolStripMenuItem
            // 
            this.pagosToolStripMenuItem.Name = "pagosToolStripMenuItem";
            this.pagosToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.pagosToolStripMenuItem.Text = " Reportes Pagos";
            this.pagosToolStripMenuItem.Click += new System.EventHandler(this.pagosToolStripMenuItem_Click);
            // 
            // reportedeUsuarioToolStripMenuItem
            // 
            this.reportedeUsuarioToolStripMenuItem.Name = "reportedeUsuarioToolStripMenuItem";
            this.reportedeUsuarioToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.reportedeUsuarioToolStripMenuItem.Text = "Reporte Usuario";
            this.reportedeUsuarioToolStripMenuItem.Click += new System.EventHandler(this.reportedeUsuarioToolStripMenuItem_Click);
            // 
            // consultasToolStripMenuItem
            // 
            this.consultasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.empleadosToolStripMenuItem1,
            this.pagoToolStripMenuItem1,
            this.consultaUsuarioToolStripMenuItem});
            this.consultasToolStripMenuItem.Name = "consultasToolStripMenuItem";
            this.consultasToolStripMenuItem.Size = new System.Drawing.Size(86, 24);
            this.consultasToolStripMenuItem.Text = "Consultas";
            // 
            // empleadosToolStripMenuItem1
            // 
            this.empleadosToolStripMenuItem1.Name = "empleadosToolStripMenuItem1";
            this.empleadosToolStripMenuItem1.Size = new System.Drawing.Size(227, 26);
            this.empleadosToolStripMenuItem1.Text = "Consulta Empleados";
            this.empleadosToolStripMenuItem1.Click += new System.EventHandler(this.empleadosToolStripMenuItem1_Click);
            // 
            // pagoToolStripMenuItem1
            // 
            this.pagoToolStripMenuItem1.Name = "pagoToolStripMenuItem1";
            this.pagoToolStripMenuItem1.Size = new System.Drawing.Size(227, 26);
            this.pagoToolStripMenuItem1.Text = "Consulta Pago";
            this.pagoToolStripMenuItem1.Click += new System.EventHandler(this.pagoToolStripMenuItem1_Click);
            // 
            // consultaUsuarioToolStripMenuItem
            // 
            this.consultaUsuarioToolStripMenuItem.Name = "consultaUsuarioToolStripMenuItem";
            this.consultaUsuarioToolStripMenuItem.Size = new System.Drawing.Size(227, 26);
            this.consultaUsuarioToolStripMenuItem.Text = "Consulta Usuario";
            this.consultaUsuarioToolStripMenuItem.Click += new System.EventHandler(this.consultaUsuarioToolStripMenuItem_Click);
            // 
            // salirToolStripMenuItem
            // 
            this.salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            this.salirToolStripMenuItem.Size = new System.Drawing.Size(52, 24);
            this.salirToolStripMenuItem.Text = "Salir";
            this.salirToolStripMenuItem.Click += new System.EventHandler(this.salirToolStripMenuItem_Click);
            // 
            // VentanaPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1289, 679);
            this.Controls.Add(this.menuStrip1);
            this.Name = "VentanaPrincipal";
            this.Text = "VentanaPrincipal";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mantenimientoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem crearempleadoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem crearpagoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ficheroUsuarioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reportesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem empleadosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pagosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reportedeUsuarioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem consultasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem empleadosToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem pagoToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem consultaUsuarioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salirToolStripMenuItem;
    }
}