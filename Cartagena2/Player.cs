using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;


namespace Cartagena2
{
    class Player
    {
        private List<Card> pcards = new List<Card>();
        public List<Pirate> pirates = new List<Pirate>();

        private Card paktif = new Card();

        public Card paktifcard
        {
            get { return paktif; }
            set { paktif = value; }
        }

        public Player(string val) {

            for (int i = 0; i < 6; i++)
            {
                pirates.Add(new Pirate());
                pirates[i].color = val;
            }


        }

     
        public List<Card> getCards() {
            return pcards;
        }

        public void addCard(Card card) {
            pcards.Add(card);

        }

        public void addPirate(Pirate pirate)
        {
            pirates.Add(pirate);

        }

 

        public byte removeCard(Card card){

            for (int j = 0; j < pcards.Count; j++)
            {
                if (pcards[j].CardName == card.CardName)
                {
                    pcards.RemoveAt(j);

                    return 1;

                }
            }
            return 0;
            
        }
        public void removeallcard() {
            for (int i = pcards.Count; i>0 ; i--)
            {
              
                    pcards.RemoveAt(i-1);
   
            }
        }

        public Byte isCard(Card card)
        {
            for (int j = 0; j < pcards.Count; j++)
            {
                if (pcards[j].CardName == card.CardName)
                    return 1;
            }
            return 0;
        }
    }
}
