using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_RPG
{
    static class Battle
    {
        public static int crit_chance = 16; // 1 in 15 attacks is a crit. ( Yes, 15 ). 
        public static int attack_timer = 1500;

        public static bool isCrit()
        {
            Random rnd = new Random();
            int crit = rnd.Next(1, crit_chance);

            if (crit == 1)
            {
                return true;
            }
            return false;
        }

        public static bool isPlayerDead(Player player)
        {
            if (player.HP <= 0)
            {
                return true;
            }
            return false;
        }

        public static bool isMobDead(Mob mob)
        {
            if (mob.HP <= 0)
            {
                return true;
            }
            return false;
        }

        public static void PlayerAttack(Player player, Mob mob)
        {
            bool was_crit = false;

            int DamageInflicted()
            {
                int damage = player.Attack() - mob.Defense();
                if (damage <= 1)
                {
                    damage = 1;
                }
                if (isCrit() == true)
                {
                    was_crit = true;
                    damage += damage;
                }
                return damage;
            }

            mob.HP -= DamageInflicted();

            if (was_crit == true)
            {
                Console.WriteLine("It was a critical hit! You dealt {0} damage.", DamageInflicted());
            }
            else
            {
                Console.WriteLine("You dealt {0} damage.", DamageInflicted());
            }
            Console.WriteLine("The enemy has {0} HP.", mob.HP);
        }

        public static void EnemyAttack(Player player, Mob mob)
        {
            bool was_crit = false;

            int DamageInflicted()
            {
                int damage = mob.Attack() - player.Defense();
                if (damage <= 0)
                {
                    damage = 0;
                }
                if (isCrit() == true)
                {
                    was_crit = true;
                    damage += damage;
                }
                return damage;
            }

            player.HP -= DamageInflicted();

            if (was_crit == true)
            {
                Console.WriteLine("It was a critical hit! The enemy dealt {0} damage.", DamageInflicted());
            }
            else
            {
                Console.WriteLine("The enemy dealt {0} damage.", DamageInflicted());
            }
            Console.WriteLine("You have {0} HP.", player.HP);
        }

        public static void MakeBattle(Player player, Mob mob)
        {
            Console.WriteLine("You, {0}, will now fight the {1} {2}.", player.name, mob.specie, mob.name);
            mob.Stats();
            Console.WriteLine("Press Enter to begin the fight.");
            Console.ReadLine();
            Random rnd = new Random();
            int move = rnd.Next(1, 3);
            if (move == 1)
            {
                Console.WriteLine("You begin!");
                while (true)
                {
                    Console.WriteLine();
                    System.Threading.Thread.Sleep(attack_timer);
                    PlayerAttack(player, mob);
                    if (isMobDead(mob))
                    {
                        Console.WriteLine("You killed the {0}!", mob.specie);
                        Console.ReadLine();
                        Console.Clear();
                        break;
                    }

                    Console.WriteLine();
                    System.Threading.Thread.Sleep(attack_timer);
                    EnemyAttack(player, mob);
                    if (isPlayerDead(player))
                    {
                        Console.WriteLine("You died! Game Over!");
                        break;
                    }
                }
            }
            else
            {
                Console.WriteLine("The enemy will begin!");
                while (true)
                {
                    Console.WriteLine();
                    System.Threading.Thread.Sleep(attack_timer);
                    EnemyAttack(player, mob);
                    if (isPlayerDead(player))
                    {
                        Console.WriteLine("You died! Game Over!");
                        break;
                    }

                    Console.WriteLine();
                    System.Threading.Thread.Sleep(attack_timer);
                    PlayerAttack(player, mob);
                    if (isMobDead(mob))
                    {
                        Console.WriteLine("You killed the {0}!", mob.specie);
                        Console.ReadLine();
                        Console.Clear();
                        break;
                    }
                }
            }
        }
    }
}