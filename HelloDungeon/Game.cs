using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;
using System.Xml;
using System.Xml.Schema;

namespace HelloDungeon
{
    struct Weapon
    {
        public string WeaponName;
        public float WeaponDamage;
        public float WeaponDefense;
        public float WeaponDurability;
        public bool IsBroken;
    }
    //Lodis instruction: wants to make battle arena type game. turn based fightingish game
    class Game
    {
        //struct = making your own variable type and storing a bunch of data, pretty much whatever variables and values you want it to.
        //always capatolize 1st letter of your structs name. ex: struct Name



        //making a struct for an item/weapon. should at least contain a name variable, but can contain ant other stats you want.
        //add a variable that has the weapon struct type to the Monster struct.
        // want to put more stats here later.


        //some shits about to go down
        //declaring variables at the top.
        bool gameOver;
        int currentScene = 0;
        // declaring that the monster variables exist.
        //Player PlayerCharacter is what I have to use to access any functions in the Player Class.

        Player PlayerCharacter;
        Character GibMoFist;
        Character BadGuyzis;
        Character Gonbu;
        Character Bibbles;
        Character Mo;
        Character[] Enemies;
        int currentEnemyIndex = 0;
        Weapon Stick;
        Weapon Shield;
        Weapon Knives;
        Weapon Axe;
        string _playerChoice = " ";



        //NEED TO FIX MATH ISSUES, ALSO NEED TO FIGURE OUT  IF I CAN USE BATTLECHOICE LOCAL VARIABLE.
        void Fight(ref Character monster2)
        {
            PlayerCharacter.PrintStats();
            monster2.PrintStats();

            string battleChoice = PlayerCharacter.GetInput("Choose an action:", "Attack", "Dodge", "Recover", "Parry");
            {
                if (battleChoice == "1")
                {
                    monster2.TakeDamage();

                    if (monster2.GetHealth() <= 0)
                    {
                        return;
                    }

                }
                //not sure how to fix yet
                else if (battleChoice == "2")
                {
                    PlayerCharacter.BoostDefense();
                }
                //need to fix in Character
                else if (battleChoice == "3")
                {
                    PlayerCharacter.Recover();
                }

                else if (battleChoice == "4")
                {
                    monster2.TakePunch();

                    if (monster2.GetHealth() <= 0)
                    {
                        return;
                    }
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Invalid Input Press Any Key To Continue...");
                    Console.ReadKey(true);
                    Console.Clear();
                    return;
                }
                PlayerCharacter.PrintStats();
                monster2.PrintStats();

            }
            //its all messed up... many days later it all works now.
        }
        void ChangeNumber(int number)
        {
            number = 2;
        }
        //function for taking in input from player

