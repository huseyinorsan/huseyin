using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cartagena2
{
    class movePirateForward : movePirate
    {
        public void move()
        {
            Form2 myform = new Form2();
            myform.Text = "forward";
        }
    }
}
