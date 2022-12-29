using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace genshin_gotcha
{
    public partial class Randombox
    {
        public string RandomWeap(ref int c5, ref int c4, ref int pick5, ref int pick4, int select_index, ref int price, ref int point, ref int weap_select)
        {
            Random r = new Random();
            int p5;
            int p4;

            int r_result = r.Next(1, 1001);
            c5++;
            c4++;

            if (c5 >= 0 && c5 <= 62)
                p5 = 7;
            else if (c5 == 77)
                p5 = 1000;
            else
                p5 = 7 + 70 * (c5 - 62);
            if (c4 == 8)
                p4 = 660;
            else if (c4 == 9)
                p4 = 1000;
            else
                p4 = 60;

            if (r_result >= 1 && r_result <= p5)//5성
            {
                Console.Write("5 - ");
                c5 = 0;
                price += 160;
                if (point != 2)//신의 궤도 포인트 0, 1
                {
                    if (pick5 == 0)//확정천장 아님
                    {
                        if (r.Next(1, 5) == 1)//픽뚫
                        {
                            pick5 = 1;
                            Console.Write($"{ra.weap_list_5[r.Next(0, ra.weap_list_5.Count)]}");
                            Inventory.AddInv(ra.weap_list_5[r.Next(0, ra.weap_list_5.Count)], 5);
                            return ra.weap_list_5[r.Next(0, ra.weap_list_5.Count)];
                        }
                        else//픽업
                        {
                            pick5 = 0;
                            if (r.Next(1, 3) == 1)//선택한 무기
                            {
                                Console.Write($"{rw[select_index].weap_list_5[weap_select]}");
                                Inventory.AddInv(rw[select_index].weap_list_5[weap_select], 5);
                                return rw[select_index].weap_list_5[weap_select];
                            }
                            else//선택하지 않은 무기
                            {
                                Console.Write($"{rw[select_index].weap_list_5[1 - weap_select]}");
                                Inventory.AddInv(rw[select_index].weap_list_5[1 - weap_select], 5);
                                return rw[select_index].weap_list_5[1 - weap_select];
                            }
                        }
                    }
                    else//확정천장 맞음
                    {
                        pick5 = 0;
                        if (r.Next(1, 3) == 1)//선택한 무기
                        {
                            Console.Write($"{rw[select_index].weap_list_5[weap_select]}");
                            Inventory.AddInv(rw[select_index].weap_list_5[weap_select], 5);
                            return rw[select_index].weap_list_5[weap_select];
                        }
                        else//선택하지 않은 무기
                        {
                            Console.Write($"{rw[select_index].weap_list_5[1 - weap_select]}");
                            Inventory.AddInv(rw[select_index].weap_list_5[1 - weap_select], 5);
                            return rw[select_index].weap_list_5[1 - weap_select];
                        }
                    }
                }
                else//신의 궤도 포인트 2
                {
                    pick5 = 0;
                    Console.Write($"{rw[select_index].weap_list_5[weap_select]}");
                    Inventory.AddInv(rw[select_index].weap_list_5[weap_select], 5);
                    return rw[select_index].weap_list_5[weap_select];
                }
            }
            else if (r_result >= 1001 - p4 && r_result <= 1000)//4성
            {
                Console.Write("4 - ");
                c4 = 0;
                price += 160;
                if (pick4 == 0)//확정천장 아님
                {
                    if (r.Next(1, 5) == 1)//픽뚫
                    {
                        pick4 = 1;
                        if (r.Next(1, ra.char_list_4.Count + ra.weap_list_4.Count) <= ra.char_list_4.Count)//캐릭터
                        {
                            Console.Write($"{ra.char_list_4[r.Next(0, ra.char_list_4.Count)]}");
                            Inventory.AddInv(ra.char_list_4[r.Next(0, ra.char_list_4.Count)], 4);
                            return ra.char_list_4[r.Next(0, ra.char_list_4.Count)];
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
                        Console.Write($"{rw[select_index].weap_list_4[r.Next(0, rw[select_index].weap_list_4.Count)]}");
                        Inventory.AddInv(rw[select_index].weap_list_4[r.Next(0, rw[select_index].weap_list_4.Count)], 4);
                        return rw[select_index].weap_list_4[r.Next(0, rw[select_index].weap_list_4.Count)];
                    }
                }
                else//확정천장
                {
                    pick4 = 0;
                    Console.Write($"{rw[select_index].weap_list_4[r.Next(0, rw[select_index].weap_list_4.Count)]}");
                    Inventory.AddInv(rw[select_index].weap_list_4[r.Next(0, rw[select_index].weap_list_4.Count)], 4);
                    return rw[select_index].weap_list_4[r.Next(0, rw[select_index].weap_list_4.Count)];
                }
            }
            else//3성
            {
                price += 160;
                Console.Write("3 - ");
                Console.Write($"{ra.weap_list_3[r.Next(0, ra.weap_list_3.Count)]}");
                Inventory.AddInv(ra.weap_list_3[r.Next(0, ra.weap_list_3.Count)], 4);
                return ra.weap_list_3[r.Next(0, ra.weap_list_3.Count)];
            }
        }
    }
}
