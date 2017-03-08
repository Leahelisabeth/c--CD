namespace ConsoleApplication
{
    //health=200; death_blow() =attack() & ifsamurai.health>50: health =0; meditate()=samurai.health reset to 200
    public class Samurai: Human
    {
        public Samurai(string n) : base(n)
        {
            health = 200;
        }

        public void Attack(object human){
            Human enemy = human as Human;
            if(enemy != null){
                enemy.health -= 5*strength;
                if(health < 50){
                    health = 0;
                }
            }
            else{
                System.Console.WriteLine("Failed Attack");
            }
        }
        public void Meditate(){
            health = 200;
        }

    }
}