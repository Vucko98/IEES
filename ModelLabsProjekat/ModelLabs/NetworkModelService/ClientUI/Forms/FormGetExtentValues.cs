using FTN.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClientUI.Forms
{
    public partial class FormGetExtentValues : Form
    {
        private TestGda tGDA = null;        
        private Dictionary<DMSType, List<ModelCode>> DMSType_ModelCodes = null;

        public FormGetExtentValues(TestGda _tGDA, Dictionary<DMSType, List<ModelCode>> _DMSType_ModelCodes)
        {
            InitializeComponent();

            InitializeData(_tGDA, _DMSType_ModelCodes);

            InitializeTools();
        }

        private void InitializeData(TestGda _tGDA, Dictionary<DMSType, List<ModelCode>> _DMSType_ModelCodes)
        {
            tGDA = _tGDA;

            try //TRY
            {
                DMSType_ModelCodes = new Dictionary<DMSType, List<ModelCode>>(_DMSType_ModelCodes);
            }
            catch (Exception e)
            {
                Console.WriteLine(string.Format("ClientUI->FormGetExtentValues->InitializeData->DMSType_ModelCodes failed:\n\t{0}", e.Message));
                throw;
            }
        }

        private void InitializeTools()
        {
            comboBoxConcreteClass.Items.Clear();
            comboBoxConcreteClass.DropDownStyle = ComboBoxStyle.DropDownList;
            listBoxAttribute.Items.Clear();
            listBoxAttribute.SelectionMode = SelectionMode.MultiExtended;
            listBoxAttribute.Sorted = true;
            richTextBoxResult.ReadOnly = true;

            try //TRY
            {
                foreach (KeyValuePair<DMSType, List<ModelCode>> _DMSType_ModelCodes in DMSType_ModelCodes)
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
            try //TRY
            {                               
                foreach (ModelCode modelCode in DMSType_ModelCodes[(DMSType)comboBoxConcreteClass.SelectedItem])                
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

                richTextBoxResult.Text = tGDA.GetExtentValues(SelectedConcreteClass, properties);
            }
            catch (Exception exc)
            {
                Console.WriteLine(string.Format("ClientUI->FormGetExtentValues->buttonStart_Click failed:\n\t{0}", exc.Message));
                richTextBoxResult.Clear();
            }
        }
    }
}
