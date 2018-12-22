using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_RPG
{
    class Weapon
    {
        public string name;
        public int attack;
        public int defense;

        public static List<Weapon> weapon_list = new List<Weapon>();

        public Weapon(string aName, int aAttack, int aDefense)
        {
            name = aName;
            attack = aAttack;
            defense = aDefense;

        }

        public static void CreateWeapon(string name, int attack, int defense)
        {
            Weapon weapon = new Weapon(name, attack, defense);
            weapon_list.Add(weapon);
        }

        public static void CheckAllAvailableWeaponsStats()
        {
            Console.WriteLine("\nAll weapons in the game:");
            foreach (Weapon weapon in Weapon.weapon_list)
            {
                Console.Write("Name: {0}\nAttack: {1}\nDefense: {2}\n", weapon.name, weapon.attack, weapon.defense);
                Console.WriteLine("---------------------------");
            }
        }

        public static void CheckWeaponStats(Weapon weapon)
        {
            Console.Write("\nName: {0}\nAttack: {1}\nDefense: {2}\n", weapon.name, weapon.attack, weapon.defense);
        }

        public static void CompareWeaponStats(Weapon other_weapon, Weapon your_weapon)
        {
            if (your_weapon == Player.equipped_weapon)
            {
                Console.Write("Name: {0} | Equipped Weapon Name: {1}\nAttack: {2} | Equipped Weapon Attack: {3} \nDefense: {4} |" +
                    " Equipped Weapon Defense: {5}\n", other_weapon.name, your_weapon.name, other_weapon.attack, your_weapon.attack, other_weapon.defense, your_weapon.defense);
            }
            else
            {
                Console.Write("Other Weapon Name: {0} | Your Weapon Name: {1}\nOther Weapon Attack: {2} | Your Weapon Attack: {3} \nOther Weapon Defense: {4} " +
                    "| Your Weapon Defense: {5}\n", other_weapon.name, your_weapon.name, other_weapon.attack, your_weapon.attack, other_weapon.defense, your_weapon.defense);
            }
        }
    }
}