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
            string datapath = "C:\\projects\\genshin_gotcha\\data\\";//������ ���� ����
            Randombox rb = new Randombox(datapath);
            int select_index = rb.CharSelect();
            int time = DataSet.IntInput("��� Ƚ�� : ");
            int price = 0;
            int c5 = DataSet.IntInput("��� ����(0 ~ 80) : ");
            int c4 = 0;
            int pick5 = DataSet.IntInput("õ�� ����(��õ�� = 0, Ȯ��õ�� = 1) : ");
            int pick4 = 0;
            int point = 0;
            int weap_select;
            Console.WriteLine("===============================");
            for (int i = 0; i < time; i++)
            {
                rb.RandomChar(ref c5, ref c4, ref pick5, ref pick4, select_index, ref price);
                Console.WriteLine($" {i + 1}");
            }
            Inventory.PrintInv();

            
        }
    }
}
