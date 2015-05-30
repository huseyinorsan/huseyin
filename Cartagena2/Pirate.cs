using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Cartagena2
{
    class Pirate
    {

        moveBehavior movePirateBehavior;

        public void setPirateMoveBehavior(moveBehavior moveBehavior)
        {
            movePirateBehavior = moveBehavior;
        }

        public void performMove(Form form, string piratename)
        {
            movePirateBehavior.move(form, piratename);
        }

        private int id;
        public string color;

    }
}
