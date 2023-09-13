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
        struct Character
        {
            public string Name;
            public float Health;
            public float Damage;
            public float Defense;
            public float Stamina;
            public Weapon Weapon;
        }

        //making a struct for an item/weapon. should at least contain a name variable, but can contain ant other stats you want.
        //add a variable that has the weapon struct type to the Monster struct.
        // want to put more stats here later.
        struct Weapon
        {
            public string WeaponName;
            public float WeaponDamage;
            public float WeaponDefense;
            public float WeaponDurability;
            public bool IsBroken;
        }

        //some shits about to go down
        //declaring variables at the top.
        bool gameOver;
        int currentScene = 0;
        // declaring that the monster variables exist.
        Character Player;
        Character Enemy;
        Character GibMoFist;
        Character Gonbu;
        Character Bibbles;
        Character Mo;
        Weapon Stick;
        Weapon Shield;
        Weapon Knives;
        Weapon Axe;
        string playerChoice = " ";
        float Attack(Character attacker, Character defender)
        {
            float totalDamage = attacker.Damage + attacker.Weapon.WeaponDamage - defender.Defense + defender.Weapon.WeaponDefense;

            return defender.Health - totalDamage;
        }
        //use stamina value to heal some health.
        float Recover(Character creature)
        {
            float totalhealth = creature.Health + creature.Stamina;
            return totalhealth;
        }
        

        void Fight(ref Character monster2)
        {
            PrintStats(Player);
            PrintStats(monster2);

            string battleChoice = GetInput("Choose an action:", "Attack", "Dodge", "Recover", "Parry");
            {
                if (battleChoice == "1")
                {
                    monster2.Health = Attack(Player, monster2);

                    if (monster2.Health <= 0)
                    {
                        return;
                    }
                }

                else if (battleChoice == "2")
                {
                    Player.Defense *= 2;
                }

                else if (battleChoice == "3")
                {
                    Recover(Player);
                }

                else if (battleChoice == "4")
                {
                    Player.Defense /= 2;
                    monster2.Health = Attack(Player, monster2);

                    if (monster2.Health <= 0)
                    {
                        return;
                    }

                }
                PrintStats(Player);
                PrintStats(monster2);

            }

        }
        void ChangeNumber(int number)
        {
            number = 2;
        }
        //function for combat
        void PrintStats(Character monster)
        {
            Console.WriteLine("Name: " + monster.Name);
            Console.WriteLine("Health: " + monster.Health);
            Console.WriteLine("Damage: " + monster.Damage);
            Console.WriteLine("Defense: " + monster.Defense);
            Console.WriteLine("Stamina: " + monster.Stamina);
            Console.WriteLine("Weapon: " + monster.Weapon.WeaponName);
        }
        string GetInput(string prompt, string option1, string option2, string option3, string option4)
        {
            Console.WriteLine(prompt);
            Console.WriteLine("1. " + option1);
            Console.WriteLine("1. " + option2);
            Console.WriteLine("1. " + option3);
            Console.WriteLine("1. " + option4);
            Console.Write(">");
            
            playerChoice = Console.ReadLine();
            return playerChoice;
        }
        //Character selection choice list
        void CharacterSelect()
        {
            string playerChoice = GetInput("CHOOSE YOUR FIGHTER:", "1. GibMoFist", "2. Bibbles", "3. Sleepy Mo", "4. Gonbu");
            {
              
                if (playerChoice == "1")
                {
                    Player = GibMoFist;
                    currentScene++;
                }
                else if (playerChoice == "2")
                {
                    Player = Bibbles;
                    currentScene++;
                }
                else if (playerChoice == "3")
                {
                    Player = Mo;
                    currentScene++;
                }
                else if (playerChoice == "4")
                {
                    Player = Gonbu;
                    currentScene++;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Invalid Input Press Any Key To Continue...");
                    Console.ReadKey(true);
                    Console.Clear();
                    return;
                }
                
            }
        }
        void EnemySelect()
        {
            string playerChoice = GetInput("CHOOSE YOUR CHALLENGER:", "1. GibMoFist", "2. Bibbles", "3. Sleepy Mo", "4. Gonbu");
            {

                if (playerChoice == "1")
                {
                    Enemy = GibMoFist;
                    currentScene++;
                }
                else if (playerChoice == "2")
                {
                    Enemy = Bibbles;
                    currentScene++;
                }
                else if (playerChoice == "3")
                {
                    Enemy = Mo;
                    currentScene++;
                }
                else if (playerChoice == "4")
                {
                    Enemy = Gonbu;
                    currentScene++;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Invalid Input Press Any Key To Continue...");
                    Console.ReadKey(true);
                    Console.Clear();
                    return;
                }

            }
        }

        //setting up an array just cause its the alphabet
        char[] letters = new char[26] {'a','b','c','d','e','f','g','h','i','j','k','l','m','n','o','p','q','r','s','t','u','v','w','x','y','z' };
        
        
        //Start is where we put all logic that needs to be initialized when the game as been called to begin/run.
        void Start()
        {
            //weapons list need to figure out how to impliment in combat

   
            Stick.WeaponName = "Quarterstaff";
            Stick.WeaponDamage = 15f;
            Stick.WeaponDefense = 15f;
            Stick.WeaponDurability = 50f;
            Stick.IsBroken = false;

            
            Shield.WeaponName = "Round Shield";
            Shield.WeaponDamage = 5f;
            Shield.WeaponDefense = 35f;
            Shield.WeaponDurability = 75f;
            Shield.IsBroken = false;

            
            Knives.WeaponName = "Fighting Knives";
            Knives.WeaponDamage = 35f;
            Knives.WeaponDefense = 5f;
            Knives.WeaponDurability = 40f;
            Knives.IsBroken = false;

            
            Axe.WeaponName = "Hatchet";
            Axe.WeaponDamage = 20f;
            Axe.WeaponDefense = 10f;
            Axe.WeaponDurability = 65f;
            Axe.IsBroken = false;


            //first instance of utilizing struct Monster 
           
            GibMoFist.Name = "GibMoFist";
            GibMoFist.Health = 75f;
            GibMoFist.Damage = 25f;
            GibMoFist.Defense = 10f;
            GibMoFist.Stamina = 10f;
            GibMoFist.Weapon = Stick;


            
            Bibbles.Name = "Bibbles";
            Bibbles.Health = 25f;
            Bibbles.Damage = 15f;
            Bibbles.Defense = 10f;
            Bibbles.Stamina = 5f;
            Bibbles.Weapon = Axe;

            
            Gonbu.Name = "Gonbu";
            Gonbu.Health = 30f;
            Gonbu.Damage = 5f;
            Gonbu.Defense = 20f;
            Gonbu.Stamina = 6f;
            Gonbu.Weapon = Knives;

            
            Mo.Name = "Sleepy Mo";
            Mo.Health = 50f;
            Mo.Damage = 20f;
            Mo.Defense = 5f;
            Mo.Stamina = 1f;
            Mo.Weapon = Shield;

        }
        //Update is where the game while it is playing will make changes and stuff
        //most things in a game will happen within the Update function.
        void Update()
        {
            if (currentScene == 0)
            {
                CharacterSelect();
            }
            if (currentScene == 1)
            {
                EnemySelect();
            }
            else if (currentScene == 2)
            {
                BattleScene();
            }
            else if (currentScene == 3)
            {
                WinResultsScene();
                
            }
            else if (currentScene == 4)
            {
                End();
            }
            else if (currentScene == 5)
            {
                End();
            }
        }
        //Make guys Fight here need to make better later.
        void BattleScene()
        {
            
            Fight (ref Enemy);

            Console.Clear();

            Fight (ref Enemy);
        
            if (Gonbu.Health <= 0 || GibMoFist.Health <= 0)
            {
                currentScene = 1;
            }
            else if (Gonbu.Health <= 0 && GibMoFist.Health <= 0)
            {
                Console.WriteLine("both have fallen");
                Console.ReadKey(true);
                currentScene = 2;
            }
        }
        void WinResultsScene()
        {
            if (Player.Health > 0 && Enemy.Health <= 0)
            {
                Console.WriteLine("The Winner Is:" + Player.Name);
            }
            else if (Enemy.Health > 0 && Player.Health <= 0)
            {
                Console.WriteLine("The Winner Is:" + Enemy.Name);
            }
            Console.ReadKey(true);
            Console.Clear();
        }


        void End()
        {
            Console.WriteLine("Thanks For Playing!");
        }
        ///Make a new scene for Character Selection. Display all the characters we created as options. When the player selects a...
        ///... their Character, display the player's current stats.
        ///In the battle scene give the player the ability to fight one of the characters. They should have the ability to make choices.
        //Copy values from one struct to another. will need to do this.
        
        
        public void Run()
        {
            Start();
            //Start - called before the 1st loop
            // is mainly used to initialize variables at the beginning of the game.


            //Update - called every time the game loops
            //used to update game logic like player input, character positions, game timers, etc.
            //stuff changing in a game is where update exists.

            //End - called after the main game loop exits. Used to clean up memory or display in game messages.
            //

            ///these are the Golden Functions as according to the book of Lodis.

            while (gameOver == false)
            {
             Update();
            }
           
            End();
        }
        
    }
}

