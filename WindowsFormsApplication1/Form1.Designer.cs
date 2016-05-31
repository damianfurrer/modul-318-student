namespace WindowsFormsApplication1
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
            this.button1 = new System.Windows.Forms.Button();
            this.lblStart = new System.Windows.Forms.Label();
            this.lblEnd = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.cobStart = new System.Windows.Forms.ComboBox();
            this.cobEnd = new System.Windows.Forms.ComboBox();
            this.lblConnections = new System.Windows.Forms.Label();
            this.chbCoordinates = new System.Windows.Forms.CheckBox();
            this.livConnections = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnAbfahrtstafelStart = new System.Windows.Forms.Button();
            this.pibMapStart = new System.Windows.Forms.PictureBox();
            this.pibMapEnd = new System.Windows.Forms.PictureBox();
            this.btnAbfahrtstafelEnd = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pibMapStart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pibMapEnd)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.AutoSize = true;
            this.button1.Location = new System.Drawing.Point(409, 128);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(123, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Verbindungen Suchen";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lblStart
            // 
            this.lblStart.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblStart.Location = new System.Drawing.Point(27, 20);
            this.lblStart.Name = "lblStart";
            this.lblStart.Size = new System.Drawing.Size(67, 20);
            this.lblStart.TabIndex = 3;
            this.lblStart.Text = "Start Station";
            this.lblStart.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblEnd
            // 
            this.lblEnd.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblEnd.Location = new System.Drawing.Point(27, 51);
            this.lblEnd.Name = "lblEnd";
            this.lblEnd.Size = new System.Drawing.Size(67, 20);
            this.lblEnd.TabIndex = 4;
            this.lblEnd.Text = "End Station";
            this.lblEnd.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label2.Location = new System.Drawing.Point(27, 129);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 20);
            this.label2.TabIndex = 9;
            this.label2.Text = "Start Zeit";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label2.Visible = false;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(101, 130);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(143, 20);
            this.textBox2.TabIndex = 8;
            this.textBox2.Visible = false;
            // 
            // cobStart
            // 
            this.cobStart.FormattingEnabled = true;
            this.cobStart.Items.AddRange(new object[] {
            "(Geben sie eine Suche ein)"});
            this.cobStart.Location = new System.Drawing.Point(101, 20);
            this.cobStart.Name = "cobStart";
            this.cobStart.Size = new System.Drawing.Size(205, 21);
            this.cobStart.TabIndex = 10;
            this.cobStart.SelectedIndexChanged += new System.EventHandler(this.cobStart_SelectedIndexChanged);
            this.cobStart.TextUpdate += new System.EventHandler(this.cobStart_TextUpdate);
            this.cobStart.Enter += new System.EventHandler(this.cobStart_Enter);
            // 
            // cobEnd
            // 
            this.cobEnd.FormattingEnabled = true;
            this.cobEnd.Items.AddRange(new object[] {
            "(Geben sie eine Suche ein)"});
            this.cobEnd.Location = new System.Drawing.Point(101, 50);
            this.cobEnd.Name = "cobEnd";
            this.cobEnd.Size = new System.Drawing.Size(205, 21);
            this.cobEnd.TabIndex = 11;
            this.cobEnd.SelectedIndexChanged += new System.EventHandler(this.cobEnd_SelectedIndexChanged);
            this.cobEnd.TextUpdate += new System.EventHandler(this.cobEnd_TextUpdate);
            this.cobEnd.Enter += new System.EventHandler(this.cobEnd_Enter);
            // 
            // lblConnections
            // 
            this.lblConnections.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblConnections.Location = new System.Drawing.Point(24, 165);
            this.lblConnections.Name = "lblConnections";
            this.lblConnections.Size = new System.Drawing.Size(557, 20);
            this.lblConnections.TabIndex = 12;
            this.lblConnections.Text = "Verbindungen:";
            this.lblConnections.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // chbCoordinates
            // 
            this.chbCoordinates.Location = new System.Drawing.Point(24, 80);
            this.chbCoordinates.Name = "chbCoordinates";
            this.chbCoordinates.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chbCoordinates.Size = new System.Drawing.Size(133, 24);
            this.chbCoordinates.TabIndex = 16;
            this.chbCoordinates.Text = "Koordinaten beachten";
            this.chbCoordinates.UseVisualStyleBackColor = true;
            this.chbCoordinates.Visible = false;
            // 
            // livConnections
            // 
            this.livConnections.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader3,
            this.columnHeader2,
            this.columnHeader4,
            this.columnHeader5});
            this.livConnections.Location = new System.Drawing.Point(24, 188);
            this.livConnections.Name = "livConnections";
            this.livConnections.Size = new System.Drawing.Size(557, 180);
            this.livConnections.TabIndex = 17;
            this.livConnections.TileSize = new System.Drawing.Size(168, 30);
            this.livConnections.UseCompatibleStateImageBehavior = false;
            this.livConnections.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Von";
            this.columnHeader1.Width = 200;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Abfahrt";
            this.columnHeader2.Width = 46;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Bis";
            this.columnHeader3.Width = 200;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Ankunft";
            this.columnHeader4.Width = 49;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Dauer";
            this.columnHeader5.Width = 401;
            // 
            // btnAbfahrtstafelStart
            // 
            this.btnAbfahrtstafelStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAbfahrtstafelStart.Location = new System.Drawing.Point(312, 16);
            this.btnAbfahrtstafelStart.Name = "btnAbfahrtstafelStart";
            this.btnAbfahrtstafelStart.Size = new System.Drawing.Size(81, 30);
            this.btnAbfahrtstafelStart.TabIndex = 18;
            this.btnAbfahrtstafelStart.Text = "Abfahrtstafel";
            this.btnAbfahrtstafelStart.UseVisualStyleBackColor = true;
            this.btnAbfahrtstafelStart.Click += new System.EventHandler(this.btnAbfahrtstafelStart_Click);
            // 
            // pibMapStart
            // 
            this.pibMapStart.BackgroundImage = global::WindowsFormsApplication1.Properties.Resources.maps_64dp_1_;
            this.pibMapStart.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pibMapStart.Location = new System.Drawing.Point(395, 16);
            this.pibMapStart.Name = "pibMapStart";
            this.pibMapStart.Size = new System.Drawing.Size(32, 32);
            this.pibMapStart.TabIndex = 19;
            this.pibMapStart.TabStop = false;
            this.pibMapStart.Click += new System.EventHandler(this.pibMapStart_Click);
            // 
            // pibMapEnd
            // 
            this.pibMapEnd.BackgroundImage = global::WindowsFormsApplication1.Properties.Resources.maps_64dp_1_;
            this.pibMapEnd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pibMapEnd.Location = new System.Drawing.Point(395, 46);
            this.pibMapEnd.Name = "pibMapEnd";
            this.pibMapEnd.Size = new System.Drawing.Size(32, 32);
            this.pibMapEnd.TabIndex = 20;
            this.pibMapEnd.TabStop = false;
            this.pibMapEnd.Click += new System.EventHandler(this.pibMapEnd_Click);
            // 
            // btnAbfahrtstafelEnd
            // 
            this.btnAbfahrtstafelEnd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAbfahrtstafelEnd.Location = new System.Drawing.Point(312, 48);
            this.btnAbfahrtstafelEnd.Name = "btnAbfahrtstafelEnd";
            this.btnAbfahrtstafelEnd.Size = new System.Drawing.Size(81, 30);
            this.btnAbfahrtstafelEnd.TabIndex = 21;
            this.btnAbfahrtstafelEnd.Text = "Abfahrtstafel";
            this.btnAbfahrtstafelEnd.UseVisualStyleBackColor = true;
            this.btnAbfahrtstafelEnd.Click += new System.EventHandler(this.btnAbfahrtstafelEnd_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(609, 391);
            this.Controls.Add(this.btnAbfahrtstafelEnd);
            this.Controls.Add(this.pibMapEnd);
            this.Controls.Add(this.pibMapStart);
            this.Controls.Add(this.btnAbfahrtstafelStart);
            this.Controls.Add(this.livConnections);
            this.Controls.Add(this.chbCoordinates);
            this.Controls.Add(this.lblConnections);
            this.Controls.Add(this.cobEnd);
            this.Controls.Add(this.cobStart);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.lblEnd);
            this.Controls.Add(this.lblStart);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pibMapStart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pibMapEnd)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lblStart;
        private System.Windows.Forms.Label lblEnd;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.ComboBox cobStart;
        private System.Windows.Forms.ComboBox cobEnd;
        private System.Windows.Forms.Label lblConnections;
        private System.Windows.Forms.CheckBox chbCoordinates;
        private System.Windows.Forms.ListView livConnections;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.Button btnAbfahrtstafelStart;
        private System.Windows.Forms.PictureBox pibMapStart;
        private System.Windows.Forms.PictureBox pibMapEnd;
        private System.Windows.Forms.Button btnAbfahrtstafelEnd;
    }
}

