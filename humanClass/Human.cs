namespace ConsoleApplication{
    public class Human{
        //att name, strength, intelligence, dexterity, health
        public string name;
        public int strength {get; set;}
        public int intelligence {get; set;}
        public int dexterity{get; set;}
        public int health{get; set;}
        public Human(string _name){
            name = _name;
            strength = 3;
            intelligence =3;
            dexterity=3;
            health=100;
        }
        //default val of 3 for strength intelligence, and dexterity and health 100
        //get set allows us to change a variable
        //access to reading and not writing it means they can read but not write it in.--example bank account.

        //namew should be passed as a parameter in constructor func

        //create an additional constructor that accepts 5 params
        public Human(int _health, int _strength, int _dexterity, int _intelligence, string _name){
            health = _health;
            strength = _strength;
            dexterity = _dexterity;
            intelligence = _intelligence;
            name = _name;

        }
        //add method caleld attack, when invoked, should attack another human obj that is passed as a parameter. damage done should be 5*strength, 5 pts dmg for 1pt strength
        public void Attack(object human){
           Human enemy = human as Human;
           if(enemy != null){
               enemy.health -= 5*strength;
           }
           else{
               System.Console.WriteLine("Failed Attack");
           }
        }
    }
}

//what is this refering to in constructor functions and methods, this instance of human?
//can you return something different from a method or a function based on a conditional other than void or a boolean? ie an OR statement where expected output is.
