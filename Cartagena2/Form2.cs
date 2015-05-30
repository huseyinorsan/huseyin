using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections;

namespace Cartagena2
{
    public partial class Form2 : Form
    {
        Image[] sekil = new Image[6];
        //Cartegana newgame = new Cartegana();
        //Cartegana newgame;// = Cartegana.getInstance();
        
        Random s = new Random(); //Board kartları için random sayı üret
        public Form2()
        {
            InitializeComponent();
            sekil[0] = Cartagena2.Properties.Resources.pistol;
            sekil[1] = Cartagena2.Properties.Resources.sword;
            sekil[2] = Cartagena2.Properties.Resources.key;
            sekil[3] = Cartagena2.Properties.Resources.cap;
            sekil[4] = Cartagena2.Properties.Resources.bottle;
            sekil[5] = Cartagena2.Properties.Resources.flag;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            //CartagenaBoard CartagenaBoard = new CartagenaBoard();
            //CartagenaBoard.BoxsClean(this);
            //CartagenaBoard.NewBoard(this);

        }

        private void button2_Click(object sender, EventArgs e)
        {


            CartagenaBoard.getInstance().BoxsClean(this);
            CartagenaBoard.getInstance().NewBoard(this);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            CartagenaBoard.getInstance().player1.pirates[0].setPirateMoveBehavior(new movePirateBackwards());
            CartagenaBoard.getInstance().player1.pirates[0].performMove(this,"aa");
        }

        private void Form2_MouseClick(object sender, MouseEventArgs e)
        {

        }



    }
}
