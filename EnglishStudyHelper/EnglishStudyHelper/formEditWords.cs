using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EnglishStudyHelper
{
    public partial class FormEditWords : Form
    {
        FormWords frmWords;
        ErrorProvider errorTextBoxProvider;
       
        public FormEditWords()
        {
            InitializeComponent();
            errorTextBoxProvider = new ErrorProvider();
        }

        public FormEditWords(FormWords frm)
        {
            InitializeComponent();
            this.frmWords = frm;
            errorTextBoxProvider = new ErrorProvider();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAddWord_Click(object sender, EventArgs e)
        {
            DBManager db = new DBManager();
            
            if (textWord.Text != "" && textTranslate.Text != "")
            {
                int id = frmWords.GetIdCategory();

                if (id == -1)
                {
                    db.InsertWordTrans(textWord.Text, textTranslate.Text);
                    frmWords.SetGridDatasourse(db.SelectWords());
                }
                else
                {
                    string idCat = (id + 1).ToString();
                    db.InsertWordTrans(textWord.Text, textTranslate.Text, idCat);
                    frmWords.SetGridDatasourse(db.SelectWordsForCat(idCat, true));
                }
                
            }
            
        }

        private void textWord_Validating(object sender, CancelEventArgs e)
        {
            textBox_Validating(sender, e, Validator.Alphabets.En);
        }

      

        private void textWord_Validated(object sender, EventArgs e)
        {
            textBox_Validated(sender, e);
        }

        private void textTranslate_Validating(object sender, CancelEventArgs e)
        {
            textBox_Validating(sender, e, Validator.Alphabets.Ru);
            
        }

        private void textTranslate_Validated(object sender, EventArgs e)
        {
            textBox_Validated(sender, e);
        }

        //проверка ввода в текстовое поле
        private void textBox_Validating(object sender, CancelEventArgs e, Validator.Alphabets alphabet)
        {
            string errorMessage;
            if (!Validator.ValidText(((TextBox)sender).Text, alphabet, out errorMessage))
            {
                e.Cancel = true;
                ((TextBox)sender).Select(0, ((TextBox)sender).Text.Length);
                errorTextBoxProvider.SetError((TextBox)sender, errorMessage);
                
            }
        }

        //проверка прошла успешно
        private void textBox_Validated(object sender, EventArgs e)
        {
            errorTextBoxProvider.SetError((TextBox)sender, String.Empty);
        }




    }
}
