using System;

namespace Supermarkets.ClientWF
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
            this.importXML = new System.Windows.Forms.Button();
            this.exportXML = new System.Windows.Forms.Button();
            this.exportPDF = new System.Windows.Forms.Button();
            this.outputTextBox = new System.Windows.Forms.TextBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.startDatePicker = new System.Windows.Forms.DateTimePicker();
            this.endDatePicker = new System.Windows.Forms.DateTimePicker();
            this.exportJSONSales = new System.Windows.Forms.Button();
            this.populateMySqlDb = new System.Windows.Forms.Button();
            this.exportExcel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // importXML
            // 
            this.importXML.Location = new System.Drawing.Point(186, 41);
            this.importXML.Name = "importXML";
            this.importXML.Size = new System.Drawing.Size(150, 52);
            this.importXML.TabIndex = 0;
            this.importXML.Text = "Import XML Report";
            this.importXML.UseVisualStyleBackColor = true;
            this.importXML.Click += new System.EventHandler(this.importXML_Click);
            // 
            // exportXML
            // 
            this.exportXML.Location = new System.Drawing.Point(12, 248);
            this.exportXML.Name = "exportXML";
            this.exportXML.Size = new System.Drawing.Size(101, 44);
            this.exportXML.TabIndex = 1;
            this.exportXML.Text = "Export XML Sales";
            this.exportXML.UseVisualStyleBackColor = true;
            this.exportXML.Click += new System.EventHandler(this.exportXML_Click);
            // 
            // exportPDF
            // 
            this.exportPDF.Enabled = false;
            this.exportPDF.Location = new System.Drawing.Point(12, 162);
            this.exportPDF.Name = "exportPDF";
            this.exportPDF.Size = new System.Drawing.Size(324, 47);
            this.exportPDF.TabIndex = 2;
            this.exportPDF.Text = "Generate PDF Sale Report";
            this.exportPDF.UseVisualStyleBackColor = true;
            this.exportPDF.Click += new System.EventHandler(this.exportPDF_Click);
            // 
            // outputTextBox
            // 
            this.outputTextBox.BackColor = System.Drawing.Color.Black;
            this.outputTextBox.ForeColor = System.Drawing.Color.Chartreuse;
            this.outputTextBox.Location = new System.Drawing.Point(375, 41);
            this.outputTextBox.Multiline = true;
            this.outputTextBox.Name = "outputTextBox";
            this.outputTextBox.Size = new System.Drawing.Size(583, 289);
            this.outputTextBox.TabIndex = 3;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(375, 360);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(583, 23);
            this.progressBar1.TabIndex = 4;
            // 
            // startDatePicker
            // 
            this.startDatePicker.Location = new System.Drawing.Point(12, 134);
            this.startDatePicker.Name = "startDatePicker";
            this.startDatePicker.Size = new System.Drawing.Size(159, 22);
            this.startDatePicker.TabIndex = 5;
            this.startDatePicker.ValueChanged += new System.EventHandler(this.startDatePicker_ValueChanged);
            // 
            // endDatePicker
            // 
            this.endDatePicker.Location = new System.Drawing.Point(177, 134);
            this.endDatePicker.Name = "endDatePicker";
            this.endDatePicker.Size = new System.Drawing.Size(159, 22);
            this.endDatePicker.TabIndex = 6;
            this.endDatePicker.ValueChanged += new System.EventHandler(this.endDatePicker_ValueChanged);
            // 
            // exportJSONSales
            // 
            this.exportJSONSales.Location = new System.Drawing.Point(123, 248);
            this.exportJSONSales.Name = "exportJSONSales";
            this.exportJSONSales.Size = new System.Drawing.Size(101, 44);
            this.exportJSONSales.TabIndex = 7;
            this.exportJSONSales.Text = "Export JSON Sales";
            this.exportJSONSales.UseVisualStyleBackColor = true;
            this.exportJSONSales.Click += new System.EventHandler(this.exportJSONSales_Click);
            // 
            // populateMySqlDb
            // 
            this.populateMySqlDb.Location = new System.Drawing.Point(12, 41);
            this.populateMySqlDb.Name = "populateMySqlDb";
            this.populateMySqlDb.Size = new System.Drawing.Size(159, 52);
            this.populateMySqlDb.TabIndex = 8;
            this.populateMySqlDb.Text = "Populate MySQL DB";
            this.populateMySqlDb.UseVisualStyleBackColor = true;
            this.populateMySqlDb.Click += new System.EventHandler(this.populateMySqlDb_Click);
            // 
            // exportExcel
            // 
            this.exportExcel.Location = new System.Drawing.Point(235, 248);
            this.exportExcel.Name = "exportExcel";
            this.exportExcel.Size = new System.Drawing.Size(101, 44);
            this.exportExcel.TabIndex = 9;
            this.exportExcel.Text = "Export Excel Report";
            this.exportExcel.UseVisualStyleBackColor = true;
            this.exportExcel.Click += new System.EventHandler(this.exportExcel_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(994, 395);
            this.Controls.Add(this.exportExcel);
            this.Controls.Add(this.populateMySqlDb);
            this.Controls.Add(this.exportJSONSales);
            this.Controls.Add(this.endDatePicker);
            this.Controls.Add(this.startDatePicker);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.outputTextBox);
            this.Controls.Add(this.exportPDF);
            this.Controls.Add(this.exportXML);
            this.Controls.Add(this.importXML);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button importXML;
        private System.Windows.Forms.Button exportXML;
        private System.Windows.Forms.Button exportPDF;
        private System.Windows.Forms.TextBox outputTextBox;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.DateTimePicker startDatePicker;
        private System.Windows.Forms.DateTimePicker endDatePicker;
        private System.Windows.Forms.Button exportJSONSales;
        private System.Windows.Forms.Button populateMySqlDb;
        private System.Windows.Forms.Button exportExcel;
    }
}

