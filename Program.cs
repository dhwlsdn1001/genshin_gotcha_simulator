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
            string datapath = "C:\\projects\\genshin_gotcha\\data\\";//언제든 변경 가능
            List<Randombox_Character_PickUp> rc = DataSet.JsonToString(datapath, "randombox_character_pickup.json", "cp");
            List<Randombox_Weapon_PickUp> rw = DataSet.JsonToString(datapath, "randombox_weapon_pickup.json", "wp");
            Randombox_Always ra = DataSet.JsonToString(datapath, "randombox_always.json", "al");
            Randombox rb = new Randombox(rc, rw, ra);
            int select_index = rb.CharSelect();
            int price = 0;
            int c5 = 0;
            int c4 = 0;
            int pick5 = 0;
            int pick4 = 0;
            for (int i = 0; i < 180; i++)
            {
                rb.RandomChar(ref c5, ref c4, ref pick5, ref pick4, 0, ref price);
                Console.WriteLine($" {i + 1}");
            }

            
        }
    }
}
