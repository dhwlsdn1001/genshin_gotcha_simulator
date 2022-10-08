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
    public class Weapon
    {
        public string name;
        public int grade;
        public string type;

        public Weapon(string name, int grade, string type)
        {
            this.name = name;
            this.grade = grade;
            this.type = type;
        }
    }
}
