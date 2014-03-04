namespace Bodega.Plantillas
{
    partial class PlantillaLista
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
            this.toolBarra = new System.Windows.Forms.ToolStrip();
            this.toolNuevo = new System.Windows.Forms.ToolStripButton();
            this.toolEditar = new System.Windows.Forms.ToolStripButton();
            this.toolBuscar = new System.Windows.Forms.ToolStripButton();
            this.toolEliminar = new System.Windows.Forms.ToolStripButton();
            this.toolBarra.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolBarra
            // 
            this.toolBarra.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolNuevo,
            this.toolEditar,
            this.toolEliminar,
            this.toolBuscar});
            this.toolBarra.Location = new System.Drawing.Point(0, 0);
            this.toolBarra.Name = "toolBarra";
            this.toolBarra.Size = new System.Drawing.Size(551, 25);
            this.toolBarra.TabIndex = 0;
            this.toolBarra.Text = "toolStrip1";
            // 
            // toolNuevo
            // 
            this.toolNuevo.Image = global::Bodega.Plantillas.Properties.Resources.Nuevo_16x16;
            this.toolNuevo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolNuevo.Name = "toolNuevo";
            this.toolNuevo.Size = new System.Drawing.Size(62, 22);
            this.toolNuevo.Text = "&Nuevo";
            // 
            // toolEditar
            // 
            this.toolEditar.Image = global::Bodega.Plantillas.Properties.Resources.Editar_16x16;
            this.toolEditar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolEditar.Name = "toolEditar";
            this.toolEditar.Size = new System.Drawing.Size(79, 22);
            this.toolEditar.Text = "&Ver/Editar";
            // 
            // toolBuscar
            // 
            this.toolBuscar.Image = global::Bodega.Plantillas.Properties.Resources.Buscar_16x16;
            this.toolBuscar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolBuscar.Name = "toolBuscar";
            this.toolBuscar.Size = new System.Drawing.Size(62, 22);
            this.toolBuscar.Text = "&Buscar";
            // 
            // toolEliminar
            // 
            this.toolEliminar.Image = global::Bodega.Plantillas.Properties.Resources.Eliminar_16x16;
            this.toolEliminar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolEliminar.Name = "toolEliminar";
            this.toolEliminar.Size = new System.Drawing.Size(70, 22);
            this.toolEliminar.Text = "&Eliminar";
            // 
            // PlantillaLista
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(551, 403);
            this.Controls.Add(this.toolBarra);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            this.MaximizeBox = true;
            this.Name = "PlantillaLista";
            this.Text = "PlantillaLista";
            this.toolBarra.ResumeLayout(false);
            this.toolBarra.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolBarra;
        private System.Windows.Forms.ToolStripButton toolNuevo;
        private System.Windows.Forms.ToolStripButton toolEditar;
        private System.Windows.Forms.ToolStripButton toolEliminar;
        private System.Windows.Forms.ToolStripButton toolBuscar;
    }
}