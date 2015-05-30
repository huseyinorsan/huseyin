using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Windows.Forms;
using System.Drawing;

namespace Cartagena2
{
    class CartagenaBoard
    {
        private static CartagenaBoard uniqueInstance;//singleton

        public static CartagenaBoard getInstance()
        {
            if (uniqueInstance == null)
            {
                uniqueInstance = new CartagenaBoard();

            }
            return uniqueInstance;
        }

   
        Image[] sekil = new Image[6];

        public Card[] cards = new Card[102];

        public Card pcard = new Card();

        public int Kartsiranumber;


        public Player player1 = new Player("yellow");
        public Player player2 = new Player("green");
        public Boolean player1kartsec;
        public Boolean player2kartsec;
        
        public BoardSpace[] positions = new BoardSpace[36];

        public CartagenaBoard() {
            for (int i = 0; i < cards.Length; i++)            
                cards[i] = new Card();

            for (int i = 0; i < positions.Length; i++)
                positions[i] = new BoardSpace();
            
        }



        public void BoxsClean(Form form) 
        {

            player1.removeallcard();
            player2.removeallcard();
            for (int t = 0; t <= form.Controls.Count - 1; t++)
            {
                if (form.Controls[t].Name.Contains("gBox_Board"))
                {
                    GroupBox boxlar = (GroupBox)form.Controls[t];
                    boxlar.Dispose();
                    continue;
                }
                if (form.Controls[t].Name.Contains("gBox_Yer"))
                {
                    GroupBox boxlar = (GroupBox)form.Controls[t];
                    boxlar.Dispose();
                    continue;
                }
                if (form.Controls[t].Name.Contains("gBox_P1"))
                {
                    GroupBox boxlar = (GroupBox)form.Controls[t];
                    boxlar.Dispose();
                    continue;
                }
                if (form.Controls[t].Name.Contains("gBox_P2"))
                {
                    GroupBox boxlar = (GroupBox)form.Controls[t];
                    boxlar.Dispose();
                    continue;
                }
                if (form.Controls[t].Name.Contains("gBox_oynanan1"))
                {
                    GroupBox boxoynanan = (GroupBox)form.Controls[t];
                    boxoynanan.Dispose();
                    continue;
                }
                if (form.Controls[t].Name.Contains("oynanan"))
                {
                    GroupBox boxoynanan2 = (GroupBox)form.Controls[t];
                    boxoynanan2.Dispose();
                    continue;
                }

             

            }

        }
        public void NewBoard(Form form)
        {
            //object bname;
            //bname = System.Reflection.Assembly.GetExecutingAssembly().CreateInstance("[Cartagena2].[Form2]");
            //((Form)oform).Show();

            PictureBox oynanan1 = new PictureBox();
            PictureBox oynanan2 = new PictureBox();

            GroupBox boardname = new GroupBox();
            boardname.Width = 740;
            boardname.Height = 510;
            boardname.BackgroundImage = Cartagena2.Properties.Resources.Parchment;
            boardname.BackgroundImageLayout = ImageLayout.Stretch;
            boardname.Location = new Point(151, 0);
            boardname.Name = "gBox_Board";
            //boardname.Text = "gBox_Board";


            int boxTop = 20;

            int piratetop = 440;

            int pirateleft = 20;

            GroupBox gBox_oynanan1 = new GroupBox();
            gBox_oynanan1.Width = 110;
            gBox_oynanan1.Height = 110;
            gBox_oynanan1.Location = new Point(400, 580);
            gBox_oynanan1.Name = "gBox_oynanan1";

            GroupBox gBox_oynanan2 = new GroupBox();
            gBox_oynanan2.Width = 110;
            gBox_oynanan2.Height = 110;
            gBox_oynanan2.Location = new Point(520, 580);
            gBox_oynanan2.Name = "gBox_oynanan2";

            GroupBox gBox_P1 = new GroupBox();
            gBox_P1.Width = 148;
            gBox_P1.Height = 509;
            gBox_P1.Location = new Point(0, 0);
            gBox_P1.BackgroundImageLayout = ImageLayout.Stretch;
            gBox_P1.Name = "gBox_P1";

            GroupBox gBox_P2 = new GroupBox();
            gBox_P2.Width = 148;
            gBox_P2.Height = 509;
            gBox_P2.Location = new Point(896, 0);
            gBox_P2.BackgroundImageLayout = ImageLayout.Stretch;
            gBox_P2.Name = "gBox_P2";

            sekil[0] = Cartagena2.Properties.Resources.pistol;
            sekil[1] = Cartagena2.Properties.Resources.sword;
            sekil[2] = Cartagena2.Properties.Resources.key;
            sekil[3] = Cartagena2.Properties.Resources.cap;
            sekil[4] = Cartagena2.Properties.Resources.bottle;
            sekil[5] = Cartagena2.Properties.Resources.flag;
            
            int satir1Left = 145;
            int satir1Top = 425;
            int satir2Left = 35;
            int satir2Top = 300;
            int satir3Left = 30;
            int satir3Top = 180;
            int satir4Left = 145;
            int satir4Top = 60;
            int boxswitdh = ((boardname.Width - satir1Left) / 8) - 30;
            int piratewidth = 20;

            //************************************************************
            //kartlistesi oluştur. Başlangıç
            //************************************************************

            ArrayList CardArray = new ArrayList(); // boarda dagıtılacak 6 farklı imge 6 şar adetten tablo ile dağıttım. 
            //çünkü random olunca bazen 3 aynı tipte kart ard arda geliyor. 
            int[,] puzzle = new int[,] { { 1,1 }, { 1, 2 }, { 1, 3 }, { 1, 4 }, { 1, 6 }, { 1,5 },
                                         { 2,2 }, { 2, 3 }, { 2, 4 }, { 2, 5 }, { 2, 1 }, { 2,6 },
                                         { 3,3 }, { 3, 4 }, { 3, 5 }, { 3, 6 }, { 3, 2 }, { 3,1 },
                                         { 4,4 }, { 4, 5 }, { 4, 6 }, { 4, 1 }, { 4, 3 }, { 4,2 },
                                         { 5,5 }, { 5, 6 }, { 5, 1 }, { 5, 2 }, { 5, 4 }, { 5,3 },
                                         { 6,6 }, { 6, 1 }, { 6, 2 }, { 6, 3 }, { 6, 5 }, { 6,4 }};



            List<int> CardArr = new List<int>();
            
            CardDoldur(CardArr);

          

            Random random = new Random();
            int rastgele = random.Next(1, 6);

            int cardId = 0;
            int cardIdMod = 0;
            int cardNumber = 0;

            for (int i = 0; i < positions.Length; i++)
            {
                int number = rastgele % 6;
                CardArray.Add(puzzle[number, 1]);
                rastgele++;

                ////////////////////////////////////////

                cardId = (int)(CardArray[i]);
                cardIdMod = (int)CardArray[i] % 6;

                PictureBox boxs = new PictureBox();
                boxs.Width = boxswitdh;
                if (cardNumber >= 0 && cardNumber <= 7)
                {
                    boxs.Top = satir1Top;
                    boxs.Left = satir1Left;
                    satir1Left += boxs.Width + 30;
                    satir2Left = satir1Left - boxs.Width - 30;
                }
                if (cardNumber >= 8 && cardNumber <= 17)
                {
                    boxs.Top = satir2Top;
                    boxs.Left = satir2Left;
                    satir2Left -= boxs.Width + 25;
                    //satir3Left = satir2Left - boxs.Width;
                }

                if (cardNumber >= 18 && cardNumber <= 27)
                {
                    boxs.Top = satir3Top;
                    boxs.Left = satir3Left;
                    satir3Left += boxs.Width + 25;
                    satir4Left = satir3Left - boxs.Width- 20;
                }

                if (cardNumber >= 28 && cardNumber <= 35)
                {
                    boxs.Top = satir4Top;
                    boxs.Left = satir4Left;
                    satir4Left -= boxs.Width + 30;
                }
                
                //positions[i].setType(cardIdMod);

                //boxs.Image = sekil[cardIdMod];

                positions[i].setType((int)CardArr[i]);

                boxs.Image = sekil[(int)CardArr[i]];
                boxs.SizeMode = PictureBoxSizeMode.StretchImage;
                boxs.BorderStyle = BorderStyle.FixedSingle;
                boxs.Name = "Boxs" + cardNumber.ToString();
                cardNumber++;
                boxs.BackColor = Color.DarkGoldenrod;
                boxs.Click += delegate
                {
                    ToolTip tt = new ToolTip();
                    tt.SetToolTip(boxs, boxs.Image.ToString());
                    //MessageBox.Show(boxs.Name);
                };


                for (int p = 0; p < 3; p++)
                {

                    PictureBox boxsp = new PictureBox();
                    boxsp.Width = 15;
                    boxsp.Height = 15;
                    
                    switch (p)
                    {
                        case 0:
                            boxsp.Top = 1;
                            boxsp.Left = 1;
                            break;
                        case 1:
                            boxsp.Top = 1;
                            boxsp.Left = 25;
                            break;
                        case 2:
                            boxsp.Top = 30;
                            boxsp.Left = 1;
                            break;
                    }
                        
                    boxsp.SizeMode = PictureBoxSizeMode.StretchImage;
                    //boxsp.BorderStyle = BorderStyle.FixedSingle;
                    boxsp.Name = boxs.Name + "P" + p;
                    boxsp.Visible = false;
                    //boxsp.BackColor = Color.Transparent;
                    boxsp.Click += delegate
                    {
                        //ToolTip tt = new ToolTip();
                        //tt.SetToolTip(boxsp, boxsp.Image.ToString());
                        int deee = int.Parse(boxs.Name.Substring(4, boxs.Name.Length - 4));

                        if (boxsp.BackColor == Color.Yellow)
                        {
                            if (player1kartsec == true)
                            {
                                player1kartsec = false;

                                if (player1.removeCard(player1.paktifcard) == 1)
                                {
                                    string deneme = "P1Label" + player1.paktifcard.CardName;

                                    for (int t = 0; t <= gBox_P1.Controls.Count - 1; t++)
                                    {
                                        if (gBox_P1.Controls[t].Name.Contains(deneme))
                                        {
                                            int itextcount = int.Parse(gBox_P1.Controls[t].Text);
                                            itextcount = itextcount - 1;
                                            gBox_P1.Controls[t].Text = itextcount.ToString();
                                        }
                                    }
                                    CartagenaBoard.getInstance().player1.pirates[0].setPirateMoveBehavior(new movePirateForward());
                                    CartagenaBoard.getInstance().player1.pirates[0].performMove(form, boxs.Name.ToString());

                                }
                            }
                            else
                            { }
                            //CartagenaBoard.getInstance().positions[deee].removePirate( int.Parse(boxsp.Name.Substring(boxsp.Name.Length-1,1)));
                            //}
                            //MessageBox.Show(boxsp.Name);
                        }

                        
                    };
                    boxs.Controls.Add(boxsp);
                }

                boardname.Controls.Add(boxs);
                //Form1.ActiveForm.Controls.Add(boxs);
            }







            int randsayi;
            // 102 Adet kart : 6 farklı imge 17 adetten random karıştırılıyor.

            for (int j = 0; j < cards.Length; j++)
                cards[j].CardName = null;

            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 17; j++)
                {
                    Random rand = new Random();
                    randsayi = rand.Next(0, 102);

                    while (!(cards[randsayi].CardName == null))
                    {
                        randsayi = rand.Next(0, 102);

                    }
                    cards[randsayi].CardName = i.ToString();
                    //Kartdeste[randsayi] = i.ToString();

                }

            }

