namespace Sistema.Presentation
{
    partial class FrmIngreso
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
            this.ErrorIcono = new System.Windows.Forms.ErrorProvider(this.components);
            this.BtnCancelar = new System.Windows.Forms.Button();
            this.BtnInsertar = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.TxtId = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.PanelArticulos = new System.Windows.Forms.Panel();
            this.LblTotalArticulos = new System.Windows.Forms.Label();
            this.DgvArticulos = new System.Windows.Forms.DataGridView();
            this.BtnCerrarArticulos = new System.Windows.Forms.Button();
            this.BtnFiltrarArticulos = new System.Windows.Forms.Button();
            this.TxtBuscarArticulo = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.TxtTotal = new System.Windows.Forms.TextBox();
            this.TxtTotalImpuestos = new System.Windows.Forms.TextBox();
            this.TxtSubTotal = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.LbTotalImpuestos = new System.Windows.Forms.Label();
            this.DgvDetalle = new System.Windows.Forms.DataGridView();
            this.BtnVerArticulos = new System.Windows.Forms.Button();
            this.TxtCodigo = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.TxtImpuestos = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.TxtNumComprobante = new System.Windows.Forms.TextBox();
            this.TxtSerieComprobante = new System.Windows.Forms.TextBox();
            this.CboComprobante = new System.Windows.Forms.ComboBox();
            this.BtnBuscarProveedor = new System.Windows.Forms.Button();
            this.TxtNombreProveedor = new System.Windows.Forms.TextBox();
            this.TxtIdProveedor = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Seleccionar = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.BtnAnular = new System.Windows.Forms.Button();
            this.ChkSeleccion = new System.Windows.Forms.CheckBox();
            this.BtnBuscar = new System.Windows.Forms.Button();
            this.TxtBuscar = new System.Windows.Forms.TextBox();
            this.LblTotal = new System.Windows.Forms.Label();
            this.DgvListado = new System.Windows.Forms.DataGridView();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.TabGeneral = new System.Windows.Forms.TabControl();
            this.PanelMostrar = new System.Windows.Forms.Panel();
            this.DgvMostrarDetalle = new System.Windows.Forms.DataGridView();
            this.BtnCerrarDetalle = new System.Windows.Forms.Button();
            this.TxtTotalD = new System.Windows.Forms.TextBox();
            this.TxtTotalImpuestoD = new System.Windows.Forms.TextBox();
            this.TxtSubTotalD = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ErrorIcono)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.PanelArticulos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvArticulos)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvDetalle)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvListado)).BeginInit();
            this.tabPage1.SuspendLayout();
            this.TabGeneral.SuspendLayout();
            this.PanelMostrar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvMostrarDetalle)).BeginInit();
            this.SuspendLayout();
            // 
            // ErrorIcono
            // 
            this.ErrorIcono.ContainerControl = this;
            // 
            // BtnCancelar
            // 
            this.BtnCancelar.Location = new System.Drawing.Point(269, 611);
            this.BtnCancelar.Margin = new System.Windows.Forms.Padding(2);
            this.BtnCancelar.Name = "BtnCancelar";
            this.BtnCancelar.Size = new System.Drawing.Size(215, 46);
            this.BtnCancelar.TabIndex = 7;
            this.BtnCancelar.Text = "Cancelar";
            this.BtnCancelar.UseVisualStyleBackColor = true;
            this.BtnCancelar.Click += new System.EventHandler(this.BtnCancelar_Click);
            // 
            // BtnInsertar
            // 
            this.BtnInsertar.Location = new System.Drawing.Point(35, 611);
            this.BtnInsertar.Margin = new System.Windows.Forms.Padding(2);
            this.BtnInsertar.Name = "BtnInsertar";
            this.BtnInsertar.Size = new System.Drawing.Size(210, 46);
            this.BtnInsertar.TabIndex = 6;
            this.BtnInsertar.Text = "Insertar";
            this.BtnInsertar.UseVisualStyleBackColor = true;
            this.BtnInsertar.Click += new System.EventHandler(this.BtnInsertar_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(32, 579);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(170, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "(*) Indica que el dato es obligatorio";
            // 
            // TxtId
            // 
            this.TxtId.Location = new System.Drawing.Point(590, 18);
            this.TxtId.Margin = new System.Windows.Forms.Padding(2);
            this.TxtId.Name = "TxtId";
            this.TxtId.Size = new System.Drawing.Size(101, 20);
            this.TxtId.TabIndex = 4;
            this.TxtId.Visible = false;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.PanelArticulos);
            this.tabPage2.Controls.Add(this.groupBox2);
            this.tabPage2.Controls.Add(this.groupBox1);
            this.tabPage2.Controls.Add(this.BtnCancelar);
            this.tabPage2.Controls.Add(this.BtnInsertar);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(981, 677);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Mantenimiento";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // PanelArticulos
            // 
            this.PanelArticulos.BackColor = System.Drawing.Color.LightSkyBlue;
            this.PanelArticulos.Controls.Add(this.LblTotalArticulos);
            this.PanelArticulos.Controls.Add(this.DgvArticulos);
            this.PanelArticulos.Controls.Add(this.BtnCerrarArticulos);
            this.PanelArticulos.Controls.Add(this.BtnFiltrarArticulos);
            this.PanelArticulos.Controls.Add(this.TxtBuscarArticulo);
            this.PanelArticulos.Controls.Add(this.label8);
            this.PanelArticulos.Location = new System.Drawing.Point(61, 267);
            this.PanelArticulos.Name = "PanelArticulos";
            this.PanelArticulos.Size = new System.Drawing.Size(885, 289);
            this.PanelArticulos.TabIndex = 10;
            // 
            // LblTotalArticulos
            // 
            this.LblTotalArticulos.AutoSize = true;
            this.LblTotalArticulos.Location = new System.Drawing.Point(798, 263);
            this.LblTotalArticulos.Name = "LblTotalArticulos";
            this.LblTotalArticulos.Size = new System.Drawing.Size(31, 13);
            this.LblTotalArticulos.TabIndex = 22;
            this.LblTotalArticulos.Text = "Total";
            this.LblTotalArticulos.Visible = false;
            // 
            // DgvArticulos
            // 
            this.DgvArticulos.AllowUserToAddRows = false;
            this.DgvArticulos.AllowUserToDeleteRows = false;
            this.DgvArticulos.AllowUserToOrderColumns = true;
            this.DgvArticulos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvArticulos.Location = new System.Drawing.Point(18, 46);
            this.DgvArticulos.Name = "DgvArticulos";
            this.DgvArticulos.ReadOnly = true;
            this.DgvArticulos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvArticulos.Size = new System.Drawing.Size(850, 206);
            this.DgvArticulos.TabIndex = 21;
            this.DgvArticulos.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvArticulos_CellDoubleClick);
            // 
            // BtnCerrarArticulos
            // 
            this.BtnCerrarArticulos.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCerrarArticulos.ForeColor = System.Drawing.Color.Brown;
            this.BtnCerrarArticulos.Location = new System.Drawing.Point(850, 11);
            this.BtnCerrarArticulos.Name = "BtnCerrarArticulos";
            this.BtnCerrarArticulos.Size = new System.Drawing.Size(23, 23);
            this.BtnCerrarArticulos.TabIndex = 20;
            this.BtnCerrarArticulos.Text = "x";
            this.BtnCerrarArticulos.UseVisualStyleBackColor = true;
            this.BtnCerrarArticulos.Click += new System.EventHandler(this.BtnCerrarArticulos_Click);
            // 
            // BtnFiltrarArticulos
            // 
            this.BtnFiltrarArticulos.Location = new System.Drawing.Point(453, 18);
            this.BtnFiltrarArticulos.Name = "BtnFiltrarArticulos";
            this.BtnFiltrarArticulos.Size = new System.Drawing.Size(75, 23);
            this.BtnFiltrarArticulos.TabIndex = 19;
            this.BtnFiltrarArticulos.Text = "Buscar Articulo";
            this.BtnFiltrarArticulos.UseVisualStyleBackColor = true;
            this.BtnFiltrarArticulos.Click += new System.EventHandler(this.BtnFiltrarArticulos_Click);
            // 
            // TxtBuscarArticulo
            // 
            this.TxtBuscarArticulo.Location = new System.Drawing.Point(65, 20);
            this.TxtBuscarArticulo.Name = "TxtBuscarArticulo";
            this.TxtBuscarArticulo.Size = new System.Drawing.Size(371, 20);
            this.TxtBuscarArticulo.TabIndex = 1;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(18, 22);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(40, 13);
            this.label8.TabIndex = 0;
            this.label8.Text = "Buscar";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.TxtTotal);
            this.groupBox2.Controls.Add(this.TxtTotalImpuestos);
            this.groupBox2.Controls.Add(this.TxtSubTotal);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.LbTotalImpuestos);
            this.groupBox2.Controls.Add(this.DgvDetalle);
            this.groupBox2.Controls.Add(this.BtnVerArticulos);
            this.groupBox2.Controls.Add(this.TxtCodigo);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Location = new System.Drawing.Point(15, 173);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(708, 383);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Detalle";
            // 
            // TxtTotal
            // 
            this.TxtTotal.Enabled = false;
            this.TxtTotal.Location = new System.Drawing.Point(590, 346);
            this.TxtTotal.Name = "TxtTotal";
            this.TxtTotal.Size = new System.Drawing.Size(100, 20);
            this.TxtTotal.TabIndex = 24;
            // 
            // TxtTotalImpuestos
            // 
            this.TxtTotalImpuestos.Enabled = false;
            this.TxtTotalImpuestos.Location = new System.Drawing.Point(590, 320);
            this.TxtTotalImpuestos.Name = "TxtTotalImpuestos";
            this.TxtTotalImpuestos.Size = new System.Drawing.Size(100, 20);
            this.TxtTotalImpuestos.TabIndex = 23;
            // 
            // TxtSubTotal
            // 
            this.TxtSubTotal.Enabled = false;
            this.TxtSubTotal.Location = new System.Drawing.Point(591, 294);
            this.TxtSubTotal.Name = "TxtSubTotal";
            this.TxtSubTotal.Size = new System.Drawing.Size(100, 20);
            this.TxtSubTotal.TabIndex = 17;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(534, 297);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(50, 13);
            this.label10.TabIndex = 22;
            this.label10.Text = "SubTotal";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(548, 349);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(31, 13);
            this.label9.TabIndex = 21;
            this.label9.Text = "Total";
            // 
            // LbTotalImpuestos
            // 
            this.LbTotalImpuestos.AutoSize = true;
            this.LbTotalImpuestos.Location = new System.Drawing.Point(502, 323);
            this.LbTotalImpuestos.Name = "LbTotalImpuestos";
            this.LbTotalImpuestos.Size = new System.Drawing.Size(82, 13);
            this.LbTotalImpuestos.TabIndex = 20;
            this.LbTotalImpuestos.Text = "Total Impuestos";
            // 
            // DgvDetalle
            // 
            this.DgvDetalle.AllowUserToAddRows = false;
            this.DgvDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvDetalle.Location = new System.Drawing.Point(20, 94);
            this.DgvDetalle.Name = "DgvDetalle";
            this.DgvDetalle.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvDetalle.Size = new System.Drawing.Size(671, 184);
            this.DgvDetalle.TabIndex = 19;
            this.DgvDetalle.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvDetalle_CellEndEdit);
            this.DgvDetalle.UserDeletedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.DgvDetalle_UserDeletedRow);
            // 
            // BtnVerArticulos
            // 
            this.BtnVerArticulos.Location = new System.Drawing.Point(348, 48);
            this.BtnVerArticulos.Name = "BtnVerArticulos";
            this.BtnVerArticulos.Size = new System.Drawing.Size(75, 23);
            this.BtnVerArticulos.TabIndex = 18;
            this.BtnVerArticulos.Text = "Ver";
            this.BtnVerArticulos.UseVisualStyleBackColor = true;
            this.BtnVerArticulos.Click += new System.EventHandler(this.BtnVerArticulos_Click);
            // 
            // TxtCodigo
            // 
            this.TxtCodigo.Location = new System.Drawing.Point(69, 49);
            this.TxtCodigo.Name = "TxtCodigo";
            this.TxtCodigo.Size = new System.Drawing.Size(273, 20);
            this.TxtCodigo.TabIndex = 17;
            this.TxtCodigo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtCodigo_KeyDown);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(17, 54);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(42, 13);
            this.label7.TabIndex = 17;
            this.label7.Text = "Articulo";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.TxtImpuestos);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.TxtNumComprobante);
            this.groupBox1.Controls.Add(this.TxtSerieComprobante);
            this.groupBox1.Controls.Add(this.CboComprobante);
            this.groupBox1.Controls.Add(this.BtnBuscarProveedor);
            this.groupBox1.Controls.Add(this.TxtNombreProveedor);
            this.groupBox1.Controls.Add(this.TxtIdProveedor);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.TxtId);
            this.groupBox1.Location = new System.Drawing.Point(15, 16);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(708, 135);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Cabecera";
            // 
            // TxtImpuestos
            // 
            this.TxtImpuestos.Location = new System.Drawing.Point(562, 91);
            this.TxtImpuestos.Name = "TxtImpuestos";
            this.TxtImpuestos.Size = new System.Drawing.Size(146, 20);
            this.TxtImpuestos.TabIndex = 16;
            this.TxtImpuestos.Text = "0.18";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(502, 94);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 13);
            this.label6.TabIndex = 15;
            this.label6.Text = "Impuestos";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(338, 73);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "Numero";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(232, 73);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(31, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Serie";
            // 
            // TxtNumComprobante
            // 
            this.TxtNumComprobante.Location = new System.Drawing.Point(341, 90);
            this.TxtNumComprobante.Name = "TxtNumComprobante";
            this.TxtNumComprobante.Size = new System.Drawing.Size(146, 20);
            this.TxtNumComprobante.TabIndex = 12;
            // 
            // TxtSerieComprobante
            // 
            this.TxtSerieComprobante.Location = new System.Drawing.Point(235, 89);
            this.TxtSerieComprobante.Name = "TxtSerieComprobante";
            this.TxtSerieComprobante.Size = new System.Drawing.Size(100, 20);
            this.TxtSerieComprobante.TabIndex = 11;
            // 
            // CboComprobante
            // 
            this.CboComprobante.FormattingEnabled = true;
            this.CboComprobante.Items.AddRange(new object[] {
            "Factura",
            "Boleta",
            "Ticket",
            "Guia"});
            this.CboComprobante.Location = new System.Drawing.Point(108, 89);
            this.CboComprobante.Name = "CboComprobante";
            this.CboComprobante.Size = new System.Drawing.Size(121, 21);
            this.CboComprobante.TabIndex = 10;
            this.CboComprobante.Text = "Factura";
            // 
            // BtnBuscarProveedor
            // 
            this.BtnBuscarProveedor.Location = new System.Drawing.Point(477, 30);
            this.BtnBuscarProveedor.Name = "BtnBuscarProveedor";
            this.BtnBuscarProveedor.Size = new System.Drawing.Size(75, 23);
            this.BtnBuscarProveedor.TabIndex = 9;
            this.BtnBuscarProveedor.Text = "Buscar";
            this.BtnBuscarProveedor.UseVisualStyleBackColor = true;
            this.BtnBuscarProveedor.Click += new System.EventHandler(this.BtnBuscarProveedor_Click);
            // 
            // TxtNombreProveedor
            // 
            this.TxtNombreProveedor.AcceptsReturn = true;
            this.TxtNombreProveedor.Enabled = false;
            this.TxtNombreProveedor.Location = new System.Drawing.Point(198, 30);
            this.TxtNombreProveedor.Name = "TxtNombreProveedor";
            this.TxtNombreProveedor.Size = new System.Drawing.Size(273, 20);
            this.TxtNombreProveedor.TabIndex = 8;
            // 
            // TxtIdProveedor
            // 
            this.TxtIdProveedor.Enabled = false;
            this.TxtIdProveedor.Location = new System.Drawing.Point(92, 30);
            this.TxtIdProveedor.Name = "TxtIdProveedor";
            this.TxtIdProveedor.Size = new System.Drawing.Size(100, 20);
            this.TxtIdProveedor.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 92);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Comprobante(*)";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Proveedor(*)";
            // 
            // Seleccionar
            // 
            this.Seleccionar.HeaderText = "Seleccionar";
            this.Seleccionar.MinimumWidth = 6;
            this.Seleccionar.Name = "Seleccionar";
            this.Seleccionar.ReadOnly = true;
            this.Seleccionar.Width = 125;
            // 
            // BtnAnular
            // 
            this.BtnAnular.Location = new System.Drawing.Point(207, 376);
            this.BtnAnular.Margin = new System.Windows.Forms.Padding(2);
            this.BtnAnular.Name = "BtnAnular";
            this.BtnAnular.Size = new System.Drawing.Size(98, 31);
            this.BtnAnular.TabIndex = 6;
            this.BtnAnular.Text = "Anular";
            this.BtnAnular.UseVisualStyleBackColor = true;
            this.BtnAnular.Click += new System.EventHandler(this.BtnAnular_Click);
            // 
            // ChkSeleccion
            // 
            this.ChkSeleccion.AutoSize = true;
            this.ChkSeleccion.Location = new System.Drawing.Point(18, 384);
            this.ChkSeleccion.Margin = new System.Windows.Forms.Padding(2);
            this.ChkSeleccion.Name = "ChkSeleccion";
            this.ChkSeleccion.Size = new System.Drawing.Size(82, 17);
            this.ChkSeleccion.TabIndex = 4;
            this.ChkSeleccion.Text = "Seleccionar";
            this.ChkSeleccion.UseVisualStyleBackColor = true;
            this.ChkSeleccion.CheckedChanged += new System.EventHandler(this.ChkSeleccion_CheckedChanged);
            // 
            // BtnBuscar
            // 
            this.BtnBuscar.Location = new System.Drawing.Point(486, 16);
            this.BtnBuscar.Name = "BtnBuscar";
            this.BtnBuscar.Size = new System.Drawing.Size(200, 23);
            this.BtnBuscar.TabIndex = 3;
            this.BtnBuscar.Text = "Buscar";
            this.BtnBuscar.UseVisualStyleBackColor = true;
            this.BtnBuscar.Click += new System.EventHandler(this.BtnBuscar_Click);
            // 
            // TxtBuscar
            // 
            this.TxtBuscar.Location = new System.Drawing.Point(8, 16);
            this.TxtBuscar.Name = "TxtBuscar";
            this.TxtBuscar.Size = new System.Drawing.Size(472, 20);
            this.TxtBuscar.TabIndex = 2;
            // 
            // LblTotal
            // 
            this.LblTotal.AutoSize = true;
            this.LblTotal.Location = new System.Drawing.Point(872, 384);
            this.LblTotal.Name = "LblTotal";
            this.LblTotal.Size = new System.Drawing.Size(31, 13);
            this.LblTotal.TabIndex = 1;
            this.LblTotal.Text = "Total";
            // 
            // DgvListado
            // 
            this.DgvListado.AllowUserToAddRows = false;
            this.DgvListado.AllowUserToDeleteRows = false;
            this.DgvListado.AllowUserToOrderColumns = true;
            this.DgvListado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvListado.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Seleccionar});
            this.DgvListado.Location = new System.Drawing.Point(6, 57);
            this.DgvListado.Name = "DgvListado";
            this.DgvListado.ReadOnly = true;
            this.DgvListado.RowHeadersWidth = 51;
            this.DgvListado.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvListado.Size = new System.Drawing.Size(968, 298);
            this.DgvListado.TabIndex = 0;
            this.DgvListado.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvListado_CellContentClick);
            this.DgvListado.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvListado_CellDoubleClick);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.PanelMostrar);
            this.tabPage1.Controls.Add(this.BtnAnular);
            this.tabPage1.Controls.Add(this.ChkSeleccion);
            this.tabPage1.Controls.Add(this.BtnBuscar);
            this.tabPage1.Controls.Add(this.TxtBuscar);
            this.tabPage1.Controls.Add(this.LblTotal);
            this.tabPage1.Controls.Add(this.DgvListado);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(981, 677);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Listado";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // TabGeneral
            // 
            this.TabGeneral.Controls.Add(this.tabPage1);
            this.TabGeneral.Controls.Add(this.tabPage2);
            this.TabGeneral.Location = new System.Drawing.Point(12, 12);
            this.TabGeneral.Name = "TabGeneral";
            this.TabGeneral.SelectedIndex = 0;
            this.TabGeneral.Size = new System.Drawing.Size(989, 703);
            this.TabGeneral.TabIndex = 1;
            // 
            // PanelMostrar
            // 
            this.PanelMostrar.BackColor = System.Drawing.Color.Lavender;
            this.PanelMostrar.Controls.Add(this.TxtTotalD);
            this.PanelMostrar.Controls.Add(this.TxtTotalImpuestoD);
            this.PanelMostrar.Controls.Add(this.TxtSubTotalD);
            this.PanelMostrar.Controls.Add(this.label11);
            this.PanelMostrar.Controls.Add(this.label12);
            this.PanelMostrar.Controls.Add(this.label13);
            this.PanelMostrar.Controls.Add(this.BtnCerrarDetalle);
            this.PanelMostrar.Controls.Add(this.DgvMostrarDetalle);
            this.PanelMostrar.Location = new System.Drawing.Point(192, 298);
            this.PanelMostrar.Name = "PanelMostrar";
            this.PanelMostrar.Size = new System.Drawing.Size(767, 364);
            this.PanelMostrar.TabIndex = 7;
            this.PanelMostrar.Visible = false;
            // 
            // DgvMostrarDetalle
            // 
            this.DgvMostrarDetalle.AllowUserToAddRows = false;
            this.DgvMostrarDetalle.AllowUserToDeleteRows = false;
            this.DgvMostrarDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvMostrarDetalle.Location = new System.Drawing.Point(15, 54);
            this.DgvMostrarDetalle.Name = "DgvMostrarDetalle";
            this.DgvMostrarDetalle.ReadOnly = true;
            this.DgvMostrarDetalle.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvMostrarDetalle.Size = new System.Drawing.Size(737, 208);
            this.DgvMostrarDetalle.TabIndex = 0;
            // 
            // BtnCerrarDetalle
            // 
            this.BtnCerrarDetalle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCerrarDetalle.ForeColor = System.Drawing.Color.Brown;
            this.BtnCerrarDetalle.Location = new System.Drawing.Point(729, 16);
            this.BtnCerrarDetalle.Name = "BtnCerrarDetalle";
            this.BtnCerrarDetalle.Size = new System.Drawing.Size(23, 23);
            this.BtnCerrarDetalle.TabIndex = 21;
            this.BtnCerrarDetalle.Text = "x";
            this.BtnCerrarDetalle.UseVisualStyleBackColor = true;
            this.BtnCerrarDetalle.Click += new System.EventHandler(this.BtnCerrarDetalle_Click);
            // 
            // TxtTotalD
            // 
            this.TxtTotalD.Enabled = false;
            this.TxtTotalD.Location = new System.Drawing.Point(652, 328);
            this.TxtTotalD.Name = "TxtTotalD";
            this.TxtTotalD.Size = new System.Drawing.Size(100, 20);
            this.TxtTotalD.TabIndex = 30;
            // 
            // TxtTotalImpuestoD
            // 
            this.TxtTotalImpuestoD.Enabled = false;
            this.TxtTotalImpuestoD.Location = new System.Drawing.Point(652, 302);
            this.TxtTotalImpuestoD.Name = "TxtTotalImpuestoD";
            this.TxtTotalImpuestoD.Size = new System.Drawing.Size(100, 20);
            this.TxtTotalImpuestoD.TabIndex = 29;
            // 
            // TxtSubTotalD
            // 
            this.TxtSubTotalD.Enabled = false;
            this.TxtSubTotalD.Location = new System.Drawing.Point(653, 276);
            this.TxtSubTotalD.Name = "TxtSubTotalD";
            this.TxtSubTotalD.Size = new System.Drawing.Size(100, 20);
            this.TxtSubTotalD.TabIndex = 25;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(596, 279);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(50, 13);
            this.label11.TabIndex = 28;
            this.label11.Text = "SubTotal";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(610, 331);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(31, 13);
            this.label12.TabIndex = 27;
            this.label12.Text = "Total";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(564, 305);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(82, 13);
            this.label13.TabIndex = 26;
            this.label13.Text = "Total Impuestos";
            // 
            // FrmIngreso
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1009, 727);
            this.Controls.Add(this.TabGeneral);
            this.Name = "FrmIngreso";
            this.Text = "Ingresos";
            this.Load += new System.EventHandler(this.FrmIngreso_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ErrorIcono)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.PanelArticulos.ResumeLayout(false);
            this.PanelArticulos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvArticulos)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvDetalle)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvListado)).EndInit();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.TabGeneral.ResumeLayout(false);
            this.PanelMostrar.ResumeLayout(false);
            this.PanelMostrar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvMostrarDetalle)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ErrorProvider ErrorIcono;
        private System.Windows.Forms.TabControl TabGeneral;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button BtnAnular;
        private System.Windows.Forms.CheckBox ChkSeleccion;
        private System.Windows.Forms.Button BtnBuscar;
        private System.Windows.Forms.TextBox TxtBuscar;
        private System.Windows.Forms.Label LblTotal;
        private System.Windows.Forms.DataGridView DgvListado;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Seleccionar;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button BtnCancelar;
        private System.Windows.Forms.Button BtnInsertar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TxtId;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox TxtNumComprobante;
        private System.Windows.Forms.TextBox TxtSerieComprobante;
        private System.Windows.Forms.ComboBox CboComprobante;
        private System.Windows.Forms.Button BtnBuscarProveedor;
        private System.Windows.Forms.TextBox TxtNombreProveedor;
        private System.Windows.Forms.TextBox TxtIdProveedor;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox TxtTotal;
        private System.Windows.Forms.TextBox TxtTotalImpuestos;
        private System.Windows.Forms.TextBox TxtSubTotal;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label LbTotalImpuestos;
        private System.Windows.Forms.DataGridView DgvDetalle;
        private System.Windows.Forms.Button BtnVerArticulos;
        private System.Windows.Forms.TextBox TxtCodigo;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox TxtImpuestos;
        private System.Windows.Forms.Panel PanelArticulos;
        private System.Windows.Forms.Label LblTotalArticulos;
        private System.Windows.Forms.DataGridView DgvArticulos;
        private System.Windows.Forms.Button BtnCerrarArticulos;
        private System.Windows.Forms.Button BtnFiltrarArticulos;
        private System.Windows.Forms.TextBox TxtBuscarArticulo;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel PanelMostrar;
        private System.Windows.Forms.Button BtnCerrarDetalle;
        private System.Windows.Forms.DataGridView DgvMostrarDetalle;
        private System.Windows.Forms.TextBox TxtTotalD;
        private System.Windows.Forms.TextBox TxtTotalImpuestoD;
        private System.Windows.Forms.TextBox TxtSubTotalD;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
    }
}