using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Cartagena2
{
    class Cartegana
    {
        public Pirate[] pirates = new Pirate[12];

        public Cartegana() {
            for (int i = 0; i < pirates.Length; i++) {
                pirates[i] = new Pirate();
            }
        }

        private static byte numberOfPlayers = 2;

        private static Cartegana uniqueInstance;

        public static Cartegana getInstance() {
            if (uniqueInstance == null)
            {
                uniqueInstance = new Cartegana();

            }
            return uniqueInstance;
        }
        public CartagenaBoard board = new CartagenaBoard();
        
        private Card cards = new Card();
        

        //public Pirate pirates = new Pirate();
        

        public Player[] players = new Player[numberOfPlayers];
        
        public int createPlayer(){
           
            return 0;
        }

        public Drive move() {
            Drive aaa = new Drive();
            return aaa;
        }


    }
}
