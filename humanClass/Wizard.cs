using System;
namespace ConsoleApplication
{
    //health = 50; intl = 25; method heal()=health+= intelligence*10;
    // method fireball health-=rand.Next(20,50);
    public class Wizard : Human
    {
        public Wizard(string n) : base(n)
        {
            health = 50;
            intelligence = 25;

        }
        public void Heal()
        {
            health += intelligence * 10;
        }
        public void Fireball(Human enemy)
        {
            Attack(enemy);
            Random rando = new Random();
            health -= rando.Next(20, 50);
        }
    }
}