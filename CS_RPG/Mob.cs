using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_RPG
{
    class Mob
    {
        public string specie;
        public string name;
        public int base_attack = 2;
        public int base_defense = 1;
        public int HP;

        public int mob_defense;
        public int mob_attack;

        public Mob(string aSpecie, string aName, int aHP, int aAttack, int aDefense)
        {
            specie = aSpecie;
            name = aName;
            HP = aHP;
            mob_attack = aAttack;
            mob_defense = aDefense;
        }

        public int Attack()
        {
            return (base_attack + mob_attack);
        }

        public int Defense()
        {
            return (base_defense + mob_defense);
        }

        public void Stats()
        {
            Console.WriteLine("The {0} {1}'s Stats:", specie, name);
            Console.WriteLine("HP: {0}", HP);
            Console.WriteLine("Attack: {0}", Attack());
            Console.WriteLine("Defense: {0}", Defense());
        }
    }
}