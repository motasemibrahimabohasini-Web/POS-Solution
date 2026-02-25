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

    public partial class frmShifts : Form
    {
        private static DataTable _dtAllShifts;

        public frmShifts()
        {
            InitializeComponent();
            clsCommonFormMethods.CenterPanel(FormPanel, this);

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }










        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {

            //frmAddUpdateShift Frm1 = new frmAddUpdateShift((int)dgvShifts.CurrentRow.Cells[0].Value);
            //Frm1.ShowDialog();
            frmShifts_Load(null, null);

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //frmAddUpdateShift Frm1 = new frmAddUpdateShift();
            //Frm1.ShowDialog();
            frmShifts_Load(null, null);

        }

        private void dgvShifts_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //frmShiftInfo Frm1 = new frmShiftInfo((int)dgvShifts.CurrentRow.Cells[0].Value);
            //Frm1.ShowDialog();

        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //frmShiftInfo Frm1 = new frmShiftInfo((int)dgvShifts.CurrentRow.Cells[0].Value);
            //Frm1.ShowDialog();

        }

        private void ChangePasswordtoolStripMenuItem_Click(object sender, EventArgs e)
        {

            int ShiftID = (int)dgvShifts.CurrentRow.Cells[0].Value;
            frmChangePassword Frm1 = new frmChangePassword(ShiftID);
            Frm1.ShowDialog();

        }





        private void frmListShifts_Resize(object sender, EventArgs e)
        {

        }

        private void frmListShifts_Resize_1(object sender, EventArgs e)
        {
            clsCommonFormMethods.CenterPanel(FormPanel, this);
        }

        private void lblTitle_Click(object sender, EventArgs e)
        {

        }

        private void btnAddShift_Click_1(object sender, EventArgs e)
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




        private void frmShifts_Resize(object sender, EventArgs e)
        {
            clsCommonFormMethods.CenterPanel(FormPanel, this);
        }

        private void cbFilterBy_SelectedIndexChanged_3(object sender, EventArgs e)
        {
            dateTimePicker1.Visible = cbFilterBy.Text == "Coming Date" ? true : false;
            txtFilterValue.Visible = (cbFilterBy.Text != "None");

        }



        private void txtFilterValue_KeyPress_2(object sender, KeyPressEventArgs e)
        {
            //we allow number incase person id or user id is selected.
            if (cbFilterBy.Text == "Person ID" || cbFilterBy.Text == "User ID")
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void frmShifts_Load(object sender, EventArgs e)
        {
            _dtAllShifts = clsShifts.GetAllShifts();
            dgvShifts.DataSource = _dtAllShifts;
            cbFilterBy.SelectedIndex = 0;
            lblRecordsCount.Text = dgvShifts.Rows.Count.ToString();

            dgvShifts.Columns[0].HeaderText = "Shift ID";
            dgvShifts.Columns[0].Width = 110;


            dgvShifts.Columns[1].HeaderText = "Full Name";
            dgvShifts.Columns[1].Width = 200;

            dgvShifts.Columns[2].HeaderText = "Coming Date";
            dgvShifts.Columns[2].Width = 120;

            dgvShifts.Columns[3].HeaderText = "Leaving Date";
            dgvShifts.Columns[3].Width = 120;

            dgvShifts.Columns[4].HeaderText = "Is In Vacation";
            dgvShifts.Columns[4].Width = 120;





        }

        private void txtFilterValue_TextChanged(object sender, EventArgs e)
        {
            string FilterColumn = "";
            //Map Selected Filter to real Column name 
            switch (cbFilterBy.Text)
            {
                case "Shift ID":
                    FilterColumn = "ShiftID";
                    break;
                case "Full Name":
                    FilterColumn = "Fullname";
                    break;
                case "Coming Date":
                    FilterColumn = "ComingDate";
                    break;
                default:
                    FilterColumn = "None";
                    break;
            }

            //Reset the filters in case nothing selected or filter value conains nothing.
            if (txtFilterValue.Text.Trim() == "" || FilterColumn == "None")
            {
                _dtAllShifts.DefaultView.RowFilter = "";
                lblRecordsCount.Text = dgvShifts.Rows.Count.ToString();
                return;
            }


            if (FilterColumn != "Fullname" && FilterColumn != "ComingDate")
            {
                _dtAllShifts.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, txtFilterValue.Text.Trim());
                lblRecordsCount.Text = _dtAllShifts.Rows.Count.ToString(); return;
            }
           
            else
            {
                _dtAllShifts.DefaultView.RowFilter = string.Format("[{0}] LIKE '%{1}%'", FilterColumn, txtFilterValue.Text.Trim().Replace("'", "''"));
                lblRecordsCount.Text = _dtAllShifts.Rows.Count.ToString(); return;
            }
        }

        private void dateTimePicker1_KeyPress(object sender, KeyPressEventArgs e)
        {
          

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            DateTime selectedDate = dateTimePicker1.Value.Date;

            _dtAllShifts.DefaultView.RowFilter =
                $"[ComingDate] >= #{selectedDate:MM/dd/yyyy}# AND " +
                $"[ComingDate] < #{selectedDate.AddDays(1):MM/dd/yyyy}#";

            lblRecordsCount.Text = dgvShifts.Rows.Count.ToString();
        }

        private void btnAddNewShift_Click(object sender, EventArgs e)
        {

        }
    }
}
