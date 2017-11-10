namespace readBSA3
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.button_read = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rBmodule6 = new System.Windows.Forms.RadioButton();
            this.rBmodule5 = new System.Windows.Forms.RadioButton();
            this.rBmodule4 = new System.Windows.Forms.RadioButton();
            this.rBmodule3 = new System.Windows.Forms.RadioButton();
            this.rBmodule2 = new System.Windows.Forms.RadioButton();
            this.rBmodule1 = new System.Windows.Forms.RadioButton();
            this.tBmessages = new System.Windows.Forms.TextBox();
            this.tChart1 = new Steema.TeeChart.TChart();
            this.fastLine1 = new Steema.TeeChart.Styles.FastLine();
            this.fastLine2 = new Steema.TeeChart.Styles.FastLine();
            this.fastLine3 = new Steema.TeeChart.Styles.FastLine();
            this.fastLine4 = new Steema.TeeChart.Styles.FastLine();
            this.fastLine5 = new Steema.TeeChart.Styles.FastLine();
            this.fastLine6 = new Steema.TeeChart.Styles.FastLine();
            this.fastLine7 = new Steema.TeeChart.Styles.FastLine();
            this.fastLine8 = new Steema.TeeChart.Styles.FastLine();
            this.button1 = new System.Windows.Forms.Button();
            this.label_position = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox_gmt = new System.Windows.Forms.ComboBox();
            this.label_path = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button_p1h_rigth = new System.Windows.Forms.Button();
            this.button_m1h_rigth = new System.Windows.Forms.Button();
            this.button_p1h_left = new System.Windows.Forms.Button();
            this.button_m1h_left = new System.Windows.Forms.Button();
            this.pB_load = new System.Windows.Forms.ProgressBar();
            this.cBox_spectr = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // button_read
            // 
            this.button_read.Location = new System.Drawing.Point(2, 6);
            this.button_read.Name = "button_read";
            this.button_read.Size = new System.Drawing.Size(154, 21);
            this.button_read.TabIndex = 1;
            this.button_read.Text = "Открыть файл данных";
            this.button_read.UseVisualStyleBackColor = true;
            this.button_read.Click += new System.EventHandler(this.button_read_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "\"shortdata|*.pnt|longdata|*.pnthr|All files|*.*";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rBmodule6);
            this.groupBox1.Controls.Add(this.rBmodule5);
            this.groupBox1.Controls.Add(this.rBmodule4);
            this.groupBox1.Controls.Add(this.rBmodule3);
            this.groupBox1.Controls.Add(this.rBmodule2);
            this.groupBox1.Controls.Add(this.rBmodule1);
            this.groupBox1.Location = new System.Drawing.Point(162, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(193, 48);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Номер модуля";
            // 
            // rBmodule6
            // 
            this.rBmodule6.AutoSize = true;
            this.rBmodule6.Location = new System.Drawing.Point(162, 19);
            this.rBmodule6.Name = "rBmodule6";
            this.rBmodule6.Size = new System.Drawing.Size(31, 17);
            this.rBmodule6.TabIndex = 5;
            this.rBmodule6.TabStop = true;
            this.rBmodule6.Tag = "6";
            this.rBmodule6.Text = "6";
            this.rBmodule6.UseVisualStyleBackColor = true;
            this.rBmodule6.CheckedChanged += new System.EventHandler(this.rBmodule1_CheckedChanged);
            // 
            // rBmodule5
            // 
            this.rBmodule5.AutoSize = true;
            this.rBmodule5.Location = new System.Drawing.Point(132, 19);
            this.rBmodule5.Name = "rBmodule5";
            this.rBmodule5.Size = new System.Drawing.Size(31, 17);
            this.rBmodule5.TabIndex = 4;
            this.rBmodule5.TabStop = true;
            this.rBmodule5.Tag = "5";
            this.rBmodule5.Text = "5";
            this.rBmodule5.UseVisualStyleBackColor = true;
            this.rBmodule5.CheckedChanged += new System.EventHandler(this.rBmodule1_CheckedChanged);
            // 
            // rBmodule4
            // 
            this.rBmodule4.AutoSize = true;
            this.rBmodule4.Location = new System.Drawing.Point(102, 19);
            this.rBmodule4.Name = "rBmodule4";
            this.rBmodule4.Size = new System.Drawing.Size(31, 17);
            this.rBmodule4.TabIndex = 3;
            this.rBmodule4.TabStop = true;
            this.rBmodule4.Tag = "4";
            this.rBmodule4.Text = "4";
            this.rBmodule4.UseVisualStyleBackColor = true;
            this.rBmodule4.CheckedChanged += new System.EventHandler(this.rBmodule1_CheckedChanged);
            // 
            // rBmodule3
            // 
            this.rBmodule3.AutoSize = true;
            this.rBmodule3.Location = new System.Drawing.Point(72, 19);
            this.rBmodule3.Name = "rBmodule3";
            this.rBmodule3.Size = new System.Drawing.Size(31, 17);
            this.rBmodule3.TabIndex = 2;
            this.rBmodule3.TabStop = true;
            this.rBmodule3.Tag = "3";
            this.rBmodule3.Text = "3";
            this.rBmodule3.UseVisualStyleBackColor = true;
            this.rBmodule3.CheckedChanged += new System.EventHandler(this.rBmodule1_CheckedChanged);
            // 
            // rBmodule2
            // 
            this.rBmodule2.AutoSize = true;
            this.rBmodule2.Location = new System.Drawing.Point(40, 19);
            this.rBmodule2.Name = "rBmodule2";
            this.rBmodule2.Size = new System.Drawing.Size(31, 17);
            this.rBmodule2.TabIndex = 1;
            this.rBmodule2.Tag = "2";
            this.rBmodule2.Text = "2";
            this.rBmodule2.UseVisualStyleBackColor = true;
            this.rBmodule2.CheckedChanged += new System.EventHandler(this.rBmodule1_CheckedChanged);
            // 
            // rBmodule1
            // 
            this.rBmodule1.AutoSize = true;
            this.rBmodule1.Checked = true;
            this.rBmodule1.Location = new System.Drawing.Point(12, 19);
            this.rBmodule1.Name = "rBmodule1";
            this.rBmodule1.Size = new System.Drawing.Size(31, 17);
            this.rBmodule1.TabIndex = 0;
            this.rBmodule1.TabStop = true;
            this.rBmodule1.Tag = "1";
            this.rBmodule1.Text = "1";
            this.rBmodule1.UseVisualStyleBackColor = true;
            this.rBmodule1.CheckedChanged += new System.EventHandler(this.rBmodule1_CheckedChanged);
            // 
            // tBmessages
            // 
            this.tBmessages.Location = new System.Drawing.Point(8, 14);
            this.tBmessages.Multiline = true;
            this.tBmessages.Name = "tBmessages";
            this.tBmessages.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tBmessages.Size = new System.Drawing.Size(190, 199);
            this.tBmessages.TabIndex = 3;
            this.tBmessages.WordWrap = false;
            // 
            // tChart1
            // 
            this.tChart1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.tChart1.Aspect.ElevationFloat = 345D;
            this.tChart1.Aspect.RotationFloat = 345D;
            this.tChart1.Aspect.View3D = false;
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChart1.Axes.Bottom.Automatic = true;
            // 
            // 
            // 
            this.tChart1.Axes.Bottom.Grid.Style = System.Drawing.Drawing2D.DashStyle.Dash;
            this.tChart1.Axes.Bottom.Grid.ZPosition = 0D;
            // 
            // 
            // 
            this.tChart1.Axes.Bottom.Labels.DateTimeFormat = "HH.mm.ss";
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChart1.Axes.Bottom.Labels.Font.Shadow.Visible = false;
            this.tChart1.Axes.Bottom.Labels.Font.Unit = System.Drawing.GraphicsUnit.World;
            // 
            // 
            // 
            this.tChart1.Axes.Bottom.Labels.Shadow.Visible = false;
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChart1.Axes.Bottom.Title.Font.Shadow.Visible = false;
            this.tChart1.Axes.Bottom.Title.Font.Unit = System.Drawing.GraphicsUnit.World;
            // 
            // 
            // 
            this.tChart1.Axes.Bottom.Title.Shadow.Visible = false;
            // 
            // 
            // 
            this.tChart1.Axes.Depth.Automatic = true;
            // 
            // 
            // 
            this.tChart1.Axes.Depth.Grid.Style = System.Drawing.Drawing2D.DashStyle.Dash;
            this.tChart1.Axes.Depth.Grid.ZPosition = 0D;
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChart1.Axes.Depth.Labels.Font.Shadow.Visible = false;
            this.tChart1.Axes.Depth.Labels.Font.Unit = System.Drawing.GraphicsUnit.World;
            // 
            // 
            // 
            this.tChart1.Axes.Depth.Labels.Shadow.Visible = false;
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChart1.Axes.Depth.Title.Font.Shadow.Visible = false;
            this.tChart1.Axes.Depth.Title.Font.Unit = System.Drawing.GraphicsUnit.World;
            // 
            // 
            // 
            this.tChart1.Axes.Depth.Title.Shadow.Visible = false;
            // 
            // 
            // 
            this.tChart1.Axes.DepthTop.Automatic = true;
            // 
            // 
            // 
            this.tChart1.Axes.DepthTop.Grid.Style = System.Drawing.Drawing2D.DashStyle.Dash;
            this.tChart1.Axes.DepthTop.Grid.ZPosition = 0D;
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChart1.Axes.DepthTop.Labels.Font.Shadow.Visible = false;
            this.tChart1.Axes.DepthTop.Labels.Font.Unit = System.Drawing.GraphicsUnit.World;
            // 
            // 
            // 
            this.tChart1.Axes.DepthTop.Labels.Shadow.Visible = false;
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChart1.Axes.DepthTop.Title.Font.Shadow.Visible = false;
            this.tChart1.Axes.DepthTop.Title.Font.Unit = System.Drawing.GraphicsUnit.World;
            // 
            // 
            // 
            this.tChart1.Axes.DepthTop.Title.Shadow.Visible = false;
            // 
            // 
            // 
            this.tChart1.Axes.Left.Automatic = true;
            // 
            // 
            // 
            this.tChart1.Axes.Left.Grid.Style = System.Drawing.Drawing2D.DashStyle.Dash;
            this.tChart1.Axes.Left.Grid.ZPosition = 0D;
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChart1.Axes.Left.Labels.Font.Shadow.Visible = false;
            this.tChart1.Axes.Left.Labels.Font.Unit = System.Drawing.GraphicsUnit.World;
            // 
            // 
            // 
            this.tChart1.Axes.Left.Labels.Shadow.Visible = false;
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChart1.Axes.Left.Title.Font.Shadow.Visible = false;
            this.tChart1.Axes.Left.Title.Font.Unit = System.Drawing.GraphicsUnit.World;
            // 
            // 
            // 
            this.tChart1.Axes.Left.Title.Shadow.Visible = false;
            // 
            // 
            // 
            this.tChart1.Axes.Right.Automatic = true;
            // 
            // 
            // 
            this.tChart1.Axes.Right.Grid.Style = System.Drawing.Drawing2D.DashStyle.Dash;
            this.tChart1.Axes.Right.Grid.ZPosition = 0D;
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChart1.Axes.Right.Labels.Font.Shadow.Visible = false;
            this.tChart1.Axes.Right.Labels.Font.Unit = System.Drawing.GraphicsUnit.World;
            // 
            // 
            // 
            this.tChart1.Axes.Right.Labels.Shadow.Visible = false;
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChart1.Axes.Right.Title.Font.Shadow.Visible = false;
            this.tChart1.Axes.Right.Title.Font.Unit = System.Drawing.GraphicsUnit.World;
            // 
            // 
            // 
            this.tChart1.Axes.Right.Title.Shadow.Visible = false;
            // 
            // 
            // 
            this.tChart1.Axes.Top.Automatic = true;
            // 
            // 
            // 
            this.tChart1.Axes.Top.Grid.Style = System.Drawing.Drawing2D.DashStyle.Dash;
            this.tChart1.Axes.Top.Grid.ZPosition = 0D;
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChart1.Axes.Top.Labels.Font.Shadow.Visible = false;
            this.tChart1.Axes.Top.Labels.Font.Unit = System.Drawing.GraphicsUnit.World;
            // 
            // 
            // 
            this.tChart1.Axes.Top.Labels.Shadow.Visible = false;
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChart1.Axes.Top.Title.Font.Shadow.Visible = false;
            this.tChart1.Axes.Top.Title.Font.Unit = System.Drawing.GraphicsUnit.World;
            // 
            // 
            // 
            this.tChart1.Axes.Top.Title.Shadow.Visible = false;
            this.tChart1.Axes.Top.Visible = false;
            this.tChart1.Cursor = System.Windows.Forms.Cursors.Default;
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChart1.Footer.Font.Shadow.Visible = false;
            this.tChart1.Footer.Font.Unit = System.Drawing.GraphicsUnit.World;
            // 
            // 
            // 
            this.tChart1.Footer.Shadow.Visible = false;
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChart1.Header.Font.Shadow.Visible = false;
            this.tChart1.Header.Font.Unit = System.Drawing.GraphicsUnit.World;
            this.tChart1.Header.Lines = new string[] {
        "TeeChart"};
            // 
            // 
            // 
            this.tChart1.Header.Shadow.Visible = false;
            this.tChart1.Header.Visible = false;
            // 
            // 
            // 
            this.tChart1.Legend.Alignment = Steema.TeeChart.LegendAlignments.Bottom;
            this.tChart1.Legend.CheckBoxes = true;
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChart1.Legend.Font.Shadow.Visible = false;
            this.tChart1.Legend.Font.Unit = System.Drawing.GraphicsUnit.World;
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChart1.Legend.Title.Font.Bold = true;
            // 
            // 
            // 
            this.tChart1.Legend.Title.Font.Shadow.Visible = false;
            this.tChart1.Legend.Title.Font.Unit = System.Drawing.GraphicsUnit.World;
            // 
            // 
            // 
            this.tChart1.Legend.Title.Pen.Visible = false;
            // 
            // 
            // 
            this.tChart1.Legend.Title.Shadow.Visible = false;
            this.tChart1.Location = new System.Drawing.Point(3, 6);
            this.tChart1.Name = "tChart1";
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChart1.Panel.Shadow.Visible = false;
            this.tChart1.Series.Add(this.fastLine1);
            this.tChart1.Series.Add(this.fastLine2);
            this.tChart1.Series.Add(this.fastLine3);
            this.tChart1.Series.Add(this.fastLine4);
            this.tChart1.Series.Add(this.fastLine5);
            this.tChart1.Series.Add(this.fastLine6);
            this.tChart1.Series.Add(this.fastLine7);
            this.tChart1.Series.Add(this.fastLine8);
            this.tChart1.Size = new System.Drawing.Size(758, 282);
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChart1.SubFooter.Font.Shadow.Visible = false;
            this.tChart1.SubFooter.Font.Unit = System.Drawing.GraphicsUnit.World;
            // 
            // 
            // 
            this.tChart1.SubFooter.Shadow.Visible = false;
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChart1.SubHeader.Font.Shadow.Visible = false;
            this.tChart1.SubHeader.Font.Unit = System.Drawing.GraphicsUnit.World;
            // 
            // 
            // 
            this.tChart1.SubHeader.Shadow.Visible = false;
            this.tChart1.TabIndex = 8;
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChart1.Walls.Back.AutoHide = false;
            // 
            // 
            // 
            this.tChart1.Walls.Back.Shadow.Visible = false;
            // 
            // 
            // 
            this.tChart1.Walls.Bottom.AutoHide = false;
            // 
            // 
            // 
            this.tChart1.Walls.Bottom.Shadow.Visible = false;
            // 
            // 
            // 
            this.tChart1.Walls.Left.AutoHide = false;
            // 
            // 
            // 
            this.tChart1.Walls.Left.Shadow.Visible = false;
            // 
            // 
            // 
            this.tChart1.Walls.Right.AutoHide = false;
            // 
            // 
            // 
            this.tChart1.Walls.Right.Shadow.Visible = false;
            this.tChart1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.tChart1_MouseMove);
            // 
            // fastLine1
            // 
            // 
            // 
            // 
            this.fastLine1.LinePen.Color = System.Drawing.Color.Red;
            // 
            // 
            // 
            // 
            // 
            // 
            this.fastLine1.Marks.Callout.ArrowHead = Steema.TeeChart.Styles.ArrowHeadStyles.None;
            this.fastLine1.Marks.Callout.ArrowHeadSize = 8;
            // 
            // 
            // 
            this.fastLine1.Marks.Callout.Brush.Color = System.Drawing.Color.Black;
            this.fastLine1.Marks.Callout.Distance = 0;
            this.fastLine1.Marks.Callout.Draw3D = false;
            this.fastLine1.Marks.Callout.Length = 10;
            this.fastLine1.Marks.Callout.Style = Steema.TeeChart.Styles.PointerStyles.Rectangle;
            // 
            // 
            // 
            // 
            // 
            // 
            this.fastLine1.Marks.Font.Shadow.Visible = false;
            this.fastLine1.Marks.Font.Unit = System.Drawing.GraphicsUnit.World;
            this.fastLine1.Title = "канал1";
            // 
            // 
            // 
            this.fastLine1.XValues.DataMember = "X";
            this.fastLine1.XValues.DateTime = true;
            this.fastLine1.XValues.Order = Steema.TeeChart.Styles.ValueListOrder.Ascending;
            // 
            // 
            // 
            this.fastLine1.YValues.DataMember = "Y";
            // 
            // fastLine2
            // 
            // 
            // 
            // 
            this.fastLine2.LinePen.Color = System.Drawing.Color.Green;
            // 
            // 
            // 
            // 
            // 
            // 
            this.fastLine2.Marks.Callout.ArrowHead = Steema.TeeChart.Styles.ArrowHeadStyles.None;
            this.fastLine2.Marks.Callout.ArrowHeadSize = 8;
            // 
            // 
            // 
            this.fastLine2.Marks.Callout.Brush.Color = System.Drawing.Color.Black;
            this.fastLine2.Marks.Callout.Distance = 0;
            this.fastLine2.Marks.Callout.Draw3D = false;
            this.fastLine2.Marks.Callout.Length = 10;
            this.fastLine2.Marks.Callout.Style = Steema.TeeChart.Styles.PointerStyles.Rectangle;
            // 
            // 
            // 
            // 
            // 
            // 
            this.fastLine2.Marks.Font.Shadow.Visible = false;
            this.fastLine2.Marks.Font.Unit = System.Drawing.GraphicsUnit.World;
            this.fastLine2.Title = "канал2";
            // 
            // 
            // 
            this.fastLine2.XValues.DataMember = "X";
            this.fastLine2.XValues.Order = Steema.TeeChart.Styles.ValueListOrder.Ascending;
            // 
            // 
            // 
            this.fastLine2.YValues.DataMember = "Y";
            // 
            // fastLine3
            // 
            // 
            // 
            // 
            this.fastLine3.LinePen.Color = System.Drawing.Color.Yellow;
            // 
            // 
            // 
            // 
            // 
            // 
            this.fastLine3.Marks.Callout.ArrowHead = Steema.TeeChart.Styles.ArrowHeadStyles.None;
            this.fastLine3.Marks.Callout.ArrowHeadSize = 8;
            // 
            // 
            // 
            this.fastLine3.Marks.Callout.Brush.Color = System.Drawing.Color.Black;
            this.fastLine3.Marks.Callout.Distance = 0;
            this.fastLine3.Marks.Callout.Draw3D = false;
            this.fastLine3.Marks.Callout.Length = 10;
            this.fastLine3.Marks.Callout.Style = Steema.TeeChart.Styles.PointerStyles.Rectangle;
            // 
            // 
            // 
            // 
            // 
            // 
            this.fastLine3.Marks.Font.Shadow.Visible = false;
            this.fastLine3.Marks.Font.Unit = System.Drawing.GraphicsUnit.World;
            this.fastLine3.Title = "канал3";
            // 
            // 
            // 
            this.fastLine3.XValues.DataMember = "X";
            this.fastLine3.XValues.Order = Steema.TeeChart.Styles.ValueListOrder.Ascending;
            // 
            // 
            // 
            this.fastLine3.YValues.DataMember = "Y";
            // 
            // fastLine4
            // 
            // 
            // 
            // 
            this.fastLine4.LinePen.Color = System.Drawing.Color.Blue;
            // 
            // 
            // 
            // 
            // 
            // 
            this.fastLine4.Marks.Callout.ArrowHead = Steema.TeeChart.Styles.ArrowHeadStyles.None;
            this.fastLine4.Marks.Callout.ArrowHeadSize = 8;
            // 
            // 
            // 
            this.fastLine4.Marks.Callout.Brush.Color = System.Drawing.Color.Black;
            this.fastLine4.Marks.Callout.Distance = 0;
            this.fastLine4.Marks.Callout.Draw3D = false;
            this.fastLine4.Marks.Callout.Length = 10;
            this.fastLine4.Marks.Callout.Style = Steema.TeeChart.Styles.PointerStyles.Rectangle;
            // 
            // 
            // 
            // 
            // 
            // 
            this.fastLine4.Marks.Font.Shadow.Visible = false;
            this.fastLine4.Marks.Font.Unit = System.Drawing.GraphicsUnit.World;
            this.fastLine4.Title = "канал4";
            // 
            // 
            // 
            this.fastLine4.XValues.DataMember = "X";
            this.fastLine4.XValues.Order = Steema.TeeChart.Styles.ValueListOrder.Ascending;
            // 
            // 
            // 
            this.fastLine4.YValues.DataMember = "Y";
            // 
            // fastLine5
            // 
            // 
            // 
            // 
            this.fastLine5.LinePen.Color = System.Drawing.Color.White;
            // 
            // 
            // 
            // 
            // 
            // 
            this.fastLine5.Marks.Callout.ArrowHead = Steema.TeeChart.Styles.ArrowHeadStyles.None;
            this.fastLine5.Marks.Callout.ArrowHeadSize = 8;
            // 
            // 
            // 
            this.fastLine5.Marks.Callout.Brush.Color = System.Drawing.Color.Black;
            this.fastLine5.Marks.Callout.Distance = 0;
            this.fastLine5.Marks.Callout.Draw3D = false;
            this.fastLine5.Marks.Callout.Length = 10;
            this.fastLine5.Marks.Callout.Style = Steema.TeeChart.Styles.PointerStyles.Rectangle;
            // 
            // 
            // 
            // 
            // 
            // 
            this.fastLine5.Marks.Font.Shadow.Visible = false;
            this.fastLine5.Marks.Font.Unit = System.Drawing.GraphicsUnit.World;
            this.fastLine5.Title = "канал5";
            // 
            // 
            // 
            this.fastLine5.XValues.DataMember = "X";
            this.fastLine5.XValues.Order = Steema.TeeChart.Styles.ValueListOrder.Ascending;
            // 
            // 
            // 
            this.fastLine5.YValues.DataMember = "Y";
            // 
            // fastLine6
            // 
            // 
            // 
            // 
            this.fastLine6.LinePen.Color = System.Drawing.Color.Gray;
            // 
            // 
            // 
            // 
            // 
            // 
            this.fastLine6.Marks.Callout.ArrowHead = Steema.TeeChart.Styles.ArrowHeadStyles.None;
            this.fastLine6.Marks.Callout.ArrowHeadSize = 8;
            // 
            // 
            // 
            this.fastLine6.Marks.Callout.Brush.Color = System.Drawing.Color.Black;
            this.fastLine6.Marks.Callout.Distance = 0;
            this.fastLine6.Marks.Callout.Draw3D = false;
            this.fastLine6.Marks.Callout.Length = 10;
            this.fastLine6.Marks.Callout.Style = Steema.TeeChart.Styles.PointerStyles.Rectangle;
            // 
            // 
            // 
            // 
            // 
            // 
            this.fastLine6.Marks.Font.Shadow.Visible = false;
            this.fastLine6.Marks.Font.Unit = System.Drawing.GraphicsUnit.World;
            this.fastLine6.Title = "канал6";
            // 
            // 
            // 
            this.fastLine6.XValues.DataMember = "X";
            this.fastLine6.XValues.Order = Steema.TeeChart.Styles.ValueListOrder.Ascending;
            // 
            // 
            // 
            this.fastLine6.YValues.DataMember = "Y";
            // 
            // fastLine7
            // 
            // 
            // 
            // 
            this.fastLine7.LinePen.Color = System.Drawing.Color.Fuchsia;
            // 
            // 
            // 
            // 
            // 
            // 
            this.fastLine7.Marks.Callout.ArrowHead = Steema.TeeChart.Styles.ArrowHeadStyles.None;
            this.fastLine7.Marks.Callout.ArrowHeadSize = 8;
            // 
            // 
            // 
            this.fastLine7.Marks.Callout.Brush.Color = System.Drawing.Color.Black;
            this.fastLine7.Marks.Callout.Distance = 0;
            this.fastLine7.Marks.Callout.Draw3D = false;
            this.fastLine7.Marks.Callout.Length = 10;
            this.fastLine7.Marks.Callout.Style = Steema.TeeChart.Styles.PointerStyles.Rectangle;
            // 
            // 
            // 
            // 
            // 
            // 
            this.fastLine7.Marks.Font.Shadow.Visible = false;
            this.fastLine7.Marks.Font.Unit = System.Drawing.GraphicsUnit.World;
            this.fastLine7.Title = "канал7";
            // 
            // 
            // 
            this.fastLine7.XValues.DataMember = "X";
            this.fastLine7.XValues.Order = Steema.TeeChart.Styles.ValueListOrder.Ascending;
            // 
            // 
            // 
            this.fastLine7.YValues.DataMember = "Y";
            // 
            // fastLine8
            // 
            // 
            // 
            // 
            this.fastLine8.LinePen.Color = System.Drawing.Color.Teal;
            // 
            // 
            // 
            // 
            // 
            // 
            this.fastLine8.Marks.Callout.ArrowHead = Steema.TeeChart.Styles.ArrowHeadStyles.None;
            this.fastLine8.Marks.Callout.ArrowHeadSize = 8;
            // 
            // 
            // 
            this.fastLine8.Marks.Callout.Brush.Color = System.Drawing.Color.Black;
            this.fastLine8.Marks.Callout.Distance = 0;
            this.fastLine8.Marks.Callout.Draw3D = false;
            this.fastLine8.Marks.Callout.Length = 10;
            this.fastLine8.Marks.Callout.Style = Steema.TeeChart.Styles.PointerStyles.Rectangle;
            // 
            // 
            // 
            // 
            // 
            // 
            this.fastLine8.Marks.Font.Shadow.Visible = false;
            this.fastLine8.Marks.Font.Unit = System.Drawing.GraphicsUnit.World;
            this.fastLine8.Title = "канал8";
            // 
            // 
            // 
            this.fastLine8.XValues.DataMember = "X";
            this.fastLine8.XValues.Order = Steema.TeeChart.Styles.ValueListOrder.Ascending;
            // 
            // 
            // 
            this.fastLine8.YValues.DataMember = "Y";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(2, 32);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(154, 23);
            this.button1.TabIndex = 10;
            this.button1.Text = "Копировать в буфер обмена";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label_position
            // 
            this.label_position.AutoSize = true;
            this.label_position.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_position.ForeColor = System.Drawing.Color.Blue;
            this.label_position.Location = new System.Drawing.Point(7, 57);
            this.label_position.Name = "label_position";
            this.label_position.Size = new System.Drawing.Size(71, 19);
            this.label_position.TabIndex = 11;
            this.label_position.Text = "X=0  Y=0";
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(2, 78);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(774, 319);
            this.tabControl1.TabIndex = 12;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.tChart1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(2);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(2);
            this.tabPage1.Size = new System.Drawing.Size(766, 293);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Графики";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.comboBox_gmt);
            this.tabPage2.Controls.Add(this.label_path);
            this.tabPage2.Controls.Add(this.textBox1);
            this.tabPage2.Controls.Add(this.tBmessages);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(2);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(2);
            this.tabPage2.Size = new System.Drawing.Size(766, 293);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Служебная";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(461, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(117, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Часовой пояс GMT + ";
            // 
            // comboBox_gmt
            // 
            this.comboBox_gmt.FormattingEnabled = true;
            this.comboBox_gmt.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5"});
            this.comboBox_gmt.Location = new System.Drawing.Point(473, 96);
            this.comboBox_gmt.Name = "comboBox_gmt";
            this.comboBox_gmt.Size = new System.Drawing.Size(86, 21);
            this.comboBox_gmt.TabIndex = 7;
            this.comboBox_gmt.SelectedIndexChanged += new System.EventHandler(this.comboBox_gmt_SelectedIndexChanged);
            // 
            // label_path
            // 
            this.label_path.AutoSize = true;
            this.label_path.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_path.ForeColor = System.Drawing.Color.Blue;
            this.label_path.Location = new System.Drawing.Point(152, 226);
            this.label_path.Name = "label_path";
            this.label_path.Size = new System.Drawing.Size(46, 17);
            this.label_path.TabIndex = 6;
            this.label_path.Text = "Path:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(270, 14);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox1.Size = new System.Drawing.Size(184, 199);
            this.textBox1.TabIndex = 5;
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox1.WordWrap = false;
            // 
            // button_p1h_rigth
            // 
            this.button_p1h_rigth.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_p1h_rigth.Location = new System.Drawing.Point(699, 10);
            this.button_p1h_rigth.Margin = new System.Windows.Forms.Padding(2);
            this.button_p1h_rigth.Name = "button_p1h_rigth";
            this.button_p1h_rigth.Size = new System.Drawing.Size(74, 19);
            this.button_p1h_rigth.TabIndex = 9;
            this.button_p1h_rigth.Text = "+1h справа";
            this.button_p1h_rigth.UseVisualStyleBackColor = true;
            this.button_p1h_rigth.Click += new System.EventHandler(this.button_p1h_rigth_Click);
            // 
            // button_m1h_rigth
            // 
            this.button_m1h_rigth.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_m1h_rigth.Location = new System.Drawing.Point(700, 36);
            this.button_m1h_rigth.Margin = new System.Windows.Forms.Padding(2);
            this.button_m1h_rigth.Name = "button_m1h_rigth";
            this.button_m1h_rigth.Size = new System.Drawing.Size(74, 19);
            this.button_m1h_rigth.TabIndex = 13;
            this.button_m1h_rigth.Text = "-1h справа";
            this.button_m1h_rigth.UseVisualStyleBackColor = true;
            this.button_m1h_rigth.Click += new System.EventHandler(this.button_m1h_rigth_Click);
            // 
            // button_p1h_left
            // 
            this.button_p1h_left.Location = new System.Drawing.Point(372, 10);
            this.button_p1h_left.Margin = new System.Windows.Forms.Padding(2);
            this.button_p1h_left.Name = "button_p1h_left";
            this.button_p1h_left.Size = new System.Drawing.Size(74, 19);
            this.button_p1h_left.TabIndex = 14;
            this.button_p1h_left.Text = "+1h слева";
            this.button_p1h_left.UseVisualStyleBackColor = true;
            this.button_p1h_left.Click += new System.EventHandler(this.button_p1h_left_Click);
            // 
            // button_m1h_left
            // 
            this.button_m1h_left.Location = new System.Drawing.Point(372, 36);
            this.button_m1h_left.Margin = new System.Windows.Forms.Padding(2);
            this.button_m1h_left.Name = "button_m1h_left";
            this.button_m1h_left.Size = new System.Drawing.Size(74, 19);
            this.button_m1h_left.TabIndex = 15;
            this.button_m1h_left.Text = "-1h слева";
            this.button_m1h_left.UseVisualStyleBackColor = true;
            this.button_m1h_left.Click += new System.EventHandler(this.button_m1h_left_Click);
            // 
            // pB_load
            // 
            this.pB_load.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pB_load.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.pB_load.Location = new System.Drawing.Point(507, 56);
            this.pB_load.Name = "pB_load";
            this.pB_load.Size = new System.Drawing.Size(265, 20);
            this.pB_load.TabIndex = 17;
            this.pB_load.Visible = false;
            // 
            // cBox_spectr
            // 
            this.cBox_spectr.FormattingEnabled = true;
            this.cBox_spectr.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9"});
            this.cBox_spectr.Location = new System.Drawing.Point(451, 34);
            this.cBox_spectr.Name = "cBox_spectr";
            this.cBox_spectr.Size = new System.Drawing.Size(81, 21);
            this.cBox_spectr.TabIndex = 21;
            this.cBox_spectr.Text = "1";
            this.cBox_spectr.SelectedIndexChanged += new System.EventHandler(this.cBox_spectr_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(449, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 13);
            this.label1.TabIndex = 22;
            this.label1.Text = "Номер спектра";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(569, 9);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 23;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(780, 396);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cBox_spectr);
            this.Controls.Add(this.pB_load);
            this.Controls.Add(this.button_m1h_left);
            this.Controls.Add(this.button_p1h_left);
            this.Controls.Add(this.button_m1h_rigth);
            this.Controls.Add(this.button_p1h_rigth);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.label_position);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button_read);
            this.MinimumSize = new System.Drawing.Size(655, 379);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Просмотр данных регистратора БСА3";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_read;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rBmodule2;
        private System.Windows.Forms.RadioButton rBmodule1;
        private System.Windows.Forms.RadioButton rBmodule6;
        private System.Windows.Forms.RadioButton rBmodule5;
        private System.Windows.Forms.RadioButton rBmodule4;
        private System.Windows.Forms.RadioButton rBmodule3;
        private System.Windows.Forms.TextBox tBmessages;
        private Steema.TeeChart.TChart tChart1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label_position;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private Steema.TeeChart.Styles.FastLine fastLine1;
        private Steema.TeeChart.Styles.FastLine fastLine2;
        private Steema.TeeChart.Styles.FastLine fastLine3;
        private Steema.TeeChart.Styles.FastLine fastLine4;
        private Steema.TeeChart.Styles.FastLine fastLine5;
        private Steema.TeeChart.Styles.FastLine fastLine6;
        private Steema.TeeChart.Styles.FastLine fastLine7;
        private Steema.TeeChart.Styles.FastLine fastLine8;
        private System.Windows.Forms.Button button_p1h_rigth;
        private System.Windows.Forms.Button button_m1h_rigth;
        private System.Windows.Forms.Button button_p1h_left;
        private System.Windows.Forms.Button button_m1h_left;
        private System.Windows.Forms.ProgressBar pB_load;
        private System.Windows.Forms.ComboBox cBox_spectr;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label_path;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBox_gmt;
        private System.Windows.Forms.Button button2;
    }
}

