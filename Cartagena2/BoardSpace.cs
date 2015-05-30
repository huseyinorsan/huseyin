using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Cartagena2
{
    class BoardSpace
    {
        private int type;
        private int numberOfPirate;
        private Pirate[] pirates = new Pirate[3];

        public BoardSpace() {
            pirates[0] = null;
            pirates[1] = null;
            pirates[2] = null;
            numberOfPirate = 0;
        }

        public int getType() {
            return type;
        }

        public void setType(int val) {
            type = val;
        }

        public void addPirate(Pirate pirate){
            if (numberOfPirate < 3)
            {
                pirates[numberOfPirate] = pirate;
                numberOfPirate++;
            }
        }

        public int getNumberOfPirates() {

            if (numberOfPirate ==0)
            {
                return 0;
            }
            else
            return numberOfPirate;
        }

        public void removePirate(int pnumber){
            if (numberOfPirate > 0)
            {
                pirates[pnumber] = null;
                numberOfPirate--;
            }
        }
    }
}
