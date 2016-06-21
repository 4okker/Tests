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
using System.Text.RegularExpressions;

namespace Tests
{
    public partial class Form1 : Form
    {
        string readText;
        string path = @"testsFile\BD_Login_Password.txt";

        public Form1()
        {
            InitializeComponent();
            //Form2 f = new Form2(textBox1.Text.ToString());
            //f.ShowDialog();

           // Adminka admin = new Adminka();
           // admin.ShowDialog();
        }

        private void button_SignIn_Click(object sender, EventArgs e)
        {
            if (checkBox_adminka.Checked == true && textBox1.Text == "admin" && textBox2.Text == "admin")
            {
                Adminka admin = new Adminka();
                admin.ShowDialog();
                return;
            }

            try
            {
                readText = File.ReadAllText(path);
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
            string t = readText;// все що записано в текстовому
            string str = textBox1.Text + "+" + textBox2.Text;// строка для перевырки

            string regv = @"" + textBox1.Text + "\\+" + textBox2.Text + "";// рег вираз
            Regex reg = new Regex(regv);// обект  Regex з рег виразом
            MatchCollection matches = reg.Matches(t);// t- где ищет

            if (matches.Count == 1)
            {
                Form2 f = new Form2(textBox1.Text.ToString());
                f.ShowDialog();
            }
            else
            {
                MessageBox.Show("Не вірний логін або пароль");
            }
        }

        private void button_Registration_Click(object sender, EventArgs e)
        {
            if (!File.Exists(path))
            {
                string login = "(" + textBox1.Text + "+";
                string pass = textBox2.Text + ")";
                string sum = login + pass;
                File.WriteAllText(path, sum + Environment.NewLine);
            }
            else
            {
                readText = File.ReadAllText(path);

                string read_text = readText;//// все що записано в текстовому файлі
                string regv = @"\(" + textBox1.Text + "\\+";// рег вираз
                Regex reg = new Regex(regv);// обект  Regex з рег виразом
                MatchCollection matches = reg.Matches(read_text);// t- где ищет
                if (matches.Count == 0)
                {
                    string login1 = "(" + textBox1.Text + "+"; //Environment.NewLine;
                    string pass1 = textBox2.Text + ")";
                    string sum1 = login1 + pass1;// +Environment.NewLine;
                    File.AppendAllText(path, sum1 + Environment.NewLine);
                    MessageBox.Show("зареєстровано, " + "тепер зайдіть під своїм паролем і логіном");
                    textBox1.Clear();
                    textBox2.Clear();
                }
                else
                {
                    MessageBox.Show("Такий вже логін є, введіть інший");
                }
            }
        }

    }
}
