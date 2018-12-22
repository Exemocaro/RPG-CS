using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_RPG
{
    static class Events
    {
        public static void SpawnWeapon(string weapon_name)
        {
            Console.WriteLine("\nAfter that fight you looted a weapon from the enemy party: {0}", weapon_name);
            Player.EquipWeapon(weapon_name);
        }

        public static void LootHerbs(Player player)
        {
            Console.WriteLine("\nYou also managed to loot some herbs that you will use to cure you! You gained 3 HP.");
            player.HP += 3;
        }

        public static void LootSpecialHerbs(Player player)
        {
            Console.WriteLine("\nYou also managed to loot some special herbs that you will use to cure you! You gained 5 HP.");
            player.HP += 5;
        }

        public static void LootMedicine(Player player)
        {
            Console.WriteLine("\nYou looted some medicine that you will use to cure you! You gained 5 HP.");
            player.HP += 5;
        }

        public static void LootHighGradeMedicine(Player player)
        {
            Console.WriteLine("\nAnd you also managed to loot some high grade medicine that you will use to cure you! You gained 7 HP.");
            player.HP += 7;
        }

        public static void GodBlessing(Player player)
        {
            Console.WriteLine("\nAs you were walking towards the dragon nest, you suddenly hear a angelical voice behind you\n" +
                "and your wounds magically heal. You were blessed by a god to finish your journey! You gained 12 HP.");
            player.HP += 12;
        }
    }
}