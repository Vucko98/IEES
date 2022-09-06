using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using FTN.Common;

namespace ClientUI.Forms
{
    public partial class FormGetValues : Form
    {
        private TestGda tGDA = null;
        private Dictionary<string, (long, DMSType)> xGID_GID_DMSType = null;
        private Dictionary<DMSType, List<ModelCode>> DMSType_ModelCodes = null;

        public FormGetValues(TestGda _tGDA, Dictionary<string, (long, DMSType)> _0xGID_GID_DMSType, Dictionary<DMSType, List<ModelCode>> _DMSType_ModelCodes)
        {
            InitializeComponent();

            InitializeData(_tGDA, _0xGID_GID_DMSType, _DMSType_ModelCodes);

            InitializeTools();
        }

        private void InitializeData(TestGda _tGDA, Dictionary<string, (long, DMSType)> _0xGID_GID_DMSType, Dictionary<DMSType, List<ModelCode>> _DMSType_ModelCodes)
        {
            tGDA = _tGDA;

            try //TRY
            {
                xGID_GID_DMSType = new Dictionary<string, (long, DMSType)>(_0xGID_GID_DMSType);
            }
            catch (Exception e)
            {
                Console.WriteLine(string.Format("ClientUI->FormGetValues->InitializeData->xGID_GID_DMSType failed:\n\t{0}", e.Message));             
                throw;                
            }

            try //TRY
            {                
                DMSType_ModelCodes = new Dictionary<DMSType, List<ModelCode>>(_DMSType_ModelCodes);
            }
            catch (Exception e)
            {
                Console.WriteLine(string.Format("ClientUI->FormGetValues->InitializeData->DMSType_ModelCodes failed:\n\t{0}", e.Message));
                throw;
            }
        }

        private void InitializeTools()
        {
            comboBoxGIDs.Items.Clear();            
            comboBoxGIDs.DropDownStyle = ComboBoxStyle.DropDownList;
            listBoxDMSTypes.Items.Clear();
            listBoxDMSTypes.SelectionMode = SelectionMode.MultiExtended;
            listBoxDMSTypes.Sorted = true;
            richTextBoxResult.ReadOnly = true;

            try //TRY
            {
                foreach (KeyValuePair<string, (long, DMSType)> _0xGID_GID_DMSType in xGID_GID_DMSType)
                    comboBoxGIDs.Items.Add(_0xGID_GID_DMSType.Key);                       
            }
            catch (Exception e)
            {
                Console.WriteLine(string.Format("ClientUI->FormGetValues->InitializeTools failed:\n\t{0}", e.Message));
            }                        
        }

        private void comboBoxGIDs_SelectedIndexChanged(object sender, EventArgs e)
        {            
            listBoxDMSTypes.Items.Clear();
            richTextBoxResult.Clear();
            try //TRY
            {
                DMSType typeOfSelectedGID = xGID_GID_DMSType[comboBoxGIDs.SelectedItem.ToString()].Item2;
                
                foreach (ModelCode item in DMSType_ModelCodes[typeOfSelectedGID])                
                    listBoxDMSTypes.Items.Add(item);                                    
            }
            catch (Exception exc)
            {
                Console.WriteLine(string.Format("ClientUI->FormGetValues->comboBoxGIDs_SelectedIndexChanged failed:\n\t{0}", exc.Message));
                listBoxDMSTypes.Items.Clear();
            }          
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            try //TRY
            {
                long gid = xGID_GID_DMSType[comboBoxGIDs.SelectedItem.ToString()].Item1;

                List<ModelCode> properties = new List<ModelCode>();
                foreach (ModelCode modelCode in listBoxDMSTypes.SelectedItems)
                    properties.Add(modelCode);

                richTextBoxResult.Text = tGDA.GetValues(gid, properties);
            }
            catch (Exception exc)
            {
                Console.WriteLine(string.Format("ClientUI->FormGetValues->buttonStart_Click failed:\n\t{0}", exc.Message));
                richTextBoxResult.Clear();
            }           
        }
    }
}
