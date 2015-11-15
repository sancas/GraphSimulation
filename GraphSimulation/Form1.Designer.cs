namespace GraphSimulation
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.ribbon1 = new System.Windows.Forms.Ribbon();
            this.ribbonOrbMenuItem1 = new System.Windows.Forms.RibbonOrbMenuItem();
            this.btnClose = new System.Windows.Forms.RibbonOrbOptionButton();
            this.btnQuickNewFile = new System.Windows.Forms.RibbonButton();
            this.btnNewFile = new System.Windows.Forms.RibbonButton();
            this.btnQuickSaveFile = new System.Windows.Forms.RibbonButton();
            this.btnQuickOpenFile = new System.Windows.Forms.RibbonButton();
            this.rvTInicio = new System.Windows.Forms.RibbonTab();
            this.rbPArchivo = new System.Windows.Forms.RibbonPanel();
            this.btnSaveFile = new System.Windows.Forms.RibbonButton();
            this.btnLoadFile = new System.Windows.Forms.RibbonButton();
            this.btnPrint = new System.Windows.Forms.RibbonButton();
            this.rbTGrafo = new System.Windows.Forms.RibbonTab();
            this.rbPNodos = new System.Windows.Forms.RibbonPanel();
            this.btnNewNode = new System.Windows.Forms.RibbonButton();
            this.btnDelNode = new System.Windows.Forms.RibbonButton();
            this.rbPAristas = new System.Windows.Forms.RibbonPanel();
            this.rbnBAgregarArista = new System.Windows.Forms.RibbonButton();
            this.rbnEliminarArista = new System.Windows.Forms.RibbonButton();
            this.rbTRecorridos = new System.Windows.Forms.RibbonTab();
            this.rbPRecorridos = new System.Windows.Forms.RibbonPanel();
            this.btnRecorridoAnchura = new System.Windows.Forms.RibbonButton();
            this.ribbonButton4 = new System.Windows.Forms.RibbonButton();
            this.btnRecorridoProfundidad = new System.Windows.Forms.RibbonButton();
            this.rbPRestaurar = new System.Windows.Forms.RibbonPanel();
            this.rbnRestaurar = new System.Windows.Forms.RibbonButton();
            this.rbTAlgoritmos = new System.Windows.Forms.RibbonTab();
            this.rbPDigrafos = new System.Windows.Forms.RibbonPanel();
            this.rbnDijk = new System.Windows.Forms.RibbonButton();
            this.rbnWarshall = new System.Windows.Forms.RibbonButton();
            this.rbPNoDigrafos = new System.Windows.Forms.RibbonPanel();
            this.rbnBPrim = new System.Windows.Forms.RibbonButton();
            this.rbnBKruskal = new System.Windows.Forms.RibbonButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.pbCanvas = new System.Windows.Forms.PictureBox();
            this.PnSimulador = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.lbRecorrido = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.LblSimu = new System.Windows.Forms.Label();
            this.CMSCrearVertice = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.nuevoVerticeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ribbonButton1 = new System.Windows.Forms.RibbonButton();
            this.ribbonOrbMenuItem2 = new System.Windows.Forms.RibbonOrbMenuItem();
            this.ribbonButton6 = new System.Windows.Forms.RibbonButton();
            this.ribbonOrbRecentItem2 = new System.Windows.Forms.RibbonOrbRecentItem();
            this.ribbonOrbMenuItem3 = new System.Windows.Forms.RibbonOrbMenuItem();
            this.ribbonSeparator1 = new System.Windows.Forms.RibbonSeparator();
            this.ribbonOrbMenuItem4 = new System.Windows.Forms.RibbonOrbMenuItem();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbCanvas)).BeginInit();
            this.PnSimulador.SuspendLayout();
            this.CMSCrearVertice.SuspendLayout();
            this.SuspendLayout();
            // 
            // ribbon1
            // 
            this.ribbon1.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.ribbon1.Location = new System.Drawing.Point(0, 0);
            this.ribbon1.Name = "ribbon1";
            // 
            // 
            // 
            this.ribbon1.OrbDropDown.BorderRoundness = 8;
            this.ribbon1.OrbDropDown.Location = new System.Drawing.Point(0, 0);
            this.ribbon1.OrbDropDown.MenuItems.Add(this.ribbonOrbMenuItem1);
            this.ribbon1.OrbDropDown.Name = "";
            this.ribbon1.OrbDropDown.OptionItems.Add(this.btnClose);
            this.ribbon1.OrbDropDown.RecentItemsCaption = null;
            this.ribbon1.OrbDropDown.Size = new System.Drawing.Size(527, 116);
            this.ribbon1.OrbDropDown.TabIndex = 0;
            this.ribbon1.OrbImage = ((System.Drawing.Image)(resources.GetObject("ribbon1.OrbImage")));
            this.ribbon1.OrbText = null;
            // 
            // 
            // 
            this.ribbon1.QuickAcessToolbar.Image = null;
            this.ribbon1.QuickAcessToolbar.Items.Add(this.btnQuickNewFile);
            this.ribbon1.QuickAcessToolbar.Items.Add(this.btnQuickSaveFile);
            this.ribbon1.QuickAcessToolbar.Items.Add(this.btnQuickOpenFile);
            this.ribbon1.QuickAcessToolbar.Tag = null;
            this.ribbon1.QuickAcessToolbar.Value = null;
            this.ribbon1.Size = new System.Drawing.Size(568, 170);
            this.ribbon1.TabIndex = 0;
            this.ribbon1.Tabs.Add(this.rvTInicio);
            this.ribbon1.Tabs.Add(this.rbTGrafo);
            this.ribbon1.Tabs.Add(this.rbTRecorridos);
            this.ribbon1.Tabs.Add(this.rbTAlgoritmos);
            this.ribbon1.TabsMargin = new System.Windows.Forms.Padding(12, 26, 20, 0);
            this.ribbon1.TabSpacing = 6;
            // 
            // ribbonOrbMenuItem1
            // 
            this.ribbonOrbMenuItem1.AltKey = null;
            this.ribbonOrbMenuItem1.CheckedGroup = null;
            this.ribbonOrbMenuItem1.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left;
            this.ribbonOrbMenuItem1.DropDownArrowSize = new System.Drawing.Size(5, 3);
            this.ribbonOrbMenuItem1.Image = ((System.Drawing.Image)(resources.GetObject("ribbonOrbMenuItem1.Image")));
            this.ribbonOrbMenuItem1.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonOrbMenuItem1.SmallImage")));
            this.ribbonOrbMenuItem1.Style = System.Windows.Forms.RibbonButtonStyle.Normal;
            this.ribbonOrbMenuItem1.Tag = null;
            this.ribbonOrbMenuItem1.Text = "ribbonOrbMenuItem1";
            this.ribbonOrbMenuItem1.ToolTip = null;
            this.ribbonOrbMenuItem1.ToolTipTitle = null;
            this.ribbonOrbMenuItem1.Value = null;
            // 
            // btnClose
            // 
            this.btnClose.AltKey = null;
            this.btnClose.CheckedGroup = null;
            this.btnClose.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Down;
            this.btnClose.DropDownArrowSize = new System.Drawing.Size(5, 3);
            this.btnClose.Image = null;
            this.btnClose.Style = System.Windows.Forms.RibbonButtonStyle.Normal;
            this.btnClose.Tag = null;
            this.btnClose.Text = "Cerrar";
            this.btnClose.ToolTip = null;
            this.btnClose.ToolTipTitle = null;
            this.btnClose.Value = null;
            // 
            // btnQuickNewFile
            // 
            this.btnQuickNewFile.AltKey = null;
            this.btnQuickNewFile.CheckedGroup = null;
            this.btnQuickNewFile.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Down;
            this.btnQuickNewFile.DropDownArrowSize = new System.Drawing.Size(5, 3);
            this.btnQuickNewFile.DropDownItems.Add(this.btnNewFile);
            this.btnQuickNewFile.Image = ((System.Drawing.Image)(resources.GetObject("btnQuickNewFile.Image")));
            this.btnQuickNewFile.MaxSizeMode = System.Windows.Forms.RibbonElementSizeMode.Compact;
            this.btnQuickNewFile.SmallImage = ((System.Drawing.Image)(resources.GetObject("btnQuickNewFile.SmallImage")));
            this.btnQuickNewFile.Style = System.Windows.Forms.RibbonButtonStyle.Normal;
            this.btnQuickNewFile.Tag = null;
            this.btnQuickNewFile.Text = "ribbonButton2";
            this.btnQuickNewFile.ToolTip = null;
            this.btnQuickNewFile.ToolTipTitle = null;
            this.btnQuickNewFile.Value = null;
            this.btnQuickNewFile.Click += new System.EventHandler(this.btnNewFile_Click);
            // 
            // btnNewFile
            // 
            this.btnNewFile.AltKey = null;
            this.btnNewFile.CheckedGroup = null;
            this.btnNewFile.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Down;
            this.btnNewFile.DropDownArrowSize = new System.Drawing.Size(5, 3);
            this.btnNewFile.Image = ((System.Drawing.Image)(resources.GetObject("btnNewFile.Image")));
            this.btnNewFile.SmallImage = ((System.Drawing.Image)(resources.GetObject("btnNewFile.SmallImage")));
            this.btnNewFile.Style = System.Windows.Forms.RibbonButtonStyle.Normal;
            this.btnNewFile.Tag = null;
            this.btnNewFile.Text = "Nuevo";
            this.btnNewFile.ToolTip = null;
            this.btnNewFile.ToolTipTitle = null;
            this.btnNewFile.Value = null;
            this.btnNewFile.Click += new System.EventHandler(this.btnNewFile_Click);
            // 
            // btnQuickSaveFile
            // 
            this.btnQuickSaveFile.AltKey = null;
            this.btnQuickSaveFile.CheckedGroup = null;
            this.btnQuickSaveFile.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Down;
            this.btnQuickSaveFile.DropDownArrowSize = new System.Drawing.Size(5, 3);
            this.btnQuickSaveFile.Image = ((System.Drawing.Image)(resources.GetObject("btnQuickSaveFile.Image")));
            this.btnQuickSaveFile.MaxSizeMode = System.Windows.Forms.RibbonElementSizeMode.Compact;
            this.btnQuickSaveFile.SmallImage = ((System.Drawing.Image)(resources.GetObject("btnQuickSaveFile.SmallImage")));
            this.btnQuickSaveFile.Style = System.Windows.Forms.RibbonButtonStyle.Normal;
            this.btnQuickSaveFile.Tag = null;
            this.btnQuickSaveFile.Text = "ribbonButton3";
            this.btnQuickSaveFile.ToolTip = null;
            this.btnQuickSaveFile.ToolTipTitle = null;
            this.btnQuickSaveFile.Value = null;
            this.btnQuickSaveFile.Click += new System.EventHandler(this.btnSaveFile_Click);
            // 
            // btnQuickOpenFile
            // 
            this.btnQuickOpenFile.AltKey = null;
            this.btnQuickOpenFile.CheckedGroup = null;
            this.btnQuickOpenFile.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Down;
            this.btnQuickOpenFile.DropDownArrowSize = new System.Drawing.Size(5, 3);
            this.btnQuickOpenFile.Image = ((System.Drawing.Image)(resources.GetObject("btnQuickOpenFile.Image")));
            this.btnQuickOpenFile.MaxSizeMode = System.Windows.Forms.RibbonElementSizeMode.Compact;
            this.btnQuickOpenFile.SmallImage = ((System.Drawing.Image)(resources.GetObject("btnQuickOpenFile.SmallImage")));
            this.btnQuickOpenFile.Style = System.Windows.Forms.RibbonButtonStyle.Normal;
            this.btnQuickOpenFile.Tag = null;
            this.btnQuickOpenFile.Text = "ribbonButton5";
            this.btnQuickOpenFile.ToolTip = null;
            this.btnQuickOpenFile.ToolTipTitle = null;
            this.btnQuickOpenFile.Value = null;
            this.btnQuickOpenFile.Click += new System.EventHandler(this.btnLoadFile_Click);
            // 
            // rvTInicio
            // 
            this.rvTInicio.Panels.Add(this.rbPArchivo);
            this.rvTInicio.Tag = null;
            this.rvTInicio.Text = "Inicio";
            this.rvTInicio.ToolTip = null;
            this.rvTInicio.ToolTipIcon = System.Windows.Forms.ToolTipIcon.None;
            this.rvTInicio.ToolTipImage = null;
            this.rvTInicio.ToolTipTitle = null;
            this.rvTInicio.Value = null;
            // 
            // rbPArchivo
            // 
            this.rbPArchivo.Items.Add(this.btnNewFile);
            this.rbPArchivo.Items.Add(this.btnSaveFile);
            this.rbPArchivo.Items.Add(this.btnLoadFile);
            this.rbPArchivo.Items.Add(this.btnPrint);
            this.rbPArchivo.Tag = null;
            this.rbPArchivo.Text = "Archivo";
            // 
            // btnSaveFile
            // 
            this.btnSaveFile.AltKey = null;
            this.btnSaveFile.CheckedGroup = null;
            this.btnSaveFile.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Down;
            this.btnSaveFile.DropDownArrowSize = new System.Drawing.Size(5, 3);
            this.btnSaveFile.Image = ((System.Drawing.Image)(resources.GetObject("btnSaveFile.Image")));
            this.btnSaveFile.SmallImage = ((System.Drawing.Image)(resources.GetObject("btnSaveFile.SmallImage")));
            this.btnSaveFile.Style = System.Windows.Forms.RibbonButtonStyle.Normal;
            this.btnSaveFile.Tag = null;
            this.btnSaveFile.Text = "Guardar";
            this.btnSaveFile.ToolTip = null;
            this.btnSaveFile.ToolTipTitle = null;
            this.btnSaveFile.Value = null;
            this.btnSaveFile.Click += new System.EventHandler(this.btnSaveFile_Click);
            // 
            // btnLoadFile
            // 
            this.btnLoadFile.AltKey = null;
            this.btnLoadFile.CheckedGroup = null;
            this.btnLoadFile.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Down;
            this.btnLoadFile.DropDownArrowSize = new System.Drawing.Size(5, 3);
            this.btnLoadFile.Image = ((System.Drawing.Image)(resources.GetObject("btnLoadFile.Image")));
            this.btnLoadFile.SmallImage = ((System.Drawing.Image)(resources.GetObject("btnLoadFile.SmallImage")));
            this.btnLoadFile.Style = System.Windows.Forms.RibbonButtonStyle.Normal;
            this.btnLoadFile.Tag = null;
            this.btnLoadFile.Text = "Abrir";
            this.btnLoadFile.ToolTip = null;
            this.btnLoadFile.ToolTipTitle = null;
            this.btnLoadFile.Value = null;
            this.btnLoadFile.Click += new System.EventHandler(this.btnLoadFile_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.AltKey = null;
            this.btnPrint.CheckedGroup = null;
            this.btnPrint.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Down;
            this.btnPrint.DropDownArrowSize = new System.Drawing.Size(5, 3);
            this.btnPrint.Image = ((System.Drawing.Image)(resources.GetObject("btnPrint.Image")));
            this.btnPrint.SmallImage = ((System.Drawing.Image)(resources.GetObject("btnPrint.SmallImage")));
            this.btnPrint.Style = System.Windows.Forms.RibbonButtonStyle.Normal;
            this.btnPrint.Tag = null;
            this.btnPrint.Text = "Imprimir";
            this.btnPrint.ToolTip = null;
            this.btnPrint.ToolTipTitle = null;
            this.btnPrint.Value = null;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // rbTGrafo
            // 
            this.rbTGrafo.Panels.Add(this.rbPNodos);
            this.rbTGrafo.Panels.Add(this.rbPAristas);
            this.rbTGrafo.Tag = null;
            this.rbTGrafo.Text = "Grafo";
            this.rbTGrafo.ToolTip = null;
            this.rbTGrafo.ToolTipIcon = System.Windows.Forms.ToolTipIcon.None;
            this.rbTGrafo.ToolTipImage = null;
            this.rbTGrafo.ToolTipTitle = null;
            this.rbTGrafo.Value = null;
            // 
            // rbPNodos
            // 
            this.rbPNodos.Items.Add(this.btnNewNode);
            this.rbPNodos.Items.Add(this.btnDelNode);
            this.rbPNodos.Tag = null;
            this.rbPNodos.Text = "Nodos";
            // 
            // btnNewNode
            // 
            this.btnNewNode.AltKey = null;
            this.btnNewNode.CheckedGroup = null;
            this.btnNewNode.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Down;
            this.btnNewNode.DropDownArrowSize = new System.Drawing.Size(5, 3);
            this.btnNewNode.Image = ((System.Drawing.Image)(resources.GetObject("btnNewNode.Image")));
            this.btnNewNode.SmallImage = ((System.Drawing.Image)(resources.GetObject("btnNewNode.SmallImage")));
            this.btnNewNode.Style = System.Windows.Forms.RibbonButtonStyle.Normal;
            this.btnNewNode.Tag = null;
            this.btnNewNode.Text = "Nuevo";
            this.btnNewNode.ToolTip = null;
            this.btnNewNode.ToolTipTitle = null;
            this.btnNewNode.Value = null;
            this.btnNewNode.Click += new System.EventHandler(this.btnNewNode_Click);
            // 
            // btnDelNode
            // 
            this.btnDelNode.AltKey = null;
            this.btnDelNode.CheckedGroup = null;
            this.btnDelNode.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Down;
            this.btnDelNode.DropDownArrowSize = new System.Drawing.Size(5, 3);
            this.btnDelNode.Image = ((System.Drawing.Image)(resources.GetObject("btnDelNode.Image")));
            this.btnDelNode.SmallImage = ((System.Drawing.Image)(resources.GetObject("btnDelNode.SmallImage")));
            this.btnDelNode.Style = System.Windows.Forms.RibbonButtonStyle.Normal;
            this.btnDelNode.Tag = null;
            this.btnDelNode.Text = "Eliminar";
            this.btnDelNode.ToolTip = null;
            this.btnDelNode.ToolTipTitle = null;
            this.btnDelNode.Value = null;
            this.btnDelNode.Click += new System.EventHandler(this.btnDelNode_Click);
            // 
            // rbPAristas
            // 
            this.rbPAristas.Items.Add(this.rbnBAgregarArista);
            this.rbPAristas.Items.Add(this.rbnEliminarArista);
            this.rbPAristas.Tag = null;
            this.rbPAristas.Text = "Aristas";
            // 
            // rbnBAgregarArista
            // 
            this.rbnBAgregarArista.AltKey = null;
            this.rbnBAgregarArista.CheckedGroup = null;
            this.rbnBAgregarArista.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Down;
            this.rbnBAgregarArista.DropDownArrowSize = new System.Drawing.Size(5, 3);
            this.rbnBAgregarArista.Image = ((System.Drawing.Image)(resources.GetObject("rbnBAgregarArista.Image")));
            this.rbnBAgregarArista.SmallImage = ((System.Drawing.Image)(resources.GetObject("rbnBAgregarArista.SmallImage")));
            this.rbnBAgregarArista.Style = System.Windows.Forms.RibbonButtonStyle.Normal;
            this.rbnBAgregarArista.Tag = null;
            this.rbnBAgregarArista.Text = "Agregar";
            this.rbnBAgregarArista.ToolTip = null;
            this.rbnBAgregarArista.ToolTipTitle = null;
            this.rbnBAgregarArista.Value = null;
            this.rbnBAgregarArista.Click += new System.EventHandler(this.rbnBAgregarArista_Click);
            // 
            // rbnEliminarArista
            // 
            this.rbnEliminarArista.AltKey = null;
            this.rbnEliminarArista.CheckedGroup = null;
            this.rbnEliminarArista.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Down;
            this.rbnEliminarArista.DropDownArrowSize = new System.Drawing.Size(5, 3);
            this.rbnEliminarArista.Image = ((System.Drawing.Image)(resources.GetObject("rbnEliminarArista.Image")));
            this.rbnEliminarArista.SmallImage = ((System.Drawing.Image)(resources.GetObject("rbnEliminarArista.SmallImage")));
            this.rbnEliminarArista.Style = System.Windows.Forms.RibbonButtonStyle.Normal;
            this.rbnEliminarArista.Tag = null;
            this.rbnEliminarArista.Text = "Eliminar";
            this.rbnEliminarArista.ToolTip = null;
            this.rbnEliminarArista.ToolTipTitle = null;
            this.rbnEliminarArista.Value = null;
            this.rbnEliminarArista.Click += new System.EventHandler(this.rbnEliminarArista_Click);
            // 
            // rbTRecorridos
            // 
            this.rbTRecorridos.Panels.Add(this.rbPRecorridos);
            this.rbTRecorridos.Panels.Add(this.rbPRestaurar);
            this.rbTRecorridos.Tag = null;
            this.rbTRecorridos.Text = "Recorridos";
            this.rbTRecorridos.ToolTip = null;
            this.rbTRecorridos.ToolTipIcon = System.Windows.Forms.ToolTipIcon.None;
            this.rbTRecorridos.ToolTipImage = null;
            this.rbTRecorridos.ToolTipTitle = null;
            this.rbTRecorridos.Value = null;
            // 
            // rbPRecorridos
            // 
            this.rbPRecorridos.Items.Add(this.btnRecorridoAnchura);
            this.rbPRecorridos.Items.Add(this.btnRecorridoProfundidad);
            this.rbPRecorridos.Tag = null;
            this.rbPRecorridos.Text = "Recorridos";
            // 
            // btnRecorridoAnchura
            // 
            this.btnRecorridoAnchura.AltKey = null;
            this.btnRecorridoAnchura.CheckedGroup = null;
            this.btnRecorridoAnchura.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Down;
            this.btnRecorridoAnchura.DropDownArrowSize = new System.Drawing.Size(5, 3);
            this.btnRecorridoAnchura.DropDownItems.Add(this.ribbonButton4);
            this.btnRecorridoAnchura.Image = ((System.Drawing.Image)(resources.GetObject("btnRecorridoAnchura.Image")));
            this.btnRecorridoAnchura.SmallImage = ((System.Drawing.Image)(resources.GetObject("btnRecorridoAnchura.SmallImage")));
            this.btnRecorridoAnchura.Style = System.Windows.Forms.RibbonButtonStyle.Normal;
            this.btnRecorridoAnchura.Tag = null;
            this.btnRecorridoAnchura.Text = "Anchura";
            this.btnRecorridoAnchura.ToolTip = null;
            this.btnRecorridoAnchura.ToolTipTitle = null;
            this.btnRecorridoAnchura.Value = null;
            this.btnRecorridoAnchura.Click += new System.EventHandler(this.btnRecorridoAnchura_Click);
            // 
            // ribbonButton4
            // 
            this.ribbonButton4.AltKey = null;
            this.ribbonButton4.CheckedGroup = null;
            this.ribbonButton4.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Down;
            this.ribbonButton4.DropDownArrowSize = new System.Drawing.Size(5, 3);
            this.ribbonButton4.Image = ((System.Drawing.Image)(resources.GetObject("ribbonButton4.Image")));
            this.ribbonButton4.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton4.SmallImage")));
            this.ribbonButton4.Style = System.Windows.Forms.RibbonButtonStyle.Normal;
            this.ribbonButton4.Tag = null;
            this.ribbonButton4.Text = "ribbonButton4";
            this.ribbonButton4.ToolTip = null;
            this.ribbonButton4.ToolTipTitle = null;
            this.ribbonButton4.Value = null;
            // 
            // btnRecorridoProfundidad
            // 
            this.btnRecorridoProfundidad.AltKey = null;
            this.btnRecorridoProfundidad.CheckedGroup = null;
            this.btnRecorridoProfundidad.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Down;
            this.btnRecorridoProfundidad.DropDownArrowSize = new System.Drawing.Size(5, 3);
            this.btnRecorridoProfundidad.Image = ((System.Drawing.Image)(resources.GetObject("btnRecorridoProfundidad.Image")));
            this.btnRecorridoProfundidad.SmallImage = ((System.Drawing.Image)(resources.GetObject("btnRecorridoProfundidad.SmallImage")));
            this.btnRecorridoProfundidad.Style = System.Windows.Forms.RibbonButtonStyle.Normal;
            this.btnRecorridoProfundidad.Tag = null;
            this.btnRecorridoProfundidad.Text = "Profundidad";
            this.btnRecorridoProfundidad.ToolTip = null;
            this.btnRecorridoProfundidad.ToolTipTitle = null;
            this.btnRecorridoProfundidad.Value = null;
            this.btnRecorridoProfundidad.Click += new System.EventHandler(this.btnRecorridoProfundidad_Click);
            // 
            // rbPRestaurar
            // 
            this.rbPRestaurar.Items.Add(this.rbnRestaurar);
            this.rbPRestaurar.Tag = null;
            this.rbPRestaurar.Text = "Restaurar";
            // 
            // rbnRestaurar
            // 
            this.rbnRestaurar.AltKey = null;
            this.rbnRestaurar.CheckedGroup = null;
            this.rbnRestaurar.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Down;
            this.rbnRestaurar.DropDownArrowSize = new System.Drawing.Size(5, 3);
            this.rbnRestaurar.Image = ((System.Drawing.Image)(resources.GetObject("rbnRestaurar.Image")));
            this.rbnRestaurar.SmallImage = ((System.Drawing.Image)(resources.GetObject("rbnRestaurar.SmallImage")));
            this.rbnRestaurar.Style = System.Windows.Forms.RibbonButtonStyle.Normal;
            this.rbnRestaurar.Tag = null;
            this.rbnRestaurar.Text = "Restaurar";
            this.rbnRestaurar.ToolTip = null;
            this.rbnRestaurar.ToolTipTitle = null;
            this.rbnRestaurar.Value = null;
            this.rbnRestaurar.Click += new System.EventHandler(this.rbnRestaurar_Click);
            // 
            // rbTAlgoritmos
            // 
            this.rbTAlgoritmos.Panels.Add(this.rbPDigrafos);
            this.rbTAlgoritmos.Panels.Add(this.rbPNoDigrafos);
            this.rbTAlgoritmos.Panels.Add(this.rbPRestaurar);
            this.rbTAlgoritmos.Tag = null;
            this.rbTAlgoritmos.Text = "Algoritmos";
            this.rbTAlgoritmos.ToolTip = null;
            this.rbTAlgoritmos.ToolTipIcon = System.Windows.Forms.ToolTipIcon.None;
            this.rbTAlgoritmos.ToolTipImage = null;
            this.rbTAlgoritmos.ToolTipTitle = null;
            this.rbTAlgoritmos.Value = null;
            // 
            // rbPDigrafos
            // 
            this.rbPDigrafos.Items.Add(this.rbnDijk);
            this.rbPDigrafos.Items.Add(this.rbnWarshall);
            this.rbPDigrafos.Tag = null;
            this.rbPDigrafos.Text = "Algoritmos";
            // 
            // rbnDijk
            // 
            this.rbnDijk.AltKey = null;
            this.rbnDijk.CheckedGroup = null;
            this.rbnDijk.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Down;
            this.rbnDijk.DropDownArrowSize = new System.Drawing.Size(5, 3);
            this.rbnDijk.Image = ((System.Drawing.Image)(resources.GetObject("rbnDijk.Image")));
            this.rbnDijk.SmallImage = ((System.Drawing.Image)(resources.GetObject("rbnDijk.SmallImage")));
            this.rbnDijk.Style = System.Windows.Forms.RibbonButtonStyle.Normal;
            this.rbnDijk.Tag = null;
            this.rbnDijk.Text = "Dijkstra";
            this.rbnDijk.ToolTip = null;
            this.rbnDijk.ToolTipTitle = null;
            this.rbnDijk.Value = null;
            this.rbnDijk.Click += new System.EventHandler(this.rbnDijk_Click);
            // 
            // rbnWarshall
            // 
            this.rbnWarshall.AltKey = null;
            this.rbnWarshall.CheckedGroup = null;
            this.rbnWarshall.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Down;
            this.rbnWarshall.DropDownArrowSize = new System.Drawing.Size(5, 3);
            this.rbnWarshall.Image = ((System.Drawing.Image)(resources.GetObject("rbnWarshall.Image")));
            this.rbnWarshall.SmallImage = ((System.Drawing.Image)(resources.GetObject("rbnWarshall.SmallImage")));
            this.rbnWarshall.Style = System.Windows.Forms.RibbonButtonStyle.Normal;
            this.rbnWarshall.Tag = null;
            this.rbnWarshall.Text = "Warshall";
            this.rbnWarshall.ToolTip = null;
            this.rbnWarshall.ToolTipTitle = null;
            this.rbnWarshall.Value = null;
            this.rbnWarshall.Click += new System.EventHandler(this.rbnWarshall_Click);
            // 
            // rbPNoDigrafos
            // 
            this.rbPNoDigrafos.Items.Add(this.rbnBPrim);
            this.rbPNoDigrafos.Items.Add(this.rbnBKruskal);
            this.rbPNoDigrafos.Tag = null;
            this.rbPNoDigrafos.Text = "Algoritmos";
            // 
            // rbnBPrim
            // 
            this.rbnBPrim.AltKey = null;
            this.rbnBPrim.CheckedGroup = null;
            this.rbnBPrim.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Down;
            this.rbnBPrim.DropDownArrowSize = new System.Drawing.Size(5, 3);
            this.rbnBPrim.Image = ((System.Drawing.Image)(resources.GetObject("rbnBPrim.Image")));
            this.rbnBPrim.SmallImage = ((System.Drawing.Image)(resources.GetObject("rbnBPrim.SmallImage")));
            this.rbnBPrim.Style = System.Windows.Forms.RibbonButtonStyle.Normal;
            this.rbnBPrim.Tag = null;
            this.rbnBPrim.Text = "Prim";
            this.rbnBPrim.ToolTip = null;
            this.rbnBPrim.ToolTipTitle = null;
            this.rbnBPrim.Value = null;
            this.rbnBPrim.Click += new System.EventHandler(this.rbnBPrim_Click);
            // 
            // rbnBKruskal
            // 
            this.rbnBKruskal.AltKey = null;
            this.rbnBKruskal.CheckedGroup = null;
            this.rbnBKruskal.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Down;
            this.rbnBKruskal.DropDownArrowSize = new System.Drawing.Size(5, 3);
            this.rbnBKruskal.Image = ((System.Drawing.Image)(resources.GetObject("rbnBKruskal.Image")));
            this.rbnBKruskal.SmallImage = ((System.Drawing.Image)(resources.GetObject("rbnBKruskal.SmallImage")));
            this.rbnBKruskal.Style = System.Windows.Forms.RibbonButtonStyle.Normal;
            this.rbnBKruskal.Tag = null;
            this.rbnBKruskal.Text = "Kruskal";
            this.rbnBKruskal.ToolTip = null;
            this.rbnBKruskal.ToolTipTitle = null;
            this.rbnBKruskal.Value = null;
            this.rbnBKruskal.Click += new System.EventHandler(this.rbnBKruskal_Click);
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.splitContainer1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 170);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(568, 273);
            this.panel1.TabIndex = 2;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.pbCanvas);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.PnSimulador);
            this.splitContainer1.Size = new System.Drawing.Size(568, 273);
            this.splitContainer1.SplitterDistance = 306;
            this.splitContainer1.TabIndex = 3;
            // 
            // pbCanvas
            // 
            this.pbCanvas.BackColor = System.Drawing.SystemColors.Info;
            this.pbCanvas.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pbCanvas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbCanvas.Enabled = false;
            this.pbCanvas.Location = new System.Drawing.Point(0, 0);
            this.pbCanvas.Name = "pbCanvas";
            this.pbCanvas.Size = new System.Drawing.Size(306, 273);
            this.pbCanvas.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbCanvas.TabIndex = 1;
            this.pbCanvas.TabStop = false;
            this.pbCanvas.Visible = false;
            this.pbCanvas.Paint += new System.Windows.Forms.PaintEventHandler(this.pbCanvas_Paint);
            this.pbCanvas.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pbCanvas_MouseDown);
            this.pbCanvas.MouseLeave += new System.EventHandler(this.pbCanvas_MouseLeave);
            this.pbCanvas.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pbCanvas_MouseMove);
            this.pbCanvas.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pbCanvas_MouseUp);
            // 
            // PnSimulador
            // 
            this.PnSimulador.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.PnSimulador.Controls.Add(this.label4);
            this.PnSimulador.Controls.Add(this.lbRecorrido);
            this.PnSimulador.Controls.Add(this.label2);
            this.PnSimulador.Controls.Add(this.label1);
            this.PnSimulador.Controls.Add(this.LblSimu);
            this.PnSimulador.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PnSimulador.Location = new System.Drawing.Point(0, 0);
            this.PnSimulador.Name = "PnSimulador";
            this.PnSimulador.Size = new System.Drawing.Size(258, 273);
            this.PnSimulador.TabIndex = 2;
            this.PnSimulador.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(4, 173);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 20);
            this.label4.TabIndex = 4;
            this.label4.Text = "Tiempo";
            // 
            // lbRecorrido
            // 
            this.lbRecorrido.AutoSize = true;
            this.lbRecorrido.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbRecorrido.Location = new System.Drawing.Point(4, 153);
            this.lbRecorrido.Name = "lbRecorrido";
            this.lbRecorrido.Size = new System.Drawing.Size(78, 20);
            this.lbRecorrido.TabIndex = 3;
            this.lbRecorrido.Text = "Recorrido";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(4, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "SubTitulo";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(4, 133);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Algo mas";
            // 
            // LblSimu
            // 
            this.LblSimu.AutoSize = true;
            this.LblSimu.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblSimu.Location = new System.Drawing.Point(3, 14);
            this.LblSimu.Name = "LblSimu";
            this.LblSimu.Size = new System.Drawing.Size(208, 25);
            this.LblSimu.TabIndex = 0;
            this.LblSimu.Text = "Simulador de Grafos";
            // 
            // CMSCrearVertice
            // 
            this.CMSCrearVertice.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nuevoVerticeToolStripMenuItem});
            this.CMSCrearVertice.Name = "CMSCrearVertice";
            this.CMSCrearVertice.Size = new System.Drawing.Size(148, 26);
            // 
            // nuevoVerticeToolStripMenuItem
            // 
            this.nuevoVerticeToolStripMenuItem.Name = "nuevoVerticeToolStripMenuItem";
            this.nuevoVerticeToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
            this.nuevoVerticeToolStripMenuItem.Text = "Nuevo vertice";
            this.nuevoVerticeToolStripMenuItem.Click += new System.EventHandler(this.nuevoVerticeToolStripMenuItem_Click);
            // 
            // ribbonButton1
            // 
            this.ribbonButton1.AltKey = null;
            this.ribbonButton1.CheckedGroup = null;
            this.ribbonButton1.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Down;
            this.ribbonButton1.DropDownArrowSize = new System.Drawing.Size(5, 3);
            this.ribbonButton1.Image = ((System.Drawing.Image)(resources.GetObject("ribbonButton1.Image")));
            this.ribbonButton1.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton1.SmallImage")));
            this.ribbonButton1.Style = System.Windows.Forms.RibbonButtonStyle.Normal;
            this.ribbonButton1.Tag = null;
            this.ribbonButton1.Text = "ribbonButton1";
            this.ribbonButton1.ToolTip = null;
            this.ribbonButton1.ToolTipTitle = null;
            this.ribbonButton1.Value = null;
            // 
            // ribbonOrbMenuItem2
            // 
            this.ribbonOrbMenuItem2.AltKey = null;
            this.ribbonOrbMenuItem2.CheckedGroup = null;
            this.ribbonOrbMenuItem2.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left;
            this.ribbonOrbMenuItem2.DropDownArrowSize = new System.Drawing.Size(5, 3);
            this.ribbonOrbMenuItem2.DropDownItems.Add(this.ribbonButton6);
            this.ribbonOrbMenuItem2.Image = ((System.Drawing.Image)(resources.GetObject("ribbonOrbMenuItem2.Image")));
            this.ribbonOrbMenuItem2.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonOrbMenuItem2.SmallImage")));
            this.ribbonOrbMenuItem2.Style = System.Windows.Forms.RibbonButtonStyle.Normal;
            this.ribbonOrbMenuItem2.Tag = null;
            this.ribbonOrbMenuItem2.Text = "ribbonOrbMenuItem2";
            this.ribbonOrbMenuItem2.ToolTip = null;
            this.ribbonOrbMenuItem2.ToolTipTitle = null;
            this.ribbonOrbMenuItem2.Value = null;
            // 
            // ribbonButton6
            // 
            this.ribbonButton6.AltKey = null;
            this.ribbonButton6.CheckedGroup = null;
            this.ribbonButton6.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Down;
            this.ribbonButton6.DropDownArrowSize = new System.Drawing.Size(5, 3);
            this.ribbonButton6.Image = ((System.Drawing.Image)(resources.GetObject("ribbonButton6.Image")));
            this.ribbonButton6.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton6.SmallImage")));
            this.ribbonButton6.Style = System.Windows.Forms.RibbonButtonStyle.Normal;
            this.ribbonButton6.Tag = null;
            this.ribbonButton6.Text = null;
            this.ribbonButton6.ToolTip = null;
            this.ribbonButton6.ToolTipTitle = null;
            this.ribbonButton6.Value = null;
            // 
            // ribbonOrbRecentItem2
            // 
            this.ribbonOrbRecentItem2.AltKey = null;
            this.ribbonOrbRecentItem2.CheckedGroup = null;
            this.ribbonOrbRecentItem2.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Down;
            this.ribbonOrbRecentItem2.DropDownArrowSize = new System.Drawing.Size(5, 3);
            this.ribbonOrbRecentItem2.Image = ((System.Drawing.Image)(resources.GetObject("ribbonOrbRecentItem2.Image")));
            this.ribbonOrbRecentItem2.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonOrbRecentItem2.SmallImage")));
            this.ribbonOrbRecentItem2.Style = System.Windows.Forms.RibbonButtonStyle.Normal;
            this.ribbonOrbRecentItem2.Tag = null;
            this.ribbonOrbRecentItem2.Text = "ribbonOrbRecentItem2";
            this.ribbonOrbRecentItem2.ToolTip = null;
            this.ribbonOrbRecentItem2.ToolTipTitle = null;
            this.ribbonOrbRecentItem2.Value = null;
            // 
            // ribbonOrbMenuItem3
            // 
            this.ribbonOrbMenuItem3.AltKey = null;
            this.ribbonOrbMenuItem3.CheckedGroup = null;
            this.ribbonOrbMenuItem3.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left;
            this.ribbonOrbMenuItem3.DropDownArrowSize = new System.Drawing.Size(5, 3);
            this.ribbonOrbMenuItem3.Image = ((System.Drawing.Image)(resources.GetObject("ribbonOrbMenuItem3.Image")));
            this.ribbonOrbMenuItem3.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonOrbMenuItem3.SmallImage")));
            this.ribbonOrbMenuItem3.Style = System.Windows.Forms.RibbonButtonStyle.Normal;
            this.ribbonOrbMenuItem3.Tag = null;
            this.ribbonOrbMenuItem3.Text = "ribbonOrbMenuItem3";
            this.ribbonOrbMenuItem3.ToolTip = null;
            this.ribbonOrbMenuItem3.ToolTipTitle = null;
            this.ribbonOrbMenuItem3.Value = null;
            // 
            // ribbonSeparator1
            // 
            this.ribbonSeparator1.AltKey = null;
            this.ribbonSeparator1.CheckedGroup = null;
            this.ribbonSeparator1.Image = null;
            this.ribbonSeparator1.Tag = null;
            this.ribbonSeparator1.Text = null;
            this.ribbonSeparator1.ToolTip = null;
            this.ribbonSeparator1.ToolTipTitle = null;
            this.ribbonSeparator1.Value = null;
            // 
            // ribbonOrbMenuItem4
            // 
            this.ribbonOrbMenuItem4.AltKey = null;
            this.ribbonOrbMenuItem4.CheckedGroup = null;
            this.ribbonOrbMenuItem4.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left;
            this.ribbonOrbMenuItem4.DropDownArrowSize = new System.Drawing.Size(5, 3);
            this.ribbonOrbMenuItem4.Image = ((System.Drawing.Image)(resources.GetObject("ribbonOrbMenuItem4.Image")));
            this.ribbonOrbMenuItem4.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonOrbMenuItem4.SmallImage")));
            this.ribbonOrbMenuItem4.Style = System.Windows.Forms.RibbonButtonStyle.Normal;
            this.ribbonOrbMenuItem4.Tag = null;
            this.ribbonOrbMenuItem4.Text = "ribbonOrbMenuItem4";
            this.ribbonOrbMenuItem4.ToolTip = null;
            this.ribbonOrbMenuItem4.ToolTipTitle = null;
            this.ribbonOrbMenuItem4.Value = null;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(568, 443);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.ribbon1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Simulador de grafos";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbCanvas)).EndInit();
            this.PnSimulador.ResumeLayout(false);
            this.PnSimulador.PerformLayout();
            this.CMSCrearVertice.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.RibbonTab rvTInicio;
        private System.Windows.Forms.RibbonPanel rbPArchivo;
        private System.Windows.Forms.RibbonTab rbTGrafo;
        private System.Windows.Forms.RibbonPanel rbPNodos;
        private System.Windows.Forms.RibbonButton btnNewNode;
        private System.Windows.Forms.RibbonButton btnDelNode;
        private System.Windows.Forms.RibbonButton btnNewFile;
        private System.Windows.Forms.RibbonButton btnSaveFile;
        private System.Windows.Forms.RibbonButton btnPrint;
        private System.Windows.Forms.RibbonOrbMenuItem ribbonOrbMenuItem1;
        private System.Windows.Forms.RibbonOrbOptionButton btnClose;
        private System.Windows.Forms.RibbonButton ribbonButton1;
        private System.Windows.Forms.RibbonButton btnQuickNewFile;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ContextMenuStrip CMSCrearVertice;
        private System.Windows.Forms.ToolStripMenuItem nuevoVerticeToolStripMenuItem;
        private System.Windows.Forms.RibbonPanel rbPRecorridos;
        private System.Windows.Forms.RibbonButton btnRecorridoAnchura;
        private System.Windows.Forms.RibbonButton ribbonButton4;
        private System.Windows.Forms.RibbonButton btnRecorridoProfundidad;
        private System.Windows.Forms.RibbonPanel rbPDigrafos;
        private System.Windows.Forms.RibbonButton rbnEliminarArista;
        private System.Windows.Forms.RibbonButton rbnDijk;
        public System.Windows.Forms.PictureBox pbCanvas;
        private System.Windows.Forms.Panel PnSimulador;
        private System.Windows.Forms.Label LblSimu;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbRecorrido;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RibbonButton rbnWarshall;
        private System.Windows.Forms.RibbonButton rbnRestaurar;
        private System.Windows.Forms.RibbonButton btnLoadFile;
        private System.Windows.Forms.RibbonButton btnQuickSaveFile;
        private System.Windows.Forms.RibbonButton btnQuickOpenFile;
        private System.Windows.Forms.Ribbon ribbon1;
        private System.Windows.Forms.RibbonOrbMenuItem ribbonOrbMenuItem2;
        private System.Windows.Forms.RibbonButton ribbonButton6;
        private System.Windows.Forms.RibbonOrbRecentItem ribbonOrbRecentItem2;
        private System.Windows.Forms.RibbonOrbMenuItem ribbonOrbMenuItem3;
        private System.Windows.Forms.RibbonSeparator ribbonSeparator1;
        private System.Windows.Forms.RibbonOrbMenuItem ribbonOrbMenuItem4;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.RibbonPanel rbPNoDigrafos;
        private System.Windows.Forms.RibbonPanel rbPAristas;
        private System.Windows.Forms.RibbonTab rbTRecorridos;
        private System.Windows.Forms.RibbonTab rbTAlgoritmos;
        private System.Windows.Forms.RibbonPanel rbPRestaurar;
        private System.Windows.Forms.RibbonButton rbnBAgregarArista;
        private System.Windows.Forms.RibbonButton rbnBPrim;
        private System.Windows.Forms.RibbonButton rbnBKruskal;
    }
}

