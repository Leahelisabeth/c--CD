
namespace ConsoleApplication
{
    public class Enemy{
        public string name;
        public int strength {get; set;}
        public int wickedness {get; set;}
        public int health{get; set;}
        public int mana{get; set;}
        public Enemy(string _name){
            name = _name;
            strength = 2;
            wickedness = 3;
            health = 100;
            mana = 10;
        }
        public void Attack(Human hero){
            Human target = hero as Human;
            if(target != null && mana > 0){
                target.health -= 5*strength;
                mana -= 1;
            }
            else{
                System.Console.WriteLine("Failed Attack");
            }
        }
    }
}