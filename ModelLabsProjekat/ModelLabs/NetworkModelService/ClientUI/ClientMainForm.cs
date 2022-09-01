using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using ClientUI.Properties;

namespace ClientUI
{
    public partial class ClientMainForm : Form
    {
        public ClientMainForm()
        {
            InitializeComponent();

            //this.FormBorderStyle = FormBorderStyle.SizableToolWindow;
            //this.FormBorderStyle = FormBorderStyle.None;
            this.Text = string.Empty;
            this.ControlBox = false;
            //this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
        }

        #region FormBorderControl
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void panelControl_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        #endregion FormBorderControl

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
                        currentButton.BackColor = Color.FromArgb(51, 51, 76);
                    }
                    else
                    {
                        buttonHome.BackColor = Color.FromArgb(51, 51, 76); 
                    }

                    currentButton = (Button)btnSender;
                    currentButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    currentButton.BackColor = Color.FromArgb(156, 168, 171);
                }                
            }
        }
        #endregion HighlightSelected

        #region OpenForm
        private Form currentForm = null;
        private void ChangeForm(Form newForm)
        {
            if (currentForm != null)
            {
                currentForm.Close();
            }
            currentForm = newForm;

            currentForm.TopLevel = false;
            currentForm.FormBorderStyle = FormBorderStyle.None;
            currentForm.Dock = DockStyle.Fill;
            this.panelWorkspace.Controls.Add(currentForm);
            this.panelWorkspace.Tag = currentForm;
            currentForm.BringToFront();
            currentForm.Show();
        }
        #endregion OpenForm

        private void buttonGetValues_Click(object sender, EventArgs e)
        {
            SelectedButton(sender);
            //ChangeForm(new ClientUI.Forms.FormGetValues());
        }

        private void buttonGetExtentValues_Click(object sender, EventArgs e)
        {
            SelectedButton(sender);
            //ChangeForm(new ClientUI.Forms.FormGetExtentValues());
        }

        private void buttonGetRelatedValues_Click(object sender, EventArgs e)
        {
            SelectedButton(sender);
            //ChangeForm(new ClientUI.Forms.FormGetRelatedValues());
        }

        private void buttonHome_Click(object sender, EventArgs e)
        {
            SelectedButton(sender);
            //ChangeForm(new ClientUI.Forms.FormHome());
        }
        #region CloseMaximizeMinimize
        private void buttonClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void buttonMaximize_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
            {
                this.WindowState = FormWindowState.Maximized;
            }
            else
            {
                this.WindowState = FormWindowState.Normal;
            }

        }

        private void buttonMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        #endregion CloseMaximizeMinimize
    }
}
