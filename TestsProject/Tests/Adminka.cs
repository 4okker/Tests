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
    public partial class Adminka : Form
    {
       // string[] st = new string[4];
        List<string> st = new List<string>();
     //   int i = 0;
        string path = null;

        public Adminka()
        {
            InitializeComponent();
        }

    

        private void button_createTema_Click(object sender, EventArgs e)
        {
            st.Clear();
            path = @"testsFile\tems\" + textBox_tema.Text + ".txt";
           // File.Create(path);
            button_createTema.Enabled = false;
            textBox_tema.Enabled = false;
        }

        private void button_AddQuestionAnswer_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked == false && radioButton2.Checked == false && radioButton3.Checked == false)
            {
                MessageBox.Show("Checked true! ");
                return;
            }

            listBox_Question.Items.Add(textBox_Question.Text);
            st.Add(textBox_Question.Text);

            if (radioButton1.Checked == true)
            {
                st.Add("a." + textBox_answer1.Text + "+");
                radioButton1.Checked = false;
            }
            else
                st.Add("a." + textBox_answer1.Text);

            if (radioButton2.Checked == true)
            {

                st.Add("b." + textBox_answer2.Text + "+");
                radioButton2.Checked = false;
            }
            else
                st.Add("b." + textBox_answer2.Text);

            if (radioButton3.Checked == true)
            {
                st.Add("c." + textBox_answer3.Text + "+");
                radioButton3.Checked = false;
            }
            else
                st.Add("c." + textBox_answer3.Text);

           // MessageBox.Show(System.IO.Directory.GetCurrentDirectory());

            textBox_answer1.Clear();
            textBox_answer2.Clear();
            textBox_answer3.Clear();
            textBox_Question.Clear();
        }

        private void button_saveTema_Click(object sender, EventArgs e)
        {

            button_createTema.Enabled = true;
            textBox_tema.Enabled = true;
            textBox_tema.Text = "";
            
            File.AppendAllLines(path, st, Encoding.UTF8);

            MessageBox.Show("Save");
        }

        private void button_deleteQuestion_Click(object sender, EventArgs e)
        {
            if (listBox_Question.SelectedIndex < 0)
                return;

            int currentSelect = listBox_Question.SelectedIndex+1;

            int tmp = (currentSelect - 1) * 4;


            for (int g = 0; g <  4; g++)
                st.RemoveAt(tmp);

            listBox_Question.Items.RemoveAt(listBox_Question.SelectedIndex);
            listBox_Question.Refresh();
        }
    }
}
