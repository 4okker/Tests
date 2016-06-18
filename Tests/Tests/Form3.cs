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
    public partial class Form3 : Form
    {
     static  Dictionary<string, string> dict= new Dictionary<string,string>();
        public Form3()
        {
            InitializeComponent();
        }

        public  Dictionary<string, string> Mydic()
        {
            
            dict.Add( textBox1.Text, textBox2.Text);
            return dict;
        }
        private void button1_Click(object sender, EventArgs e)
        {
                   
            dict = this.Mydic();
           
            //dict = Dictionary_class.MyDic();
            MessageBox.Show("зареестровані");
           
            
            
            //this.Close();
          
          
        }
    }
}
