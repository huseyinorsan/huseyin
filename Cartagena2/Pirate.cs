using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cartagena2
{
    class Pirate
    {

        movePirate movePirateBehavior = new movePirateBackwards();

        public void setPirateMoveBehavior(movePirate moveBehavior)
        {
            movePirateBehavior = moveBehavior;
        }

        public void performMove()
        {
            movePirateBehavior.move();
        }

        private int id;
        private int color;

    }
}
