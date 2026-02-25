using CS_BusinessLayer;
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
    public partial class ctrlEmployeeCard : UserControl
    {

        private clsEmployee _Employee;
        private int _EmployeeID = -1;

        public int EmployeeID
        {
            get { return _EmployeeID; }
        }

        public ctrlEmployeeCard()
        {
            InitializeComponent();
            
            

           
        }

        public void LoadEmployeeInfo(int EmployeeID)
        {
            _Employee = clsEmployee.Find(EmployeeID);
            if (_Employee == null)
            {
                _ResetPersonInfo();
                MessageBox.Show("No Employee with EmployeeID = " + EmployeeID.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _FillEmployeeInfo();
        }

        private void _FillEmployeeInfo()
        {

            ctrlPersonCard1.LoadPersonInfo(_Employee.PersonID);
            lbEmployeeID.Text = _Employee._EmployeeID.ToString();
           

            if (_Employee._IsActive)
                lbIsActive.Text = "Yes";
            else
                lbIsActive.Text = "No";
            lbEmployeeID.Text = _Employee._EmployeeID.ToString();
            lbHireDate.Text = _Employee._HireDate.ToShortDateString();
            if (_Employee._ResignationDate == DateTime.MinValue)
                lbResignationDate.Text = "[Active Employee]";
            else
                lbResignationDate.Text = _Employee._ResignationDate.ToString();
            lbSalary.Text = _Employee._Salary.ToString("C");
            lbHiredBy.Text = _Employee._HiredByUserID.ToString();
        }

        private void _ResetPersonInfo()
        {

            ctrlPersonCard1.ResetPersonInfo();
            lbEmployeeID.Text = "[???]";
            lbHireDate.Text = "[???]";
            lbResignationDate.Text = "[???]";
            lbSalary.Text = "[???]";
            lbHiredBy.Text = "[???]";
            lbIsActive.Text = "[???]";
        }
    }
}

