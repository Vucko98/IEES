using FTN.Common;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ClientUI.Forms
{
    public partial class FormGetRelatedValues : Form
    {
        private TestGda tGDA = null;
        private Dictionary<string, (long, DMSType)> xGID_GID_DMSType = null;
        private Dictionary<DMSType, List<ModelCode>> DMSType_ModelCodes = null;
        private Dictionary<DMSType, List<ModelCode>> DMSType_Reference = null;

        public FormGetRelatedValues(TestGda _tGDA, Dictionary<string, (long, DMSType)> _0xGID_GID_DMSType, Dictionary<DMSType, List<ModelCode>> _DMSType_ModelCodes, Dictionary<DMSType, List<ModelCode>> _DMSType_Reference)        
        {
            InitializeComponent();

            InitializeData(_tGDA, _0xGID_GID_DMSType, _DMSType_ModelCodes, _DMSType_Reference);

            InitializeTools();
        }

        private void InitializeData(TestGda _tGDA, Dictionary<string, (long, DMSType)> _0xGID_GID_DMSType, Dictionary<DMSType, List<ModelCode>> _DMSType_ModelCodes, Dictionary<DMSType, List<ModelCode>> _DMSType_Reference)
        {
            tGDA = _tGDA;

            try //TRY
            {
                xGID_GID_DMSType = new Dictionary<string, (long, DMSType)>(_0xGID_GID_DMSType);
            }
            catch (Exception e)
            {
                Console.WriteLine(string.Format("ClientUI->FormGetRelatedValues->InitializeData->xGID_GID_DMSType failed:\n\t{0}", e.Message));
                throw;
            }

            try //TRY
            {
                DMSType_ModelCodes = new Dictionary<DMSType, List<ModelCode>>(_DMSType_ModelCodes);
            }
            catch (Exception e)
            {
                Console.WriteLine(string.Format("ClientUI->FormGetRelatedValues->InitializeData->DMSType_ModelCodes failed:\n\t{0}", e.Message));
                throw;
            }

            try //TRY
            {
                DMSType_Reference = new Dictionary<DMSType, List<ModelCode>>(_DMSType_Reference);
            }
            catch (Exception e)
            {
                Console.WriteLine(string.Format("ClientUI->FormGetRelatedValues->InitializeData->DMSType_Reference failed:\n\t{0}", e.Message));
                throw;
            }
        }

        private void InitializeTools()
        {
            //comboBoxGIDs.Items.Clear();
            //comboBoxGIDs.Text = "Resource_GID";
            comboBoxGIDs.DropDownStyle = ComboBoxStyle.DropDownList;
            //comboBoxReference.Items.Clear();            
            //comboBoxReference.Text = "Reference ModelCode";
            comboBoxReference.Enabled = false;
            comboBoxReference.DropDownStyle = ComboBoxStyle.DropDownList;
            //comboBoxConcreteClass.Items.Clear();
            //comboBoxConcreteClass.Text = "Concrete Class";
            comboBoxConcreteClass.Enabled = false;
            comboBoxConcreteClass.DropDownStyle = ComboBoxStyle.DropDownList;
            //listBoxAttribute.Items.Clear();
            listBoxAttribute.SelectionMode = SelectionMode.MultiExtended;
            listBoxAttribute.Sorted = true;
            //richTextBoxResult.Clear();
            richTextBoxResult.ReadOnly = true;
            buttonStart.Enabled = false;


            try //TRY
            {
                foreach (KeyValuePair<string, (long, DMSType)> _0xGID_GID_DMSType in xGID_GID_DMSType)
                    comboBoxGIDs.Items.Add(_0xGID_GID_DMSType.Key);
            }
            catch (Exception e)
            {
                Console.WriteLine(string.Format("ClientUI->FormGetRelatedValues->InitializeTools->comboBoxGIDs failed:\n\t{0}", e.Message));
            }

            try //TRY
            {
                comboBoxConcreteClass.Items.Add("ALL");
                foreach (KeyValuePair<DMSType, List<ModelCode>> _DMSType_ModelCodes in DMSType_ModelCodes)
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
                DMSType typeOfSelectedGID = xGID_GID_DMSType[comboBoxGIDs.SelectedItem.ToString()].Item2;

                foreach (ModelCode item in DMSType_Reference[typeOfSelectedGID])
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
                //comboBoxConcreteClass
                string selectedTypeStr = comboBoxConcreteClass.SelectedItem.ToString();
                if (selectedTypeStr == "ALL")
                {
                    foreach (KeyValuePair<DMSType, List<ModelCode>> _DMSType_ModelCodes in DMSType_ModelCodes)
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

                    foreach (ModelCode modelCode in DMSType_ModelCodes[selectedType])
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
                long GID = xGID_GID_DMSType[comboBoxGIDs.SelectedItem.ToString()].Item1;
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

                richTextBoxResult.Text = tGDA.GetRelatedValues(GID, properties, association);
            }
            catch (Exception exc)
            {
                Console.WriteLine(string.Format("ClientUI->FormGetRelatedValues->buttonStart_Click failed:\n\t{0}", exc.Message));
                richTextBoxResult.Clear();
            }
        }

    }
}
