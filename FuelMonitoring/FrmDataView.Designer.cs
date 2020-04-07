namespace FuelMonitoring
{
    partial class FrmDataView
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.DGFM = new System.Windows.Forms.DataGridView();
            this.chkside = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.txtNozle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtCurrenRS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CurrentKG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CurrentRate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NonRestableTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RestableTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FillCounter = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LastRs = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LastKG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LastRate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DateTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.wsmbsControl1 = new WSMBS.WSMBSControl(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.label10 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DGFM)).BeginInit();
            this.SuspendLayout();
            // 
            // DGFM
            // 
            this.DGFM.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.DGFM.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.YellowGreen;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.GradientActiveCaption;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGFM.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.DGFM.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGFM.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.chkside,
            this.txtNozle,
            this.txtCurrenRS,
            this.CurrentKG,
            this.CurrentRate,
            this.NonRestableTotal,
            this.RestableTotal,
            this.FillCounter,
            this.LastRs,
            this.LastKG,
            this.LastRate,
            this.DateTime});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Verdana", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DGFM.DefaultCellStyle = dataGridViewCellStyle2;
            this.DGFM.GridColor = System.Drawing.Color.White;
            this.DGFM.Location = new System.Drawing.Point(2, 55);
            this.DGFM.Name = "DGFM";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGFM.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.DGFM.RowHeadersWidth = 5;
            this.DGFM.Size = new System.Drawing.Size(1340, 505);
            this.DGFM.TabIndex = 0;
            // 
            // chkside
            // 
            this.chkside.HeaderText = "";
            this.chkside.Name = "chkside";
            this.chkside.TrueValue = "true";
            this.chkside.Width = 20;
            // 
            // txtNozle
            // 
            this.txtNozle.HeaderText = "Nozel";
            this.txtNozle.Name = "txtNozle";
            // 
            // txtCurrenRS
            // 
            this.txtCurrenRS.HeaderText = "Current RS";
            this.txtCurrenRS.MinimumWidth = 7;
            this.txtCurrenRS.Name = "txtCurrenRS";
            this.txtCurrenRS.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.txtCurrenRS.Width = 130;
            // 
            // CurrentKG
            // 
            this.CurrentKG.HeaderText = "Current KG";
            this.CurrentKG.MinimumWidth = 7;
            this.CurrentKG.Name = "CurrentKG";
            this.CurrentKG.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.CurrentKG.Width = 130;
            // 
            // CurrentRate
            // 
            this.CurrentRate.HeaderText = "Current Rate";
            this.CurrentRate.Name = "CurrentRate";
            this.CurrentRate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // NonRestableTotal
            // 
            this.NonRestableTotal.HeaderText = "NonRestable otal";
            this.NonRestableTotal.MinimumWidth = 9;
            this.NonRestableTotal.Name = "NonRestableTotal";
            this.NonRestableTotal.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.NonRestableTotal.Width = 160;
            // 
            // RestableTotal
            // 
            this.RestableTotal.HeaderText = "Restable Total";
            this.RestableTotal.MinimumWidth = 9;
            this.RestableTotal.Name = "RestableTotal";
            this.RestableTotal.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.RestableTotal.Width = 160;
            // 
            // FillCounter
            // 
            this.FillCounter.HeaderText = "Fill Counter";
            this.FillCounter.MinimumWidth = 6;
            this.FillCounter.Name = "FillCounter";
            this.FillCounter.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // LastRs
            // 
            this.LastRs.HeaderText = "Last Rs";
            this.LastRs.MinimumWidth = 7;
            this.LastRs.Name = "LastRs";
            this.LastRs.Width = 130;
            // 
            // LastKG
            // 
            this.LastKG.HeaderText = "Last KG";
            this.LastKG.MinimumWidth = 7;
            this.LastKG.Name = "LastKG";
            this.LastKG.Width = 130;
            // 
            // LastRate
            // 
            this.LastRate.HeaderText = "Last Rate";
            this.LastRate.Name = "LastRate";
            // 
            // DateTime
            // 
            this.DateTime.HeaderText = "Date Time";
            this.DateTime.MinimumWidth = 100;
            this.DateTime.Name = "DateTime";
            this.DateTime.Width = 200;
            // 
            // timer1
            // 
            this.timer1.Interval = 20;
            // 
            // wsmbsControl1
            // 
            this.wsmbsControl1.BaudRate = 9600;
            this.wsmbsControl1.Mode = WSMBS.Mode.RTU;
            this.wsmbsControl1.Parity = WSMBS.Parity.None;
            this.wsmbsControl1.PortName = "COM1";
            this.wsmbsControl1.ResponseTimeout = 1000;
            this.wsmbsControl1.StopBits = 1;
            // 
            // timer2
            // 
            this.timer2.Interval = 6000;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.SystemColors.Desktop;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Gainsboro;
            this.label10.Location = new System.Drawing.Point(1, -1);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(1353, 53);
            this.label10.TabIndex = 920;
            this.label10.Text = "Advance Electronics International";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FrmDataView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1028, 666);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.DGFM);
            this.MaximumSize = new System.Drawing.Size(1200, 700);
            this.MinimumSize = new System.Drawing.Size(1022, 700);
            this.Name = "FrmDataView";
            this.Text = "FrmDataView";
            this.Load += new System.EventHandler(this.FrmDataView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGFM)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView DGFM;
        private System.Windows.Forms.Timer timer1;
        private WSMBS.WSMBSControl wsmbsControl1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn chkside;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtNozle;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtCurrenRS;
        private System.Windows.Forms.DataGridViewTextBoxColumn CurrentKG;
        private System.Windows.Forms.DataGridViewTextBoxColumn CurrentRate;
        private System.Windows.Forms.DataGridViewTextBoxColumn NonRestableTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn RestableTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn FillCounter;
        private System.Windows.Forms.DataGridViewTextBoxColumn LastRs;
        private System.Windows.Forms.DataGridViewTextBoxColumn LastKG;
        private System.Windows.Forms.DataGridViewTextBoxColumn LastRate;
        private System.Windows.Forms.DataGridViewTextBoxColumn DateTime;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Label label10;
    }
}