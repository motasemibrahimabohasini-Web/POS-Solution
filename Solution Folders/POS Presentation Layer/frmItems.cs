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
    public partial class frmItems : Form
    {
        private static DataTable _dtAllItems;
        public frmItems()
        {
            InitializeComponent();
        }

        private void FormPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void frmProducts_Load(object sender, EventArgs e)
        {
            clsCommonFormMethods.CenterPanel(FormPanel, this);
            _dtAllItems = clsItem.GetAllItemss();
            dgvItems.DataSource = _dtAllItems;
            cbFilterBy.SelectedIndex = 0;
            lblRecordsCount.Text = dgvItems.Rows.Count.ToString();

            dgvItems.Columns[0].HeaderText = "Item ID";
            dgvItems.Columns[0].Width = 110;

            dgvItems.Columns[1].HeaderText = "Item name";
            dgvItems.Columns[1].Width = 120;

            dgvItems.Columns[2].HeaderText = "Price";
            dgvItems.Columns[2].Width = 60;

            dgvItems.Columns[3].HeaderText = "Category Name";
            dgvItems.Columns[3].Width = 200;

            dgvItems.Columns[4].HeaderText = "IsActive";
            dgvItems.Columns[4].Width = 50;

            dgvItems.Columns[5].HeaderText = "Created By";
            dgvItems.Columns[5].Width = 135;

        }

        private void frmProducts_Resize(object sender, EventArgs e)
        {
            clsCommonFormMethods.CenterPanel(FormPanel, this);
        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbFilterBy.Text == "Is Active")
            {
                txtFilterValue.Visible = false;
                cbIsActive.Visible = true;
                cbIsActive.Focus();
                cbIsActive.SelectedIndex = 0;
            }

            else

            {

                txtFilterValue.Visible = (cbFilterBy.Text != "None");
                cbIsActive.Visible = false;

                if (cbFilterBy.Text == "None")
                {
                    txtFilterValue.Enabled = false;
                }
                else
                    txtFilterValue.Enabled = true;

                txtFilterValue.Text = "";
                txtFilterValue.Focus();
            }
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            frmAddUpdateItem frmAddUpdateItem = new frmAddUpdateItem();
            frmAddUpdateItem.ShowDialog();
            frmProducts_Load(null, null);

        }

        private void cbIsActive_SelectedIndexChanged(object sender, EventArgs e)
        {
            string FilterColumn = "IsActive";
            string FilterValue = cbIsActive.Text;

            switch (FilterValue)
            {
                case "All":
                    break;
                case "Yes":
                    FilterValue = "1";
                    break;
                case "No":
                    FilterValue = "0";
                    break;
            }


            if (FilterValue == "All")
                _dtAllItems.DefaultView.RowFilter = "";
            else
                //in this case we deal with numbers not string.
                _dtAllItems.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, FilterValue);

            lblRecordsCount.Text = _dtAllItems.Rows.Count.ToString();
        }

        private void txtFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilterBy.Text == "Item ID")
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtFilterValue_TextChanged(object sender, EventArgs e)
        {
            string FilterColumn = "";
            //Map Selected Filter to real Column name 
            switch (cbFilterBy.Text)
            {
                case "Item ID":
                    FilterColumn = "ItemID";
                    break;
                case "Item Name":
                    FilterColumn = "ItemName";
                    break;
                case "Category Name":
                    FilterColumn = "CategoryName";
                    break;
                case "Is Active":
                    FilterColumn = "IsActive";
                    break;
                case "Created By":
                    FilterColumn = "CreatedBy";
                    break;

                default:
                    FilterColumn = "None";
                    break;
            }
            if (txtFilterValue.Text.Trim() == "" || FilterColumn == "None")
            {
                _dtAllItems.DefaultView.RowFilter = "";
                lblRecordsCount.Text = dgvItems.Rows.Count.ToString();
                return;
            }


            if (FilterColumn != "CreatedBy" && FilterColumn != "ItemName" && FilterColumn != "CategoryName")
                //in this case we deal with numbers not string.
                _dtAllItems.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, txtFilterValue.Text.Trim());
            else
                _dtAllItems.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", FilterColumn, txtFilterValue.Text.Trim());

            lblRecordsCount.Text = _dtAllItems.Rows.Count.ToString();
        }

        private void deleteItemToolStripMenuItem_Click(object sender, EventArgs e)
        {

            int ItemID = (int)dgvItems.CurrentRow.Cells[0].Value;
            if (MessageBox.Show("Are you sure you want to delete this item?", "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                return;
            if (clsItem.Delete(ItemID))
            {
                _dtAllItems.DefaultView.RowFilter = string.Format("[ItemID] <> {0}", ItemID);
                MessageBox.Show("Item has been deleted successfully", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                frmProducts_Load(null, null);
            }

            else
                MessageBox.Show("Item is not deleted due to data connected to it.", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void editItemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddUpdateItem frm = new frmAddUpdateItem((int)dgvItems.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            frmProducts_Load(null, null);
        }

        private void itemInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmItemInfo frm = new frmItemInfo((int)dgvItems.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
        }
    }
}
