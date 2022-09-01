namespace ClientUI
{
    partial class ClientMainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.navigationMenu = new System.Windows.Forms.Panel();
            this.buttonGetRelatedValues = new System.Windows.Forms.Button();
            this.buttonResize = new System.Windows.Forms.Button();
            this.buttonGetExtentValues = new System.Windows.Forms.Button();
            this.buttonGetValues = new System.Windows.Forms.Button();
            this.buttonHome = new System.Windows.Forms.Button();
            this.panelWorkspace = new System.Windows.Forms.Panel();
            this.panelControl = new System.Windows.Forms.Panel();
            this.buttonMinimize = new System.Windows.Forms.Button();
            this.buttonMaximize = new System.Windows.Forms.Button();
            this.buttonClose = new System.Windows.Forms.Button();
            this.navigationMenu.SuspendLayout();
            this.panelControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // navigationMenu
            // 
            this.navigationMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.navigationMenu.Controls.Add(this.buttonGetRelatedValues);
            this.navigationMenu.Controls.Add(this.buttonResize);
            this.navigationMenu.Controls.Add(this.buttonGetExtentValues);
            this.navigationMenu.Controls.Add(this.buttonGetValues);
            this.navigationMenu.Controls.Add(this.buttonHome);
            this.navigationMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.navigationMenu.Location = new System.Drawing.Point(0, 0);
            this.navigationMenu.Name = "navigationMenu";
            this.navigationMenu.Size = new System.Drawing.Size(210, 450);
            this.navigationMenu.TabIndex = 0;
            // 
            // buttonGetRelatedValues
            // 
            this.buttonGetRelatedValues.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonGetRelatedValues.FlatAppearance.BorderSize = 0;
            this.buttonGetRelatedValues.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonGetRelatedValues.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonGetRelatedValues.ForeColor = System.Drawing.Color.Gainsboro;
            this.buttonGetRelatedValues.Image = global::ClientUI.Properties.Resources.icons8_favorites_33;
            this.buttonGetRelatedValues.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonGetRelatedValues.Location = new System.Drawing.Point(0, 220);
            this.buttonGetRelatedValues.Name = "buttonGetRelatedValues";
            this.buttonGetRelatedValues.Size = new System.Drawing.Size(210, 65);
            this.buttonGetRelatedValues.TabIndex = 1;
            this.buttonGetRelatedValues.Text = "GetRelatedValues";
            this.buttonGetRelatedValues.UseVisualStyleBackColor = true;
            this.buttonGetRelatedValues.Click += new System.EventHandler(this.buttonGetRelatedValues_Click);
            // 
            // buttonResize
            // 
            this.buttonResize.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.buttonResize.FlatAppearance.BorderSize = 0;
            this.buttonResize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonResize.ForeColor = System.Drawing.Color.Gainsboro;
            this.buttonResize.Image = global::ClientUI.Properties.Resources.icons8_arrowRight_33;
            this.buttonResize.Location = new System.Drawing.Point(0, 385);
            this.buttonResize.Name = "buttonResize";
            this.buttonResize.Size = new System.Drawing.Size(210, 65);
            this.buttonResize.TabIndex = 4;
            this.buttonResize.UseVisualStyleBackColor = true;
            this.buttonResize.Click += new System.EventHandler(this.buttonResize_Click);
            // 
            // buttonGetExtentValues
            // 
            this.buttonGetExtentValues.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonGetExtentValues.FlatAppearance.BorderSize = 0;
            this.buttonGetExtentValues.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonGetExtentValues.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonGetExtentValues.ForeColor = System.Drawing.Color.Gainsboro;
            this.buttonGetExtentValues.Image = global::ClientUI.Properties.Resources.icons8_folder_33;
            this.buttonGetExtentValues.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonGetExtentValues.Location = new System.Drawing.Point(0, 155);
            this.buttonGetExtentValues.Name = "buttonGetExtentValues";
            this.buttonGetExtentValues.Size = new System.Drawing.Size(210, 65);
            this.buttonGetExtentValues.TabIndex = 3;
            this.buttonGetExtentValues.Text = "GetExtentValues";
            this.buttonGetExtentValues.UseVisualStyleBackColor = true;
            this.buttonGetExtentValues.Click += new System.EventHandler(this.buttonGetExtentValues_Click);
            // 
            // buttonGetValues
            // 
            this.buttonGetValues.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonGetValues.FlatAppearance.BorderSize = 0;
            this.buttonGetValues.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonGetValues.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonGetValues.ForeColor = System.Drawing.Color.Gainsboro;
            this.buttonGetValues.Image = global::ClientUI.Properties.Resources.icons8_document_33;
            this.buttonGetValues.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonGetValues.Location = new System.Drawing.Point(0, 90);
            this.buttonGetValues.Name = "buttonGetValues";
            this.buttonGetValues.Size = new System.Drawing.Size(210, 65);
            this.buttonGetValues.TabIndex = 2;
            this.buttonGetValues.Text = "GetValues";
            this.buttonGetValues.UseVisualStyleBackColor = true;
            this.buttonGetValues.Click += new System.EventHandler(this.buttonGetValues_Click);
            // 
            // buttonHome
            // 
            this.buttonHome.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(168)))), ((int)(((byte)(171)))));
            this.buttonHome.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonHome.FlatAppearance.BorderSize = 0;
            this.buttonHome.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonHome.ForeColor = System.Drawing.Color.Gainsboro;
            this.buttonHome.Image = global::ClientUI.Properties.Resources.icons8_home_33;
            this.buttonHome.Location = new System.Drawing.Point(0, 0);
            this.buttonHome.Name = "buttonHome";
            this.buttonHome.Size = new System.Drawing.Size(210, 90);
            this.buttonHome.TabIndex = 2;
            this.buttonHome.UseVisualStyleBackColor = false;
            this.buttonHome.Click += new System.EventHandler(this.buttonHome_Click);
            // 
            // panelWorkspace
            // 
            this.panelWorkspace.BackColor = System.Drawing.Color.Gray;
            this.panelWorkspace.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelWorkspace.Location = new System.Drawing.Point(210, 0);
            this.panelWorkspace.Name = "panelWorkspace";
            this.panelWorkspace.Size = new System.Drawing.Size(590, 450);
            this.panelWorkspace.TabIndex = 1;
            // 
            // panelControl
            // 
            this.panelControl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(168)))), ((int)(((byte)(171)))));
            this.panelControl.Controls.Add(this.buttonMinimize);
            this.panelControl.Controls.Add(this.buttonMaximize);
            this.panelControl.Controls.Add(this.buttonClose);
            this.panelControl.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl.Location = new System.Drawing.Point(210, 0);
            this.panelControl.Name = "panelControl";
            this.panelControl.Size = new System.Drawing.Size(590, 27);
            this.panelControl.TabIndex = 2;
            this.panelControl.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelControl_MouseDown);
            // 
            // buttonMinimize
            // 
            this.buttonMinimize.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.buttonMinimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonMinimize.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(168)))), ((int)(((byte)(171)))));
            this.buttonMinimize.Image = global::ClientUI.Properties.Resources.icons8_subtract_23;
            this.buttonMinimize.Location = new System.Drawing.Point(491, 0);
            this.buttonMinimize.Margin = new System.Windows.Forms.Padding(0);
            this.buttonMinimize.Name = "buttonMinimize";
            this.buttonMinimize.Size = new System.Drawing.Size(33, 26);
            this.buttonMinimize.TabIndex = 2;
            this.buttonMinimize.UseVisualStyleBackColor = true;
            this.buttonMinimize.Click += new System.EventHandler(this.buttonMinimize_Click);
            // 
            // buttonMaximize
            // 
            this.buttonMaximize.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.buttonMaximize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonMaximize.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(168)))), ((int)(((byte)(171)))));
            this.buttonMaximize.Image = global::ClientUI.Properties.Resources.icons8_maximize_window_24;
            this.buttonMaximize.Location = new System.Drawing.Point(524, 0);
            this.buttonMaximize.Margin = new System.Windows.Forms.Padding(0);
            this.buttonMaximize.Name = "buttonMaximize";
            this.buttonMaximize.Size = new System.Drawing.Size(33, 26);
            this.buttonMaximize.TabIndex = 1;
            this.buttonMaximize.UseVisualStyleBackColor = true;
            this.buttonMaximize.Click += new System.EventHandler(this.buttonMaximize_Click);
            // 
            // buttonClose
            // 
            this.buttonClose.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.buttonClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonClose.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(168)))), ((int)(((byte)(171)))));
            this.buttonClose.Image = global::ClientUI.Properties.Resources.icons8_close_21;
            this.buttonClose.Location = new System.Drawing.Point(557, 0);
            this.buttonClose.Margin = new System.Windows.Forms.Padding(0);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(33, 26);
            this.buttonClose.TabIndex = 0;
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // ClientMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panelControl);
            this.Controls.Add(this.panelWorkspace);
            this.Controls.Add(this.navigationMenu);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.MinimumSize = new System.Drawing.Size(300, 370);
            this.Name = "ClientMainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "IEES Client Service";
            this.navigationMenu.ResumeLayout(false);
            this.panelControl.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel navigationMenu;
        private System.Windows.Forms.Button buttonHome;
        private System.Windows.Forms.Button buttonGetExtentValues;
        private System.Windows.Forms.Button buttonGetValues;
        private System.Windows.Forms.Button buttonResize;
        private System.Windows.Forms.Button buttonGetRelatedValues;
        private System.Windows.Forms.Panel panelWorkspace;
        private System.Windows.Forms.Panel panelControl;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Button buttonMinimize;
        private System.Windows.Forms.Button buttonMaximize;
    }
}

