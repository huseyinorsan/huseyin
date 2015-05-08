using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Reflection;


namespace Cartagena2
{
    public class ColorComboBox : ComboBox
    {
        private ComboBox comboBox1;

        public ColorComboBox()
        {
            FillColors();

            // Change DrawMode for custom drawing
            this.DrawMode = DrawMode.OwnerDrawFixed;
            this.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void FillColors()
        {
            this.Items.Clear();


            //// Fill Colors using Reflection
            //foreach (Color color in typeof(Color).GetProperties(BindingFlags.Static | BindingFlags.Public).Where(c => c.PropertyType == typeof(Color)).Select(c => (Color)c.GetValue(c, null)))
            //{
            //    this.Items.Add(color);
            //}
        }

        /// <summary>
        /// Override Draw Method
        /// </summary>
        /// <param name="e"></param>
        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            if (e.Index >= 0)
            {
                Color color = (Color)this.Items[e.Index];

                int nextX = 0;

                e.Graphics.FillRectangle(new SolidBrush(e.BackColor), e.Bounds);
                DrawColor(e, color, ref nextX);
                DrawText(e, color, nextX);
            }
            else
                base.OnDrawItem(e);
        }

        /// <summary>
        /// Draw the Color rectangle filled with item color
        /// </summary>
        /// <param name="e"></param>
        /// <param name="color"></param>
        /// <param name="nextX"></param>
        private void DrawColor(DrawItemEventArgs e, Color color, ref int nextX)
        {
            int width = e.Bounds.Height * 2 - 8;
            Rectangle rectangle = new Rectangle(e.Bounds.X + 3, e.Bounds.Y + 3, width, e.Bounds.Height - 6);
            e.Graphics.FillRectangle(new SolidBrush(color), rectangle);

            nextX = width + 8;
        }

        /// <summary>
        /// Draw the color name next to the color rectangle
        /// </summary>
        /// <param name="e"></param>
        /// <param name="color"></param>
        /// <param name="nextX"></param>
        private void DrawText(DrawItemEventArgs e, Color color, int nextX)
        {
            e.Graphics.DrawString(color.Name, e.Font, new SolidBrush(e.ForeColor), new PointF(nextX, e.Bounds.Y + (e.Bounds.Height - e.Font.Height) / 2));
        }

        /// <summary>
        /// Gets/sets the selected color of ComboBox
        /// (Default color is Black)
        /// </summary>
        public Color Color
        {
            get
            {
                if (this.SelectedItem != null)
                    return (Color)this.SelectedItem;

                return Color.Black;
            }
            set
            {
                int ix = this.Items.IndexOf(value);
                if (ix >= 0)
                    this.SelectedIndex = ix;
            }
        }

        private void InitializeComponent()
        {
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(0, 0);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 0;
            this.ResumeLayout(false);

        }
    }

}
