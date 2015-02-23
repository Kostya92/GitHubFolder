namespace EnglishStudyHelper
{
    partial class FormCategories
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.gridCat = new System.Windows.Forms.DataGridView();
            this.dataSetCat = new System.Data.DataSet();
            ((System.ComponentModel.ISupportInitialize)(this.gridCat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetCat)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 213);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(284, 49);
            this.panel2.TabIndex = 1;
            // 
            // gridCat
            // 
            this.gridCat.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridCat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridCat.Location = new System.Drawing.Point(0, 0);
            this.gridCat.Name = "gridCat";
            this.gridCat.Size = new System.Drawing.Size(284, 213);
            this.gridCat.TabIndex = 2;
            // 
            // dataSetCat
            // 
            this.dataSetCat.DataSetName = "NewDataSet";
            // 
            // FormCategories
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.gridCat);
            this.Controls.Add(this.panel2);
            this.Name = "FormCategories";
            this.Text = "FormCategories";
            ((System.ComponentModel.ISupportInitialize)(this.gridCat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetCat)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView gridCat;
        private System.Data.DataSet dataSetCat;

    }
}