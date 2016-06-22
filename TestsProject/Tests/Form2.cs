using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Tests
{
    public partial class Form2 : Form
    {
        string userName;
        bool CheckHistory = false;
        bool CheckHistory2 = false;
        string[] str = null;
        int i = 0;
        int str_length = 0;
        int goodAnswer = 0;
        int countQuestion = 0;
        int countActive = 0;

        public Form2(string login)
        {
            InitializeComponent();
           // MessageBox.Show(Directory.GetCurrentDirectory());
            string pathToFile = Directory.GetCurrentDirectory() + @"\testsFile\tems\";
           string [] filesName= Directory.GetFiles(pathToFile,"*.txt");

            for (int g = 0; g < filesName.Length; g++)
            {
                comboBox1.Items.Add(Path.GetFileName(filesName[g])); 

            }
            userName = login;
            
            button_ok.Visible = false;
            label1.Visible = false;
            label_result.Visible = false;
            radioButton1.Visible = false;
            radioButton2.Visible = false;
            radioButton3.Visible = false;

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (label1.Visible == false)
            {
                button_ok.Visible = true;
                label1.Visible = true;
                radioButton1.Visible = true;
                radioButton2.Visible = true;
                radioButton3.Visible = true;
                label_result.Visible = false;
            }
            button_ok.Enabled = true;
            button_ok.Text = "Next";
            countQuestion = 0;
            countActive = 0;
            goodAnswer = 0;
            i = 0;
            string[] lines = null;

            lines = File.ReadAllLines(Directory.GetCurrentDirectory()+@"\testsFile\tems\" +comboBox1.Items[comboBox1.SelectedIndex].ToString());   // файл txt
            str_length = lines.Length;

            //if (comboBox1.SelectedIndex == 0)
            //{
            //    lines = File.ReadAllLines(@"testsFile\tems\C++test.txt");   // файл txt
            //    str_length = lines.Length;

            //}
            //if (comboBox1.SelectedIndex == 1)
            //{
            //    lines = File.ReadAllLines(@"testsFile\tems\C#test.txt");
            //    str_length = lines.Length;
            //}
            //if (comboBox1.SelectedIndex == 2)
            //{
            //    lines = File.ReadAllLines(@"testsFile\tems\Sqltest.txt");
            //    str_length = lines.Length;
            //}
            str = lines;
            countQuestion = lines.Length / 4;

            listBox1.Items.Clear();
            //int jj = 0;
            //while (jj < lines.Length)
            //{
            //    //if(jj%3==0)
            //    listBox1.Items.Add(str[jj]);
            //    jj++;
            //}
            addQuestion();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            countActive++;
            if (str == null)
            {
                MessageBox.Show("Choose the subject!!");
                return;
            }

            bool cc = false;

            string answer=null;

            if (radioButton1.Checked == true)
            {
                if ((bool)radioButton1.Tag ) { 
                goodAnswer++;
                cc = true;
            }
                answer = radioButton1.Text;
            }
            if (radioButton2.Checked == true)
            {
                if ((bool)radioButton2.Tag)
                {
                    goodAnswer++;
                    cc = true;
                }
                answer = radioButton2.Text;
            }
            if (radioButton3.Checked == true)
            {
                if ((bool)radioButton3.Tag)
                {
                    goodAnswer++;
                    cc = true;
                }
                answer = radioButton3.Text;
            }


            History(userName, label1.Text, answer, cc);


            if (countActive == countQuestion )
            {
                MessageBox.Show("End");
                button_ok.Visible = false;

                label1.Visible = false;
                radioButton1.Visible = false;
                radioButton2.Visible = false;
                radioButton3.Visible = false;
                str = null;
                label_result.Text="Result -> "+goodAnswer+'/'+countQuestion;
                label_result.Visible = true;

                Statistics(userName, countQuestion, goodAnswer);// сатаистика в тхт

                return;
            }
            
                cc = false;

            addQuestion();
        }

        private void addQuestion()
        {
            if (radioButton1.Checked == true)
                radioButton1.Checked = false;
            if (radioButton2.Checked == true)
                radioButton2.Checked = false;
            if (radioButton3.Checked == true)
                radioButton3.Checked = false;

            radioButton1.Tag = false;
            radioButton2.Tag = false;
            radioButton3.Tag = false;

            // listBox1.Items.Clear();
            listBox1.Items.Add(str[i]);   //додає питання
            label1.Text = str[i++];

            radioButton1.Text = str[i++];   //відповіді
            radioButton2.Text = str[i++];
            radioButton3.Text = str[i++];

            if (radioButton1.Text.Contains("+"))
            {
                radioButton1.Tag = true;    ////мітка для правильного питання
                int s = radioButton1.Text.IndexOf("+");
                string st = radioButton1.Text;

                st = st.Remove(s);   // видаляє помітку з правильного питання(тобто плюс зі стрічки)
                radioButton1.Text = st;
            }
            if (radioButton2.Text.Contains("+"))
            {
                radioButton2.Tag = true;
                int s = radioButton2.Text.IndexOf("+");
                string st = radioButton2.Text;

                st = st.Remove(s);
                radioButton2.Text = st;
            }
            if (radioButton3.Text.Contains("+"))
            {
                radioButton3.Tag = true;
                int s = radioButton3.Text.IndexOf("+");
                string st = radioButton3.Text;

                st = st.Remove(s);
                radioButton3.Text = st;
            }
        }

        public void History(string User, string Question, string ChooseAnswer, bool isCorrect)
        {

            if (CheckHistory == false)
            {
                File.AppendAllText("d:\\history.txt", "-----------HISTORY---------" + Environment.NewLine + Environment.NewLine);
                CheckHistory = true;
            }
            File.AppendAllText("d:\\history.txt", "User : " + User + "\n" + Environment.NewLine);
            File.AppendAllText("d:\\history.txt", "Time : " + DateTime.UtcNow.ToString() + Environment.NewLine);
            File.AppendAllText("d:\\history.txt", "Question : " + Question + "\n" + Environment.NewLine);
            File.AppendAllText("d:\\history.txt", "Answer : " + ChooseAnswer + "\n" + Environment.NewLine);
            File.AppendAllText("d:\\history.txt", "IsCorect? : " + isCorrect.ToString() + "\n" + Environment.NewLine);
        }

        public void Statistics(string Login, int CountMark, int CountCorectMark)
        {
            if (CheckHistory2 == false)
            {
                File.AppendAllText("d:\\history.txt", "-----------STATISTIC---------" + Environment.NewLine + Environment.NewLine);
                CheckHistory = true;
            }
            File.AppendAllText("d:\\Statistics.txt", "Login : " + Login + "\n" + Environment.NewLine + Environment.NewLine);
            File.AppendAllText("d:\\Statistics.txt", "Time : " + DateTime.UtcNow.ToString() + Environment.NewLine + Environment.NewLine);
            File.AppendAllText("d:\\Statistics.txt", "CountAllMark : " + CountMark + "\n" + Environment.NewLine + Environment.NewLine);
            File.AppendAllText("d:\\Statistics.txt", "CountCorrectMark : " + CountCorectMark + "\n" + Environment.NewLine + Environment.NewLine);
        }

    }

}
