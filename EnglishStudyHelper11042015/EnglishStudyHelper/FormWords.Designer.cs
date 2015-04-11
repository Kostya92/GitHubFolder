namespace EnglishStudyHelper
{
    partial class FormWords
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.checkFilterOff = new System.Windows.Forms.CheckBox();
            this.cmbCategories = new System.Windows.Forms.ComboBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.labelWords = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.bntNew = new System.Windows.Forms.Button();
            this.gridWords = new System.Windows.Forms.DataGridView();
            this.bindingSourceWords = new System.Windows.Forms.BindingSource(this.components);
            this.ColumnIndex = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.wordNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.translateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.categoryNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridWords)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceWords)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.checkFilterOff);
            this.panel1.Controls.Add(this.cmbCategories);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(436, 43);
            this.panel1.TabIndex = 0;
            // 
            // checkFilterOff
            // 
            this.checkFilterOff.AutoSize = true;
            this.checkFilterOff.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.checkFilterOff.Location = new System.Drawing.Point(307, 11);
            this.checkFilterOff.Name = "checkFilterOff";
            this.checkFilterOff.Size = new System.Drawing.Size(122, 21);
            this.checkFilterOff.TabIndex = 1;
            this.checkFilterOff.Text = "Все категории";
            this.checkFilterOff.UseVisualStyleBackColor = true;
            this.checkFilterOff.CheckedChanged += new System.EventHandler(this.checkFilterOff_CheckedChanged);
            this.checkFilterOff.CheckStateChanged += new System.EventHandler(this.checkFilterOff_CheckStateChanged);
            // 
            // cmbCategories
            // 
            this.cmbCategories.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCategories.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cmbCategories.FormattingEnabled = true;
            this.cmbCategories.Location = new System.Drawing.Point(3, 11);
            this.cmbCategories.Name = "cmbCategories";
            this.cmbCategories.Size = new System.Drawing.Size(125, 24);
            this.cmbCategories.TabIndex = 0;
            this.cmbCategories.DropDownClosed += new System.EventHandler(this.cmbCategories_DropDownClosed);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.labelWords);
            this.panel2.Controls.Add(this.btnClose);
            this.panel2.Controls.Add(this.bntNew);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 312);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(436, 69);
            this.panel2.TabIndex = 1;
            // 
            // labelWords
            // 
            this.labelWords.Location = new System.Drawing.Point(140, 7);
            this.labelWords.Name = "labelWords";
            this.labelWords.Size = new System.Drawing.Size(170, 53);
            this.labelWords.TabIndex = 6;
            this.labelWords.Text = "Убрать флажок - посмотреть слова из конкретной категорий\r\n\r\n";
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(344, 6);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 37);
            this.btnClose.TabIndex = 5;
            this.btnClose.Text = "Закрыть окно";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // bntNew
            // 
            this.bntNew.Location = new System.Drawing.Point(3, 6);
            this.bntNew.Name = "bntNew";
            this.bntNew.Size = new System.Drawing.Size(89, 37);
            this.bntNew.TabIndex = 3;
            this.bntNew.Text = "Добавить слово";
            this.bntNew.UseVisualStyleBackColor = true;
            this.bntNew.Click += new System.EventHandler(this.bntNew_Click);
            // 
            // gridWords
            // 
            this.gridWords.AutoGenerateColumns = false;
            this.gridWords.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridWords.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridWords.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnIndex,
            this.wordNameDataGridViewTextBoxColumn,
            this.translateDataGridViewTextBoxColumn,
            this.categoryNameDataGridViewTextBoxColumn});
            this.gridWords.DataSource = this.bindingSourceWords;
            this.gridWords.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridWords.Location = new System.Drawing.Point(0, 43);
            this.gridWords.Name = "gridWords";
            this.gridWords.ReadOnly = true;
            this.gridWords.Size = new System.Drawing.Size(436, 269);
            this.gridWords.TabIndex = 2;
            this.gridWords.DataSourceChanged += new System.EventHandler(this.gridWords_DataSourceChanged);
            // 
            // bindingSourceWords
            // 
            this.bindingSourceWords.DataSource = typeof(EnglishStudyHelper.Entities.Word);
            // 
            // ColumnIndex
            // 
            this.ColumnIndex.HeaderText = "№";
            this.ColumnIndex.Name = "ColumnIndex";
            this.ColumnIndex.ReadOnly = true;
            // 
            // wordNameDataGridViewTextBoxColumn
            // 
            this.wordNameDataGridViewTextBoxColumn.DataPropertyName = "WordName";
            this.wordNameDataGridViewTextBoxColumn.HeaderText = "Слово";
            this.wordNameDataGridViewTextBoxColumn.Name = "wordNameDataGridViewTextBoxColumn";
            this.wordNameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // translateDataGridViewTextBoxColumn
            // 
            this.translateDataGridViewTextBoxColumn.DataPropertyName = "Translate";
            this.translateDataGridViewTextBoxColumn.HeaderText = "Перевод";
            this.translateDataGridViewTextBoxColumn.Name = "translateDataGridViewTextBoxColumn";
            this.translateDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // categoryNameDataGridViewTextBoxColumn
            // 
            this.categoryNameDataGridViewTextBoxColumn.DataPropertyName = "CategoryName";
            this.categoryNameDataGridViewTextBoxColumn.HeaderText = "Категория";
            this.categoryNameDataGridViewTextBoxColumn.Name = "categoryNameDataGridViewTextBoxColumn";
            this.categoryNameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // FormWords
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(436, 381);
            this.Controls.Add(this.gridWords);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormWords";
            this.Text = "Форма слов";
            this.Load += new System.EventHandler(this.FormWords_Load);
            this.Shown += new System.EventHandler(this.FormWords_Shown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridWords)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceWords)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView gridWords;
        private System.Windows.Forms.Button bntNew;
        private System.Windows.Forms.ComboBox cmbCategories;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.CheckBox checkFilterOff;
        private System.Windows.Forms.Label labelWords;
        private System.Windows.Forms.BindingSource bindingSourceWords;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnIndex;
        private System.Windows.Forms.DataGridViewTextBoxColumn wordNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn translateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn categoryNameDataGridViewTextBoxColumn;

    }
}