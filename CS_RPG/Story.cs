using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_RPG
{
    static class Story
    {
        public static void S_1_Bandits(Player player)
        {
            Console.WriteLine("You are " + player.name + ", who's on his way to kill the dragons which are destroying the kingdom.");
            Console.WriteLine("As you are on your way to the lairs of the dragons, you run into a couple of bandits.");
            Console.WriteLine("And they don't seem so friendly...");
            Console.ReadLine();
            Console.Clear();
        }

        public static void S_2_Knights()
        {
            Console.WriteLine("The bandits weren't much of a match for you. Well Done! You continue on to the dragons lair!");
            Console.WriteLine("However, a new movement has risen that wants to protect the dragons of the world.");
            Console.WriteLine("Many people have joined this movement, including some knights.");
            Console.WriteLine("And uh oh, 3 of them have found out about your quest...");
            Console.WriteLine("Maybe they're friendly?");
            Console.ReadLine();
            Console.WriteLine("Nope.");
            Console.ReadLine();
            Console.Clear();
        }

        public static void S_3_Dragons()
        {
            Console.WriteLine("With the knights defeated you continue on your journey!");
            Console.WriteLine("After a while you make it to the lair of dragons...");
            Console.WriteLine("It's hot and little smokey in there. You put your sight on the pair of dragons in the center of it.");
            Console.WriteLine("The time has come to end the dragons rampage!");
            Console.ReadLine();
            Console.Clear();
        }

        public static void S_End(Player player)
        {
            Console.WriteLine("You killed the dragons and saved the kingdom!");
            Console.WriteLine("Your name will be remembered forever and legends will be told about the hero {0} that defeated the evil dragons!", player.name);
            Console.WriteLine("Congrats!");
        }
    }
}