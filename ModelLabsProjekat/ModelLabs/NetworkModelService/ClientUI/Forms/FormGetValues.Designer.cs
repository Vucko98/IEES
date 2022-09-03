namespace ClientUI.Forms
{
    partial class FormGetValues
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
            this.comboBoxGIDs = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // comboBoxGIDs
            // 
            this.comboBoxGIDs.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxGIDs.FormattingEnabled = true;
            this.comboBoxGIDs.Location = new System.Drawing.Point(20, 50);
            this.comboBoxGIDs.Name = "comboBoxGIDs";
            this.comboBoxGIDs.Size = new System.Drawing.Size(242, 24);
            this.comboBoxGIDs.TabIndex = 0;
            // 
            // FormGetValues
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.comboBoxGIDs);
            this.Name = "FormGetValues";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxGIDs;
    }
}