namespace soiltester
{
    partial class Test2Page
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint7 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(5D, 10D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint8 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(20D, 10D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint9 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(8D, 16D);
            this.heading = new System.Windows.Forms.DataGridView();
            this.liquit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.plastic = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mainTable = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.midTable = new System.Windows.Forms.DataGridView();
            this.m9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.b4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tr13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.avfac = new System.Windows.Forms.Label();
            this.limTable = new System.Windows.Forms.DataGridView();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.linearTable = new System.Windows.Forms.DataGridView();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label18 = new System.Windows.Forms.Label();
            this.cBoxTable = new System.Windows.Forms.DataGridView();
            this.col1 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Col2 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Col3 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Col4 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Col5 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.tabsTable = new System.Windows.Forms.DataGridView();
            this.Col7 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Col8 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Col9 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.heading)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mainTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.midTable)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.limTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.linearTable)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cBoxTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabsTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // heading
            // 
            this.heading.AllowUserToAddRows = false;
            this.heading.AllowUserToDeleteRows = false;
            this.heading.AllowUserToResizeColumns = false;
            this.heading.AllowUserToResizeRows = false;
            this.heading.BackgroundColor = System.Drawing.SystemColors.Window;
            this.heading.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.heading.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.heading.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.liquit,
            this.plastic});
            this.heading.Location = new System.Drawing.Point(537, 105);
            this.heading.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.heading.Name = "heading";
            this.heading.RowHeadersVisible = false;
            this.heading.Size = new System.Drawing.Size(604, 38);
            this.heading.TabIndex = 0;
            this.heading.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.heading_CellContentClick);
            // 
            // liquit
            // 
            this.liquit.HeaderText = "Liquit Limit";
            this.liquit.Name = "liquit";
            this.liquit.ReadOnly = true;
            this.liquit.Width = 300;
            // 
            // plastic
            // 
            this.plastic.HeaderText = "Plastic limit";
            this.plastic.Name = "plastic";
            this.plastic.ReadOnly = true;
            this.plastic.Width = 300;
            // 
            // mainTable
            // 
            this.mainTable.AllowUserToAddRows = false;
            this.mainTable.AllowUserToDeleteRows = false;
            this.mainTable.AllowUserToResizeColumns = false;
            this.mainTable.AllowUserToResizeRows = false;
            this.mainTable.BackgroundColor = System.Drawing.SystemColors.Window;
            this.mainTable.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.mainTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.mainTable.ColumnHeadersVisible = false;
            this.mainTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6});
            this.mainTable.Location = new System.Drawing.Point(537, 153);
            this.mainTable.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.mainTable.Name = "mainTable";
            this.mainTable.RowHeadersVisible = false;
            this.mainTable.Size = new System.Drawing.Size(604, 137);
            this.mainTable.TabIndex = 1;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Column1";
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Column2";
            this.Column2.Name = "Column2";
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Column3";
            this.Column3.Name = "Column3";
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Column4";
            this.Column4.Name = "Column4";
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Column5";
            this.Column5.Name = "Column5";
            // 
            // Column6
            // 
            this.Column6.HeaderText = "Column6";
            this.Column6.Name = "Column6";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(156, 143);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(168, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Moisture container No:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(156, 165);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(299, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Mass of container plus wet material (wm) ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(156, 188);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(288, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "Mass of container plus dry material (cm)";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(156, 210);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(157, 20);
            this.label4.TabIndex = 5;
            this.label4.Text = "Mass of container (c)";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(156, 231);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(234, 20);
            this.label5.TabIndex = 6;
            this.label5.Text = "Mass of moisture (wm - cm)=(m)";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(156, 253);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(251, 20);
            this.label6.TabIndex = 7;
            this.label6.Text = "Mass of dry material (cm - c)= (dm)";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(156, 275);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(264, 20);
            this.label7.TabIndex = 8;
            this.label7.Text = "Percentage moisture = (m/dm) x 100";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(156, 295);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(118, 20);
            this.label8.TabIndex = 9;
            this.label8.Text = "Number of taps";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(155, 345);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(126, 16);
            this.label9.TabIndex = 10;
            this.label9.Text = "Linear shrinkage:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(155, 374);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(206, 20);
            this.label10.TabIndex = 11;
            this.label10.Text = "Number of shrinkage trough";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(155, 399);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(244, 20);
            this.label11.TabIndex = 12;
            this.label11.Text = "Length of shrinkage gap (mm) (L)";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(155, 426);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(232, 20);
            this.label12.TabIndex = 13;
            this.label12.Text = "Shrinkage (%) = Average*factor";
            // 
            // midTable
            // 
            this.midTable.AllowUserToAddRows = false;
            this.midTable.AllowUserToDeleteRows = false;
            this.midTable.AllowUserToResizeColumns = false;
            this.midTable.AllowUserToResizeRows = false;
            this.midTable.BackgroundColor = System.Drawing.SystemColors.Window;
            this.midTable.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.midTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.midTable.ColumnHeadersVisible = false;
            this.midTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.m9,
            this.b4,
            this.tr13});
            this.midTable.Location = new System.Drawing.Point(442, 372);
            this.midTable.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.midTable.Name = "midTable";
            this.midTable.RowHeadersVisible = false;
            this.midTable.Size = new System.Drawing.Size(213, 75);
            this.midTable.TabIndex = 14;
            // 
            // m9
            // 
            this.m9.HeaderText = "M9";
            this.m9.Name = "m9";
            this.m9.Width = 70;
            // 
            // b4
            // 
            this.b4.HeaderText = "B4";
            this.b4.Name = "b4";
            this.b4.Width = 70;
            // 
            // tr13
            // 
            this.tr13.HeaderText = "TR13";
            this.tr13.Name = "tr13";
            this.tr13.Width = 70;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.panel1.Controls.Add(this.avfac);
            this.panel1.Location = new System.Drawing.Point(506, 421);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(80, 31);
            this.panel1.TabIndex = 15;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // avfac
            // 
            this.avfac.AutoSize = true;
            this.avfac.ForeColor = System.Drawing.SystemColors.InfoText;
            this.avfac.Location = new System.Drawing.Point(5, 5);
            this.avfac.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.avfac.Name = "avfac";
            this.avfac.Size = new System.Drawing.Size(18, 20);
            this.avfac.TabIndex = 16;
            this.avfac.Text = "0";
            // 
            // limTable
            // 
            this.limTable.AllowUserToAddRows = false;
            this.limTable.AllowUserToDeleteRows = false;
            this.limTable.AllowUserToResizeColumns = false;
            this.limTable.AllowUserToResizeRows = false;
            this.limTable.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.limTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.limTable.ColumnHeadersVisible = false;
            this.limTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column7});
            this.limTable.Location = new System.Drawing.Point(879, 326);
            this.limTable.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.limTable.Name = "limTable";
            this.limTable.RowHeadersVisible = false;
            this.limTable.Size = new System.Drawing.Size(153, 48);
            this.limTable.TabIndex = 16;
            // 
            // Column7
            // 
            this.Column7.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column7.HeaderText = "Column7";
            this.Column7.Name = "Column7";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(702, 330);
            this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(169, 15);
            this.label14.TabIndex = 17;
            this.label14.Text = "Liquid limit from graph  =";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(777, 351);
            this.label15.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(94, 15);
            this.label15.TabIndex = 18;
            this.label15.Text = "Plastic limit =";
            // 
            // linearTable
            // 
            this.linearTable.AllowUserToAddRows = false;
            this.linearTable.AllowUserToDeleteRows = false;
            this.linearTable.AllowUserToResizeColumns = false;
            this.linearTable.AllowUserToResizeRows = false;
            this.linearTable.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.linearTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.linearTable.ColumnHeadersVisible = false;
            this.linearTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column9});
            this.linearTable.Location = new System.Drawing.Point(879, 377);
            this.linearTable.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.linearTable.Name = "linearTable";
            this.linearTable.RowHeadersVisible = false;
            this.linearTable.Size = new System.Drawing.Size(153, 48);
            this.linearTable.TabIndex = 19;
            // 
            // Column9
            // 
            this.Column9.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column9.HeaderText = "Column9";
            this.Column9.Name = "Column9";
            this.Column9.ReadOnly = true;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(760, 379);
            this.label16.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(111, 15);
            this.label16.TabIndex = 20;
            this.label16.Text = "Plasticity index=";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(744, 402);
            this.label17.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(127, 15);
            this.label17.TabIndex = 21;
            this.label17.Text = "Linear shrinkage =";
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.chart1);
            this.panel2.Location = new System.Drawing.Point(188, 474);
            this.panel2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(798, 431);
            this.panel2.TabIndex = 22;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(262, 40);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(823, 48);
            this.label18.TabIndex = 23;
            this.label18.Text = "FORM S2 to S4:DETERMINATION OF THE ONE-POINT LIQUID LIMIT, PLASTIC LIMIT, \r\nPLAST" +
    "ICITY INDEX AND LINEAR SHRINKAGE [SANS 3001: GR10]";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cBoxTable
            // 
            this.cBoxTable.AllowUserToAddRows = false;
            this.cBoxTable.AllowUserToDeleteRows = false;
            this.cBoxTable.AllowUserToResizeColumns = false;
            this.cBoxTable.AllowUserToResizeRows = false;
            this.cBoxTable.BackgroundColor = System.Drawing.SystemColors.Window;
            this.cBoxTable.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.cBoxTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.cBoxTable.ColumnHeadersVisible = false;
            this.cBoxTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col1,
            this.Col2,
            this.Col3,
            this.Col4,
            this.Col5});
            this.cBoxTable.Location = new System.Drawing.Point(537, 132);
            this.cBoxTable.Name = "cBoxTable";
            this.cBoxTable.RowHeadersVisible = false;
            this.cBoxTable.Size = new System.Drawing.Size(604, 23);
            this.cBoxTable.TabIndex = 24;
            this.cBoxTable.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.cBoxTable_CellValueChanged);
            // 
            // col1
            // 
            this.col1.HeaderText = "col1";
            this.col1.Name = "col1";
            this.col1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.col1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // Col2
            // 
            this.Col2.HeaderText = "Col2";
            this.Col2.Name = "Col2";
            this.Col2.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Col2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // Col3
            // 
            this.Col3.HeaderText = "Co3";
            this.Col3.Name = "Col3";
            this.Col3.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Col3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // Col4
            // 
            this.Col4.HeaderText = "Col4";
            this.Col4.Name = "Col4";
            this.Col4.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Col4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // Col5
            // 
            this.Col5.HeaderText = "Col5";
            this.Col5.Name = "Col5";
            this.Col5.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Col5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // tabsTable
            // 
            this.tabsTable.AllowUserToAddRows = false;
            this.tabsTable.AllowUserToDeleteRows = false;
            this.tabsTable.AllowUserToResizeColumns = false;
            this.tabsTable.AllowUserToResizeRows = false;
            this.tabsTable.BackgroundColor = System.Drawing.SystemColors.ControlDarkDark;
            this.tabsTable.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tabsTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tabsTable.ColumnHeadersVisible = false;
            this.tabsTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Col7,
            this.Col8,
            this.Col9});
            this.tabsTable.Location = new System.Drawing.Point(537, 287);
            this.tabsTable.Name = "tabsTable";
            this.tabsTable.RowHeadersVisible = false;
            this.tabsTable.Size = new System.Drawing.Size(604, 23);
            this.tabsTable.TabIndex = 24;
            // 
            // Col7
            // 
            this.Col7.HeaderText = "Col7";
            this.Col7.Name = "Col7";
            this.Col7.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Col7.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // Col8
            // 
            this.Col8.HeaderText = "Col8";
            this.Col8.Name = "Col8";
            this.Col8.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Col8.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // Col9
            // 
            this.Col9.HeaderText = "Col9";
            this.Col9.Name = "Col9";
            this.Col9.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Col9.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // chart1
            // 
            chartArea3.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea3);
            legend3.Name = "Legend1";
            this.chart1.Legends.Add(legend3);
            this.chart1.Location = new System.Drawing.Point(73, -1);
            this.chart1.Name = "chart1";
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series3.Legend = "Legend1";
            series3.Name = "lineChart";
            series3.Points.Add(dataPoint7);
            series3.Points.Add(dataPoint8);
            series3.Points.Add(dataPoint9);
            this.chart1.Series.Add(series3);
            this.chart1.Size = new System.Drawing.Size(672, 414);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart1";
            // 
            // Test2Page
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabsTable);
            this.Controls.Add(this.cBoxTable);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.linearTable);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.limTable);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.midTable);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.mainTable);
            this.Controls.Add(this.heading);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Test2Page";
            this.Size = new System.Drawing.Size(1300, 1036);
            this.Load += new System.EventHandler(this.Test2Page_Load);
            ((System.ComponentModel.ISupportInitialize)(this.heading)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mainTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.midTable)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.limTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.linearTable)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cBoxTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabsTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView heading;
        private System.Windows.Forms.DataGridViewTextBoxColumn liquit;
        private System.Windows.Forms.DataGridViewTextBoxColumn plastic;
        private System.Windows.Forms.DataGridView mainTable;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.DataGridView midTable;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label avfac;
        private System.Windows.Forms.DataGridViewTextBoxColumn m9;
        private System.Windows.Forms.DataGridViewTextBoxColumn b4;
        private System.Windows.Forms.DataGridViewTextBoxColumn tr13;
        private System.Windows.Forms.DataGridView limTable;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.DataGridView linearTable;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.DataGridView cBoxTable;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridView tabsTable;
        private System.Windows.Forms.DataGridViewComboBoxColumn Col7;
        private System.Windows.Forms.DataGridViewComboBoxColumn Col8;
        private System.Windows.Forms.DataGridViewComboBoxColumn Col9;
        private System.Windows.Forms.DataGridViewComboBoxColumn col1;
        private System.Windows.Forms.DataGridViewComboBoxColumn Col2;
        private System.Windows.Forms.DataGridViewComboBoxColumn Col3;
        private System.Windows.Forms.DataGridViewComboBoxColumn Col4;
        private System.Windows.Forms.DataGridViewComboBoxColumn Col5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
    }
}
