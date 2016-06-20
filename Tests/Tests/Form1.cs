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
//using System.re
namespace Tests
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //static int count = 1;
        //string s;// для  счетчика
        string readText;
        string path = @"C:\Users\Ирина\Desktop\t1.txt";

        private void button_SignIn_Click(object sender, EventArgs e)
        {
            readText = File.ReadAllText(path);

            string t = readText;// все що записано в текстовому
            string str = textBox1.Text + "+" + textBox2.Text;// строка для перевырки

            //string regv = @"lago\+123";  // рег вираз
            //string regv55 = "Здравствуйте,"+username+"!!!\r Last visit "+lastvisit+"";  // рег вираз
           
            string regv = @"" + textBox1.Text + "\\+" + textBox2.Text + "";// рег вираз
            //MessageBox.Show(regv);
            Regex reg = new Regex(regv);// обект  Regex з рег виразом
            MatchCollection matches = reg.Matches(t);// t- где ищет

            if (matches.Count == 1)
            {
                //  MessageBox.Show("лог співпав");
                Form2 f = new Form2();
                f.ShowDialog();
            }

            else
            {
                MessageBox.Show("не вірний логін або пароль");

            }

        }

        private void button_Registration_Click(object sender, EventArgs e)
        {
            // s = Convert.ToString(count);

            if (!File.Exists(path))
            {

                string login = "(" + textBox1.Text + "+"; 
                string pass = textBox2.Text + ")";
                string sum = login + pass;
                File.WriteAllText(path, sum + Environment.NewLine);
            }
            //
            else
            {
                readText = File.ReadAllText(path);
                // string login_text = textBox1.Text;//  строка для первірки логіна

                string read_text = readText;//// все що записано в текстовому файлі
                string regv = @"\(" + textBox1.Text + "\\+";// рег вираз
                Regex reg = new Regex(regv);// обект  Regex з рег виразом
                MatchCollection matches = reg.Matches(read_text);// t- где ищет
                if (matches.Count == 0)
                {
                    // MessageBox.Show("введить пароль");
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
            //count++;

        }

    }
}