            GroupBox yerkart = new GroupBox();
            yerkart.Width = 740;
            yerkart.Height = 80;
            yerkart.Location = new Point(151, 510);
            yerkart.BackgroundImageLayout = ImageLayout.Stretch;
            yerkart.Name = "gBox_Yer";
            //yerkart.Text = "gBox_Yer";


            int boxLeft = 30;

            for (int i = 0; i < 12; i++) // yere dağıtılıcak 12 kart kardeste den alınıyor.
            {

                PictureBox boxs6 = new PictureBox();
                boxs6.Top = 18;
                boxs6.Left = boxLeft;
                boxs6.Width = boxswitdh;


                boxs6.Image = sekil[int.Parse(cards[i].CardName)];
                boxs6.SizeMode = PictureBoxSizeMode.StretchImage;
                boxs6.BorderStyle = BorderStyle.FixedSingle;
                boxs6.Name = "YerBoxs" + i.ToString();
                boxs6.BackColor = Color.DarkGoldenrod;
                boxs6.Click += delegate
                {
                    ToolTip tt = new ToolTip();
                    tt.SetToolTip(boxs6, boxs6.Image.ToString());
                    //MessageBox.Show(boxs6.Name);

                };
                
                yerkart.Controls.Add(boxs6);
                boxLeft = boxLeft + 60;
            }

   
        

            

