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
    public partial class frmRefundOrder : Form
    {
        public frmRefundOrder(int OrderID)
        {
            InitializeComponent();
            ctrlOrderDetails1.LoadOrderInformation(OrderID);
        }

        private void btnRefund_Click(object sender, EventArgs e)
        {
            ctrlOrderDetails1._Order._IsActive = false;

            if (MessageBox.Show("Are you sure you want to Refund This Order ? ", "Are You sure", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)==DialogResult.Yes)
            {
                if (ctrlOrderDetails1._Order.Refund())
                {
                    MessageBox.Show("Order Have Been Refunded Successfully", "Success");
                }
                else
                {
                    MessageBox.Show("Something Went Wrong Order does not Refunded", "Faild", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            
            
        }
    }
}
