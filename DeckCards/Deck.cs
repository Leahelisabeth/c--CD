using System;
using System.Collections.Generic;
namespace ConsoleApplication
{
    public class Deck
    {
        public List<Card> cards;
     
        public List<Card> Reset(){
            cards = new List<Card>();
            int i = 1;
                while(i < 14 ){
                    cards.Add(new Card("Spade", i));
                    cards.Add(new Card("Club", i));
                    cards.Add(new Card("Diamond", i));
                    cards.Add(new Card("Heart", i));
                    i++;
                }

                return cards;
        }
        public Deck(){
            Reset();
        }
        
        public Card Deal(){
            if(cards.Count > 0){
            Card _card = cards[0];
            cards.RemoveAt(0);
            return _card;
            }
            return null;
        }
        public Deck shuffle(){
            Random rando = new Random();
            for (int i = cards.Count -1; i > 0; i--){
                int index = rando.Next(i);
                Card tmp = cards[index];
                cards[index] = cards[i];
                cards[i] = tmp;

            }
            return this;
        }
        public override string ToString() {
            string info = "";
            foreach(Card card in cards) {
                info += card + "\n";
            }
            return info;
        }

    }
}
//this is returned so you can chain methods--