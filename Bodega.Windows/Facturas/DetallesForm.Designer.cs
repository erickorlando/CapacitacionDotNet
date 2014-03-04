namespace Bodega.Windows.Facturas
{
    partial class DetallesForm
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
            System.Windows.Forms.Label productoLabel;
            System.Windows.Forms.Label precioUnitarioLabel;
            System.Windows.Forms.Label cantidadLabel;
            System.Windows.Forms.Label totalLabel;
            this.detallesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.productoComboBox = new System.Windows.Forms.ComboBox();
            this.productoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.precioUnitarioTextBox = new System.Windows.Forms.TextBox();
            this.cantidadTextBox = new System.Windows.Forms.TextBox();
            this.totalTextBox = new System.Windows.Forms.TextBox();
            productoLabel = new System.Windows.Forms.Label();
            precioUnitarioLabel = new System.Windows.Forms.Label();
            cantidadLabel = new System.Windows.Forms.Label();
            totalLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.detallesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.productoBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // productoLabel
            // 
            productoLabel.AutoSize = true;
            productoLabel.Location = new System.Drawing.Point(12, 43);
            productoLabel.Name = "productoLabel";
            productoLabel.Size = new System.Drawing.Size(53, 13);
            productoLabel.TabIndex = 4;
            productoLabel.Text = "Producto:";
            // 
            // precioUnitarioLabel
            // 
            precioUnitarioLabel.AutoSize = true;
            precioUnitarioLabel.Location = new System.Drawing.Point(12, 74);
            precioUnitarioLabel.Name = "precioUnitarioLabel";
            precioUnitarioLabel.Size = new System.Drawing.Size(79, 13);
            precioUnitarioLabel.TabIndex = 5;
            precioUnitarioLabel.Text = "Precio Unitario:";
            // 
            // cantidadLabel
            // 
            cantidadLabel.AutoSize = true;
            cantidadLabel.Location = new System.Drawing.Point(12, 99);
            cantidadLabel.Name = "cantidadLabel";
            cantidadLabel.Size = new System.Drawing.Size(52, 13);
            cantidadLabel.TabIndex = 6;
            cantidadLabel.Text = "Cantidad:";
            // 
            // totalLabel
            // 
            totalLabel.AutoSize = true;
            totalLabel.Location = new System.Drawing.Point(12, 125);
            totalLabel.Name = "totalLabel";
            totalLabel.Size = new System.Drawing.Size(34, 13);
            totalLabel.TabIndex = 7;
            totalLabel.Text = "Total:";
            // 
            // detallesBindingSource
            // 
            this.detallesBindingSource.DataSource = typeof(Bodega.Negocio.DetalleFacturaNegocio);
            // 
            // productoComboBox
            // 
            this.productoComboBox.DataSource = this.productoBindingSource;
            this.productoComboBox.DisplayMember = "Descripcion";
            this.productoComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.productoComboBox.FormattingEnabled = true;
            this.productoComboBox.Location = new System.Drawing.Point(99, 40);
            this.productoComboBox.Name = "productoComboBox";
            this.productoComboBox.Size = new System.Drawing.Size(121, 21);
            this.productoComboBox.TabIndex = 5;
            this.productoComboBox.ValueMember = "IdProducto";
            // 
            // productoBindingSource
            // 
            this.productoBindingSource.DataSource = typeof(Bodega.Entidades.Producto);
            // 
            // precioUnitarioTextBox
            // 
            this.precioUnitarioTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.detallesBindingSource, "PrecioUnitario", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged, null, "C2"));
            this.precioUnitarioTextBox.Location = new System.Drawing.Point(99, 71);
            this.precioUnitarioTextBox.Name = "precioUnitarioTextBox";
            this.precioUnitarioTextBox.Size = new System.Drawing.Size(61, 20);
            this.precioUnitarioTextBox.TabIndex = 6;
            // 
            // cantidadTextBox
            // 
            this.cantidadTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.detallesBindingSource, "Cantidad", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged, null, "C2"));
            this.cantidadTextBox.Location = new System.Drawing.Point(99, 96);
            this.cantidadTextBox.Name = "cantidadTextBox";
            this.cantidadTextBox.Size = new System.Drawing.Size(61, 20);
            this.cantidadTextBox.TabIndex = 7;
            // 
            // totalTextBox
            // 
            this.totalTextBox.BackColor = System.Drawing.Color.LightYellow;
            this.totalTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.detallesBindingSource, "Total", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, null, "C2"));
            this.totalTextBox.Location = new System.Drawing.Point(99, 122);
            this.totalTextBox.Name = "totalTextBox";
            this.totalTextBox.ReadOnly = true;
            this.totalTextBox.Size = new System.Drawing.Size(61, 20);
            this.totalTextBox.TabIndex = 8;
            // 
            // DetallesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(306, 158);
            this.Controls.Add(totalLabel);
            this.Controls.Add(this.totalTextBox);
            this.Controls.Add(cantidadLabel);
            this.Controls.Add(this.cantidadTextBox);
            this.Controls.Add(precioUnitarioLabel);
            this.Controls.Add(this.precioUnitarioTextBox);
            this.Controls.Add(productoLabel);
            this.Controls.Add(this.productoComboBox);
            this.Name = "DetallesForm";
            this.Text = "DetallesForm";
            this.Controls.SetChildIndex(this.productoComboBox, 0);
            this.Controls.SetChildIndex(productoLabel, 0);
            this.Controls.SetChildIndex(this.precioUnitarioTextBox, 0);
            this.Controls.SetChildIndex(precioUnitarioLabel, 0);
            this.Controls.SetChildIndex(this.cantidadTextBox, 0);
            this.Controls.SetChildIndex(cantidadLabel, 0);
            this.Controls.SetChildIndex(this.totalTextBox, 0);
            this.Controls.SetChildIndex(totalLabel, 0);
            ((System.ComponentModel.ISupportInitialize)(this.detallesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.productoBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource detallesBindingSource;
        private System.Windows.Forms.ComboBox productoComboBox;
        private System.Windows.Forms.TextBox precioUnitarioTextBox;
        private System.Windows.Forms.TextBox cantidadTextBox;
        private System.Windows.Forms.TextBox totalTextBox;
        private System.Windows.Forms.BindingSource productoBindingSource;
    }
}