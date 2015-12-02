namespace Bodega.Windows.Facturas
{
    partial class FacturasForm
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
			System.Windows.Forms.Label fechaLabel;
			System.Windows.Forms.Label subTotalLabel;
			System.Windows.Forms.Label impuestosLabel;
			System.Windows.Forms.Label totalLabel;
			System.Windows.Forms.Label clienteLabel;
			this.facturaNegocioBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.fechaDateTimePicker = new System.Windows.Forms.DateTimePicker();
			this.detallesBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.detallesDataGridView = new System.Windows.Forms.DataGridView();
			this.DescripcionProducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.subTotalTextBox = new System.Windows.Forms.TextBox();
			this.impuestosTextBox = new System.Windows.Forms.TextBox();
			this.totalTextBox = new System.Windows.Forms.TextBox();
			this.btmAgregar = new System.Windows.Forms.Button();
			this.btnEliminar = new System.Windows.Forms.Button();
			this.clienteComboBox = new System.Windows.Forms.ComboBox();
			this.clientesBindingSource = new System.Windows.Forms.BindingSource(this.components);
			fechaLabel = new System.Windows.Forms.Label();
			subTotalLabel = new System.Windows.Forms.Label();
			impuestosLabel = new System.Windows.Forms.Label();
			totalLabel = new System.Windows.Forms.Label();
			clienteLabel = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.facturaNegocioBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.detallesBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.detallesDataGridView)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.clientesBindingSource)).BeginInit();
			this.SuspendLayout();
			// 
			// fechaLabel
			// 
			fechaLabel.AutoSize = true;
			fechaLabel.Location = new System.Drawing.Point(8, 42);
			fechaLabel.Name = "fechaLabel";
			fechaLabel.Size = new System.Drawing.Size(40, 13);
			fechaLabel.TabIndex = 3;
			fechaLabel.Text = "Fecha:";
			// 
			// subTotalLabel
			// 
			subTotalLabel.AutoSize = true;
			subTotalLabel.Location = new System.Drawing.Point(385, 349);
			subTotalLabel.Name = "subTotalLabel";
			subTotalLabel.Size = new System.Drawing.Size(56, 13);
			subTotalLabel.TabIndex = 6;
			subTotalLabel.Text = "Sub Total:";
			// 
			// impuestosLabel
			// 
			impuestosLabel.AutoSize = true;
			impuestosLabel.Location = new System.Drawing.Point(383, 375);
			impuestosLabel.Name = "impuestosLabel";
			impuestosLabel.Size = new System.Drawing.Size(58, 13);
			impuestosLabel.TabIndex = 8;
			impuestosLabel.Text = "Impuestos:";
			// 
			// totalLabel
			// 
			totalLabel.AutoSize = true;
			totalLabel.Location = new System.Drawing.Point(408, 401);
			totalLabel.Name = "totalLabel";
			totalLabel.Size = new System.Drawing.Size(34, 13);
			totalLabel.TabIndex = 10;
			totalLabel.Text = "Total:";
			// 
			// clienteLabel
			// 
			clienteLabel.AutoSize = true;
			clienteLabel.Location = new System.Drawing.Point(8, 67);
			clienteLabel.Name = "clienteLabel";
			clienteLabel.Size = new System.Drawing.Size(42, 13);
			clienteLabel.TabIndex = 12;
			clienteLabel.Text = "Cliente:";
			// 
			// facturaNegocioBindingSource
			// 
			this.facturaNegocioBindingSource.DataSource = typeof(Bodega.Negocio.FacturaNegocio);
			// 
			// fechaDateTimePicker
			// 
			this.fechaDateTimePicker.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.facturaNegocioBindingSource, "Fecha", true));
			this.fechaDateTimePicker.Location = new System.Drawing.Point(56, 38);
			this.fechaDateTimePicker.Name = "fechaDateTimePicker";
			this.fechaDateTimePicker.Size = new System.Drawing.Size(200, 20);
			this.fechaDateTimePicker.TabIndex = 4;
			// 
			// detallesBindingSource
			// 
			this.detallesBindingSource.DataMember = "Detalles";
			this.detallesBindingSource.DataSource = this.facturaNegocioBindingSource;
			// 
			// detallesDataGridView
			// 
			this.detallesDataGridView.AllowUserToAddRows = false;
			this.detallesDataGridView.AllowUserToDeleteRows = false;
			this.detallesDataGridView.AutoGenerateColumns = false;
			this.detallesDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.detallesDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DescripcionProducto,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4});
			this.detallesDataGridView.DataSource = this.detallesBindingSource;
			this.detallesDataGridView.Location = new System.Drawing.Point(12, 121);
			this.detallesDataGridView.Name = "detallesDataGridView";
			this.detallesDataGridView.Size = new System.Drawing.Size(536, 220);
			this.detallesDataGridView.TabIndex = 5;
			// 
			// DescripcionProducto
			// 
			this.DescripcionProducto.DataPropertyName = "DescripcionProducto";
			this.DescripcionProducto.HeaderText = "Producto";
			this.DescripcionProducto.Name = "DescripcionProducto";
			this.DescripcionProducto.ReadOnly = true;
			// 
			// dataGridViewTextBoxColumn2
			// 
			this.dataGridViewTextBoxColumn2.DataPropertyName = "Cantidad";
			this.dataGridViewTextBoxColumn2.HeaderText = "Cantidad";
			this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
			// 
			// dataGridViewTextBoxColumn3
			// 
			this.dataGridViewTextBoxColumn3.DataPropertyName = "PrecioUnitario";
			this.dataGridViewTextBoxColumn3.HeaderText = "PrecioUnitario";
			this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
			// 
			// dataGridViewTextBoxColumn4
			// 
			this.dataGridViewTextBoxColumn4.DataPropertyName = "Total";
			this.dataGridViewTextBoxColumn4.HeaderText = "Total";
			this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
			this.dataGridViewTextBoxColumn4.ReadOnly = true;
			// 
			// subTotalTextBox
			// 
			this.subTotalTextBox.BackColor = System.Drawing.Color.LightYellow;
			this.subTotalTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.facturaNegocioBindingSource, "SubTotal", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, null, "C2"));
			this.subTotalTextBox.Location = new System.Drawing.Point(447, 346);
			this.subTotalTextBox.Name = "subTotalTextBox";
			this.subTotalTextBox.ReadOnly = true;
			this.subTotalTextBox.Size = new System.Drawing.Size(100, 20);
			this.subTotalTextBox.TabIndex = 7;
			// 
			// impuestosTextBox
			// 
			this.impuestosTextBox.BackColor = System.Drawing.Color.LightYellow;
			this.impuestosTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.facturaNegocioBindingSource, "Impuestos", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, null, "C2"));
			this.impuestosTextBox.Location = new System.Drawing.Point(447, 372);
			this.impuestosTextBox.Name = "impuestosTextBox";
			this.impuestosTextBox.ReadOnly = true;
			this.impuestosTextBox.Size = new System.Drawing.Size(100, 20);
			this.impuestosTextBox.TabIndex = 9;
			// 
			// totalTextBox
			// 
			this.totalTextBox.BackColor = System.Drawing.Color.LightYellow;
			this.totalTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.facturaNegocioBindingSource, "Total", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, null, "C2"));
			this.totalTextBox.Location = new System.Drawing.Point(448, 398);
			this.totalTextBox.Name = "totalTextBox";
			this.totalTextBox.ReadOnly = true;
			this.totalTextBox.Size = new System.Drawing.Size(100, 20);
			this.totalTextBox.TabIndex = 11;
			// 
			// btmAgregar
			// 
			this.btmAgregar.Location = new System.Drawing.Point(386, 92);
			this.btmAgregar.Name = "btmAgregar";
			this.btmAgregar.Size = new System.Drawing.Size(75, 23);
			this.btmAgregar.TabIndex = 12;
			this.btmAgregar.Text = "&Agregar";
			this.btmAgregar.UseVisualStyleBackColor = true;
			this.btmAgregar.Click += new System.EventHandler(this.btmAgregar_Click);
			// 
			// btnEliminar
			// 
			this.btnEliminar.Location = new System.Drawing.Point(472, 92);
			this.btnEliminar.Name = "btnEliminar";
			this.btnEliminar.Size = new System.Drawing.Size(75, 23);
			this.btnEliminar.TabIndex = 12;
			this.btnEliminar.Text = "&Eliminar";
			this.btnEliminar.UseVisualStyleBackColor = true;
			this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
			// 
			// clienteComboBox
			// 
			this.clienteComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
			this.clienteComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
			this.clienteComboBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.facturaNegocioBindingSource, "Cliente", true));
			this.clienteComboBox.DataSource = this.clientesBindingSource;
			this.clienteComboBox.DisplayMember = "Nombres";
			this.clienteComboBox.FormattingEnabled = true;
			this.clienteComboBox.Location = new System.Drawing.Point(56, 64);
			this.clienteComboBox.Name = "clienteComboBox";
			this.clienteComboBox.Size = new System.Drawing.Size(200, 21);
			this.clienteComboBox.TabIndex = 13;
			this.clienteComboBox.ValueMember = "IdCliente";
			// 
			// clientesBindingSource
			// 
			this.clientesBindingSource.DataSource = typeof(Bodega.Entidades.Clientes);
			// 
			// FacturasForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(568, 438);
			this.Controls.Add(clienteLabel);
			this.Controls.Add(this.clienteComboBox);
			this.Controls.Add(this.btnEliminar);
			this.Controls.Add(this.btmAgregar);
			this.Controls.Add(totalLabel);
			this.Controls.Add(this.totalTextBox);
			this.Controls.Add(impuestosLabel);
			this.Controls.Add(this.impuestosTextBox);
			this.Controls.Add(subTotalLabel);
			this.Controls.Add(this.subTotalTextBox);
			this.Controls.Add(this.detallesDataGridView);
			this.Controls.Add(fechaLabel);
			this.Controls.Add(this.fechaDateTimePicker);
			this.Name = "FacturasForm";
			this.Text = "Facturas";
			this.Load += new System.EventHandler(this.FacturasForm_Load);
			this.Controls.SetChildIndex(this.fechaDateTimePicker, 0);
			this.Controls.SetChildIndex(fechaLabel, 0);
			this.Controls.SetChildIndex(this.detallesDataGridView, 0);
			this.Controls.SetChildIndex(this.subTotalTextBox, 0);
			this.Controls.SetChildIndex(subTotalLabel, 0);
			this.Controls.SetChildIndex(this.impuestosTextBox, 0);
			this.Controls.SetChildIndex(impuestosLabel, 0);
			this.Controls.SetChildIndex(this.totalTextBox, 0);
			this.Controls.SetChildIndex(totalLabel, 0);
			this.Controls.SetChildIndex(this.btmAgregar, 0);
			this.Controls.SetChildIndex(this.btnEliminar, 0);
			this.Controls.SetChildIndex(this.clienteComboBox, 0);
			this.Controls.SetChildIndex(clienteLabel, 0);
			((System.ComponentModel.ISupportInitialize)(this.facturaNegocioBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.detallesBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.detallesDataGridView)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.clientesBindingSource)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

		private System.Windows.Forms.BindingSource facturaNegocioBindingSource;
        private System.Windows.Forms.DateTimePicker fechaDateTimePicker;
        private System.Windows.Forms.BindingSource detallesBindingSource;
        private System.Windows.Forms.DataGridView detallesDataGridView;
        private System.Windows.Forms.TextBox subTotalTextBox;
        private System.Windows.Forms.TextBox impuestosTextBox;
        private System.Windows.Forms.TextBox totalTextBox;
        private System.Windows.Forms.Button btmAgregar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.ComboBox clienteComboBox;
        private System.Windows.Forms.BindingSource clientesBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn DescripcionProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
    }
}