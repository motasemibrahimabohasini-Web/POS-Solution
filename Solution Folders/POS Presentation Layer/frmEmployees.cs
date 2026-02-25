using Cash_System;
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
    public partial class frmEmployees : Form
    {
        private static DataTable _dtAllEmployees = clsEmployee.GetAllEmployees();

        public frmEmployees()
        {
            InitializeComponent();
            clsCommonFormMethods.CenterPanel(FormPanel, this);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
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

        private void txtFilterValue_TextChanged(object sender, EventArgs e)
        {
            string FilterColumn = "";
            //Map Selected Filter to real Column name 
            switch (cbFilterBy.Text)
            {
                case "Employee ID":
                    FilterColumn = "EmployeeID";
                    break;
                case "EmployeeName":
                    FilterColumn = "EmployeeName";
                    break;

                case "Person ID":
                    FilterColumn = "PersonID";
                    break;


                case "Full Name":
                    FilterColumn = "FullName";
                    break;

                default:
                    FilterColumn = "None";
                    break;

            }

            //Reset the filters in case nothing selected or filter value conains nothing.
            if (txtFilterValue.Text.Trim() == "" || FilterColumn == "None")
            {
                _dtAllEmployees.DefaultView.RowFilter = "";
                lblRecordsCount.Text = dgvEmployees.Rows.Count.ToString();
                return;
            }


            if (FilterColumn != "FullName" && FilterColumn != "EmployeeName")
                //in this case we deal with numbers not string.
                _dtAllEmployees.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, txtFilterValue.Text.Trim());
            else
                _dtAllEmployees.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", FilterColumn, txtFilterValue.Text.Trim());

            lblRecordsCount.Text = _dtAllEmployees.Rows.Count.ToString();
        }


        private void btnAddEmployee_Click(object sender, EventArgs e)
        {

            frmEmployees_Load(null, null);
        }

        private void editToolStripMenuEmployee_Click(object sender, EventArgs e)
        {


            frmEmployees_Load(null, null);

        }

        private void toolStripMenuEmployee1_Click(object sender, EventArgs e)
        {

            frmEmployees_Load(null, null);

        }

        private void dgvEmployees_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {


        }




        private void frmListEmployees_Resize(object sender, EventArgs e)
        {

        }

        private void frmListEmployees_Resize_1(object sender, EventArgs e)
        {

        }

        private void lblTitle_Click(object sender, EventArgs e)
        {

        }

        private void btnAddEmployee_Click_1(object sender, EventArgs e)
        {

        }

        private void frmEmployees_Resize(object sender, EventArgs e)
        {
            clsCommonFormMethods.CenterPanel(FormPanel, this);
        }

        private void frmEmployees_Load(object sender, EventArgs e)
        {

            _dtAllEmployees = clsEmployee.GetAllEmployees();
            dgvEmployees.DataSource = _dtAllEmployees;
            cbFilterBy.SelectedIndex = 0;
            lblRecordsCount.Text = dgvEmployees.Rows.Count.ToString();

            dgvEmployees.Columns[0].HeaderText = "Employee ID";
            dgvEmployees.Columns[0].Width = 110;

            dgvEmployees.Columns[1].HeaderText = "Full Name";
            dgvEmployees.Columns[1].Width = 200;

            dgvEmployees.Columns[2].HeaderText = "Hire Date ";
            dgvEmployees.Columns[2].Width = 150;


            dgvEmployees.Columns[3].HeaderText = "Resignation Date ";
            dgvEmployees.Columns[3].Width = 150;

            dgvEmployees.Columns[4].HeaderText = "Salary ";
            dgvEmployees.Columns[4].Width = 150;

            dgvEmployees.Columns[5].HeaderText = "Is Active";
            dgvEmployees.Columns[5].Width = 120;
        }

        private void btnAddNewEmployee_Click(object sender, EventArgs e)
        {
            frmAddUpdateEmployee Frm1 = new frmAddUpdateEmployee();
            Frm1.ShowDialog();
            frmEmployees_Load(null, null);
        }

        private void cbFilterBy_SelectedIndexChanged_1(object sender, EventArgs e)
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
                _dtAllEmployees.DefaultView.RowFilter = "";
            else
                //in this case we deal with numbers not string.
                _dtAllEmployees.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, FilterValue);

            lblRecordsCount.Text = _dtAllEmployees.Rows.Count.ToString();
        }

        private void txtFilterValue_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (cbFilterBy.Text == "Employee ID")
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtFilterValue_TextChanged_1(object sender, EventArgs e)
        {
            string FilterColumn = "";
            //Map Selected Filter to real Column name 
            switch (cbFilterBy.Text)
            {
                case "Employee ID":
                    FilterColumn = "EmpID";
                    break;
                case "Full Name":
                    FilterColumn = "FullName";
                    break;
                case "Is Active":
                    FilterColumn = "IsActive";
                    break;
                case "Salary":
                    FilterColumn = "Salary";
                        break;
                default:
                    FilterColumn = "None";
                    break;
            }
            if (txtFilterValue.Text.Trim() == "" || FilterColumn == "None")
            {
                _dtAllEmployees.DefaultView.RowFilter = "";
                lblRecordsCount.Text = dgvEmployees.Rows.Count.ToString();
                return;
            }

            if ( FilterColumn != "FullName")
                //in this case we deal with numbers not string.
                _dtAllEmployees.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, txtFilterValue.Text.Trim());
            else
                _dtAllEmployees.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", FilterColumn, txtFilterValue.Text.Trim());

            lblRecordsCount.Text = _dtAllEmployees.Rows.Count.ToString();
        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEmployeeInfo Frm1 = new frmEmployeeInfo((int)dgvEmployees.CurrentRow.Cells[0].Value);
            Frm1.ShowDialog();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddUpdateEmployee Frm1 = new frmAddUpdateEmployee((int)dgvEmployees.CurrentRow.Cells[0].Value);
            Frm1.ShowDialog();
            frmEmployees_Load(null, null);
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Are you sure you want to delete this Employee?", "Delete Employee", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dr == DialogResult.No)
                return;
            if (clsEmployee.DeleteEmployee((int)dgvEmployees.CurrentRow.Cells[0].Value))
            {
                frmEmployees_Load(null, null);
                MessageBox.Show("Employee deleted successfully.", "Delete Employee", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {
                MessageBox.Show("Error deleting Employee.", "Delete Employee", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmAddUpdateEmployee Frm1 = new frmAddUpdateEmployee();
            Frm1.ShowDialog();
            frmEmployees_Load(null, null);
        }
    }
}
