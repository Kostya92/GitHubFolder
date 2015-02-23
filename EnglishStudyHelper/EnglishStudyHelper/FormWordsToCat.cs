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
    public partial class FormWordsToCat : Form
    {
        FormCategory frmCategor;

        public FormWordsToCat()
        {
            InitializeComponent();
        }

        public FormWordsToCat(FormCategory frm)
        {
            InitializeComponent();
            this.frmCategor = frm;
        }


        private void FormWordsToCat_Load(object sender, EventArgs e)
        {

            FormWords_SelectWords();   
         
        }

        private void FormWords_SelectWords()
        {

            DBManager db = new DBManager();
            string idCtg = frmCategor.GetIdCat();


            Text = "Слова данной категории";
            gridWords.DataSource = db.SelectWordsForCat(idCtg, true);
           
        }
     
    }
}
