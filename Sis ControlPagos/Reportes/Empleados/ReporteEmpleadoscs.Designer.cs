namespace Sis_ControlPagos.Reportes
{
    partial class ReporteEmpleadoscs
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
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.proyectoecomuni2023DataSet = new Sis_ControlPagos.proyectoecomuni2023DataSet();
            this.empleadosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.empleadosTableAdapter = new Sis_ControlPagos.proyectoecomuni2023DataSetTableAdapters.empleadosTableAdapter();
            this.empleadosBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.empleadosBindingSource2 = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.proyectoecomuni2023DataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.empleadosBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.empleadosBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.empleadosBindingSource2)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource2.Name = "DataSet1";
            reportDataSource2.Value = this.empleadosBindingSource2;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Sis_ControlPagos.Reportes.ReportEmpleados.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(1461, 740);
            this.reportViewer1.TabIndex = 0;
            // 
            // proyectoecomuni2023DataSet
            // 
            this.proyectoecomuni2023DataSet.DataSetName = "proyectoecomuni2023DataSet";
            this.proyectoecomuni2023DataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // empleadosBindingSource
            // 
            this.empleadosBindingSource.DataMember = "empleados";
            this.empleadosBindingSource.DataSource = this.proyectoecomuni2023DataSet;
            // 
            // empleadosTableAdapter
            // 
            this.empleadosTableAdapter.ClearBeforeFill = true;
            // 
            // empleadosBindingSource1
            // 
            this.empleadosBindingSource1.DataMember = "empleados";
            this.empleadosBindingSource1.DataSource = this.proyectoecomuni2023DataSet;
            // 
            // empleadosBindingSource2
            // 
            this.empleadosBindingSource2.DataMember = "empleados";
            this.empleadosBindingSource2.DataSource = this.proyectoecomuni2023DataSet;
            // 
            // ReporteEmpleadoscs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1461, 740);
            this.Controls.Add(this.reportViewer1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.Name = "ReporteEmpleadoscs";
            this.Text = "ReporteEmpleadoscs";
            this.Load += new System.EventHandler(this.ReporteEmpleadoscs_Load);
            ((System.ComponentModel.ISupportInitialize)(this.proyectoecomuni2023DataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.empleadosBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.empleadosBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.empleadosBindingSource2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private proyectoecomuni2023DataSet proyectoecomuni2023DataSet;
        private System.Windows.Forms.BindingSource empleadosBindingSource;
        private proyectoecomuni2023DataSetTableAdapters.empleadosTableAdapter empleadosTableAdapter;
        private System.Windows.Forms.BindingSource empleadosBindingSource2;
        private System.Windows.Forms.BindingSource empleadosBindingSource1;
    }
}