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

        //public object boardname { get; set; }

        Image[] sekil = new Image[6];

        
        public static String[] Kartdeste = new String[102];

        public int Kartsiranumber;


  

        public void BoxsClean(Form form) 
        {
            for (int t = 0; t <= form.Controls.Count - 1; t++)
            {
                if (form.Controls[t].Name.Contains("gBox_Board"))
                {
                    GroupBox boxlar = (GroupBox)form.Controls[t];
                    boxlar.Dispose();
                }
                if (form.Controls[t].Name.Contains("gBox_Yer"))
                {
                    GroupBox boxlar = (GroupBox)form.Controls[t];
                    boxlar.Dispose();
                }
            }

        }
        public void NewBoard(Form form)
        {
            //object bname;
            //bname = System.Reflection.Assembly.GetExecutingAssembly().CreateInstance("[Cartagena2].[Form2]");
            //((Form)oform).Show();

            GroupBox boardname = new GroupBox();
            boardname.Width = 740;
            boardname.Height = 510;
            boardname.BackgroundImage = Cartagena2.Properties.Resources.Parchment;
            boardname.BackgroundImageLayout = ImageLayout.Stretch;
            boardname.Location = new Point(151, 0);
            boardname.Name = "gBox_Board";
            //boardname.Text = "gBox_Board";

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
            
            
            Random random = new Random();
            int rastgele = random.Next(1, 6);

            int cardId = 0;
            int cardIdMod = 0;
            int cardNumber = 0;

            for (int i = 0; i < 36; i++)
            {
                int number = rastgele % 6;
                CardArray.Add(puzzle[number, 1]);
                rastgele++;

                ////////////////////////////////////////
                cardNumber++;
                cardId = (int)(CardArray[i]);
                cardIdMod = (int)CardArray[i] % 6;

                PictureBox boxs = new PictureBox();
                boxs.Width = boxswitdh;
                if (cardNumber >= 1 && cardNumber <= 8)
                {
                    boxs.Top = satir1Top;
                    boxs.Left = satir1Left;
                    satir1Left += boxs.Width + 30;
                    satir2Left = satir1Left - boxs.Width - 30;
                }
                if (cardNumber >= 9 && cardNumber <= 18)
                {
                    boxs.Top = satir2Top;
                    boxs.Left = satir2Left;
                    satir2Left -= boxs.Width + 25;
                    //satir3Left = satir2Left - boxs.Width;
                }

                if (cardNumber >= 19 && cardNumber <= 28)
                {
                    boxs.Top = satir3Top;
                    boxs.Left = satir3Left;
                    satir3Left += boxs.Width + 25;
                    satir4Left = satir3Left - boxs.Width- 20;
                }

                if (cardNumber >= 29 && cardNumber <= 36)
                {
                    boxs.Top = satir4Top;
                    boxs.Left = satir4Left;
                    satir4Left -= boxs.Width + 30;
                }

                boxs.Image = sekil[cardIdMod];
                boxs.SizeMode = PictureBoxSizeMode.StretchImage;
                boxs.BorderStyle = BorderStyle.FixedSingle;
                boxs.Name = "Boxs" + cardNumber.ToString();
                boxs.BackColor = Color.DarkGoldenrod;
                boxs.Click += delegate
                {
                    ToolTip tt = new ToolTip();
                    tt.SetToolTip(boxs, boxs.Image.ToString());
                    MessageBox.Show(boxs.Name);
                };

                boardname.Controls.Add(boxs);
                //Form1.ActiveForm.Controls.Add(boxs);
            }
            int randsayi;
            // 102 Adet kart : 6 farklı imge 17 adetten random karıştırılıyor.


                for (int j = 0; j < 102; j++)
                    Kartdeste[j] = null;

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

                PictureBox boxs2 = new PictureBox();
                boxs2.Top = 18;
                boxs2.Left = boxLeft;
                boxs2.Width = boxswitdh;


                boxs2.Image = sekil[int.Parse(Kartdeste[i])];
                boxs2.SizeMode = PictureBoxSizeMode.StretchImage;
                boxs2.BorderStyle = BorderStyle.FixedSingle;
                boxs2.Name = "YerBoxs" + i.ToString();
                boxs2.BackColor = Color.DarkGoldenrod;
                boxs2.Click += delegate
                {
                    ToolTip tt = new ToolTip();
                    tt.SetToolTip(boxs2, boxs2.Image.ToString());
                    MessageBox.Show(boxs2.Name);
                };
                
                yerkart.Controls.Add(boxs2);
                boxLeft = boxLeft + 60;
            }

            


            int boxTop = 20;
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

            for (int i = 0; i < 6; i++) // Oyuncuların kartları  forma resim olarak konuluyor. 
            {
                Label P1Label = new Label();
                Font font = new Font("Microsoft Sans Serif", 9.0f, FontStyle.Bold);


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
                    MessageBox.Show(boxs2.Name);
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

                //boxs3.MouseMove +=new MouseEventHandler(boxs3.MouseMove());
                //{
                
                
                //};

                boxs3.Click += delegate
                {
                    ToolTip tt = new ToolTip();
                    tt.SetToolTip(boxs3, boxs3.Image.ToString());
                    MessageBox.Show(boxs3.Name);
                };
               

                gBox_P1.Controls.Add(P1Label);
                gBox_P1.Controls.Add(boxs2);
                gBox_P2.Controls.Add(boxs3);
                gBox_P2.Controls.Add(P2Label);
                boxTop = boxTop + 60;
            }


            string dd = "0";
            foreach (Label item in gBox_P1.Controls.OfType<Label>())
                {
                    //MessageBox.Show(item.Name.ToString());
                    if (item.Name.ToString().Substring(7,1)==dd)
                    {
                        item.Text = "8";
                    }    
                }
            //int iKartSayi = 0;

            //for (int i = 12; i < 18; i++) //            //Player1 Kartları dağıtılıyor 6 adet başlangıçta...
            //{
            //    if (Kartdeste[i] == "0")
            //    {
            //        gBox_P1.Controls.
            //        iKartSayi = int.Parse(P2Label.Text) + 1;
            //    }

            //}

            
            Kartsiranumber = 24;
            form.Controls.Add(gBox_P1);
            form.Controls.Add(gBox_P2);
            form.Controls.Add(boardname);
            form.Controls.Add(yerkart);
            //MessageBox.Show("22");
        }
    }
}
