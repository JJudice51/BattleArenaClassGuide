using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using System.Xml.Linq;

namespace HelloDungeon
{
    //Inherited from Character Class
  class Player : Character
  {
        private string _playerChoice;
        private uint _lives = 3;

        //constructor for player but has to call on the contructor for the base class 'character' as well. ': base()' calls...
        //...the Character Constructor but to make it all work we need to put arguments in the Player Constructor then passing
        // just the variables in the base Contructor because you only need to call the information since the Character Constructor
        //already has the arguments.
        //A derived class is the base class plus its own specific arguments and variables you decide to add
        //So you have to follow all the rules of its base class. Player is a Character but also has its own stuff as well.
       
        //This directly below is the Default Constructor for this Derived Class and the one initialized in Character.
        public Player()
        {
            _playerChoice = " ";
        }
        public Player(string name, float health, float damage, float defense, float stamina, Weapon currentWeapon) : base(name, health, damage, defense, stamina, currentWeapon)
        {
            _playerChoice = " ";
            

        }

        //IF YOU CHANGE THE ARGUMENTS WHEN YOU MAKE A FUNCTION THAT HAS THE SAME NAME THE COMPUTER IS SMART ENOUGH TO TELL THE DIFF.
        //THIS IS CALLED FUNCTION OVERLOADING.
        //talking about polymorphism now. makes it to where 
        //we can tell our Class Player to override the function in a Base Class like Character
        //for this the key word is override.
        //20SEP23 with this we've been given all the tools we need to complete 1st assessment
        
        public override void PrintStats()
        {
            base.PrintStats();
            Console.WriteLine("Lives:" + _lives);
        }
        public string GetInput(string prompt, string option1, string option2, string option3, string option4)
        {
            _playerChoice = " ";
            Console.WriteLine(prompt);
            Console.WriteLine("1. " + option1);
            Console.WriteLine("2. " + option2);
            Console.WriteLine("3. " + option3);
            Console.WriteLine("4. " + option4);
            Console.Write(">");

            _playerChoice = Console.ReadLine();
            return _playerChoice;
        }
        public string GetInput(string prompt, string option1, string option2)
        {
            _playerChoice = " ";
            Console.WriteLine(prompt);
            Console.WriteLine("1. " + option1);
            Console.WriteLine("2. " + option2);
            Console.Write(">");

            _playerChoice = Console.ReadLine();
            return _playerChoice;
        }
    }
}
