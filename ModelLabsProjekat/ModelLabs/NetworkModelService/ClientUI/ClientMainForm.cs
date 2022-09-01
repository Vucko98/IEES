using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClientUI.Properties;

namespace ClientUI
{
    public partial class ClientMainForm : Form
    {
        public ClientMainForm()
        {
            InitializeComponent();
        }

        #region ResizeNavigation
        private bool resizeSmall = false;
        private void buttonResize_Click(object sender, EventArgs e)
        {
            if (!resizeSmall)
            {
                resizeSmall = !resizeSmall;

                navigationMenu.Width = 42;
                buttonResize.Image = Resources.icons8_arrowLeft_33;
            
                buttonGetValues.ResetText();
                buttonGetExtentValues.ResetText();
                buttonGetRelatedValues.ResetText();                
            }
            else
            {
                resizeSmall = !resizeSmall;

                navigationMenu.Width = 210;
                buttonResize.Image = Resources.icons8_arrowRight_33;

                buttonGetValues.Text = "GetValues";
                buttonGetExtentValues.Text = "GetExtentValues";
                buttonGetRelatedValues.Text = "GetRelatedValues";
            }
        }
        #endregion ResizeNavigation

        #region HighlightSelected
        private Button currentButton = null;
        private void SelectedButton(object btnSender)
        {
            if (btnSender != null)
            {
                if (currentButton != (Button)btnSender)
                {
                    if (currentButton != null)
                    {
                        currentButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                        currentButton.BackColor = ((Button)btnSender).BackColor;
                    }

                    currentButton = (Button)btnSender;
                    currentButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    currentButton.BackColor = Color.SlateGray;
                }                
            }
        }
        #endregion HighlightSelected

        private void buttonGetValues_Click(object sender, EventArgs e)
        {
            SelectedButton(sender);
        }

        private void buttonGetExtentValues_Click(object sender, EventArgs e)
        {
            SelectedButton(sender);
        }

        private void buttonGetRelatedValues_Click(object sender, EventArgs e)
        {
            SelectedButton(sender);
        }

        private void buttonHome_Click(object sender, EventArgs e)
        {
            SelectedButton(sender);
        }
    }
}
