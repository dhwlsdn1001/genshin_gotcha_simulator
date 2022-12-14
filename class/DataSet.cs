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
    public class DataSet
    {
        public static dynamic JsonToString(string path, string filename, string mode)
        {
            string json;
            using (StreamReader sr = new StreamReader(path + filename))
                json = sr.ReadToEnd();
            switch (mode)
            {
                case "cp":
                    return JsonConvert.DeserializeObject<List<Randombox_Character_PickUp>>(json);
                case "wp":
                    return JsonConvert.DeserializeObject<List<Randombox_Weapon_PickUp>>(json);
                case "al":
                    return JsonConvert.DeserializeObject<Randombox_Always>(json);
                default:
                    Console.WriteLine("wrong file");
                    return null;
            }
        }

        public static int IntInput(string context)
        {
            Console.Write(context);
            return int.Parse(Console.ReadLine());
        }

        public static string StringInput(string context)
        {
            Console.Write(context);
            return Console.ReadLine();
        }
    }
}