            for (int i = 0; i < 6; i++) // Oyuncuların kartları  forma resim olarak konuluyor. 
            {
                Label P1Label = new Label();
                Font font = new Font("Microsoft Sans Serif", 9.0f, FontStyle.Bold);

                if (i == 3)
                {
                    piratetop = piratetop + 40;
                    pirateleft = 20;
                }

                P1Label.Top = boxTop;
                P1Label.Left = 70;
                P1Label.Width = 30;

                
                
                PictureBox boxs2 = new PictureBox();
                boxs2.Top = boxTop;
                boxs2.Left = 10;
                boxs2.Width = boxswitdh;

                boxs2.Image = sekil[i];
                boxs2.SizeMode = PictureBoxSizeMode.StretchImage;
                boxs2.BorderStyle = BorderStyle.FixedSingle;
                P1Label.BorderStyle = BorderStyle.FixedSingle;
                P1Label.BackColor = Color.Yellow;
                P1Label.ForeColor = Color.Black;
                P1Label.Name = "P1Label" + i.ToString();
                P1Label.Font = font;
         
                P1Label.Text = "0";
                boxs2.Name = "P1Boxs" + i.ToString();
                boxs2.BackColor = Color.DarkGoldenrod;
                boxs2.Click += delegate
                {
                    ToolTip tt = new ToolTip();
                    tt.SetToolTip(boxs2, boxs2.Image.ToString());
                    //MessageBox.Show(boxs2.Name);
                    pcard.CardName = boxs2.Name.Substring(6, 1);

                    if (player1.isCard(pcard) == 1)
                    {
                        player1kartsec = true;
                        //player1.removeCard(pcard);
                        player1.paktifcard = pcard;
                        oynanan1.Image = sekil[int.Parse(pcard.CardName)];
                        oynanan1.SizeMode = PictureBoxSizeMode.StretchImage;
                        oynanan1.BorderStyle = BorderStyle.FixedSingle;
                        oynanan1.Left = 10;
                        oynanan1.Top = 10;
                        oynanan1.Width = 100;
                        oynanan1.Height = 104;
                        oynanan1.Name = "oynanan1";
                    }
                    else
                        MessageBox.Show("Bu karttan elinizde yok");
                };

                Label P2Label = new Label();
                P2Label.Top = boxTop;
                P2Label.Left = 70;
                P2Label.Width = 30;
                PictureBox boxs3 = new PictureBox();
                boxs3.Top = boxTop;
                boxs3.Left = 10;
                boxs3.Width = boxswitdh;

                boxs3.Image = sekil[i];
                boxs3.SizeMode = PictureBoxSizeMode.StretchImage;
                boxs3.BorderStyle = BorderStyle.FixedSingle;
                P2Label.BorderStyle = BorderStyle.FixedSingle;
                P2Label.BackColor = Color.Yellow;
                P2Label.ForeColor = Color.Black;
                P2Label.Font = font;
                P2Label.Name = "P2Label" + i.ToString();
                P2Label.Text = "0";
                boxs3.Name = "P2Boxs" + i.ToString();
                boxs3.BackColor = Color.DarkGoldenrod;
                boxs3.Click += delegate
                {
                    ToolTip tt = new ToolTip();
                    tt.SetToolTip(boxs3, boxs3.Image.ToString());
                    //MessageBox.Show(boxs3.Name);
                    pcard.CardName = boxs3.Name.Substring(6, 1);
                    if (player2.isCard(pcard) == 1)
                    {
                        //player1.removeCard(pcard);
                        player2kartsec = true;
                        player2.paktifcard = pcard;
                        oynanan2.Image = sekil[int.Parse(pcard.CardName)];
                        oynanan2.SizeMode = PictureBoxSizeMode.StretchImage;
                        oynanan2.BorderStyle = BorderStyle.FixedSingle;
                        oynanan2.Left = 10;
                        oynanan2.Top = 10;
                        oynanan2.Width = 100;
                        oynanan2.Height = 104;
                        oynanan2.Name = "oynanan2";

                    }
                    else
                        MessageBox.Show("Bu karttan elinizde yok");
                };


                PictureBox boxs4 = new PictureBox();
                boxs4.Top = piratetop;
                boxs4.Height = 20;
                boxs4.Left = pirateleft;
                boxs4.Width = piratewidth;

                boxs4.BackColor = Color.Yellow;
                boxs4.SizeMode = PictureBoxSizeMode.StretchImage;
                boxs4.BorderStyle = BorderStyle.FixedSingle;

                boxs4.Name = "P1Pirate" + i.ToString();
                boxs4.Click += delegate
                {
                    if (player1kartsec)
                    {
                        player1kartsec = false; 
                        int h = int.Parse(boxs4.Name.ToString().Substring(8, 1));
                        if (player1.removeCard(player1.paktifcard) == 1)
                        {
                            string deneme = "P1Label" + player1.paktifcard.CardName;

                            for (int t = 0; t <= gBox_P1.Controls.Count - 1; t++)
                            {

                                if (gBox_P1.Controls[t].Name.Contains(deneme))
                                {
                                    int itextcount = int.Parse(gBox_P1.Controls[t].Text);
                                    itextcount = itextcount - 1;
                                    gBox_P1.Controls[t].Text = itextcount.ToString();
                                    break;
                                  
                                }
                            }
                            CartagenaBoard.getInstance().player1.pirates[h].setPirateMoveBehavior(new movePirateForward());
                            CartagenaBoard.getInstance().player1.pirates[h].performMove(form, boxs4.Name.ToString());
                        }
                    }
                    else
                    {
                        MessageBox.Show("Piyonları hareket ettirmek için önce kart seçmeliniz.");
                    }
                    ToolTip tt = new ToolTip();
                    tt.SetToolTip(boxs4, boxs4.Name.ToString());
                    //MessageBox.Show(boxs4.Name);


                };

                PictureBox boxs5 = new PictureBox();
                boxs5.Top = piratetop;
                boxs5.Height = 20;
                boxs5.Left = pirateleft;
                boxs5.Width = piratewidth;

                boxs5.BackColor = Color.Blue;
                boxs5.SizeMode = PictureBoxSizeMode.StretchImage;
                boxs5.BorderStyle = BorderStyle.FixedSingle;
               
                boxs5.Name = "P2Pirate" + i.ToString();
                boxs5.Click += delegate
                {

                    ppirategpbox(form, gBox_P2, boxs5);
                };
               

                gBox_P1.Controls.Add(P1Label);
                gBox_P1.Controls.Add(boxs2);
                gBox_P2.Controls.Add(boxs3);
                gBox_P1.Controls.Add(boxs4);
                gBox_P2.Controls.Add(boxs5);
                gBox_P2.Controls.Add(P2Label);
                boxTop = boxTop + 60;
                pirateleft = pirateleft + 30;
                 
            }
                gBox_oynanan1.Controls.Add(oynanan1);
                gBox_oynanan2.Controls.Add(oynanan2);
          
