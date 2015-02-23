namespace EnglishStudyHelper
{
    partial class FormEditWords
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.textTranslate = new System.Windows.Forms.TextBox();
            this.textWord = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.labelWord = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnAddWord = new System.Windows.Forms.Button();
            this.labelWordExp = new System.Windows.Forms.Label();
            this.labelTransExp = new System.Windows.Forms.Label();
            this.labelExp = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.labelExp);
            this.panel1.Controls.Add(this.labelTransExp);
            this.panel1.Controls.Add(this.labelWordExp);
            this.panel1.Controls.Add(this.textTranslate);
            this.panel1.Controls.Add(this.textWord);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.labelWord);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(326, 324);
            this.panel1.TabIndex = 0;
            // 
            // textTranslate
            // 
            this.textTranslate.Location = new System.Drawing.Point(115, 104);
            this.textTranslate.Name = "textTranslate";
            this.textTranslate.Size = new System.Drawing.Size(100, 20);
            this.textTranslate.TabIndex = 7;
            this.textTranslate.Validating += new System.ComponentModel.CancelEventHandler(this.textTranslate_Validating);
            this.textTranslate.Validated += new System.EventHandler(this.textTranslate_Validated);
            // 
            // textWord
            // 
            this.textWord.Location = new System.Drawing.Point(115, 38);
            this.textWord.Name = "textWord";
            this.textWord.Size = new System.Drawing.Size(100, 20);
            this.textWord.TabIndex = 6;
            this.textWord.Validating += new System.ComponentModel.CancelEventHandler(this.textWord_Validating);
            this.textWord.Validated += new System.EventHandler(this.textWord_Validated);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 107);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Перевод слова";
            // 
            // labelWord
            // 
            this.labelWord.AutoSize = true;
            this.labelWord.Location = new System.Drawing.Point(25, 41);
            this.labelWord.Name = "labelWord";
            this.labelWord.Size = new System.Drawing.Size(38, 13);
            this.labelWord.TabIndex = 4;
            this.labelWord.Text = "Слово";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnAddWord);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 246);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(326, 78);
            this.panel2.TabIndex = 1;
            // 
            // btnAddWord
            // 
            this.btnAddWord.Location = new System.Drawing.Point(28, 12);
            this.btnAddWord.Name = "btnAddWord";
            this.btnAddWord.Size = new System.Drawing.Size(261, 44);
            this.btnAddWord.TabIndex = 0;
            this.btnAddWord.Text = "Добавить слово";
            this.btnAddWord.UseVisualStyleBackColor = true;
            this.btnAddWord.Click += new System.EventHandler(this.btnAddWord_Click);
            // 
            // labelWordExp
            // 
            this.labelWordExp.Location = new System.Drawing.Point(112, 9);
            this.labelWordExp.Name = "labelWordExp";
            this.labelWordExp.Size = new System.Drawing.Size(145, 26);
            this.labelWordExp.TabIndex = 9;
            this.labelWordExp.Text = "Введите слово на английском языке";
            // 
            // labelTransExp
            // 
            this.labelTransExp.Location = new System.Drawing.Point(112, 71);
            this.labelTransExp.Name = "labelTransExp";
            this.labelTransExp.Size = new System.Drawing.Size(166, 30);
            this.labelTransExp.TabIndex = 10;
            this.labelTransExp.Text = "Введите перевод слова(только русский язык)";
            // 
            // labelExp
            // 
            this.labelExp.Location = new System.Drawing.Point(57, 155);
            this.labelExp.Name = "labelExp";
            this.labelExp.Size = new System.Drawing.Size(211, 61);
            this.labelExp.TabIndex = 11;
            this.labelExp.Text = "Слово добавится в ту категорию,которую Вы  выбрали в предыдущем окне";
            this.labelExp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FormEditWords
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(326, 324);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormEditWords";
            this.Text = "Добавить слово";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox textTranslate;
        private System.Windows.Forms.TextBox textWord;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelWord;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnAddWord;
        private System.Windows.Forms.Label labelTransExp;
        private System.Windows.Forms.Label labelWordExp;
        private System.Windows.Forms.Label labelExp;
    }
}