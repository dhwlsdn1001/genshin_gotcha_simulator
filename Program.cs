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
            Randombox rb = new Randombox(datapath);
            string rb_select = DataSet.StringInput("'캐릭터 기원' 또는 '무기 기원' 중 하나를 선택해 입력하시오 : ");
            Console.WriteLine("===============================");
            if (rb_select == "캐릭터 기원")
            {
                int select_index = rb.CharSelect();
                int time = DataSet.IntInput("기원 횟수 : ");
                int price = 0;
                int c5 = DataSet.IntInput("기원 스택(0 ~ 80) : ");
                int c4 = 0;
                int pick5 = DataSet.IntInput("천장 종류(반천장 = 0, 확정천장 = 1) : ");
                int pick4 = 0;
                Console.WriteLine("===============================");
                for (int i = 0; i < time; i++)
                {
                    rb.RandomChar(ref c5, ref c4, ref pick5, ref pick4, select_index, ref price);
                    Console.WriteLine($" {i + 1}");
                }
                Inventory.PrintInv();
            }
            else if (rb_select == "무기 기원")
            {
                int select_index = rb.WeapSelect();
                int time = DataSet.IntInput("기원 횟수 : ");
                int price = 0;
                int c5 = DataSet.IntInput("기원 스택(0 ~ 80) : ");
                int c4 = 0;
                int pick5 = DataSet.IntInput("천장 종류(반천장 = 0, 확정천장 = 1) : ");
                int pick4 = 0;
                int point = DataSet.IntInput("운명 포인트(0 ~ 2) : ");
                int weap_select = DataSet.IntInput("신의 궤도(첫번째 무기 = 1, 두번쨰 무기 = 2) : ") - 1;
                Console.WriteLine("===============================");
                for (int i = 0; i < time; i++)
                {
                    rb.RandomWeap(ref c5, ref c4, ref pick5, ref pick4, select_index, ref price, ref point, ref weap_select);
                    Console.WriteLine($" {i + 1}");
                }
                Inventory.PrintInv();
                Console.WriteLine("===============================");
                Console.WriteLine($"약 {Math.Ceiling(price * 14.72f)}원 (원석 1개당 14.72, 1트럭 기준)");
            }
            else
                Console.WriteLine("잘못된 입력");

            
        }
    }
}
