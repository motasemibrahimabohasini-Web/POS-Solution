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
    public partial class frmAddUpdateItemOptions : Form
    {
        int _ItemID;
        DataTable dt;
        public frmAddUpdateItemOptions()
        {
            InitializeComponent();
        }

       public frmAddUpdateItemOptions(int ItemID)
       {
           InitializeComponent();
           this._ItemID = ItemID;
          

            



        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            DataTable dt = dgvItemOptions.DataSource as DataTable;
            
            if (dt != null && dt.Rows.Count > 0)
            {
                clsItemOptions itemOptions = new clsItemOptions();
                itemOptions.ItemOptions = dt;
                itemOptions.ItemID = _ItemID;
                bool success = itemOptions.Save();
                if (success)
                {
                    MessageBox.Show("Data saved successfully");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Failed to save data");
                }
            }
            else
            {
                MessageBox.Show("No data to save");
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
          if( MessageBox.Show("Are you sure You want to delete this Item Option ? ", "Are You sure", MessageBoxButtons.YesNo, MessageBoxIcon.Question)==DialogResult.Yes)
            {
                if (clsItemOptions.DeleteOptionItem((int)dgvItemOptions.CurrentRow.Cells[0].Value))
                {
                    frmAddUpdateItemOptions_Load(null, null);
                    

                }
                else
                {
                    MessageBox.Show("Failed to delete item");
                }

            }
           

           

        }

        private void dgvItemOptions_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void frmAddUpdateItemOptions_Load(object sender, EventArgs e)
        {
            dt = clsItemOptions.GetOptionsItemByItemID(_ItemID);
            dgvItemOptions.DataSource = dt;
        }
    }
}
