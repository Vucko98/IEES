namespace ClientUI.Forms
{
    partial class FormGetExtentValues
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormGetExtentValues));
            this.richTextBoxResult = new System.Windows.Forms.RichTextBox();
            this.buttonStart = new System.Windows.Forms.Button();
            this.listBoxAttribute = new System.Windows.Forms.ListBox();
            this.comboBoxConcreteClass = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // richTextBoxResult
            // 
            this.richTextBoxResult.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBoxResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBoxResult.Location = new System.Drawing.Point(245, 50);
            this.richTextBoxResult.Name = "richTextBoxResult";
            this.richTextBoxResult.Size = new System.Drawing.Size(515, 340);
            this.richTextBoxResult.TabIndex = 7;
            this.richTextBoxResult.Text = "";
            // 
            // buttonStart
            // 
            this.buttonStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonStart.Image = ((System.Drawing.Image)(resources.GetObject("buttonStart.Image")));
            this.buttonStart.Location = new System.Drawing.Point(91, 333);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(50, 40);
            this.buttonStart.TabIndex = 6;
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // listBoxAttribute
            // 
            this.listBoxAttribute.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBoxAttribute.FormattingEnabled = true;
            this.listBoxAttribute.ItemHeight = 16;
            this.listBoxAttribute.Location = new System.Drawing.Point(20, 98);
            this.listBoxAttribute.Name = "listBoxAttribute";
            this.listBoxAttribute.Size = new System.Drawing.Size(200, 212);
            this.listBoxAttribute.TabIndex = 5;
            // 
            // comboBoxConcreteClass
            // 
            this.comboBoxConcreteClass.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxConcreteClass.FormattingEnabled = true;
            this.comboBoxConcreteClass.Location = new System.Drawing.Point(20, 50);
            this.comboBoxConcreteClass.Name = "comboBoxConcreteClass";
            this.comboBoxConcreteClass.Size = new System.Drawing.Size(200, 24);
            this.comboBoxConcreteClass.TabIndex = 4;
            this.comboBoxConcreteClass.SelectedIndexChanged += new System.EventHandler(this.comboBoxConcreteClass_SelectedIndexChanged);
            // 
            // FormGetExtentValues
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.ClientSize = new System.Drawing.Size(784, 411);
            this.Controls.Add(this.richTextBoxResult);
            this.Controls.Add(this.buttonStart);
            this.Controls.Add(this.listBoxAttribute);
            this.Controls.Add(this.comboBoxConcreteClass);
            this.Name = "FormGetExtentValues";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBoxResult;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.ListBox listBoxAttribute;
        private System.Windows.Forms.ComboBox comboBoxConcreteClass;
    }
}