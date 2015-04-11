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
    public partial class FormMain : Form
    {
        public FormWords formWords;
        public FormCategory formCat;
        public FormSetting formSet;
        public int timeShowTest = 60000;
        private int trueAnswerPos;
        private RadioButton[] arrRadioBtn;
        private DBManager dbMan;
        private InactiveTimeCalculator inactiveTimeCalc;
        private const int TIME_FOR_SLEEP = 10; //  константа задающая время простоя в минутах
      

        


        public FormMain()
        {
            InitializeComponent();
            dbMan = new DBManager();
            inactiveTimeCalc = new InactiveTimeCalculator();

            if (!System.IO.File.Exists("helper.db"))
            {
              
                dbMan.InitDataBase();
            }


        } 
      
           
        private void FormMain_Load(object sender, EventArgs e)
        {
            HideMainWindow();
            arrRadioBtn = new RadioButton[5];
      
            arrRadioBtn[0] = rbtnAnswer1;
            arrRadioBtn[1] = rbtnAnswer2;
            arrRadioBtn[2] = rbtnAnswer3;
            arrRadioBtn[3] = rbtnAnswer4;
            arrRadioBtn[4] = rbtnAnswer5;

            timer1.Interval = timeShowTest;
            timer1.Start();
            timerInactivity.Start();
        }

    

        private void FormMain_Resize(object sender, EventArgs e)
        {

            HideMainWindow();

        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ShowMainWindow();
        }

        private void notifyIcon1_MouseClick(object sender, MouseEventArgs e)
        {}

        private void wordsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (formWords = new FormWords())
            {
                formWords.ShowDialog();
            }
            
        }

     
        private void categoriesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (formCat = new FormCategory())
            {
                formCat.ShowDialog();
            }
            
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void HideMainWindow()
        {
            if (WindowState == FormWindowState.Minimized)
                Hide();
        }

        private void ShowMainWindow()
        {
            if (SetRandomWord())
            {
                Show();
                WindowState = FormWindowState.Normal;
            }
            else MessageBox.Show("Вы должны выбрать в пункте 'настройки',категории с какими Вы хотите работать");
            
        }

        private void TimerEventProcessor(Object myObject,
                                           EventArgs myEventArgs)
        {
            ShowMainWindow();
        }

        //заполняет елементы главной формы случайными словом и переводами к нему
        //возваращает false, если выборка пуста и заполнять нечем (в этом случае нам не надо выводить тест на экран, а предложить пользователю
        //зайти в настройка и выбрать категории для тестирования)
      

        private bool SetRandomWord()
        {
            
            DataTable dt =  dbMan.SelectWordsForTest();
            //Random rnd;

            if (dt.Rows.Count != 0)
            {
                int[] arrRand = new int[5];
                bool[] arrFlag = new bool[5];

                int highRand = dt.Rows.Count;
                int seedRand;

                var rnd = new Random();
                seedRand = rnd.Next(1, int.MaxValue);
                rnd = new Random(seedRand);
                int rnum = 0;
               
                //массив случайных чисел - используются в качестве индексов строк со словами-переводами 
                for (int i = 0; i < 5; i++)
                {
                    rnum = rnd.Next(0, highRand);

                    for (int j = 0; j < 5; j++)
                    {
                        if (arrRand[j] == rnum)
                            break;
                        else
                            arrRand[i] = rnum;
                    }
                }


                //случайная позиция радиокнопки для правильного ответа
                //чтобы он не был всегда первым
                rnd = new Random();
                SetTrueAnswerPos(rnd.Next(0, 4));


                RadioButton temp = arrRadioBtn[trueAnswerPos];
                arrRadioBtn[trueAnswerPos] = arrRadioBtn[0];
                arrRadioBtn[0] = temp;

                lblCategory.Text = dt.Rows[arrRand[0]]["category"].ToString();
                lblWord.Text = dt.Rows[arrRand[0]]["wordEN"].ToString();



                for (int i = 0; i < arrRadioBtn.Length; i++)
                {
                    arrRadioBtn[i].Text = dt.Rows[arrRand[i]]["wordRU"].ToString();
                }

                temp = arrRadioBtn[trueAnswerPos];
                arrRadioBtn[trueAnswerPos] = arrRadioBtn[0];
                arrRadioBtn[0] = temp;
                return true;
            }
            return false;
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ShowMainWindow();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAnswer_Click(object sender, EventArgs e)
        {
           
            int answer = 0;

            for (int i = 0; i < 5; i++)
            {
                if (arrRadioBtn[i].Checked)
                {
                    if (i == trueAnswerPos)
                    {
                        answer = 1;
                        MessageBox.Show("Правильно");
                    }
                                            
                }
            }

            WindowState = FormWindowState.Minimized;
 
        }

        private void SetTrueAnswerPos(int pos)
        {
            this.trueAnswerPos = pos;
        }

        private int GetTrueAnswerPos()
        {
            return this.trueAnswerPos;
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (formSet = new FormSetting(this))
            {
                formSet.ShowDialog();
            }
            
        }

        private void btnNoAns_Click(object sender, EventArgs e)
        {

            WindowState = FormWindowState.Minimized;
        }
        
        private void timerInactivity_Tick(object sender, EventArgs e)
        {
            var inactiveTime = inactiveTimeCalc.GetInactiveTime();

            if (inactiveTime != null)
            {
                if (inactiveTime.Value.TotalMinutes > TIME_FOR_SLEEP)
                {
                    timer1.Stop();
                    timer1.Enabled = false;
                }
                else if (!timer1.Enabled)
                {
                    timer1.Enabled = true;
                    timer1.Start();
                }
            }
        }
    }
}
