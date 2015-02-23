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
    public partial class FormSetting : Form
    {
        FormMain frmMain;

        public FormSetting()
        {
            InitializeComponent();
          
        }

        public FormSetting(FormMain frmMain)
        {
            InitializeComponent();
            this.frmMain = frmMain;
        }


        private void FormSetting_Load(object sender, EventArgs e)
        {
            DBManager db = new DBManager();
            DataTable dt = new DataTable();

            dt = db.SelectCategoriesSettings();
            
            lstCategories.Items.Clear();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                lstCategories.Items.Add(dt.Rows[i][1].ToString());

                if (dt.Rows[i][2].ToString() == "1")
                    lstCategories.SetItemChecked(i, true);
           }


           dt.Dispose();

            int timeInMinutes = frmMain.timeShowTest/60000;
            timerSetting.Text = timeInMinutes.ToString();
        }

        //сохранить настройки и закрыть форму
        private void button1_Click(object sender, EventArgs e)
        {
            DBManager db = new DBManager();
            int count = lstCategories.CheckedItems.Count;
          
       
            for (int i = 0; i < count; i++)
            {
                String strCatName = lstCategories.CheckedItems[i].ToString();
                db.UpdateCategory(strCatName, "1");
            }
            for (int i = 0; i < lstCategories.Items.Count; i++)
            {
                if (!lstCategories.CheckedItems.Contains(lstCategories.Items[i]))
                {
                    String strCatName = lstCategories.Items[i].ToString();
                    db.UpdateCategory(strCatName, "0");
                }
            }

            if (timerSetting.Text != "")
                frmMain.timeShowTest = Convert.ToInt32(timerSetting.Text) * 60000; 

            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
