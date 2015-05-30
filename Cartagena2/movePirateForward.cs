using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace Cartagena2
{
    class movePirateForward : moveBehavior
    {

        int playercardtype;
        Pirate mpirate;
        private string spirate;
        private Color color = new Color();
        public void move(Form form, string piratename)
        {
            
            for (int t = 0; t <= form.Controls.Count - 1; t++)
            {

                if (form.Controls[t].Name.Contains("gBox_P1") || form.Controls[t].Name.Contains("gBox_P2"))
                {
                    GroupBox boxlar = (GroupBox)form.Controls[t];
                    for (int j = 0; j <= boxlar.Controls.Count - 1; j++)
                    {
                       
                        if (boxlar.Controls[j].Name.Contains(piratename))
                        {

                            if (piratename.Substring(0, 2) == "P1")
                            {
                                playercardtype = int.Parse(CartagenaBoard.getInstance().player1.paktifcard.CardName);
                                mpirate = CartagenaBoard.getInstance().player1.pirates[int.Parse(piratename.Substring(8,1))];
                                color = Color.Yellow;
                            }
                            else
                            {
                                playercardtype = int.Parse(CartagenaBoard.getInstance().player2.paktifcard.CardName);
                                mpirate = CartagenaBoard.getInstance().player2.pirates[int.Parse(piratename.Substring(8, 1))];
                                color = Color.DarkBlue;
                            }
                            for (int k = 0; k < CartagenaBoard.getInstance().positions.Length; k++)
                            {


                                if (CartagenaBoard.getInstance().positions[k].getType() == playercardtype)
                                {
                                    if (CartagenaBoard.getInstance().positions[k].getNumberOfPirates() > 0)
                                    {
                                        continue;
                                    }

                                    else
                                    {
                                        //CartagenaBoard.getInstance().positions[k].addPirate(CartagenaBoard.getInstance().player1.pirates[l]);
                                        
                                        boxlar.Controls[j].Dispose();
                                        String sbox= "Boxs"+k.ToString();

                                        for (int l = 0; l <= form.Controls.Count - 1; l++)
                                        {
                                            if (form.Controls[l].Name.Contains("gBox_Board"))
                                            {
                                                GroupBox yerbox = (GroupBox)form.Controls[l];

                                                for (int d = 0; d <= yerbox.Controls.Count - 1; d++)
                                                {


                                                    if (yerbox.Controls[d].Name.Contains(sbox))
                                                    {
                                                        PictureBox boxlar3 = (PictureBox)yerbox.Controls[d];  
                                                          for (int m = 0; m <= boxlar3.Controls.Count - 1; m++)
                                                          {

                                                              if (CartagenaBoard.getInstance().positions[k].getNumberOfPirates() == 0)
                                                              {
                                                                  spirate = "";
                                                                  spirate = sbox + "P0";

                                                              }
                                                              else if (CartagenaBoard.getInstance().positions[k].getNumberOfPirates() == 1)
                                                              {
                                                                  spirate = "";
                                                                  spirate = sbox + "P1";
                                                              }
                                                              else if (CartagenaBoard.getInstance().positions[k].getNumberOfPirates() == 2)
                                                              {
                                                                  spirate = "";
                                                                  spirate = sbox + "P2";
                                                              }
                                                              CartagenaBoard.getInstance().positions[k].addPirate(mpirate);

                                                              if (boxlar3.Controls[m].Name.Contains(spirate))
                                                              {
                                                                  boxlar3.Controls[m].Visible = true;
                                                                  boxlar3.Controls[m].BackColor = color;

                                                                  return;

                                                                              
                                                              }

                                                          
                                                          }

                                                    }
                                                }
                                            }
                                        }

                                        return;
                                    }
                                
                                }

                            }

                        }
                    }
                }


            }

            form.Text = "forward";


        }
    }
}
