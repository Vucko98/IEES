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


namespace ClientUI.Forms
{
    public partial class FormGetValues : Form
    {
        public FormGetValues(List<long> GIDs)
        {
            InitializeComponent();
            InitializeTools(GIDs);
        }

        private void InitializeTools(List<long> GIDs)
        {
            //comboBoxGIDs.Items.Clear();
            comboBoxGIDs.DropDownStyle = ComboBoxStyle.DropDownList;

            foreach (long gid in GIDs)
            {
                comboBoxGIDs.Items.Add(gid);
            }            
        }
    }
}
