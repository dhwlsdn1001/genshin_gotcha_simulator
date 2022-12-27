﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace genshin_gotcha
{
    public class Randombox
    {
        List<Randombox_Character_PickUp> rc;
        List<Randombox_Weapon_PickUp> rw;
        Randombox_Always ra;

        public Randombox(List<Randombox_Character_PickUp> rc, List<Randombox_Weapon_PickUp> rw, Randombox_Always ra)
        {
            this.rc = rc;
            this.rw = rw;
            this.ra = ra;
        }

        public int CharSelect()
        {
            for(int i = 0; i < rc.Count; i++)
                Console.WriteLine($"{(i + 1).ToString() + ".", 3} {rc[i].name} : {rc[i].char_list_5[0]} - {rc[i].version.ToString("F1")}\n");
            int select_index = int.Parse(Console.ReadLine()) - 1;
            Console.WriteLine($"{rc[select_index].name}");
            Console.WriteLine($"{rc[select_index].version.ToString("F1")} 버전");
            Console.WriteLine($"5성 캐릭터 : {rc[select_index].char_list_5[0]}");
            Console.WriteLine($"4성 캐릭터 : {rc[select_index].char_list_4[0]}, {rc[select_index].char_list_4[1]}, {rc[select_index].char_list_4[2]}");
            return select_index;
        }

        public string RandomChar(ref int c5, ref int c4, ref int pick5, ref int pick4, int select_index, ref int price)
        {
            Random r = new Random();
            int p5;
            int p4;

            int r_result = r.Next(1, 1000);
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

            if (r_result >= 1 && r_result <= p5)//5성 맞음
            {
                Console.Write("5 - ");
                c5 = 0;
                price += 160;
                if (pick5 == 0)//확정천장 아님
                {
                    if(r.Next(1, 2) == 1)//픽뚫
                    {
                        pick5 = 1;
                        Console.Write($"{ra.char_list_5[r.Next(0, rc[select_index].count_5 - 1)]}");
                        return ra.char_list_5[r.Next(0, rc[select_index].count_5 - 1)];
                    }
                    else//픽업
                    {
                        pick5 = 0;
                        Console.Write($"{rc[select_index].char_list_5[0]}");
                        return rc[select_index].char_list_5[0];
                    }
                }
                else//확정천장 맞음
                {
                    pick5 = 0;
                    Console.Write($"{rc[select_index].char_list_5[0]}");
                    return rc[select_index].char_list_5[0];
                }
            }
            else//5성 아님
            {
                r_result = r.Next(1, 1000);
                if (r_result >= 1 && r_result <= p4)//4성 맞음
                {
                    Console.Write("4 - ");
                    c4 = 0;
                    price += 160;
                    if(pick4 == 0)//확정천장 아님
                    {
                        if(r.Next(1, 2) == 1)//픽뚫
                        {
                            pick4 = 1;
                            if(r.Next(1, 2) == 1)//캐릭터
                            {
                                Console.Write($"{ra.char_list_4[r.Next(0, rc[select_index].count_4 - 1)]}");
                                return ra.char_list_4[r.Next(0, rc[select_index].count_4 - 1)];
                            }
                            else//무기
                            {
                                Console.Write($"{ra.weap_list_4[r.Next(0, ra.weap_list_4.Count - 1)]}");
                                return ra.weap_list_4[r.Next(0, ra.weap_list_4.Count - 1)];
                            }
                        }
                        else//픽업
                        {
                            pick4 = 0;
                            Console.Write($"{rc[select_index].char_list_4[r.Next(0, rc[select_index].char_list_4.Count - 1)]}");
                            return rc[select_index].char_list_4[r.Next(0, rc[select_index].char_list_4.Count - 1)];
                        }
                    }
                    else//확정천장 맞음
                    {
                        pick4 = 0;
                        Console.Write($"{rc[select_index].char_list_4[r.Next(0, rc[select_index].char_list_4.Count - 1)]}");
                        return rc[select_index].char_list_4[r.Next(0, rc[select_index].char_list_4.Count - 1)];
                    }
                }
                else//3성 맞음
                {
                    Console.Write("3 - ");
                    Console.Write($"{ra.weap_list_3[r.Next(0, ra.weap_list_3.Count - 1)]}");
                    price += 160;
                    return ra.weap_list_3[r.Next(0, ra.weap_list_3.Count - 1)];
                }
            }
        }
    }
}