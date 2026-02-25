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
    public partial class frmAddUpdateItem : Form
    {
        public enum enMode { AddNew = 0, Update = 1 };
        private enMode _Mode;
        private int _ItemID = -1;
       
        clsItem _Item = new clsItem();
        public frmAddUpdateItem()
        {
            InitializeComponent();
            _Mode = enMode.AddNew;

            
        }
        public frmAddUpdateItem(int ItemID)
        {
            InitializeComponent();
            _Mode = enMode.Update;
            _ItemID = ItemID;
            btnAddItemOptions.Enabled = true;
        }

        private void _LoadData()
        {

            _Item = clsItem.Find(_ItemID);
            

            if (_Item == null)
            {
                MessageBox.Show("No Item with ID = " + _Item, "Item Not Found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();

                return;
            }

            //the following code will not be executed if the person was not found
            lblTitle.Text = "Update Item";
            this.Text = "Update Item";
            tbItemName.Text = _Item._ItemName;
            tbPrice.Text = Convert.ToString( _Item._Price);
            cbIsActive.Checked = _Item._IsActive;
            if (!string.IsNullOrEmpty(_Item._ImagePath))
            {
                pbItemPicture.Image = Image.FromFile( _Item._ImagePath);
            }

        }

        private void _ResetDefualtValues()
        {
            //this will initialize the reset the defaule values

            if (_Mode == enMode.AddNew)
            {
                lblTitle.Text = "Add New Item";
                this.Text = "Add New Item";
                _Item = new clsItem();

                

                
            }
            else
            {
                lblTitle.Text = "Update Item";
                this.Text = "Update Item";

                
                btnSave.Enabled = true;


            }

            lbItemID.Text = "Item ID: N/A";
            tbItemName.Text = "";
            tbPrice.Text = "";
            cbIsActive.Checked = true;
            pbItemPicture.Image = null;


        }

        private void lblTitle_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
         
            openFileDialog1.Title = "Select a Picture";
            openFileDialog1.Filter = "Picture files (*.jpg;*.jpeg;*.png)|*.jpg;*.jpeg;*.png|All files (*.*)|*.*";
            openFileDialog1.Multiselect = false;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog1.FileName;
                pbItemPicture.Image = Image.FromFile(filePath);
                _Item._ImagePath = filePath;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            
        }

        private void frmAddNewProduct_Load(object sender, EventArgs e)
        {
            _ResetDefualtValues();
            LoadCategories();

            if (_Mode == enMode.Update)
                _LoadData();
        }

        private void btnSave_Click_1(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                //Here we dont continue becuase the form is not valid
                MessageBox.Show("Some fileds are not valide!, put the mouse over the red icon(s) to see the erro",
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }
            _Item._ItemName = tbItemName.Text;
            _Item._Price = Convert.ToSingle(tbPrice.Text);
            _Item._IsActive = cbIsActive.Checked;
            _Item._ImagePath = pbItemPicture.ImageLocation;
            _Item._UserID = 1025;
            _Item._CategoryOfItemID = (int)cbCategory.SelectedValue;
            lbCreatedByUser.Text = clsUser.Find(1025).UserName;
            //set in browse button click event
            if (_Item.Save())
            {
                btnAddItemOptions.Enabled = true;
                lbItemID.Text = _Item._ItemID.ToString();
                //change form mode to update.
                _Mode = enMode.Update;
                lblTitle.Text = "Update Item";
                this.Text = "Update Item";

                MessageBox.Show(" Item Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Error: Item Data Is not Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void tbItemName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetterOrDigit(e.KeyChar)
     && !char.IsControl(e.KeyChar)
     && e.KeyChar != ' ')
            {
                e.Handled = true; // منع أي شيء غير مسموح
            }
        }

        private void tbPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Allow control keys (Backspace, etc.)
            if (char.IsControl(e.KeyChar))
                return;

            // Allow digits
            if (char.IsDigit(e.KeyChar))
                return;

            // Allow only one decimal point
            if (e.KeyChar == '.' && !tbPrice.Text.Contains("."))
                return;

            // Block everything else
            e.Handled = true;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
        private void LoadCategories()
        {
            cbCategory.DisplayMember = "CategoryName";
            cbCategory.ValueMember = "ID";
            cbCategory.DataSource = clsCategoryOfItem.GetAllCategoryOfItems();
        }

        private void cbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
           _Item._CategoryOfItemID= (int)cbCategory.SelectedValue;
        }

        private void tbPrice_Validating(object sender, CancelEventArgs e)
        {
            if (tbPrice.Text.Length == 0)
            {
                e.Cancel = true;
                errorProvider1.SetError(tbPrice,"Please enter the price");

            }
            else
            {
                errorProvider1.SetError(tbPrice, null);
            }


        }

        private void tbItemName_Validating(object sender, CancelEventArgs e)
        {
            if (tbItemName.Text.Length == 0)
            {
                e.Cancel = true;
                errorProvider1.SetError(tbItemName, "Please enter the ITem Name");

            }
            else
            {
                errorProvider1.SetError(tbItemName, null);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmAddUpdateItemOptions frmAddUpdateItemOptions = new frmAddUpdateItemOptions(_Item._ItemID);
            frmAddUpdateItemOptions.ShowDialog();
        }
    }
}
