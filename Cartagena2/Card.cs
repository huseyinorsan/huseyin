using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cartagena2
{
    class Card
    {
        public int id;
        public string CardName
        {
            get { return CardName; }
            set { CardName = value; }
        }
        public string toString() {
            string[] kartlar = new string[] { "pistol", "sword", "key", "cap", "bottle", "flag" };

            return kartlar[id];
        }

    }
}
