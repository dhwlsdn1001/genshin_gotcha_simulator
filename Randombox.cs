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
    public class Randombox
    {
        public string name;
        public List<string> char_list_5;
        public List<string> char_list_4;
        public List<string> weap_list_5;
        public List<string> weap_list_4;
        public List<string> weap_list_3;
        public int count_5;
        public int count_4;

        public Randombox(string name, List<string> char_list_5, List<string> char_list_4, List<string> weap_list_5, List<string> weap_list_4, List<string> weap_list_3) //상시 기원
        {
            this.name = name;
            this.char_list_5 = char_list_5;
            this.char_list_4 = char_list_4;
            this.weap_list_5 = weap_list_5;
            this.weap_list_4 = weap_list_4;
            this.weap_list_3 = weap_list_3;
        }

        public Randombox(string name, List<string> char_list_5, List<string> char_list_4, int count_5, int count_4) //한정 기원
        {
            this.name = name;
            this.char_list_5 = char_list_5;
            this.char_list_4 = char_list_4;
            this.count_5 = count_5;
            this.count_4 = count_4;
        }

        public Randombox(string name, List<string> weap_list_5, List<string> weap_list_4) //무기 기원
        {
            this.name = name;
            this.weap_list_5 = weap_list_5;
            this.weap_list_4 = weap_list_4;
        }
    }
}