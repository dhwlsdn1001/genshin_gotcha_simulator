using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;

namespace genshin_gotcha
{
    public static class Program
    {
        static void Main(string[] args)
        {
            string json;
            string datapath = "C:\\projects\\genshin_gotcha\\data";//언제든 변경 가능
            using (StreamReader r = new StreamReader(datapath + "\\4_grade_character.json"))
            {
                json = r.ReadToEnd();
            }
            List<Character> ch = JsonConvert.DeserializeObject<List<Character>>(json);
            for (int i = 0; i < ch.Count; i++)
            {

                Console.Write("\"" + ch[i].name + "\", ");
            }
        }
    }
}
