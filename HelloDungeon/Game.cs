using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;

namespace HelloDungeon
{
    //Lodis instruction: wants to make battle arena type game. turn based fightingish game
    class Game
    {
        //struct = making your own variable type and storing a bunch of data, pretty much whatever variables and values you want it to.
        //always capatolize 1st letter of your structs name. ex: struct Name
        struct Monster
        {
           public string Name;
           public float Health;
           public float Damage;
           public float Defense;
           public float Stamina;
        }
        float Attack(Monster attacker, Monster defender)
        {
            float totalDamage = attacker.Damage - defender.Defense;

            return defender.Health - totalDamage;
        }

        float Heal(Monster creature)
        {
            float totalhealth = creature.Health + creature.Stamina;
            return totalhealth;
        }

        void  Fight(ref Monster monster1, ref Monster monster2)
        {
            PrintStats(monster1);
            PrintStats(monster2);

            Console.WriteLine(monster1.Name + " punches " + monster2.Name + "!");
            monster2.Health= Attack(monster1, monster2);
            Console.ReadKey(true);
            PrintStats(monster1);
            PrintStats(monster2);
         

            Console.WriteLine(monster2.Name + " punches " + monster1.Name + "!");
            monster1.Health = Attack(monster2, monster1);
            Console.ReadKey(true);
            PrintStats(monster1);
            PrintStats(monster2);
            Console.ReadKey(true);

        }


        void ChangeNumber(int number)
        {
            number = 2;
        }
        //function for combat
        void PrintStats(Monster monster)
        {
            Console.WriteLine("Name: " + monster.Name);
            Console.WriteLine("Health: " + monster.Health);
            Console.WriteLine("Damage: " + monster.Damage);
            Console.WriteLine("Defense: " + monster.Defense);
            Console.WriteLine("Stamina: " + monster.Stamina);
        }

        public void Run()
        {
            //first instance of utilizing struct Monster 
            Monster GibMoFist;
            GibMoFist.Name = "GibMoFist";
            GibMoFist.Health = 100f;
            GibMoFist.Damage = 25f;
            GibMoFist.Defense = 10f;
            GibMoFist.Stamina = 10f;

            Monster Bibbles;
            Bibbles.Name = "Bibbles";
            Bibbles.Health = 25f;
            Bibbles.Damage = 15f;
            Bibbles.Defense = 5f;
            Bibbles.Stamina = 5f;

            Monster Gonbu;
            Gonbu.Name = "Gonbu";
            Gonbu.Health = 30f;
            Gonbu.Damage = 5f;
            Gonbu.Defense = 0.5f;
            Gonbu.Stamina = 6f;

            Monster Mo;
            Mo.Name = "Sleepy Mo";
            Mo.Health = 50f;
            Mo.Damage = 30f;
            Mo.Defense = 10f;
            Mo.Stamina = 1f;


   

            Fight(ref Gonbu, ref GibMoFist);

            Console.Clear();

            Fight(ref GibMoFist, ref Gonbu);
        }
    }
}
