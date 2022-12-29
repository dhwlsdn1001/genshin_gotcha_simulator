using System;
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

        public Randombox(string datapath)
        {
            this.rc = DataSet.JsonToString(datapath, "randombox_character_pickup.json", "cp");
            this.rw = DataSet.JsonToString(datapath, "randombox_weapon_pickup.json", "wp");
            this.ra = DataSet.JsonToString(datapath, "randombox_always.json", "al");
        }

        public int CharSelect()
        {
            for (int i = 0; i < rc.Count; i++)
                Console.WriteLine($"{(i + 1).ToString() + ".",3} {rc[i].name} : {rc[i].char_list_5[0]} - {rc[i].version.ToString("F1")}\n");
            Console.WriteLine("===============================");
            Console.Write("기원 번호 : ");
            int select_index = int.Parse(Console.ReadLine()) - 1;
            Console.WriteLine("===============================");
            Console.WriteLine($"{rc[select_index].name}");
            Console.WriteLine($"{rc[select_index].version.ToString("F1")} 버전");
            Console.WriteLine($"5성 캐릭터 : {rc[select_index].char_list_5[0]}");
            Console.WriteLine($"4성 캐릭터 : {rc[select_index].char_list_4[0]}, {rc[select_index].char_list_4[1]}, {rc[select_index].char_list_4[2]}");
            Console.WriteLine("===============================");
            return select_index;
        }

        public int WeapSelect()
        {
            for (int i = 0; i < rw.Count; i++)
                Console.WriteLine($"{(i + 1).ToString() + ".",3} {rw[i].weap_list_5[0]}, {rw[i].weap_list_5[1]} - {rw[i].version.ToString("F1")}\n");
            Console.WriteLine("===============================");
            Console.Write("기원 번호 : ");
            int select_index = int.Parse(Console.ReadLine()) - 1;
            Console.WriteLine("===============================");
            Console.WriteLine($"{rw[select_index].version.ToString("F1")} 버전");
            Console.WriteLine($"5성 무기 : {rw[select_index].weap_list_5[0]}, {rw[select_index].weap_list_5[1]}");
            Console.WriteLine($"4성 무기 : {rw[select_index].weap_list_4[0]}, {rw[select_index].weap_list_4[1]}, {rw[select_index].weap_list_4[2]}, {rw[select_index].weap_list_4[3]}, {rw[select_index].weap_list_4[4]},");
            Console.WriteLine("===============================");
            return select_index;
        }

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
