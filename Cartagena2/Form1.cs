using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Cartagena2.Properties;
using Cartagena2;

namespace Cartagena2
{
    public partial class Form1 : Form
    {
        int iyer;
        Image[] sekil = new Image[6]; 
               
        public Form1()
        {
            InitializeComponent();
            sekil[0] = Cartagena2.Properties.Resources.pistol;
            sekil[1] = Cartagena2.Properties.Resources.sword;
            sekil[2] = Cartagena2.Properties.Resources.key;
            sekil[3] = Cartagena2.Properties.Resources.cap;
            sekil[4] = Cartagena2.Properties.Resources.bottle;
            sekil[5] = Cartagena2.Properties.Resources.flag;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

       
            colorComboBox1.Items.AddRange(new object[] {
            System.Drawing.Color.Blue,
            System.Drawing.Color.Red,
            System.Drawing.Color.Yellow,
            System.Drawing.Color.Green});

            colorComboBox2.Items.AddRange(new object[] {
            System.Drawing.Color.Blue,
            System.Drawing.Color.Red,
            System.Drawing.Color.Yellow,
            System.Drawing.Color.Green});

        }

        private void button1_Click(object sender, EventArgs e)
        {
            iyer = 0;
            String[] Kartdeste = new String[102];
            int[,] Player1 = new int[6,1];
            int[,] Player2 = new int[6,1];
            String[,] Tahta = new String[36, 4];
            String[] Yer = new String[12];

            String[] Karttablo = new String[6];
          


            PictureBox[] Player2Piyon = new PictureBox[6];

            Player2Piyon[0] = pictureBox189;
            Player2Piyon[1] = pictureBox190;
            Player2Piyon[2] = pictureBox191;
            Player2Piyon[3] = pictureBox192;
            Player2Piyon[4] = pictureBox193;
            Player2Piyon[5] = pictureBox194;

            PictureBox[] Player1Piyon = new PictureBox[6];

            Player1Piyon[0] = pictureBox183;
            Player1Piyon[1] = pictureBox184;
            Player1Piyon[2] = pictureBox185;
            Player1Piyon[3] = pictureBox186;
            Player1Piyon[4] = pictureBox187;
            Player1Piyon[5] = pictureBox188;


            PictureBox[] Player1CardPic = new PictureBox[6];

            Player1CardPic[0] = pictureBox50;
            Player1CardPic[1] = pictureBox51;
            Player1CardPic[2] = pictureBox52;
            Player1CardPic[3] = pictureBox53;
            Player1CardPic[4] = pictureBox54;
            Player1CardPic[5] = pictureBox55;

            PictureBox[] Player2CardPic = new PictureBox[6];

            Player2CardPic[0] = pictureBox56;
            Player2CardPic[1] = pictureBox57;
            Player2CardPic[2] = pictureBox58;
            Player2CardPic[3] = pictureBox59;
            Player2CardPic[4] = pictureBox60;
            Player2CardPic[5] = pictureBox61;

            Label[] Player1CardCount = new Label[6];

            Player1CardCount[0] = label1;
            Player1CardCount[1] = label2;
            Player1CardCount[2] = label3;
            Player1CardCount[3] = label4;
            Player1CardCount[4] = label5;
            Player1CardCount[5] = label6;

            Label[] Player2CardCount = new Label[6];

            Player2CardCount[0] = label7;
            Player2CardCount[1] = label8;
            Player2CardCount[2] = label9;
            Player2CardCount[3] = label10;
            Player2CardCount[4] = label11;
            Player2CardCount[5] = label12;
           
                 

            PictureBox[] tahtacard = new PictureBox[36];
            tahtacard[0] = pictureBox2;
            tahtacard[1] = pictureBox3;
            tahtacard[2] = pictureBox4;
            tahtacard[3] = pictureBox5;
            tahtacard[4] = pictureBox6;
            tahtacard[5] = pictureBox7;
            tahtacard[6] = pictureBox8;
            tahtacard[7] = pictureBox9;
            tahtacard[8] = pictureBox10;
            tahtacard[9] = pictureBox11;
            tahtacard[10] = pictureBox12;
            tahtacard[11] = pictureBox13;
            tahtacard[12] = pictureBox14;
            tahtacard[13] = pictureBox15;
            tahtacard[14] = pictureBox16;
            tahtacard[15] = pictureBox17;
            tahtacard[16] = pictureBox18;
            tahtacard[17] = pictureBox19;
            tahtacard[18] = pictureBox20;
            tahtacard[19] = pictureBox21;
            tahtacard[20] = pictureBox22;
            tahtacard[21] = pictureBox23;
            tahtacard[22] = pictureBox24;
            tahtacard[23] = pictureBox25;
            tahtacard[24] = pictureBox26;
            tahtacard[25] = pictureBox27;
            tahtacard[26] = pictureBox28;
            tahtacard[27] = pictureBox29;
            tahtacard[28] = pictureBox30;
            tahtacard[29] = pictureBox31;
            tahtacard[30] = pictureBox32;
            tahtacard[31] = pictureBox33;
            tahtacard[32] = pictureBox34;
            tahtacard[33] = pictureBox35;
            tahtacard[34] = pictureBox36;
            tahtacard[35] = pictureBox37;



            PictureBox[] yercard = new PictureBox[12];
            yercard[0] = pictureBox38;
            yercard[1] = pictureBox39;
            yercard[2] = pictureBox40;
            yercard[3] = pictureBox41;
            yercard[4] = pictureBox42;
            yercard[5] = pictureBox43;
            yercard[6] = pictureBox44;
            yercard[7] = pictureBox45;
            yercard[8] = pictureBox46;
            yercard[9] = pictureBox47;
            yercard[10] = pictureBox48;
            yercard[11] = pictureBox49;


            int k;
            int randsayi;
            listBox1.Items.Clear();
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 17; j++)
                {
                    Random rand = new Random();
                    randsayi = rand.Next(0, 102);
                    while (!(Kartdeste[randsayi] == null))
                    {
                        randsayi = rand.Next(0, 102);

                    }
                    Kartdeste[randsayi] = i.ToString();

                }

            }
            for (int h = 0; h < 102; h++)
            {


                listBox1.Items.Add(Kartdeste[h].ToString());

            }

