using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Cartagena2
{
    class movePirateBackwards : moveBehavior
    {
        public void move(Form form, string piratename)
        {
            for (int l = 0; l <= form.Controls.Count - 1; l++)
            {
                if (form.Controls[l].Name.Contains("gBox_Board"))
                {
                    GroupBox yerbox = (GroupBox)form.Controls[l];
                }
            }
            form.Text = "backward";
        }
    }
}
