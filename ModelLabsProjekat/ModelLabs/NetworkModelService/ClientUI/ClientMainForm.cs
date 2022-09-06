using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using ClientUI.Properties;
using FTN.Common;

namespace ClientUI
{
    public partial class ClientMainForm : Form
    {
        public ClientMainForm()
        {
            InitializeComponent();
            ConfigureMainForm();                        

            InitializeNestedForms(); //must go last
        }

        #region NestedForms

        private Form _FormHome = null;
        private Form _FormGetValues = null;
        private Form _FormGetExtentValues = null;
        private Form _FormGetRelatedValues = null;
        
        private void InitializeNestedForms()
        {            
            _FormHome = new ClientUI.Forms.FormHome();
            _FormGetValues = new ClientUI.Forms.FormGetValues();
            _FormGetExtentValues = new ClientUI.Forms.FormGetExtentValues();
            //_FormGetRelatedValues = new ClientUI.Forms.FormGetRelatedValues();

            ChangeForm(_FormHome);
        }

        #endregion NestedForms

        #region UIbehaviour

        private void ConfigureMainForm()
        {
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

        #region ResizeNavigationBar

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

        #endregion ResizeNavigationBar

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
            /*if (currentForm != null)
            {
                currentForm.Close();
            }*/
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

        #region NavigationBtnClick
        private void buttonHome_Click(object sender, EventArgs e)
        {
            SelectedButton(sender);
            //ChangeForm(new ClientUI.Forms.FormHome());
            ChangeForm(_FormHome);
        }

        private void buttonGetValues_Click(object sender, EventArgs e)
        {
            SelectedButton(sender);
            //ChangeForm(new ClientUI.Forms.FormGetValues());
            ChangeForm(_FormGetValues);
        }

        private void buttonGetExtentValues_Click(object sender, EventArgs e)
        {
            SelectedButton(sender);
            //ChangeForm(new ClientUI.Forms.FormGetExtentValues());
            ChangeForm(_FormGetExtentValues);
        }

        private void buttonGetRelatedValues_Click(object sender, EventArgs e)
        {
            SelectedButton(sender);
            //ChangeForm(new ClientUI.Forms.FormGetRelatedValues());
            ChangeForm(_FormGetRelatedValues);
        }
        #endregion NavigationBtnClick

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

        #endregion UIbehaviour
    }
}
