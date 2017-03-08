namespace ConsoleApplication
{
    public class Card
    {
        //property stringVal will hold vals ace-king
        public string suit;
        public int val;
        public string stringVal
        {
            get
            {
                if (val > 1 && val < 11)
                {
                    return val.ToString();
                }
                else if (val == 11)
                {
                    return "Jack";
                }
                else if (val == 12)
                {
                    return "Queen";
                }
                else if (val == 13)
                {
                    return "King";
                }
                else if (val == 1)
                {
                    return "Ace";
                }
                else
                {
                    return "Joker";
                }

            }

        }
        public Card(string _suit, int _val){
            suit = _suit;
            val = _val;
        }
        public override string ToString(){
            return stringVal + "of" + suit;
        }

    }
    //card property suit = club,spade,heart,diamonds
    //property val which is ints 1-13
    //card property suit = club,spade,heart,diamonds
    //property val which is ints 1-13
    //by default if i were to console write the card object it would tell me a string representation of the data type
    //using overried it will instead show me the information from the object;
}