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
    public partial class frmCategories : Form
    {
        private static DataTable _dtAllCategories;
        public frmCategories()
        {
            InitializeComponent();
            
        }

        private void frmCategories_Load(object sender, EventArgs e)
        {

            clsCommonFormMethods.CenterPanel(FormPanel, this);

            _dtAllCategories = clsCategoryOfItem.GetAllCategoryOfItems();
            dgvCategories.DataSource = _dtAllCategories;
            
            lblRecordsCount.Text = dgvCategories.Rows.Count.ToString();

            dgvCategories.Columns[0].HeaderText = "Category ID";
            dgvCategories.Columns[0].Width = 110;

            dgvCategories.Columns[1].HeaderText = "Category Name";
            dgvCategories.Columns[1].Width = 150;

            lblRecordsCount.Text = dgvCategories.Rows.Count.ToString();

        }

        private void frmCategories_Resize(object sender, EventArgs e)
        {
            clsCommonFormMethods.CenterPanel(FormPanel, this);
        }

        private void btnAddNewCategory_Click(object sender, EventArgs e)
        {
            frmAddUpdateCategory addUpdateCategory = new frmAddUpdateCategory();
            addUpdateCategory.ShowDialog();
            frmCategories_Load(null, null);
        }

        private void renameCategoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddUpdateCategory Frm1 = new frmAddUpdateCategory((int)dgvCategories.CurrentRow.Cells[0].Value);
            Frm1.ShowDialog();
        }


        private void deleteCategoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int CategoryID = (int)dgvCategories.CurrentRow.Cells[0].Value;
            if (clsCategoryOfItem.Delete(CategoryID))
            {
                MessageBox.Show("Category has been deleted successfully", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                frmCategories_Load(null, null);
            }

            else
                MessageBox.Show("Category is not deleted due to data connected to it.", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
