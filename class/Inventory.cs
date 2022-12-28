using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace genshin_gotcha
{
    public static class Inventory
    {
        public static Dictionary<string, int> inventory_5 = new Dictionary<string, int>();
        public static Dictionary<string, int> inventory_4 = new Dictionary<string, int>();
        public static Dictionary<string, int> inventory_3 = new Dictionary<string, int>();

        public static void AddInv(string name, int grade)
        {
            switch (grade)
            {
                case 5:
                    if(inventory_5.ContainsKey(name))
                        inventory_5[name]++;
                    else
                        inventory_5.Add(name, 1);
                    break;
                case 4:
                    if (inventory_4.ContainsKey(name))
                        inventory_4[name]++;
                    else
                        inventory_4.Add(name, 1);
                    break;
                case 3:
                    if (inventory_3.ContainsKey(name))
                        inventory_3[name]++;
                    else
                        inventory_3.Add(name, 1);
                    break;
                default:
                    break;
            }
        }
        public static void PrintInv()
        {
            Console.WriteLine("===============================");
            Console.WriteLine("5성");
            foreach (var item in inventory_5)
            {
                Console.WriteLine($"{item.Key} : {item.Value}");
            }
            Console.WriteLine();
            Console.WriteLine("4성");
            foreach (var item in inventory_4)
            {
                Console.WriteLine($"{item.Key} : {item.Value}");
            }
            Console.WriteLine();
            Console.WriteLine("3성");
            foreach (var item in inventory_3)
            {
                Console.WriteLine($"{item.Key} : {item.Value}");
            }
        }
    }
}
