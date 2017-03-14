namespace ConsoleApplication
{
    public class Card
    {

        public string stringVal
        // So every time we acces stringVal, it will give you a string with the card value
        // It shouldn't be inherently set or a separate property, it is directly related to val
        // Treat this like a function call, not a variable
        {
            get
            {
                if (val > 1 && val < 11)
                {
                    return val.ToString();
                }
                else if (val == 11)
                {
                    return "jack";
                }
                else if (val == 12)
                {
                    return "queen";
                }
                else if (val == 13)
                {
                    return "king";
                }
                else if (val == 1)
                {
                    return "ace";
                }
                else
                {
                    return "joker";
                }
            }
        }

        public string suit;
        public int val;
        public string imgsrc;


        public Card(string CardSuit, int NumVal)
        {
            suit = CardSuit;
            val = NumVal;
            imgsrc = stringVal +"_of_" + suit +".png";
        }

        // Do we need this? what is override string ToString()?
        // Allows you to view the object and not the type
        // By default the ToString method gives the type of array

        // string means it will return a string
        public override string ToString()
        {
            return stringVal + " of " + suit + "-" + imgsrc;
        }
    }
}