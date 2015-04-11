using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EnglishStudyHelper.DAL;
using EnglishStudyHelper.Entities;
//using System.Data.SQLite;

namespace EnglishStudyHelper
{
    public partial class FormWords : Form
    {
        FormEditWords frmEdit;
        DBManager db;
        Dictionary<String, String> catList;
        private readonly WordsRepo wordRepository = new WordsRepo();
       

        public FormWords()
        {

            InitializeComponent();
            db = new DBManager();
            catList = new Dictionary<String, String>();
        }

        public int GetIdCategory()
        {
            return this.cmbCategories.SelectedIndex;
        }

    
        public  void SetGridDatasourse(DataTable dt)
        {
            gridWords.DataSource = dt;
        }


        private void FormWords_Shown(object sender, EventArgs e)
        {

        }

        private void bntNew_Click(object sender, EventArgs e)
        {
            using (frmEdit = new FormEditWords(this))
            {
                frmEdit.ShowDialog();
            }
           
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FormWords_Load(object sender, EventArgs e)
        {
           
            DataTable dt = db.SelectCategoriesList();

            for (int i = 0; i <= dt.Rows.Count - 1; i++)
            {

                catList.Add(dt.Rows[i][0].ToString(), dt.Rows[i][1].ToString());
                
            }

            //gridWords.DataSource = db.SelectWords();
            checkFilterOff.Checked = true;
            cmbCategories.DataSource = catList.Values.ToArray();
            cmbCategories.SelectedIndex = -1;

           
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            
        }

        private void gridWords_DataSourceChanged(object sender, EventArgs e)
        {
          

        }

        private void cmbCategories_DropDownClosed(object sender, EventArgs e)
        {
            if (cmbCategories.SelectedIndex != -1)
            {
                selectWors(true);
                checkFilterOff.Checked = false;
            }
      
        }

        private void selectWors(bool isFilter)
        {
            if (isFilter)
            {
                
                string strKey = (cmbCategories.SelectedIndex + 1).ToString();
                gridWords.DataSource = db.SelectWordsForCat(strKey, true);

            }
            else
            {
                gridWords.DataSource = db.SelectWords();
            }
        }

        private void checkFilterOff_CheckStateChanged(object sender, EventArgs e)
        {

        }

        private void checkFilterOff_CheckedChanged(object sender, EventArgs e)
        {
            selectWors(!checkFilterOff.Checked);

            if (checkFilterOff.Checked)
                cmbCategories.SelectedIndex = -1;
            else 
                cmbCategories.SelectedIndex = 0;

        }
    }
}
