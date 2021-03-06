﻿namespace WindowsFormsApplication1
{
    partial class FormAbfahrtstafel
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
            this.cobStation = new System.Windows.Forms.ComboBox();
            this.lblStart = new System.Windows.Forms.Label();
            this.livAbfahrtstafel = new System.Windows.Forms.ListView();
            this.colName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colOperator = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colDeparture = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colTo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pibMapStation = new System.Windows.Forms.PictureBox();
            this.btnClose = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pibMapStation)).BeginInit();
            this.SuspendLayout();
            // 
            // cobStation
            // 
            this.cobStation.FormattingEnabled = true;
            this.cobStation.Items.AddRange(new object[] {
            "(Geben sie eine Suche ein)"});
            this.cobStation.Location = new System.Drawing.Point(131, 25);
            this.cobStation.Name = "cobStation";
            this.cobStation.Size = new System.Drawing.Size(214, 21);
            this.cobStation.TabIndex = 0;
            this.cobStation.SelectedIndexChanged += new System.EventHandler(this.cobStation_SelectedIndexChanged);
            this.cobStation.TextUpdate += new System.EventHandler(this.cobStation_TextUpdate);
            this.cobStation.Enter += new System.EventHandler(this.cobStation_Enter);
            // 
            // lblStart
            // 
            this.lblStart.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblStart.Location = new System.Drawing.Point(25, 25);
            this.lblStart.Name = "lblStart";
            this.lblStart.Size = new System.Drawing.Size(100, 20);
            this.lblStart.TabIndex = 4;
            this.lblStart.Text = "Von Station";
            this.lblStart.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // livAbfahrtstafel
            // 
            this.livAbfahrtstafel.AutoArrange = false;
            this.livAbfahrtstafel.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colName,
            this.colOperator,
            this.colDeparture,
            this.colTo});
            this.livAbfahrtstafel.Location = new System.Drawing.Point(25, 67);
            this.livAbfahrtstafel.Name = "livAbfahrtstafel";
            this.livAbfahrtstafel.Size = new System.Drawing.Size(549, 178);
            this.livAbfahrtstafel.TabIndex = 5;
            this.livAbfahrtstafel.UseCompatibleStateImageBehavior = false;
            this.livAbfahrtstafel.View = System.Windows.Forms.View.Details;
            // 
            // colName
            // 
            this.colName.Text = "Linie";
            this.colName.Width = 50;
            // 
            // colOperator
            // 
            this.colOperator.Text = "Gesellschaft";
            this.colOperator.Width = 70;
            // 
            // colDeparture
            // 
            this.colDeparture.Text = "Abfahrt Zeit";
            this.colDeparture.Width = 67;
            // 
            // colTo
            // 
            this.colTo.Text = "Bis Station";
            this.colTo.Width = 358;
            // 
            // pibMapStation
            // 
            this.pibMapStation.BackgroundImage = global::WindowsFormsApplication1.Properties.Resources.maps_64dp_1_;
            this.pibMapStation.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pibMapStation.Location = new System.Drawing.Point(351, 20);
            this.pibMapStation.Name = "pibMapStation";
            this.pibMapStation.Size = new System.Drawing.Size(32, 32);
            this.pibMapStation.TabIndex = 20;
            this.pibMapStation.TabStop = false;
            this.pibMapStation.Click += new System.EventHandler(this.pibMapStation_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(499, 270);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 21;
            this.btnClose.Text = "Schliessen";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // FormAbfahrtstafel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(610, 305);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.pibMapStation);
            this.Controls.Add(this.livAbfahrtstafel);
            this.Controls.Add(this.lblStart);
            this.Controls.Add(this.cobStation);
            this.Name = "FormAbfahrtstafel";
            this.Text = "Abfahrtstafel";
            ((System.ComponentModel.ISupportInitialize)(this.pibMapStation)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cobStation;
        private System.Windows.Forms.Label lblStart;
        private System.Windows.Forms.ListView livAbfahrtstafel;
        private System.Windows.Forms.ColumnHeader colName;
        private System.Windows.Forms.ColumnHeader colOperator;
        private System.Windows.Forms.ColumnHeader colDeparture;
        private System.Windows.Forms.ColumnHeader colTo;
        private System.Windows.Forms.PictureBox pibMapStation;
        private System.Windows.Forms.Button btnClose;
    }
}