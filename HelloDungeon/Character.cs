using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloDungeon
{
    //made new class
    class Character
    {
        private string _name;
        private float _health;
        private float _damage;
        private float _defense;
        private float _defenseBoost;
        private float _stamina;
        private Weapon _currentWeapon;
        
        // this is a constructor, allows us to initialize private variables? mega important
        //initialize all stats
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
        public void BoostDefense()
        {
            _defense += _defenseBoost;
        }
        public void ResetDefense()
        {
            _defense -= _defenseBoost;
        }
        public string GetName()
        {
            return _name;
        }
        public float GetStamina()
        {
            return _stamina;
        }



        public void PrintStats()
        {
            Console.WriteLine("Name: " + _name);
            Console.WriteLine("Health: " + _health);
            Console.WriteLine("Damage: " + _damage);
            Console.WriteLine("Defense: " + _defense);
            Console.WriteLine("Stamina: " + _stamina);
            Console.WriteLine("Weapon: " + _currentWeapon.WeaponName);
        }
        //NEED TO IMPLIMENT  Character[] Enemies ARRAY AND int currentEnemyIndex IN Fight FUNCTION.
        //new attack function

        public void TakeDamage(float damage)
        {
            _health -= damage - _defense;
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