        //Character selection choice list
        //C# has 2 major types Value types and Referrence types
        void CharacterSelect()
        {
            _playerChoice = PlayerCharacter.GetInput("CHOOSE YOUR FIGHTER:", " GibMoFist", " Bibbles", " Sleepy Mo", " Gonbu");
            {

                if (_playerChoice == "1")
                {
                    PlayerCharacter = new Player(GibMoFist.GetName(), GibMoFist.GetHealth(), GibMoFist.GetDamage(), GibMoFist.GetDefense(), GibMoFist.GetStamina(), GibMoFist.GetWeapon());
                    currentScene++;
                }
                else if (_playerChoice == "2")
                {
                    PlayerCharacter = new Player(Bibbles.GetName(), Bibbles.GetHealth(), Bibbles.GetDamage(), Bibbles.GetDefense(), Bibbles.GetStamina(), Bibbles.GetWeapon());
                    currentScene++;
                }
                else if (_playerChoice == "3")
                {
                    PlayerCharacter = new Player(Mo.GetName(), Mo.GetHealth(), Mo.GetDamage(), Mo.GetDefense(), Mo.GetStamina(), Mo.GetWeapon());
                    currentScene++;
                }
                else if (_playerChoice == "4")
                {
                    PlayerCharacter = new Player(Gonbu.GetName(), Gonbu.GetHealth(), Gonbu.GetDamage(), Gonbu.GetDefense(), Gonbu.GetStamina(), Gonbu.GetWeapon());
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

        //setting up an array just cause, its the alphabet. arrays reserve memory. brackets pretty much mean array at this point.
        //you have to set up an array just like this. the variabletype [] changes it from just a variable to an array. next part is the
        //... name of the array. after the = new 'variabletype' the number of slots reserved will be in the [1] or brackets.
        // after that in the curly braces {} you put the info that goes inside the slots. slots always start at 0 then to whatever number
        //... of slots you need to reserve.
        //the info in each slot of an array is called an ELEMENT. to change an element in an array 'letters[0] = b;'. so in the brackets
        //... after the name of the array is the slot you want to access = new element data;
        //new means its making room for the data that needs to be stored
        //arrays don't just store info. it stores a place or specific address in memory. like how ref works for individual variables.
        char[] letters = new char[26] { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };



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

            ///Lodis Instruction: make a new instance of a Character initialize them and put them in the enemies array
            //first instance of utilizing struct Monster 
            //we are utilizing the Character Class Constructor function since it initializes all the stats for any character
            //... instead of doing it how we did previously based on a struct like the commented out stats below.
            GibMoFist = new Character("GibMoFist", 75f, 25f, 10f, 10f, Stick);

            //this is how we initialized the stats before based on the Character struct instead of the Character Class Constructor.
            //GibMoFist.Name = "GibMoFist";
            //GibMoFist.Health = 75f;
            //GibMoFist.Damage = 25f;
            //GibMoFist.Defense = 10f;
            //GibMoFist.Stamina = 10f;
            //GibMoFist.CurrentWeapon = Stick;


            Bibbles = new Character("Bibbles the Relentless", 25f, 15f, 10f, 5f, Axe);

            Gonbu = new Character("Gonbu Glassbones", 30f, 5f, 20f, 6f, Knives);

            Mo = new Character("Sleepy Mo", 50f, 20f, 5f, 1f, Shield);

            BadGuyzis = new Character("Bad Guyzis", 50f, 30f, 5f, 20f, Stick);

            //Gib = 0, Bibs = 1 , Gonbu = 2, Mo = 3 BadGuyzis = 4 Index slots in the array. you can use a int variable to access them.

            Enemies = new Character[5] { GibMoFist, Bibbles, Gonbu, Mo, BadGuyzis };

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
                BattleScene();
            }
            else if (currentScene == 2)
            {
                WinResultsScene();
            }
            else if (currentScene == 3)
            {
                EndGameScene();
            }
            else if (currentScene == 4)
            {

            }
            else if (currentScene == 5)
            {

            }
        }
        //Make guys Fight here need to make better later. 
        //I have no idea why this doesn't work. Figured it out. My Update function's currentScenes were totally outta wack and...
        //looped infinitely. Just missed the issue from previous code overhauls. Now need to impliment the enemies ability to fight back
        //also need to fix the ability to fight all combatants. probably make 'if' statements in WinResultScene
        void BattleScene()
        {

            Fight(ref Enemies[currentEnemyIndex]);

            Console.Clear();

            if (PlayerCharacter.GetHealth() <= 0 || Enemies[currentEnemyIndex].GetHealth() <= 0)
            {
                currentScene = 2;
                return;
            }
            else if (PlayerCharacter.GetHealth() <= 0 && Enemies[currentEnemyIndex].GetHealth() <= 0)
            {
                Console.WriteLine("both have fallen");
                Console.ReadKey(true);
                currentScene = 3;
                return;
            }
        }
        void WinResultsScene()
        {
            if (PlayerCharacter.GetHealth() > 0 && Enemies[currentEnemyIndex].GetHealth() <= 0)
            {
                if (currentEnemyIndex < Enemies.Length)
                {
                    Console.WriteLine("The Winner Is:" + PlayerCharacter.GetName());
                    currentEnemyIndex++;
                    currentScene = 1;
                }

                else if (currentEnemyIndex >= Enemies.Length)
                {
                    gameOver = true;
                }
            }
            else if (Enemies[currentEnemyIndex].GetHealth() > 0 && PlayerCharacter.GetHealth() <= 0)
            {
                Console.WriteLine("The Winner Is:" + Enemies[currentEnemyIndex].GetName());
                currentScene = 3;
            }
            Console.ReadKey(true);
            Console.Clear();
        }
        void EndGameScene()
        {
            _playerChoice = PlayerCharacter.GetInput("Would You Like To Play Again?", "1. Yes", "2. No");

            if (_playerChoice == "1")
            {
                currentScene = 0;
            }
            else if (_playerChoice == "2")
            {
                gameOver = true;



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
            void End()
            {
                Console.WriteLine("Thanks For Playing!");
            }
            ///Make a new scene for Character Selection. Display all the characters we created as options. When the player selects a...
            ///... their Character, display the player's current stats.
            ///In the battle scene give the player the ability to fight one of the characters. They should have the ability to make choices.
            //Copy values from one struct to another. will need to do this.

            //more notes on Arrays at line 212
            //function below allows you to change info in array slots.
            //int[] grades = new int[5] { 23, 43, 56, 7, 10 };

            //void SetArrayValue(int[] arr, int index, int value)
            //{
            //    arr[index] = value;
            //}

            //for loop to print all values inside an array.
            // initializer; condition; expression.
            //for (int i = 0; i < grades.Length; i++)
            //{
            //    //grades at the index of variable i from the for loop.
            //    Console.WriteLine(grades[i]);
            //}
            //return;


            ///LODIS INsTRUCTION: create a function that takes in an integer array.
            ///the function should print out the sum of all of the values in the array.
            ///ex: Input: int[] numbers = new int [3] {1,2,3};
            ///ex: Output: 6

            //my attempt at the thing Lodis wants from us...
            //trying to figure out how to make a variable/function that = the sum of all integers in an array
            //Create a variable to store the sum.
            //Loop through all of the values in the array. Increment sum by each value in the array. Print sum to the console.
            void Total(int[] prompt)
            {
                int sum = 0;
                for (int i = 0; i < prompt.Length; i++)
                {
                    sum += prompt[i];
                }
                Console.WriteLine(sum);
            }
            ///New Array challenge: create a function that can take an integer array
            /// function should just print out the largest number in an integer array
            ///ex: Input: int[] numbers = new int [3] {1,2,3};
            ///ex: Output: 3
            void PrintLargest(int[] prompt)
            {
                int currentNumber = 0;
                int biggestNumber = 0;
                for (int i = 0; i < prompt.Length; i++)
                {
                    currentNumber = prompt[i];
                    if (currentNumber >= biggestNumber)
                    {
                        biggestNumber = currentNumber;
                    }
                    //this was pointless code that would do the same thing if there is no code here.
                    //else if (biggestNumber >= currentNumber)
                    //{
                    //    continue;
                    //} 
                }
                Console.WriteLine(biggestNumber);
            }
        
        public void Run()
        {
            Start();
            //E. A. SPORTS... ITS IN THE GAME
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




