using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_RPG
{
    class Player
    {
        //public static Weapon initial_sword = new Weapon("Initial Sword", 8, 4);

        public string name;
        public int HP;
        public int level = 0;
        public static Weapon equipped_weapon;

        public int base_attack = 4;
        public int base_defense = 2;

        public Player(string aName, int aHP)
        {
            name = aName;
            HP = aHP;
        }

        public int Attack()
        {
            return (base_attack + equipped_weapon.attack);
        }

        public int Defense()
        {
            return (base_defense + equipped_weapon.defense);
        }

        public void Stats()
        {
            Console.WriteLine("\n{0}'s Stats:", name);
            Console.WriteLine("HP: {0}", HP);
            Console.WriteLine("Attack: {0} ({1})", Attack(), base_attack);
            Console.WriteLine("Defense: {0} ({1})", Defense(), base_defense);
            Console.WriteLine("Equipped Weapon: {0}; AT: {1}; DF: {2}", equipped_weapon.name, equipped_weapon.attack, equipped_weapon.defense);
        }

        public static bool QuestionPrompt()
        {
            string[] yes_list = { "yes", "", "sure", "y", "yeah", "why not", "yes.", "y." };

            Console.Write("-->");
            string input = Console.ReadLine();
            string iinput = input.ToLower();
            foreach (string value in yes_list)
            {
                if (value.Equals(iinput))
                {
                    return true;
                }
                else
                {
                    continue;
                }
            }
            return false;
        }

        public static void ChangeWeaponByName(string new_weapon_name)
        {
            Weapon weapon_to_change = new Weapon("Test Weapon", 0, 0);

            bool WeaponExists()
            {
                foreach (Weapon weapon in Weapon.weapon_list)
                {
                    if (weapon.name.ToLower() == new_weapon_name.ToLower())
                    {
                        weapon_to_change = weapon;
                        return true;
                    }
                    else
                    {
                        continue;
                    }
                }
                return false;
            }

            if (WeaponExists() == true)
            {
                equipped_weapon = weapon_to_change;
            }
        }

        public static void ChangeWeapon(Weapon new_weapon)
        {
            equipped_weapon = new_weapon;
        }

        public static void EquipWeapon(string weapon_name)
        {
            Weapon weapon_to_equip = new Weapon("Test Weapon", 0, 0);

            bool WeaponExists()
            {
                foreach (Weapon weapon in Weapon.weapon_list)
                {
                    if (weapon.name.ToLower() == weapon_name.ToLower())
                    {
                        weapon_to_equip = weapon;
                        return true;
                    }
                    else
                    {
                        continue;
                    }
                }
                return false;
            }

            if (WeaponExists())
            {
                Console.WriteLine("\nComparison of both weapons stats:");
                Weapon.CompareWeaponStats(weapon_to_equip, Player.equipped_weapon);
                Console.WriteLine("Are you sure you want to equip this weapon?");
                if (QuestionPrompt() == true)
                {
                    Console.WriteLine("You equipped the weapon!");
                    ChangeWeapon(weapon_to_equip);
                }
                else
                {
                    Console.WriteLine("You will continue with the same weapon, the new one was discarded.");
                }
            }
            else
            {
                Console.WriteLine("The weapon you want to equip doesn't exist!");
            }
        }

        public static void CheckEquippedWeapon()
        {
            Console.WriteLine("Equipped Weapon:");
            Weapon.CheckWeaponStats(equipped_weapon);
        }
    }
}