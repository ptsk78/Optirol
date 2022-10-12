using Optrol.Theory;
using Optrol.Theory.Systems;
using SharpGL;
using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Threading;

namespace Optrol
{
    public class Optirol : Form
    {
        private Button button1;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage3;
        private TabPage tabPage4;
        private TabControl tabControl2;
        private TabPage tabPage2;
        private DataGridView dataGridView1;
        private TabPage tabPage5;
        private DataGridView dataGridView2;
        private Label label2;
        private ComboBox comboBox2;
        private Label label1;
        private ComboBox comboBox1;
        private Label label4;
        private ComboBox comboBox4;
        private Label label3;
        private ComboBox comboBox3;
        private Button button2;
        private TextBox textBox1;
        private DataGridView dataGridView3;
        private TextBox textBox2;
        private Label label6;
        private Label label5;
        private TextBox textBox3;
        private Label label7;
        private ProgressBar progressBar1;
        private TabPage tabPage6;
        private TabPage tabPage7;
        private VScrollBar vScrollBar1;
        private HScrollBar hScrollBar1;
        private VScrollBar vScrollBar2;
        private HScrollBar hScrollBar2;
        private Label label8;
        private ComboBox comboBox5;
        private Panel panel1;
        private Chart chart1;
        private TabPage tabPage8;
        private DataGridView dataGridView4;
        private RichTextBox richTextBox1;
        private Button button5;
        private Button button4;
        private Button button3;
        private Button button6;
        private Label label9;
        private ComboBox comboBox6;
        //private PictureBox pictureBox1;
        private PointCollection pc;
        private BuiltSystem system;
        private int[] whichForDim;
        private Optimizer optimizer;
        private PictureBox pictureBox1;
        private OpenGLCtrl openGLCtrl1;
        public delegate void SetPB(int num);
        public SetPB setPBDelegate;
        public delegate void WhenFinishedOptimization();
        public WhenFinishedOptimization WhenFinishedOptimizationDelegate;

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Optirol));
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            this.button1 = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.button6 = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.comboBox5 = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBox4 = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.vScrollBar1 = new System.Windows.Forms.VScrollBar();
            this.hScrollBar1 = new System.Windows.Forms.HScrollBar();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.tabPage7 = new System.Windows.Forms.TabPage();
            this.vScrollBar2 = new System.Windows.Forms.VScrollBar();
            this.hScrollBar2 = new System.Windows.Forms.HScrollBar();
            this.tabPage8 = new System.Windows.Forms.TabPage();
            this.dataGridView4 = new System.Windows.Forms.DataGridView();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.label9 = new System.Windows.Forms.Label();
            this.comboBox6 = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dataGridView3 = new System.Windows.Forms.DataGridView();
            this.button2 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.tabControl1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tabPage1.SuspendLayout();
            this.tabControl2.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.tabPage6.SuspendLayout();
            this.tabPage5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.tabPage7.SuspendLayout();
            this.tabPage8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView4)).BeginInit();
            this.tabPage4.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(16, 525);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(812, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Optimize";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(812, 507);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.pictureBox1);
            this.tabPage3.Controls.Add(this.button5);
            this.tabPage3.Controls.Add(this.button4);
            this.tabPage3.Controls.Add(this.button3);
            this.tabPage3.Controls.Add(this.richTextBox1);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(804, 481);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Settings";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.ImageLocation = "";
            this.pictureBox1.Location = new System.Drawing.Point(443, 32);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(358, 446);
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // button5
            // 
            this.button5.Enabled = false;
            this.button5.Location = new System.Drawing.Point(547, 3);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(254, 23);
            this.button5.TabIndex = 3;
            this.button5.Text = "Export Results to Matlab";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(278, 3);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(263, 23);
            this.button4.TabIndex = 2;
            this.button4.Text = "Save Model To File";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(3, 3);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(269, 23);
            this.button3.TabIndex = 1;
            this.button3.Text = "Load Model From File";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBox1.Location = new System.Drawing.Point(3, 32);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedBoth;
            this.richTextBox1.Size = new System.Drawing.Size(434, 446);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.button6);
            this.tabPage1.Controls.Add(this.label8);
            this.tabPage1.Controls.Add(this.comboBox5);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.comboBox4);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.comboBox3);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.comboBox2);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.comboBox1);
            this.tabPage1.Controls.Add(this.tabControl2);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(804, 481);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Energy + Control Value";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(777, 3);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(21, 23);
            this.button6.TabIndex = 11;
            this.button6.Text = "button6";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Visible = false;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(514, 3);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(79, 13);
            this.label8.TabIndex = 10;
            this.label8.Text = "Chosen Control";
            // 
            // comboBox5
            // 
            this.comboBox5.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox5.FormattingEnabled = true;
            this.comboBox5.Location = new System.Drawing.Point(514, 19);
            this.comboBox5.Name = "comboBox5";
            this.comboBox5.Size = new System.Drawing.Size(121, 21);
            this.comboBox5.TabIndex = 9;
            this.comboBox5.SelectedIndexChanged += new System.EventHandler(this.comboBox5_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(387, 3);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Variable value";
            // 
            // comboBox4
            // 
            this.comboBox4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox4.FormattingEnabled = true;
            this.comboBox4.Location = new System.Drawing.Point(387, 19);
            this.comboBox4.Name = "comboBox4";
            this.comboBox4.Size = new System.Drawing.Size(121, 21);
            this.comboBox4.TabIndex = 7;
            this.comboBox4.SelectedIndexChanged += new System.EventHandler(this.comboBox4_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(260, 3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Other variables";
            // 
            // comboBox3
            // 
            this.comboBox3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Location = new System.Drawing.Point(260, 19);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(121, 21);
            this.comboBox3.TabIndex = 5;
            this.comboBox3.SelectedIndexChanged += new System.EventHandler(this.comboBox3_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(133, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Variable 2";
            // 
            // comboBox2
            // 
            this.comboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(133, 19);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(121, 21);
            this.comboBox2.TabIndex = 3;
            this.comboBox2.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Variable 1";
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(6, 19);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 1;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // tabControl2
            // 
            this.tabControl2.Controls.Add(this.tabPage2);
            this.tabControl2.Controls.Add(this.tabPage6);
            this.tabControl2.Controls.Add(this.tabPage5);
            this.tabControl2.Controls.Add(this.tabPage7);
            this.tabControl2.Controls.Add(this.tabPage8);
            this.tabControl2.Location = new System.Drawing.Point(6, 46);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(792, 429);
            this.tabControl2.TabIndex = 0;
            this.tabControl2.SelectedIndexChanged += new System.EventHandler(this.tabControl2_SelectedIndexChanged);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dataGridView1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(784, 403);
            this.tabPage2.TabIndex = 0;
            this.tabPage2.Text = "Energy";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(6, 6);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(772, 391);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentDoubleClick);
            // 
            // tabPage6
            // 
            this.tabPage6.Controls.Add(this.vScrollBar1);
            this.tabPage6.Controls.Add(this.hScrollBar1);
            this.tabPage6.Location = new System.Drawing.Point(4, 22);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage6.Size = new System.Drawing.Size(784, 403);
            this.tabPage6.TabIndex = 2;
            this.tabPage6.Text = "Energy Graph";
            this.tabPage6.UseVisualStyleBackColor = true;
            // 
            // vScrollBar1
            // 
            this.vScrollBar1.Location = new System.Drawing.Point(764, 3);
            this.vScrollBar1.Maximum = 90;
            this.vScrollBar1.Minimum = -90;
            this.vScrollBar1.Name = "vScrollBar1";
            this.vScrollBar1.Size = new System.Drawing.Size(17, 380);
            this.vScrollBar1.TabIndex = 1;
            this.vScrollBar1.ValueChanged += new System.EventHandler(this.vScrollBar1_ValueChanged);
            // 
            // hScrollBar1
            // 
            this.hScrollBar1.Location = new System.Drawing.Point(3, 383);
            this.hScrollBar1.Maximum = 180;
            this.hScrollBar1.Minimum = -180;
            this.hScrollBar1.Name = "hScrollBar1";
            this.hScrollBar1.Size = new System.Drawing.Size(778, 17);
            this.hScrollBar1.TabIndex = 0;
            this.hScrollBar1.ValueChanged += new System.EventHandler(this.hScrollBar1_ValueChanged);
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.dataGridView2);
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(784, 403);
            this.tabPage5.TabIndex = 1;
            this.tabPage5.Text = "Control Values";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // dataGridView2
            // 
            this.dataGridView2.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(6, 6);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            this.dataGridView2.Size = new System.Drawing.Size(772, 391);
            this.dataGridView2.TabIndex = 0;
            this.dataGridView2.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView2_CellDoubleClick);
            // 
            // tabPage7
            // 
            this.tabPage7.Controls.Add(this.vScrollBar2);
            this.tabPage7.Controls.Add(this.hScrollBar2);
            this.tabPage7.Location = new System.Drawing.Point(4, 22);
            this.tabPage7.Name = "tabPage7";
            this.tabPage7.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage7.Size = new System.Drawing.Size(784, 403);
            this.tabPage7.TabIndex = 3;
            this.tabPage7.Text = "Control Values Graph";
            this.tabPage7.UseVisualStyleBackColor = true;
            // 
            // vScrollBar2
            // 
            this.vScrollBar2.Location = new System.Drawing.Point(764, 3);
            this.vScrollBar2.Maximum = 90;
            this.vScrollBar2.Minimum = -90;
            this.vScrollBar2.Name = "vScrollBar2";
            this.vScrollBar2.Size = new System.Drawing.Size(17, 380);
            this.vScrollBar2.TabIndex = 3;
            this.vScrollBar2.ValueChanged += new System.EventHandler(this.vScrollBar2_ValueChanged);
            // 
            // hScrollBar2
            // 
            this.hScrollBar2.Location = new System.Drawing.Point(3, 383);
            this.hScrollBar2.Maximum = 90;
            this.hScrollBar2.Minimum = -90;
            this.hScrollBar2.Name = "hScrollBar2";
            this.hScrollBar2.Size = new System.Drawing.Size(778, 17);
            this.hScrollBar2.TabIndex = 2;
            this.hScrollBar2.ValueChanged += new System.EventHandler(this.hScrollBar2_ValueChanged);
            // 
            // tabPage8
            // 
            this.tabPage8.Controls.Add(this.dataGridView4);
            this.tabPage8.Location = new System.Drawing.Point(4, 22);
            this.tabPage8.Name = "tabPage8";
            this.tabPage8.Size = new System.Drawing.Size(784, 403);
            this.tabPage8.TabIndex = 4;
            this.tabPage8.Text = "Error";
            this.tabPage8.UseVisualStyleBackColor = true;
            // 
            // dataGridView4
            // 
            this.dataGridView4.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dataGridView4.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView4.Location = new System.Drawing.Point(4, 3);
            this.dataGridView4.Name = "dataGridView4";
            this.dataGridView4.ReadOnly = true;
            this.dataGridView4.Size = new System.Drawing.Size(777, 400);
            this.dataGridView4.TabIndex = 0;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.label9);
            this.tabPage4.Controls.Add(this.comboBox6);
            this.tabPage4.Controls.Add(this.panel1);
            this.tabPage4.Controls.Add(this.textBox3);
            this.tabPage4.Controls.Add(this.label7);
            this.tabPage4.Controls.Add(this.textBox2);
            this.tabPage4.Controls.Add(this.label6);
            this.tabPage4.Controls.Add(this.label5);
            this.tabPage4.Controls.Add(this.dataGridView3);
            this.tabPage4.Controls.Add(this.button2);
            this.tabPage4.Controls.Add(this.textBox1);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(804, 481);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Simulations";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(226, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(74, 13);
            this.label9.TabIndex = 15;
            this.label9.Text = "Parameter Set";
            // 
            // comboBox6
            // 
            this.comboBox6.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox6.FormattingEnabled = true;
            this.comboBox6.Location = new System.Drawing.Point(226, 16);
            this.comboBox6.Name = "comboBox6";
            this.comboBox6.Size = new System.Drawing.Size(121, 21);
            this.comboBox6.TabIndex = 14;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.chart1);
            this.panel1.Location = new System.Drawing.Point(3, 71);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(798, 234);
            this.panel1.TabIndex = 8;
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(3, 3);
            this.chart1.Name = "chart1";
            this.chart1.Size = new System.Drawing.Size(792, 228);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart1";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(580, 16);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(221, 20);
            this.textBox3.TabIndex = 7;
            this.textBox3.Text = "600";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(577, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(84, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "Number of steps";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(353, 16);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(221, 20);
            this.textBox2.TabIndex = 5;
            this.textBox2.Text = "0.01";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(350, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 13);
            this.label6.TabIndex = 4;
            this.label6.Text = "Step Size";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "Starting point";
            // 
            // dataGridView3
            // 
            this.dataGridView3.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dataGridView3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView3.Location = new System.Drawing.Point(3, 311);
            this.dataGridView3.Name = "dataGridView3";
            this.dataGridView3.ReadOnly = true;
            this.dataGridView3.Size = new System.Drawing.Size(798, 162);
            this.dataGridView3.TabIndex = 2;
            // 
            // button2
            // 
            this.button2.Enabled = false;
            this.button2.Location = new System.Drawing.Point(0, 42);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(801, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "Run Simulation";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(3, 16);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(217, 20);
            this.textBox1.TabIndex = 0;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(12, 554);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(812, 23);
            this.progressBar1.Step = 1;
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar1.TabIndex = 2;
            // 
            // Optirol
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(836, 592);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Optirol";
            this.Text = "Optirol";
            this.tabControl1.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabControl2.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.tabPage6.ResumeLayout(false);
            this.tabPage5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.tabPage7.ResumeLayout(false);
            this.tabPage8.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView4)).EndInit();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).EndInit();
            this.ResumeLayout(false);

            setPBDelegate = new SetPB(SetPBMethod);
            WhenFinishedOptimizationDelegate = new WhenFinishedOptimization(WhenFinishedOptimizationMethod);
        }

        public Optirol()
        {
            this.InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.button1.Enabled = false;
            BuiltSystem builtSystem = new BuiltSystem();
            if (!builtSystem.Process(this.richTextBox1.Text))
                return;
            this.system = builtSystem;
            this.optimizer = new Optimizer();
            this.pc = new PointCollection(builtSystem);
            Thread thread = new Thread(new ParameterizedThreadStart(Optimize));
            thread.Start(this);
        }

        public void SetPBMethod(int num)
        {
            this.progressBar1.Value = num;
        }

        private void Optimize(object obj)
        {
            Optirol optirol = (Optirol)obj;
            this.optimizer.Optimize(optirol.pc, optirol.system, optirol);
        }

        private void WhenFinishedOptimizationMethod()
        {
            PointCollection.maxValue = 0.0;
            for (int index = 0; index < this.pc.allPoints.Count; ++index)
            {
                if (PointCollection.maxValue < this.pc.allPoints[index].Energy && this.pc.allPoints[index].Energy != double.PositiveInfinity)
                    PointCollection.maxValue = this.pc.allPoints[index].Energy;
            }
            this.button1.Enabled = true;
            this.button2.Enabled = true;
            this.button5.Enabled = true;
            this.tabControl1.SelectedTab = this.tabControl1.TabPages[1];
            this.comboBox1.Items.Clear();
            this.comboBox2.Items.Clear();
            this.comboBox3.Items.Clear();
            this.comboBox4.Items.Clear();
            this.comboBox5.Items.Clear();
            for (int num = 0; num < this.system.GetDimension(); ++num)
            {
                this.comboBox1.Items.Add((object)this.system.GetName(operation.variable, num));
                this.comboBox2.Items.Add((object)this.system.GetName(operation.variable, num));
                this.comboBox3.Items.Add((object)this.system.GetName(operation.variable, num));
            }
            for (int num = 0; num < this.system.GetConDim(); ++num)
                this.comboBox5.Items.Add((object)this.system.GetName(operation.control, num));
            this.whichForDim = new int[this.system.GetDimension()];
            this.comboBox6.Items.Clear();
            for (int i = 0; i < this.system.GetNumberOfParSets(); ++i)
            {
                double[] parSet = this.system.GetParSet(i);
                string str1;
                if (parSet == null)
                {
                    str1 = "No Parameters";
                }
                else
                {
                    string str2 = "[";
                    for (int index = 0; index < parSet.Length; ++index)
                    {
                        if (index != 0)
                            str2 += ";";
                        str2 += parSet[index].ToString();
                    }
                    str1 = str2 + "]";
                }
                this.comboBox6.Items.Add((object)str1);
            }
            this.comboBox1.SelectedIndex = 0;
            this.comboBox2.SelectedIndex = 1;
            this.comboBox5.SelectedIndex = 0;
            this.comboBox6.SelectedIndex = 0;
        }

        private void Redraw()
        {
            if (this.comboBox1.SelectedIndex == -1 || this.comboBox2.SelectedIndex == -1 || this.comboBox5.SelectedIndex == -1)
                return;
            this.pc.FillOutTable(this.comboBox1.SelectedIndex, this.comboBox2.SelectedIndex, this.whichForDim, this.dataGridView1, this.dataGridView2, this.comboBox5.SelectedIndex, this.dataGridView4);
            this.DoDrawings();
        }

        private void DoDrawings()
        {
            OpenGLCtrl openGlCtrl1 = this.openGLCtrl1;
            if (this.comboBox1.SelectedIndex == -1 || this.comboBox2.SelectedIndex == -1 || this.comboBox5.SelectedIndex == -1)
                return;
            this.openGLCtrl1 = new OpenGLCtrl();
            this.openGLCtrl1.DrawRenderTime = false;
            this.openGLCtrl1.FrameRate = 3f;
            this.openGLCtrl1.GDIEnabled = false;
            this.openGLCtrl1.Location = new System.Drawing.Point(20, 20);
            this.openGLCtrl1.Name = "openGLCtrl1";
            this.openGLCtrl1.Size = new Size(760, 380);
            this.openGLCtrl1.TabIndex = 11;
            switch (this.tabControl2.SelectedIndex)
            {
                case 1:
                    this.tabPage6.Controls.Add((Control)this.openGLCtrl1);
                    this.pc.DoDraw(this.comboBox1.SelectedIndex, this.comboBox2.SelectedIndex, this.whichForDim, this.openGLCtrl1.OpenGL, true, (float)this.hScrollBar1.Value, (float)this.vScrollBar1.Value, this.system, this.comboBox5.SelectedIndex);
                    break;
                case 3:
                    this.tabPage7.Controls.Add((Control)this.openGLCtrl1);
                    this.pc.DoDraw(this.comboBox1.SelectedIndex, this.comboBox2.SelectedIndex, this.whichForDim, this.openGLCtrl1.OpenGL, false, (float)this.hScrollBar2.Value, (float)this.vScrollBar2.Value, this.system, this.comboBox5.SelectedIndex);
                    break;
            }
            openGlCtrl1?.Dispose();
            for (int index = 0; index < this.tabPage6.Controls.Count; ++index)
            {
                if (this.tabPage6.Controls[index] != this.openGLCtrl1 && this.tabPage6.Controls[index].GetType().Name.CompareTo("OpenGLCtrl") == 0)
                {
                    this.tabPage6.Controls.RemoveAt(index);
                    --index;
                }
            }
            for (int index = 0; index < this.tabPage7.Controls.Count; ++index)
            {
                if (this.tabPage7.Controls[index] != this.openGLCtrl1 && this.tabPage7.Controls[index].GetType().Name.CompareTo("OpenGLCtrl") == 0)
                {
                    this.tabPage7.Controls.RemoveAt(index);
                    --index;
                }
            }
            this.openGLCtrl1.FrameRate = 0.0f;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.Redraw();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.Redraw();
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            double[] mins = this.system.GetMins();
            double[] maxs = this.system.GetMaxs();
            int selectedIndex = this.comboBox3.SelectedIndex;
            if (selectedIndex == -1)
                return;
            this.comboBox4.Items.Clear();
            for (int index = 0; index < this.system.divPerDim[selectedIndex]; ++index)
                this.comboBox4.Items.Add((object)(mins[selectedIndex] + (maxs[selectedIndex] - mins[selectedIndex]) * (double)index / ((double)this.system.divPerDim[selectedIndex] - 1.0)).ToString());
            this.comboBox4.SelectedIndex = this.whichForDim[selectedIndex];
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.whichForDim[this.comboBox3.SelectedIndex] = this.comboBox4.SelectedIndex;
            this.Redraw();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.chart1.Series.Clear();
            double[] point = new double[this.system.GetDimension()];
            string[] strArray = this.textBox1.Text.Split(';');
            if (strArray.Length != this.system.GetDimension())
            {
                int num1 = (int)MessageBox.Show("Wrong dimension of starting point");
            }
            else
            {
                for (int index = 0; index < this.system.GetDimension(); ++index)
                    point[index] = double.Parse(strArray[index].Trim());
                double num2 = double.Parse(this.textBox2.Text.Trim());
                int num3 = int.Parse(this.textBox3.Text.Trim());
                this.dataGridView3.Rows.Clear();
                this.dataGridView3.Columns.Clear();
                this.dataGridView3.Columns.Add("time", "time");
                for (int num4 = 0; num4 < this.system.GetDimension(); ++num4)
                    this.dataGridView3.Columns.Add(this.system.GetName(operation.variable, num4), this.system.GetName(operation.variable, num4));
                for (int num4 = 0; num4 < this.system.GetConDim(); ++num4)
                    this.dataGridView3.Columns.Add(this.system.GetName(operation.control, num4), this.system.GetName(operation.control, num4));
                for (int num4 = 0; num4 < this.system.GetConDim(); ++num4)
                    this.chart1.Series.Add(this.system.GetName(operation.control, num4));
                for (int num4 = 0; num4 < this.system.GetDimension(); ++num4)
                    this.chart1.Series.Add(this.system.GetName(operation.variable, num4));
                this.dataGridView3.Rows.Add();
                this.dataGridView3.Rows[0].Cells[0].Value = (object)0;
                for (int index = 0; index < point.Length; ++index)
                {
                    this.dataGridView3.Rows[0].Cells[1 + index].Value = (object)point[index];
                    this.chart1.Series[index + this.system.GetConDim()].Points.AddXY(0.0, point[index]);
                }
                double xValue = 0.0;
                for (int index1 = 0; index1 < num3; ++index1)
                {
                    double[] controlValue;
                    point = RungeKutta.MovePoint(this.pc, this.system, point, out controlValue, system.GetParSet(this.comboBox6.SelectedIndex), num2);
                    xValue = ((double)index1 + 1.0) * num2;
                    this.dataGridView3.Rows.Add();
                    this.dataGridView3.Rows[index1 + 1].Cells[0].Value = (object)xValue;
                    for (int index2 = 0; index2 < controlValue.Length; ++index2)
                    {
                        this.dataGridView3.Rows[index1].Cells[index2 + 1 + point.Length].Value = (object)controlValue[index2];
                        this.chart1.Series[index2].Points.AddXY((double)index1 * num2, controlValue[index2]);
                    }
                    for (int index2 = 0; index2 < point.Length; ++index2)
                    {
                        this.dataGridView3.Rows[index1 + 1].Cells[index2 + 1].Value = (object)point[index2];
                        this.chart1.Series[index2 + controlValue.Length].Points.AddXY(xValue, point[index2]);
                    }
                }
                this.chart1.ChartAreas[0].AxisX.Minimum = 0.0;
                this.chart1.ChartAreas[0].AxisX.Maximum = xValue;
                for (int index = 0; index < this.chart1.Series.Count; ++index)
                {
                    this.chart1.Series[index].BorderWidth = 3;
                    this.chart1.Series[index].ChartType = SeriesChartType.Line;
                }
            }
        }

        private void tabControl2_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.DoDrawings();
        }

        private void hScrollBar1_ValueChanged(object sender, EventArgs e)
        {
            this.Redraw();
        }

        private void vScrollBar1_ValueChanged(object sender, EventArgs e)
        {
            this.Redraw();
        }

        private void hScrollBar2_ValueChanged(object sender, EventArgs e)
        {
            this.Redraw();
        }

        private void vScrollBar2_ValueChanged(object sender, EventArgs e)
        {
            this.Redraw();
        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.Redraw();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "(*.mod)|*.mod";
            openFileDialog.InitialDirectory = Directory.GetCurrentDirectory();
            if (openFileDialog.ShowDialog() != DialogResult.OK)
                return;
            StreamReader streamReader = new StreamReader(openFileDialog.FileName);
            this.richTextBox1.Text = streamReader.ReadToEnd();
            streamReader.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "(*.mod)|*.mod";
            saveFileDialog.InitialDirectory = Directory.GetCurrentDirectory();
            if (saveFileDialog.ShowDialog() != DialogResult.OK)
                return;
            StreamWriter streamWriter = new StreamWriter(saveFileDialog.FileName);
            streamWriter.Write(this.richTextBox1.Text);
            streamWriter.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            if (folderBrowserDialog.ShowDialog() != DialogResult.OK)
                return;
            this.Export(folderBrowserDialog.SelectedPath);
        }

        private void Export(string dir)
        {
            this.pc.SaveToFile(dir + "\\data.bin");
            this.SaveLoadDataFile(dir + "\\loaddata.m");
            this.SaveControlFunction(dir + "\\controlfunction.m");
            this.SaveRunFunction(dir + "\\run.m");
            this.SaveModelFunction(dir + "\\model.m");
        }

        private void SaveModelFunction(string filename)
        {
            string str = "" + "function [dx] = model(u,x)\n" + "\n" + "dx = zeros(size(x));\n" + "\n";
            for (int index = 0; index < this.system.variables.Count; ++index)
                str = str + "dx(" + (index + 1).ToString() + ") = " + this.system.variables[index].GetMatlabFunction(this.system.GetParSet(0)) + ";\n";
            StreamWriter streamWriter = new StreamWriter(filename, false);
            streamWriter.Write(str);
            streamWriter.Close();
        }

        private void SaveRunFunction(string filename)
        {
            string str1 = "" + "if exist('control', 'var') == 0\n" + "    global mins maxs control conDimension;\n" + "    [mins, maxs, energy, error, control, conDimension] = loaddata();\n" + "end\n" + "\n";
            double[] mins = this.system.GetMins();
            double[] maxs = this.system.GetMaxs();
            for (int index = 0; index < mins.Length; ++index)
                str1 = str1 + "x0(" + (index + 1).ToString() + ") = " + mins[index].ToString() + "+rand(1,1)*(" + maxs[index].ToString() + "-" + mins[index].ToString() + ");\n";
            string str2 = str1 + "time = " + (PointCollection.maxValue * 2.0).ToString() + ";\n" + "dt = 0.01;\n" + "\n" + "[t,x] = ode23(@controlfunction, [0 : dt : time], x0);\n" + "plot(t,x);\n";
            StreamWriter streamWriter = new StreamWriter(filename, false);
            streamWriter.Write(str2);
            streamWriter.Close();
        }

        private void SaveControlFunction(string filename)
        {
            string str = "function [dx] = controlfunction(t,x0)\n\nglobal mins maxs control conDimension;\n\ns1 = size(mins);\ns2 = size(control);\n\nposition = 0;\nhm = 1;\nfor i = s1(1):-1:1,\n    p = (x0(i)-mins(i)) / (maxs(i)-mins(i)) * s2(i);\n    if(p<0)\n        p = 0;\n    else if(p>s2(i)-1)\n            p = s2(i)-1;\n        end\n    end\n\n    p = int32(round(p));\n    position = position * s2(i);\n    position = position + p;\n\n    hm = hm * s2(i);\nend\n\nu = zeros(conDimension, 1);\nfor i = 1 : conDimension,\n    u(i) = control(position + (i-1) * hm + 1);\nend\n\ndx = model(u, x0);\n";
            StreamWriter streamWriter = new StreamWriter(filename, false);
            streamWriter.Write(str);
            streamWriter.Close();
        }

        private void SaveLoadDataFile(string filename)
        {
            string str = "function [mins, maxs, energy, error, control, conDimension] = loaddata()\n\nfid = fopen('data.bin');\n\ndimension = fread(fid, 1, 'int');\nconDimension = fread(fid, 1, 'int');\n\nmins = zeros(dimension, 1);\nmaxs = zeros(dimension, 1);\ndivPerDim = zeros(dimension, 1);\n\nhm = 1;\nfor i=1:dimension,\n    mins(i) = fread(fid, 1, 'double');\n    maxs(i) = fread(fid, 1, 'double');\n    divPerDim(i) = fread(fid, 1, 'int');\n    hm = hm * divPerDim(i);\nend\n\nenergy = zeros(divPerDim');\nerror = zeros(divPerDim');\ncontrol = zeros([divPerDim', conDimension]);\n\nfor i=1:hm,\n    energy(i) = fread(fid, 1, 'double');\n    error(i) = fread(fid, 1, 'double');\n    for j=1:conDimension,\n        control(1+(i-1)+(j-1)*hm) = fread(fid, 1, 'double');\n    end\nend\nfclose(fid);";
            StreamWriter streamWriter = new StreamWriter(filename, false);
            streamWriter.Write(str);
            streamWriter.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            for (int index = 0; index < 360; index += 3)
            {
                this.hScrollBar1.Value = index - 180;
                this.DoDrawings();
                this.openGLCtrl1.OpenGL.OpenGLBitmap.Save(index.ToString() + ".bmp");
            }
        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            this.MakeSimulation(this.dataGridView1.SelectedCells[0].RowIndex, this.dataGridView1.SelectedCells[0].ColumnIndex);
        }

        private void MakeSimulation(int x1, int x2)
        {
            for (int index = 0; index < this.whichForDim.Length; ++index)
            {
                if (this.comboBox1.SelectedIndex == index)
                    this.whichForDim[index] = x2;
                if (this.comboBox2.SelectedIndex == index)
                    this.whichForDim[index] = x1;
            }
            string str = "";
            double[] mins = this.system.GetMins();
            double[] maxs = this.system.GetMaxs();
            for (int index = 0; index < this.whichForDim.Length; ++index)
            {
                if (index != 0)
                    str += "; ";
                double num = mins[index] + (double)this.whichForDim[index] * (maxs[index] - mins[index]) / ((double)this.system.divPerDim[index] - 1.0);
                str += num.ToString();
            }
            this.textBox1.Text = str;
            double num1 = double.Parse(this.textBox2.Text);
            this.textBox3.Text = ((int)Math.Ceiling((double)this.dataGridView1[x2, x1].Value / num1 * 5.0 / 4.0)).ToString();
            this.tabControl1.SelectedIndex = 2;
            this.button2_Click((object)null, (EventArgs)null);
        }

        private void dataGridView2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            this.MakeSimulation(this.dataGridView2.SelectedCells[0].RowIndex, this.dataGridView2.SelectedCells[0].ColumnIndex);
        }
    }
}
