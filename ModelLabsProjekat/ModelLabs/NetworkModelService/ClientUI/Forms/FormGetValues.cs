using System;
using System.Collections.Generic;
using System.Windows.Forms;
using FTN.Common;

namespace ClientUI.Forms
{
    public partial class FormGetValues : Form
    {
        public FormGetValues()
        {
            InitializeComponent();

            InitializeTools();
        }

        private void InitializeTools()
        {                                                                                   
            richTextBoxResult.ReadOnly = true;

            buttonStart.Enabled = false;
            try //TRY
            {                
                foreach (KeyValuePair<string, (long, DMSType)> _strGID__GID_DMSType in DataInAir.strGID__GID_DMSType)
                    comboBoxGIDs.Items.Add(_strGID__GID_DMSType.Key);                       
            }
            catch (Exception e)
            {
                Console.WriteLine(string.Format("ClientUI->FormGetValues->InitializeTools failed:\n\t{0}", e.Message));
            }                        
        }

        private void comboBoxGIDs_SelectedIndexChanged(object sender, EventArgs e)
        {
            buttonStart.Enabled = true;
            listBoxAttribute.Items.Clear();
            richTextBoxResult.Clear();
            try //TRY
            {
                DMSType typeOfSelectedGID = DataInAir.strGID__GID_DMSType[comboBoxGIDs.SelectedItem.ToString()].Item2;                
                foreach (ModelCode item in DataInAir.DMSType_ModelCodes[typeOfSelectedGID])                
                    listBoxAttribute.Items.Add(item);                                    
            }
            catch (Exception exc)
            {
                Console.WriteLine(string.Format("ClientUI->FormGetValues->comboBoxGIDs_SelectedIndexChanged failed:\n\t{0}", exc.Message));
                listBoxAttribute.Items.Clear();
            }          
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            try //TRY
            {
                long GID = DataInAir.strGID__GID_DMSType[comboBoxGIDs.SelectedItem.ToString()].Item1;

                List<ModelCode> properties = new List<ModelCode>();
                foreach (ModelCode modelCode in listBoxAttribute.SelectedItems)
                    properties.Add(modelCode);

                richTextBoxResult.Text = DataInAir.tGDA.GetValues(GID, properties);
            }
            catch (Exception exc)
            {
                Console.WriteLine(string.Format("ClientUI->FormGetValues->buttonStart_Click failed:\n\t{0}", exc.Message));
                richTextBoxResult.Clear();
            }           
        }
    }
}
