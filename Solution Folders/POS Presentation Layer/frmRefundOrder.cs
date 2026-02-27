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
    }
}
