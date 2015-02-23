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

    public partial class EditCategory : Form
    {
        FormCategory frmCateg;
        ErrorProvider errorTextBoxProvider;

        public EditCategory()
        {
            InitializeComponent();
            errorTextBoxProvider = new ErrorProvider();
        }

        public EditCategory(FormCategory frmCateg)
        {
            InitializeComponent();
            this.frmCateg = frmCateg;
            errorTextBoxProvider = new ErrorProvider();
        }

      
    

        private void button1_Click(object sender, EventArgs e)
        {
            DBManager db = new DBManager();
            db.InsertCategory(textCategory.Text);
            frmCateg.SetGridDatasourse(db.SelectCategories());
        }

        private void textCategory_Validating(object sender, CancelEventArgs e)
        {
            string errorMessage;
            if (!Validator.ValidText(((TextBox)sender).Text, Validator.Alphabets.En, out errorMessage))
            {
                e.Cancel = true;
                ((TextBox)sender).Select(0, ((TextBox)sender).Text.Length);
                errorTextBoxProvider.SetError((TextBox)sender, errorMessage);

            }
        }

        private void textCategory_Validated(object sender, EventArgs e)
        {
            errorTextBoxProvider.SetError((TextBox)sender, String.Empty);
        }
    }
}
