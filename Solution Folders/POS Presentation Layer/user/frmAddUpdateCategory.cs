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
    public partial class frmAddUpdateCategory : Form
    {
        public enum enMode { AddNew = 0, Update = 1 };
        private enMode _Mode;
        private int _CategoryID = -1;
        bool isClosing = false;

        clsCategoryOfItem _Category;
        public frmAddUpdateCategory()
        {
            InitializeComponent();
            _Mode = enMode.AddNew;
        }
        public frmAddUpdateCategory(int CaategoryID)
        {
            InitializeComponent();
            _Mode = enMode.Update;
            _CategoryID = CaategoryID;
        }
        private void _LoadData()
        {

            _Category = clsCategoryOfItem.Find(_CategoryID);


            if (_CategoryID == -1)
            {
                MessageBox.Show("No Category with ID = " + _CategoryID, "Category Not Found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();

                return;
            }

            //the following code will not be executed if the person was not found
            lblTitle.Text = "Update Item";
            this.Text = "Update Item";
            tbCategoryName.Text = _Category.CategoryName;
           
          

        }

        private void _ResetDefualtValues()
        {
            //this will initialize the reset the defaule values

            if (_Mode == enMode.AddNew)
            {
                lblTitle.Text = "Add New Category";
                this.Text = "Add New Category";
                _Category = new clsCategoryOfItem();




            }
            else
            {
                lblTitle.Text = "Update Item";
                this.Text = "Update Item";


                btnSave.Enabled = true;


            }

            lbCategoryID.Text = "Item ID: N/A";
            tbCategoryName.Text = "";
         


        }
        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void tbPrice_TextChanged(object sender, EventArgs e)
        {

        }

        private void tbCategoryName_TextChanged(object sender, EventArgs e)
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
            _Category.CategoryName = tbCategoryName.Text;
            _Category.CategoryID = _CategoryID;
            if(_Category.Save())
            {
                lbCategoryID.Text =  _Category.CategoryID.ToString();
                _Mode = enMode.Update;
                lblTitle.Text = "Update Category";
                this.Text = "Update Category";
                MessageBox.Show("Category has been saved successfully", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Error: Category Data Is not Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void frmAddUpdateCategory_Load(object sender, EventArgs e)
        {
            btnCancel.CausesValidation = false;
            _ResetDefualtValues();
           

            if (_Mode == enMode.Update)
                _LoadData();
        }

        private void tbCategoryName_Validating(object sender, CancelEventArgs e)
        {
          

            if (tbCategoryName.Text.Length == 0)
            {
               
                
                errorProvider1.SetError(tbCategoryName, "Please enter the Category Name");
                e.Cancel = true;

            }
            else
            {
                errorProvider1.SetError(tbCategoryName, null);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            
            this.Close();
        }

        private void frmAddUpdateCategory_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }

        private void tbCategoryName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetterOrDigit(e.KeyChar)
    && !char.IsControl(e.KeyChar)
    && e.KeyChar != ' ')
            {
                e.Handled = true; // منع أي شيء غير مسموح
            }
        }
    }
}
