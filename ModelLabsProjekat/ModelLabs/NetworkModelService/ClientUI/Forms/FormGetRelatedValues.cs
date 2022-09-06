using FTN.Common;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ClientUI.Forms
{
    public partial class FormGetRelatedValues : Form
    {
        public FormGetRelatedValues()        
        {
            InitializeComponent();
            InitializeTools();
        }

        private void InitializeTools()
        {
            //comboBoxGIDs.Text = "Resource_GID";            
            //comboBoxReference.Text = "Reference ModelCode";            
            //comboBoxConcreteClass.Text = "Concrete Class";                        
            try //TRY
            {                
                foreach (KeyValuePair<string, (long, DMSType)> _strGID_GID_DMSType in DataInAir.strGID__GID_DMSType)
                    comboBoxGIDs.Items.Add(_strGID_GID_DMSType.Key);
            }
            catch (Exception e)
            {
                Console.WriteLine(string.Format("ClientUI->FormGetRelatedValues->InitializeTools->comboBoxGIDs failed:\n\t{0}", e.Message));
            }

            try //TRY
            {
                comboBoxConcreteClass.Items.Add("ALL");
                foreach (KeyValuePair<DMSType, List<ModelCode>> _DMSType_ModelCodes in DataInAir.DMSType_ModelCodes)
                    comboBoxConcreteClass.Items.Add(_DMSType_ModelCodes.Key);
            }
            catch (Exception e)
            {
                Console.WriteLine(string.Format("ClientUI->FormGetRelatedValues->InitializeTools->comboBoxConcreteClass failed:\n\t{0}", e.Message));
            }
        }

        private void comboBoxGIDs_SelectedIndexChanged(object sender, EventArgs e)
        {
            richTextBoxResult.Clear();             

            comboBoxReference.Enabled = true;
            comboBoxReference.Items.Clear();

            comboBoxConcreteClass.SelectedItem = null;
            comboBoxConcreteClass.Enabled = false;

            buttonStart.Enabled = false;

            try //TRY
            {
                DMSType typeOfSelectedGID = DataInAir.strGID__GID_DMSType[comboBoxGIDs.SelectedItem.ToString()].Item2;

                foreach (ModelCode item in DataInAir.DMSType_Reference[typeOfSelectedGID])
                    comboBoxReference.Items.Add(item);
            }
            catch (Exception exc)
            {
                Console.WriteLine(string.Format("ClientUI->FormGetRelatedValues->comboBoxGIDs_SelectedIndexChanged failed:\n\t{0}", exc.Message));
                comboBoxReference.Items.Clear();
            }
        }

        private void comboBoxReference_SelectedIndexChanged(object sender, EventArgs e)
        {            
            richTextBoxResult.Clear();            
            comboBoxConcreteClass.SelectedItem = null;
            comboBoxConcreteClass.Enabled = true;
            buttonStart.Enabled = false;
        }

        private void comboBoxConcreteClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            richTextBoxResult.Clear();
            buttonStart.Enabled = true;            
            listBoxAttribute.Items.Clear();

            if (comboBoxConcreteClass.SelectedItem == null)
                return;

            try //TRY
            {
                string selectedTypeStr = comboBoxConcreteClass.SelectedItem.ToString();
                if (selectedTypeStr == "ALL")
                {
                    foreach (KeyValuePair<DMSType, List<ModelCode>> _DMSType_ModelCodes in DataInAir.DMSType_ModelCodes)
                    {
                        foreach (ModelCode modelCode in _DMSType_ModelCodes.Value)
                        {
                            if(!listBoxAttribute.Items.Contains(modelCode))
                                listBoxAttribute.Items.Add(modelCode);
                        }
                    }
                }
                else
                {
                    DMSType selectedType = (DMSType)DMSType.Parse(typeof(DMSType), selectedTypeStr);                    
                    foreach (ModelCode modelCode in DataInAir.DMSType_ModelCodes[selectedType])
                        listBoxAttribute.Items.Add(modelCode);
                }                                
            }
            catch (Exception exc)
            {
                Console.WriteLine(string.Format("ClientUI->FormGetRelatedValues->comboBoxConcreteClass_SelectedIndexChanged failed:\n\t{0}", exc.Message));
                listBoxAttribute.Items.Clear();
            }
        }       
        
        private void buttonStart_Click(object sender, EventArgs e)
        {
            try //TRY
            {
                long GID = DataInAir.strGID__GID_DMSType[comboBoxGIDs.SelectedItem.ToString()].Item1;
                ModelCode ReferenceModelCode = (ModelCode)ModelCode.Parse(typeof(ModelCode), comboBoxReference.SelectedItem.ToString());

                List<ModelCode> properties = new List<ModelCode>();
                foreach (ModelCode modelCode in listBoxAttribute.SelectedItems)
                    properties.Add(modelCode);

                Association association = new Association();
                association.PropertyId = ReferenceModelCode;

                string selectedType = comboBoxConcreteClass.SelectedItem.ToString();
                if (selectedType == "ALL")
                {
                    association.Type = 0;
                }
                else
                {
                    association.Type = (ModelCode)ModelCode.Parse(typeof(ModelCode), selectedType);
                }

                richTextBoxResult.Text = DataInAir.tGDA.GetRelatedValues(GID, properties, association);
            }
            catch (Exception exc)
            {
                Console.WriteLine(string.Format("ClientUI->FormGetRelatedValues->buttonStart_Click failed:\n\t{0}", exc.Message));
                richTextBoxResult.Clear();
            }
        }
    }
}
