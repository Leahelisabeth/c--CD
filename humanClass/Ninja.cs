namespace ConsoleApplication
{
    //dextr = 175; method steal()= attack(),health+=10; get_away()=hea;th-=15;
    public class Ninja : Human
    {
        public Ninja(string n) : base(n)
        {
            dexterity = 175;
        }
        public void Steal(Human enemy)
        {
            Attack(enemy);
            health += 10;
        }
        public void Get_away()
        {
            health -= 15;
        }
    }
}