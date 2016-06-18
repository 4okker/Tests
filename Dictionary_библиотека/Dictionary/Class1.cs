using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dictionary_ns
{
    public class Dictionary_class
    {
      static  Dictionary<string, string> dict = new Dictionary<string, string>();
        public static Dictionary<string, string> MyDic()
        {
          
            dict.Add("lolo", "123");
            dict.Add("koko", "456");
            dict.Add("hoho", "789");
            dict.Add("mumu", "852");

            return dict;
        }
      //static  Dictionary<string, string> dict;
      //  public static Dictionary<string, string> MyDic(string s, string c)
      //  {
      //       dict.Add(s, c);
           
      //      return dict;
      //  }
    }
   
}
