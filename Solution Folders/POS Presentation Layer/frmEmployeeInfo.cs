using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cash_System
{
    public partial class frmEmployeeInfo : Form
    {
        private int _EmployeeID;
        public frmEmployeeInfo()
        {
            InitializeComponent();
           
        }
        public frmEmployeeInfo(int EmployeeID) 
        {

            InitializeComponent();
            

            _EmployeeID = EmployeeID;
            
            ctrlEmployeeCard1.LoadEmployeeInfo(_EmployeeID);

        }

        private void frm_Load(object sender, EventArgs e)
        {
            
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            
        }

        private void btnClose_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
