using CS_BusinessLayer;
using DVLD.Classes;
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
    public partial class frmAddUpdateEmployee : Form
    {
        public enum enMode { AddNew = 0, Update = 1 };
        private enMode _Mode;

        private int _EmpID = -1;
        clsEmployee _Employee;

        public frmAddUpdateEmployee()
        {
            InitializeComponent();
        }
        public frmAddUpdateEmployee( int EmpID = 1)
        {
            InitializeComponent();
            _Mode = enMode.Update;
            _EmpID = EmpID;
           
                _Employee = clsEmployee.Find(_EmpID);
            

        }


        private void btnSave_Click(object sender, EventArgs e)
        {

            if (!this.ValidateChildren())
            {
                //Here we dont continue becuase the form is not valid
                MessageBox.Show("Some fileds are not valide!, put the mouse over the red icon(s) to see the erro",
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            
            _Employee.PersonID = ctrlPersonCardWithFilter1.PersonID;
            _Employee._HireDate = DateTime.Now;
            _Employee._IsActive = cbIsActive.Checked;
            _Employee._Salary = Convert.ToInt16(tbSalary.Text.Trim());
            _Employee._HiredByUserID = 1025;
            
            if (_Employee.Save())
            {
                lbEmpID.Text = _Employee._EmployeeID.ToString();
                //change form mode to update.
                _Mode = enMode.Update;
                lblTitle.Text = "Update Employee";
                this.Text = "Update Employee";

                MessageBox.Show(" Employee Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ctrlPersonCardWithFilter1.FilterEnabled = false;
                tcEmpInfo.Enabled = false;
            }
            else
                MessageBox.Show("Error: Employee Data Is not Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void btnPersonInfoNext_Click(object sender, EventArgs e)
        {
            if (_Mode == enMode.Update)
            {
                btnSave.Enabled = true;
                tpEmpInfo.Enabled = true;
                tcEmpInfo.SelectedTab = tcEmpInfo.TabPages["tpEmpInfo"];
                return;
            }

            //incase of add new mode.
            if (ctrlPersonCardWithFilter1.PersonID != -1)
            {

                if (clsEmployee.IsEmployeeExistsByPersonID(ctrlPersonCardWithFilter1.PersonID))
                {

                    MessageBox.Show("Selected Person already has a Employee Record, choose another one.", "Select another Person", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ctrlPersonCardWithFilter1.FilterFocus();
                }

                else
                {
                    btnSave.Enabled = true;
                    tpEmpInfo.Enabled = true;
                    tcEmpInfo.SelectedTab = tcEmpInfo.TabPages["tpEmpInfo"];
                }
            }

            else

            {
                MessageBox.Show("Please Select a Person", "Select a Person", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ctrlPersonCardWithFilter1.FilterFocus();

            }
        }

        private void cbIsActive_CheckedChanged(object sender, EventArgs e)
        {
            
        }

       private void frmAddUpdateEmployee_Load(object sender, EventArgs e)
        {
            if (_Mode == enMode.AddNew)
            {
                lblTitle.Text = "Add New Employee";
                this.Text = "Add New Employee";
                _Employee = new clsEmployee();
                ctrlPersonCardWithFilter1.FilterFocus();
                btnSave.Enabled = false;
                tpEmpInfo.Enabled = false;
                cbIsActive.Checked = true;
                lbHireDate.Text = DateTime.Now.ToShortDateString();
            }
            else
            {
                lblTitle.Text = "Update Employee";
                this.Text = "Update Employee";
                LoadEmployeeData();
                ctrlPersonCardWithFilter1.LoadPersonInfo( _Employee.PersonID);
                ctrlPersonCardWithFilter1.FilterEnabled = false;

            }
          
           

        }

        private void ctrlPersonCardWithFilter1_OnPersonSelected(int obj)
        {
          
            

        }

        private void LoadEmployeeData()
        {
            if (_Employee != null)
            {
                tbSalary.Text = _Employee._Salary.ToString();
                lbHireDate.Text = _Employee._HireDate.ToShortDateString();
                cbIsActive.Checked = _Employee._IsActive;
                lbEmpID.Text = _Employee._EmployeeID.ToString();
                lbHiredBy.Text = _Employee._HiredByUserID.ToString();
                _Mode = enMode.Update;
                btnSave.Enabled = true;
                tpEmpInfo.Enabled = true;
                tcEmpInfo.SelectedTab = tcEmpInfo.TabPages["tpEmpInfo"];
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tbSalary_Validating(object sender, CancelEventArgs e)
        {
          
        }

        private void tbSalary_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsControl(e.KeyChar))
                return;

            // Allow digits
            if (char.IsDigit(e.KeyChar))
                return;

            // Allow ONE decimal point
            if (e.KeyChar == '.' && !tbSalary.Text.Contains("."))
                return;

            // Block everything else
            e.Handled = true;
        }
    }
}
