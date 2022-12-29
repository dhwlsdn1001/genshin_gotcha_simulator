using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace genshin_gotcha
{
    public partial class Randombox
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
    }
}
