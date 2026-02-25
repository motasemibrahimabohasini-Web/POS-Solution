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
    public partial class frmOrders : Form
    {
        private static DataTable _dtAllOrders;

        public frmOrders()
        {
            InitializeComponent();
            clsCommonFormMethods.CenterPanel(FormPanel, this);

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmListOrders_Load(object sender, EventArgs e)
        {
           



        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {


            

                txtFilterValue.Visible = (cbFilterBy.Text != "None");
             
                if (cbFilterBy.Text == "None")
                {
                    txtFilterValue.Enabled = false;
                }
                else
                    txtFilterValue.Enabled = true;

                txtFilterValue.Text = "";
                txtFilterValue.Focus();
            


        }


  

    

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {

            //frmAddUpdateOrder Frm1 = new frmAddUpdateOrder((int)dgvOrders.CurrentRow.Cells[0].Value);
            //Frm1.ShowDialog();
            frmListOrders_Load(null, null);

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //frmAddUpdateOrder Frm1 = new frmAddUpdateOrder();
            //Frm1.ShowDialog();
            frmListOrders_Load(null, null);

        }

        private void dgvOrders_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //frmOrderInfo Frm1 = new frmOrderInfo((int)dgvOrders.CurrentRow.Cells[0].Value);
            //Frm1.ShowDialog();

        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //frmOrderInfo Frm1 = new frmOrderInfo((int)dgvOrders.CurrentRow.Cells[0].Value);
            //Frm1.ShowDialog();

        }

        private void ChangePasswordtoolStripMenuItem_Click(object sender, EventArgs e)
        {

            int OrderID = (int)dgvOrders.CurrentRow.Cells[0].Value;
            frmChangePassword Frm1 = new frmChangePassword(OrderID);
            Frm1.ShowDialog();

        }

        private void txtFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            //we allow number incase person id or Order id is selected.
            if (cbFilterBy.Text == "Person ID" || cbFilterBy.Text == "Order ID")
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

      

        private void frmListOrders_Resize(object sender, EventArgs e)
        {

        }

        private void frmListOrders_Resize_1(object sender, EventArgs e)
        {
            clsCommonFormMethods.CenterPanel(FormPanel, this);
        }

        private void lblTitle_Click(object sender, EventArgs e)
        {

        }

        private void btnAddOrder_Click_1(object sender, EventArgs e)
        {

        }

        private void FormPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void cbFilterBy_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

 

   
        private void cbFilterBy_SelectedIndexChanged_2(object sender, EventArgs e)
        {


            txtFilterValue.Visible = (cbFilterBy.Text != "None");
          

            if (cbFilterBy.Text == "None")
            {
                txtFilterValue.Enabled = false;
            }
            else
                txtFilterValue.Enabled = true;

            txtFilterValue.Text = "";
            txtFilterValue.Focus();

        }

        private void txtFilterValue_TextChanged_1(object sender, EventArgs e)
        {
            string FilterColumn = "";
            //Map Selected Filter to real Column name 
            switch (cbFilterBy.Text)
            {
                case "Order ID":
                    FilterColumn = "OrderID";
                    break;
                case "Total Amount":
                    FilterColumn = "TotalAmount";
                    break;
                case "Username":
                    FilterColumn = "Username";
                    break;
                default:
                    FilterColumn = "None";
                    break;

            }

            //Reset the filters in case nothing selected or filter value conains nothing.
            if (txtFilterValue.Text.Trim() == "" || FilterColumn == "None")
            {
                _dtAllOrders.DefaultView.RowFilter = "";
                lblRecordsCount.Text = dgvOrders.Rows.Count.ToString();
                return;
            }


            if (FilterColumn != "Fullname")
                //in this case we deal with numbers not string.
                _dtAllOrders.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, txtFilterValue.Text.Trim());

            else
                _dtAllOrders.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", FilterColumn, txtFilterValue.Text.Trim());

            lblRecordsCount.Text = _dtAllOrders.Rows.Count.ToString();
        }

        private void txtFilterValue_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            //we allow number incase person id or user id is selected.
            if (cbFilterBy.Text == "Person ID" || cbFilterBy.Text == "User ID")
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void frmOrders_Resize(object sender, EventArgs e)
        {
            clsCommonFormMethods.CenterPanel(FormPanel, this);
        }

     

        private void frmOrders_Load(object sender, EventArgs e)
        {
            _dtAllOrders = clsOrders.GetAllOrders();
            dgvOrders.DataSource = _dtAllOrders;
            cbFilterBy.SelectedIndex = 0;
            lblRecordsCount.Text = dgvOrders.Rows.Count.ToString();

            dgvOrders.Columns[0].HeaderText = "Order ID";
            dgvOrders.Columns[0].Width = 110;

            dgvOrders.Columns[1].HeaderText = "Total Amount";
            dgvOrders.Columns[1].Width = 120;

            dgvOrders.Columns[2].HeaderText = "Release Date";
            dgvOrders.Columns[2].Width = 350;

            dgvOrders.Columns[3].HeaderText = "Username";
            dgvOrders.Columns[3].Width = 100;
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {

        }

        private void lblTitle_Click_1(object sender, EventArgs e)
        {

        }
    }
}

