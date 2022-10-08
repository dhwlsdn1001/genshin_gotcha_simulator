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
    public class Character
    {
        public string name;
        public int grade;
        public string gender;
        public int birthday;
        public string region;
        public string element;
        public string weapone;
        
        public Character(string name, int grade, string gender, string region, int birthday, string element, string weapone)
        {
            this.name = name;
            this.grade = grade;
            this.gender = gender;
            this.birthday = birthday;
            this.region = region;
            this.element = element;
            this.weapone = weapone;
        }
    }
}