            for (int i = 12; i < 18; i++) //            //Player1 Kartları dağıtılıyor 6 adet başlangıçta...
            {
                foreach (Label item in gBox_P1.Controls.OfType<Label>())
                {
                    if (cards[i].CardName == item.Name.ToString().Substring(7, 1))
                    {                        
                        player1.addCard(cards[i]);

                        int k = int.Parse(item.Text);
                        k++;
                        item.Text = k.ToString();
                    }
                }

            }
    

            for (int i = 18; i < 24; i++) //            //Player2 Kartları dağıtılıyor 6 adet başlangıçta...
            {
                foreach (Label item in gBox_P2.Controls.OfType<Label>())
                {
                    if (cards[i].CardName == item.Name.ToString().Substring(7, 1))
                    {
                        player2.addCard(cards[i]);
                        int k = int.Parse(item.Text);
                        k++;
                        item.Text = k.ToString();
                    }
                }

            }
            
            Kartsiranumber = 24;
            form.Controls.Add(gBox_P1);
            form.Controls.Add(gBox_P2);
            form.Controls.Add(boardname);
            form.Controls.Add(yerkart);
            form.Controls.Add(gBox_oynanan1);
            form.Controls.Add(gBox_oynanan2);
        }

        private void ppirategpbox(Form form, GroupBox gBox_P2, PictureBox boxs5)
        {
            if (player2kartsec)
            {
                player2kartsec = false;
                int h = int.Parse(boxs5.Name.ToString().Substring(8, 1));
                if (player2.removeCard(player2.paktifcard) == 1)
                {

                    string deneme = "P2Label" + player2.paktifcard.CardName;

                    for (int t = 0; t <= gBox_P2.Controls.Count - 1; t++)
                    {

                        if (gBox_P2.Controls[t].Name.Contains(deneme))
                        {
                            int itextcount = int.Parse(gBox_P2.Controls[t].Text);
                            itextcount = itextcount - 1;
                            gBox_P2.Controls[t].Text = itextcount.ToString();

                        }
                    }

                    CartagenaBoard.getInstance().player2.pirates[h].setPirateMoveBehavior(new movePirateForward());
                    CartagenaBoard.getInstance().player2.pirates[h].performMove(form, boxs5.Name.ToString());
                }
            }
            else
            {
                MessageBox.Show("Piyonları hareket ettirmek için önce kart seçmeliniz.");

            }
            ToolTip tt = new ToolTip();
            tt.SetToolTip(boxs5, boxs5.Name.ToString());
            //MessageBox.Show(boxs5.Name);
        }

        private static void CardDoldur(List <int> CardArr)
        {
            for (int i = 0; i < 6; i++)
            {
                CardArr.Add(0);
                CardArr.Add(1);
                CardArr.Add(2);
                CardArr.Add(3);
                CardArr.Add(4);
                CardArr.Add(5);
            }

            int rast;
            int temp;
            Random random1 = new Random();

            for (int i = 0; i < 36; i++)
            {
                rast = random1.Next(0, 35);
                temp = CardArr[rast];
                CardArr[rast] = CardArr[i];
                CardArr[i] = temp;
            }
        }
    }
}