            for (int l = 0; l < 102; l++)
            {
                listBox2.Items.Add(Kartdeste[l]);
            }

            int kartadet = 0;
            Application.DoEvents();
            for (int y = 0; y < 6; y++)
            {
                for (int j = 0; j < 6; j++)
                {
                    if (j == int.Parse(Kartdeste[iyer]))
                        Player1[j, 0] = Player1[j, 0] + 1;
                    if (j == int.Parse(Kartdeste[iyer + 6]))
                        Player2[j, 0] = Player2[j, 0] + 1;

                    //listBox1.Items.Add("1.Oyuncu kartı : " + Player1[j]);
                    //listBox1.Items.Add("2.Oyuncu kartı : " + Player2[j]);
                    
                }
                iyer++;
            }
            Application.DoEvents();
            int model=0;

            for (k = 1; k < 7; k++)
            {
                Random rand = new Random();
                randsayi = rand.Next(0, 6);
                while (!(Karttablo[randsayi] == null))
                {
                    randsayi = rand.Next(0, 6);

                }

                Karttablo[randsayi] = k.ToString();
            }

            model = 0;
                 
                    for (int h = 0; h < 6; h++)
                    {
                        if (Karttablo[h] == "1")
                        {
                            
                            tahtacard[model].Image = sekil[0];
                            tahtacard[model + 1].Image = sekil[1]; 
                            tahtacard[model + 2].Image = sekil[2];
                            tahtacard[model + 3].Image = sekil[3];
                            tahtacard[model + 4].Image = sekil[4];
                            tahtacard[model + 5].Image = sekil[5];
                        }
                        if (Karttablo[h] == "2")
                        {

                            tahtacard[model].Image = sekil[3];
                            tahtacard[model + 1].Image = sekil[2];
                            tahtacard[model + 2].Image = sekil[1];
                            tahtacard[model + 3].Image = sekil[4];
                            tahtacard[model + 4].Image = sekil[5];
                            tahtacard[model + 5].Image = sekil[0];
                        }
                        if (Karttablo[h] == "3")

                        {

                            tahtacard[model].Image = sekil[5];
                            tahtacard[model + 1].Image = sekil[2];
                            tahtacard[model + 2].Image = sekil[3];
                            tahtacard[model + 3].Image = sekil[4];
                            tahtacard[model + 4].Image = sekil[0];
                            tahtacard[model + 5].Image = sekil[1];
                        }
                        if (Karttablo[h] == "4")
                        {

                            tahtacard[model].Image = sekil[4];
                            tahtacard[model + 1].Image = sekil[0];
                            tahtacard[model + 2].Image = sekil[2];
                            tahtacard[model + 3].Image = sekil[1];
                            tahtacard[model + 4].Image = sekil[5];
                            tahtacard[model + 5].Image = sekil[3];
                        }
                        if (Karttablo[h] == "5")
                        {

                            tahtacard[model].Image = sekil[2];
                            tahtacard[model + 1].Image = sekil[3];
                            tahtacard[model + 2].Image = sekil[5];
                            tahtacard[model + 3].Image = sekil[1];
                            tahtacard[model + 4].Image = sekil[0];
                            tahtacard[model + 5].Image = sekil[4];
                        }
                        if (Karttablo[h] == "6")
                        {

                            tahtacard[model].Image = sekil[1];
                            tahtacard[model + 1].Image = sekil[3];
                            tahtacard[model + 2].Image = sekil[4];
                            tahtacard[model + 3].Image = sekil[0];
                            tahtacard[model + 4].Image = sekil[5];
                            tahtacard[model + 5].Image = sekil[2];
                        }
                        model = model + 6;

                    }

 
            iyer += 6;

            for (int i = 0; i < 6; i++)
            {
                Player1CardPic[i].Image = sekil[i];
                Player2CardPic[i].Image = sekil[i];
                Player1CardCount[i].Text = Player1[i, 0].ToString();
                Player2CardCount[i].Text = Player2[i, 0].ToString();

                Player1Piyon[i].BackColor = colorComboBox1.Color;
                Player2Piyon[i].BackColor = colorComboBox2.Color;
                Player1Piyon[i].Visible = true;
                Player2Piyon[i].Visible = true;

            
            }
            for (k = 0; k < 12; k++)
            {

                yercard[k].Image = sekil[int.Parse(Kartdeste[iyer])];
                iyer++;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox62_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox50_Click(object sender, EventArgs e)
        {
            if (int.Parse(label1.Text) > 0)
            {
                int den = int.Parse(label1.Text) ;

                den -= 1;
                pictureBox62.Image = pictureBox50.Image;
                label1.Text = den.ToString();


            }
        }
    }
}
