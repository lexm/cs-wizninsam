using System;
using System.Collections.Generic;

namespace wizninsam
{
    class Program
    {
        public class Human
        {
            public string name;
            public int strength;
            public int intelligence;
            public int dexterity;
            public int health;
            // public Human(string newname = "John Doe")
            // {
            //     name = newname;
            //     strength = 3;
            //     intelligence = 3;
            //     dexterity = 3;
            //     health = 100;
            // }
            public Human(string newname = "John Doe", int newstr = 3, int newint = 3, int newdex = 3, int newhlth = 100)
            {
                name = newname;
                strength = newstr;
                intelligence = newint;
                dexterity = newdex;
                health = newhlth;
            }

            public void Attack(object victim)
            {
                if (victim is Human)
                {
                    Human enemy = victim as Human;
                    enemy.health -= 5 * strength;
                }
            }
        }

        public class Wizard : Human
        {
            public Wizard(string newname = "Gandalf") : base(newname)
            {
                intelligence = 25;
                health = 50;
            }
            public Wizard(string newname = "Gandalf", int newstr = 3, int newint = 25, int newdex = 3, int newhlth = 50) : base(newname, newstr, newint, newdex, newhlth)
            {
            }
            public void Heal()
            {
                health += 10 * intelligence;
            }
            public void Fireball(object victim, Random randy)
            {
                if (victim is Human)
                {
                    Human enemy = victim as Human;
                    enemy.health -= randy.Next(20, 51);
                }
            }

        }

        public class Ninja : Human
        {
            public Ninja(string newname = "Hattori Hanzo") : base(newname)
            {
                dexterity = 175;
            }
            public Ninja(string newname = "Hattori Hanzo", int newstr = 3, int newint = 3, int newdex = 175, int newhlth = 100) : base(newname, newstr, newint, newdex, newhlth)
            {
            }
            public void Steal(object victim){
                base.Attack(victim);
                health += 10;
            }
            public void Get_Away(){
                health -= 15;
            }
        }

        public class Samarai : Human
        {
            private static int count = 0;
            public Samarai(string newname = "Mitume") : base(newname)
            {
                health = 200;
                count++;
            }
            public Samarai(string newname = "Mitume", int newstr = 3, int newint = 3, int newdex = 3, int newhlth = 200) : base(newname, newstr, newint, newdex, newhlth)
            {
                count++;
            }
            public void Death_Blow(object victim) 
            {
                if (victim is Human)
                {
                    Human enemy = victim as Human;
                    if(enemy.health < 50)
                    {
                        enemy.health = 0;
                    }
                }
            }
            public void Meditate(){
                health = 200;
            }
            public static int How_Many()
            {
                return count;
            }
        }

        static void Main(string[] args)
        {
            Random randy = new Random();
            Human jedi = new Human("Luke");
            Wizard master = new Wizard("Yoda");
            Human sith = new Human("Darth");
            jedi.Attack(sith);
            master.Fireball(sith, randy);
            System.Console.WriteLine(jedi.health);
            System.Console.WriteLine(sith.health);
            Ninja hanzo = new Ninja("Hattori");
            System.Console.WriteLine(hanzo.dexterity);
            hanzo.Steal(sith);
            hanzo.Get_Away();
            System.Console.WriteLine(hanzo.health);
            System.Console.WriteLine(sith.health);
            Samarai ronin = new Samarai("Toshiro");
            ronin.Death_Blow(sith);
            System.Console.WriteLine(sith.health);
            jedi.Attack(ronin);
            System.Console.WriteLine(ronin.health);
            ronin.Meditate();
            System.Console.WriteLine(ronin.health);
            System.Console.WriteLine(Samarai.How_Many());
        }
    }
}

