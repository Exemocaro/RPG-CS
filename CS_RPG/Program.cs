using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_RPG
{
    class Program
    {
        static void Main()
        {
            Player player = new Player("", 30);

            bool PlayerDied()
            {
                if (Battle.isPlayerDead(player) == true)
                {
                    return true;
                }
                return false;
            }

            Weapon.CreateWeapon("Rusty Old Sword", 7, 3); // initial weapon
            Weapon.CreateWeapon("Iron Sword", 10, 5); // to give the player after he fights the bandits
            Weapon.CreateWeapon("Enchanted Silver Sword", 15, 7); // to give the player after he fights the knights

            Player.ChangeWeaponByName("rusty old sword");

            // the enemies
            Mob[] bandits =
            {
                new Mob("Bandit", "Rob", 10, 6, 2),
                new Mob("Bandit Leader", "Joe", 10, 7, 2)
            };
            Mob[] knights =
            {
                new Mob("Knight", "Rob", 12, 8, 4),
                new Mob("Knight", "John", 12, 9, 3),
                new Mob("Knight Captain", "Aaron", 14, 10, 4),
            };
            Mob[] dragons =
            {
                new Mob("Blue Dragon", "Jormungandr", 16, 10, 6),
                new Mob("Dragon Leader", "Helios", 18, 11, 6),
            };

            Console.WriteLine("What's your name, adventurer?");
            string response = Console.ReadLine();
            player.name = response;

            player.Stats();
            Console.WriteLine("\nPress anything to begin the game.");
            Console.ReadLine();
            Console.Clear();

            while (true)
            {
                Story.S_1_Bandits(player); // first part of the story
                foreach (Mob mob in bandits)
                {
                    Battle.MakeBattle(player, mob);
                    if (Battle.isPlayerDead(player) == true)
                    {
                        break;
                    }
                }

                if (PlayerDied() == true)
                {
                    break;
                }

                Events.SpawnWeapon("Iron Sword");
                if (player.HP <= 16)
                {
                    Events.LootSpecialHerbs(player);
                }
                else
                {
                    Events.LootHerbs(player);
                }
                player.Stats();
                Console.WriteLine("\nPress Enter to continue.");
                Console.ReadLine();

                Console.Clear();

                Story.S_2_Knights(); // second part of the story
                foreach (Mob mob in knights)
                {
                    Battle.MakeBattle(player, mob);
                    if (Battle.isPlayerDead(player) == true)
                    {
                        break;
                    }
                }

                if (PlayerDied() == true)
                {
                    break;
                }

                Events.SpawnWeapon("Enchanted Silver Sword");
                Events.LootMedicine(player);
                if (player.HP >= 15)
                {
                    Events.LootHighGradeMedicine(player);
                }
                else if (player.HP <= 13)
                {
                    Events.GodBlessing(player);
                }
                else
                {
                    Events.LootMedicine(player);
                }
                player.Stats();
                Console.WriteLine("\nPress Enter to continue.");
                Console.ReadLine();

                Console.Clear();

                Story.S_3_Dragons(); // third part of the story
                foreach (Mob mob in dragons)
                {
                    Battle.MakeBattle(player, mob);
                    if (Battle.isPlayerDead(player) == true)
                    {
                        break;
                    }
                }

                if (PlayerDied() == true)
                {
                    break;
                }

                Console.Clear();

                Story.S_End(player);

                break;
            }

            Console.ReadLine();
        }
    }
}