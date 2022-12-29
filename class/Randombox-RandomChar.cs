using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace genshin_gotcha
{
    public partial class Randombox
    {
        public string RandomChar(ref int c5, ref int c4, ref int pick5, ref int pick4, int select_index, ref int price)
        {
            Random r = new Random();
            int p5;
            int p4;

            int r_result = r.Next(1, 1001);
            c5++;
            c4++;

            if (c5 >= 0 && c5 <= 73)
                p5 = 6;
            else if (c5 == 90)
                p5 = 1000;
            else
                p5 = 6 + 60 * (c5 - 73);
            if (c4 == 9)
                p4 = 561;
            else if (c4 == 10)
                p4 = 1000;
            else
                p4 = 51;

            if (r_result >= 1 && r_result <= p5)//5성
            {
                Console.Write("5 - ");
                c5 = 0;
                price += 160;
                if (pick5 == 0)//확정천장 아님
                {
                    if (r.Next(1, 3) == 1)//픽뚫
                    {
                        pick5 = 1;
                        Console.Write($"{ra.char_list_5[r.Next(0, rc[select_index].count_5)]}");
                        Inventory.AddInv(ra.char_list_5[r.Next(0, rc[select_index].count_5)], 5);
                        return ra.char_list_5[r.Next(0, rc[select_index].count_5)];
                    }
                    else//픽업
                    {
                        pick5 = 0;
                        Console.Write($"{rc[select_index].char_list_5[0]}");
                        Inventory.AddInv(rc[select_index].char_list_5[0], 5);
                        return rc[select_index].char_list_5[0];
                    }
                }
                else//확정천장 맞음
                {
                    pick5 = 0;
                    Console.Write($"{rc[select_index].char_list_5[0]}");
                    Inventory.AddInv(rc[select_index].char_list_5[0], 5);
                    return rc[select_index].char_list_5[0];
                }
            }
            else if (r_result >= 1001 - p4 && r_result <= 1000)//4성
            {
                Console.Write("4 - ");
                c4 = 0;
                price += 160;
                if (pick4 == 0)//확정천장 아님
                {
                    if (r.Next(1, 3) == 1)//픽뚫
                    {
                        pick4 = 1;
                        if (r.Next(1, ra.char_list_4.Count + ra.weap_list_4.Count) <= ra.char_list_4.Count)//캐릭터
                        {
                            Console.Write($"{ra.char_list_4[r.Next(0, rc[select_index].count_4)]}");
                            Inventory.AddInv(ra.char_list_4[r.Next(0, rc[select_index].count_4)], 4);
                            return ra.char_list_4[r.Next(0, rc[select_index].count_4)];
                        }
                        else//무기
                        {
                            Console.Write($"{ra.weap_list_4[r.Next(0, ra.weap_list_4.Count)]}");
                            Inventory.AddInv(ra.weap_list_4[r.Next(0, ra.weap_list_4.Count)], 4);
                            return ra.weap_list_4[r.Next(0, ra.weap_list_4.Count)];
                        }
                    }
                    else//픽업
                    {
                        pick4 = 0;

                        Console.Write($"{rc[select_index].char_list_4[r.Next(0, rc[select_index].char_list_4.Count)]}");
                        Inventory.AddInv(rc[select_index].char_list_4[r.Next(0, rc[select_index].char_list_4.Count)], 4);
                        return rc[select_index].char_list_4[r.Next(0, rc[select_index].char_list_4.Count)];
                    }
                }
                else//확정천장 맞음
                {
                    pick4 = 0;
                    Console.Write($"{rc[select_index].char_list_4[r.Next(0, rc[select_index].char_list_4.Count)]}");
                    Inventory.AddInv(rc[select_index].char_list_4[r.Next(0, rc[select_index].char_list_4.Count)], 4);
                    return rc[select_index].char_list_4[r.Next(0, rc[select_index].char_list_4.Count)];
                }
            }
            else//3성
            {
                Console.Write("3 - ");
                Console.Write($"{ra.weap_list_3[r.Next(0, ra.weap_list_3.Count)]}");
                price += 160;
                Inventory.AddInv(ra.weap_list_3[r.Next(0, ra.weap_list_3.Count)], 3);
                return ra.weap_list_3[r.Next(0, ra.weap_list_3.Count)];
            }
        }
    }
}
