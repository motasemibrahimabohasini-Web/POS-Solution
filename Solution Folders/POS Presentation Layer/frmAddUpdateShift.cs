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
    public partial class frmAddUpdateShift : Form
    {
        public enum enMode { AddNew = 0, Update = 1 };
        private enMode _Mode;
        private int _ShiftID = -1;
        bool isClosing = false;

        clsShifts _Shift;
        public frmAddUpdateShift()
        {
            InitializeComponent();
            _Mode = enMode.AddNew;
        }
        public frmAddUpdateShift(int CaategoryID)
        {
            InitializeComponent();
            _Mode = enMode.Update;
            _ShiftID = CaategoryID;
        }
        private void _LoadData()
        {

            _Shift = clsShifts.Find(_ShiftID);


            if (_ShiftID == -1)
            {
                MessageBox.Show("No Shift with ID = " + _ShiftID, "Shift Not Found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();

                return;
            }

            //the following code will not be executed if the person was not found
            lblTitle.Text = "Update Item";
            this.Text = "Update Item";
           



        }

        private void _ResetDefualtValues()
        {
            //this will initialize the reset the defaule values

            if (_Mode == enMode.AddNew)
            {
                lblTitle.Text = "Add New Shift";
                this.Text = "Add New Shift";
                _Shift = new clsShifts();




            }
            else
            {
                lblTitle.Text = "Update Item";
                this.Text = "Update Item";


                btnSave.Enabled = true;


            }

            lbShiftID.Text = "Item ID: N/A";
            



        }
        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void tbPrice_TextChanged(object sender, EventArgs e)
        {

        }

        private void tbShiftName_TextChanged(object sender, EventArgs e)
        {

        }

        private void lbItemID_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pbGendor_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

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

            //Here we continue because the form is valid
            _Shift._ComingDate= dtpComingDate.Value;
            _Shift._LeavingDAte = dtpLeavingDate.Value;
            if (_Shift.save())
            {
                lbShiftID.Text = _Shift._ShiftID.ToString(); 
                _Mode = enMode.Update;
                lblTitle.Text = "Update Shift";
                this.Text = "Update Shift";
                MessageBox.Show("Shift has been saved successfully", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Error: Shift Data Is not Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void frmAddUpdateShift_Load(object sender, EventArgs e)
        {
            btnCancel.CausesValidation = false;
            _ResetDefualtValues();


            if (_Mode == enMode.Update)
                _LoadData();
        }

  

        private void btnCancel_Click(object sender, EventArgs e)
        {

            this.Close();
        }

        private void frmAddUpdateShift_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

       
    }
}
