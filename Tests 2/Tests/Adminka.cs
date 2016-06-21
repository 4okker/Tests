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
        string[] st = new string[4];
        int i = 0;
        string path = null;

        public Adminka()
        {
            InitializeComponent();
        }

        private void button_delAnswer_Click(object sender, EventArgs e)
        {

        }

        private void button_createTema_Click(object sender, EventArgs e)
        {
            path = @"testsFile\tems\" + textBox_tema.Text + ".txt";
           // File.Create(path);
            button_createTema.Enabled = false;
            textBox_tema.Enabled = true;


        }

        private void button_saveTema_Click(object sender, EventArgs e)
        {

            button_createTema.Enabled = true;
            textBox_tema.Enabled = true;
            textBox_tema.Text = "";
            
            st[i++] = textBox_Question.Text;
            if (radioButton1.Checked == true)
            {
                st[i++] = "a." + textBox_answer1.Text + "+";
                radioButton1.Checked = false;
            }
            else
            {
                st[i++] = "a." + textBox_answer1.Text;
            }
            if (radioButton2.Checked == true)
            {

                st[i++] = "b." + textBox_answer2.Text + "+";
                radioButton2.Checked = false;
            }
            else
            {
                st[i++] = "b." + textBox_answer2.Text;
            }
            if (radioButton3.Checked == true)
            {

                st[i++] = "c." + textBox_answer3.Text + "+";
                radioButton3.Checked = false;
            }
            else
            {
                st[i++] = "c." + textBox_answer3.Text;
            }
           // MessageBox.Show(System.IO.Directory.GetCurrentDirectory());
            File.AppendAllLines(path, st, Encoding.UTF8);

            textBox_answer1.Clear();
            textBox_answer2.Clear();
            textBox_answer3.Clear();
            textBox_Question.Clear();

            MessageBox.Show("Save");
        }
    }
}
