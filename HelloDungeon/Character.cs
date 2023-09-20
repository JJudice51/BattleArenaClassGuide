using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloDungeon
{
    //private variables is a protection level that makes it to where you can't change information of the variable outside the class
    //we will no longer be utilizing public variables only private variables from here on out.
    //OOP or Object Oriented Programming idea is about we create objects to do specific jobs only. a class can be considered an object.
    //made new class
    //A CLASS IS A REFERENCE TYPE NOT A VALUE TYPE
    //INHERITANCE : base class can be inherited by smaller subclass. ex 'class Human' is parent/base class 'class Braxton: Human' derived class
    //
    class Character
    {
        private string _name;
        private float _health;
        private float _damage;
        private float _defense;
        private float _stamina;
        private Weapon _currentWeapon;

        //This is the Default Constructor. Just allocates memory for variables until the info replaces it later.
        public Character()
        {
            _name = " ";
            _health = 0;
            _damage = 0;
            _defense = 0;
            _stamina = 0;
        }
        // this is a constructor, allows us to initialize private variables? mega important
        //initialize all stats of any new instance of a Character or any instance of something from a Class. 
        //Like all the pieces of everything that makes a thing a thing. Every Character has everything the Constructor says it has. 
        public Character(string name, float health, float damage, float defense, float stamina, Weapon currentWeapon)
        {
            _name = name;
            _health = health;
            _damage = damage;
            _defense = defense;
            _stamina = stamina;
            _currentWeapon = currentWeapon;

        }

        //bunch of functions to call private variable values

        public float GetDamage()
        {
            return _damage;
        }
        public Weapon GetWeapon()
        {
            return _currentWeapon;
        }
        public float GetHealth()
        {
            return _health;
        }
        public float GetDefense()
        {
            return _defense;
        }
        public void BoostDefense()
        {
            _defense *= 2;
        }
        public void ResetDefense()
        {
            _defense /= 2;
        }
        public string GetName()
        {
            return _name;
        }
        public float GetStamina()
        {
            return _stamina;
        }
     
        public void Recover()
        {
            _health += _stamina;
        }



        //have to tell the Character class which classes can override the function through polymorphism. the key word is virtual
        //if you add virtual to the function you are saying this function can be overidden by a Class that derives from this one
        public virtual void PrintStats()
        {
            Console.WriteLine("Name: " + GetName());
            Console.WriteLine("Health: " + GetHealth());
            Console.WriteLine("Damage: " + GetDamage());
            Console.WriteLine("Defense: " + GetDefense());
            Console.WriteLine("Stamina: " + GetStamina());
            Console.WriteLine("Weapon: " + GetWeapon());
        }
        //NEED TO IMPLIMENT  Character[] Enemies ARRAY AND int currentEnemyIndex IN Fight FUNCTION.
        //new attack function

        public void TakeDamage()
        {
            _health -= _damage +_currentWeapon.WeaponDamage - _defense;
        }
        public void TakePunch()
        {
            _health -= _damage;
        }
        ////use stamina value to heal some health.
        ////need to reorganize or remake somehow not sure yet
        //public float Recover(Character creature)
        //{
        //    totalhealth = creature _health;
        //    float totalhealth = _health + _stamina;
        //    return totalhealth;
        //}

    }
}
