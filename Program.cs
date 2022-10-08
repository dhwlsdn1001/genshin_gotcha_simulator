using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace genshin_gotcha
{
    public partial class Program
    {
        static void Main(string[] args)
        {
            Randombox alwayse = new Randombox("세상 여행", new List<string> { "keqing", "mona", "qiqi", "diluc", "jean" }, new List<string> { "amber", "lisa", "kaeya" }, new List<string> { "1" }, new List<string> { "2" });
            Randombox alwayse = new Randombox("세상 여행");
            alwayse.char_list_5.Add(keqing);
            alwayse.char_list_5.Add(mona);
            alwayse.char_list_5.Add(qiqi);
            alwayse.char_list_5.Add(diluc);
            alwayse.char_list_5.Add(jean);

            alwayse.char_list_4.Add(amber);
            alwayse.char_list_4.Add(lisa);
            alwayse.char_list_4.Add(kaeya);
        }
    }
}
