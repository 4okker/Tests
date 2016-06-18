using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dictionary_ns;
namespace Tests
{
    public partial class Form1 : Form
    {
        Dictionary<string, string> dic;
        public Form1()
        {
            InitializeComponent();
        }
       
        private void button_SignIn_Click(object sender, EventArgs e)
        {
            try
            {
                dic = Dictionary_class.MyDic();
                Form3 f3 = new Form3();
                //dic = Form3.Mydic();
                string v = "";
                if (dic.TryGetValue(textBox1.Text, out v))
                {
                    if (textBox2.Text == v)
                    {
                        MessageBox.Show("Логін і пароль введено правильно");
                        textBox1.Clear();
                        textBox2.Clear();
                        Form2 f = new Form2();
                        f.ShowDialog();
                        
                    }
                    else
                    {
                        MessageBox.Show("щось не правильно введено, повторіть");
                        textBox1.Clear();
                        textBox2.Clear();
                    }
                }
                else
                {
                    MessageBox.Show("щось не правильно введено, повторіть");
                    textBox1.Clear();
                    textBox2.Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
          
        }
        // з цим проблемс
        private void button_Registration_Click(object sender, EventArgs e)
        {
            Form3 f3 = new Form3();
            f3.ShowDialog();
        }
    }
}
