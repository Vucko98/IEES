using FTN.Common;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ClientUI.Forms
{
    public partial class FormGetExtentValues : Form
    {
        public FormGetExtentValues()
        {
            InitializeComponent();
            InitializeTools();
        }

        private void InitializeTools()
        { 
            try //TRY
            {                
                foreach (KeyValuePair<DMSType, List<ModelCode>> _DMSType_ModelCodes in DataInAir.DMSType_ModelCodes)
                    comboBoxConcreteClass.Items.Add(_DMSType_ModelCodes.Key);
            }
            catch (Exception e)
            {
                Console.WriteLine(string.Format("ClientUI->FormGetExtentValues->InitializeTools failed:\n\t{0}", e.Message));
            }
        }

        private void comboBoxConcreteClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBoxAttribute.Items.Clear();
            richTextBoxResult.Clear();
            buttonStart.Enabled = true;
            try //TRY
            {                               
                foreach (ModelCode modelCode in DataInAir.DMSType_ModelCodes[(DMSType)comboBoxConcreteClass.SelectedItem])                
                    listBoxAttribute.Items.Add(modelCode);                
            }
            catch (Exception exc)
            {
                Console.WriteLine(string.Format("ClientUI->FormGetExtentValues->comboBoxConcreteClass_SelectedIndexChanged failed:\n\t{0}", exc.Message));
                listBoxAttribute.Items.Clear();
            }
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            try //TRY
            {
                DMSType SelectedConcreteClassType = (DMSType)comboBoxConcreteClass.SelectedItem;
                ModelCode SelectedConcreteClass = (ModelCode)ModelCode.Parse(typeof(ModelCode), SelectedConcreteClassType.ToString());                

                List<ModelCode> properties = new List<ModelCode>();
                foreach (ModelCode modelCode in listBoxAttribute.SelectedItems)
                    properties.Add(modelCode);

                richTextBoxResult.Text = DataInAir.tGDA.GetExtentValues(SelectedConcreteClass, properties);
            }
            catch (Exception exc)
            {
                Console.WriteLine(string.Format("ClientUI->FormGetExtentValues->buttonStart_Click failed:\n\t{0}", exc.Message));
                richTextBoxResult.Clear();
            }
        }
    }
}
