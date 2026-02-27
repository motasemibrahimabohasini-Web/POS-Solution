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
    public partial class ctrlOrderDetails : UserControl
    {
       public clsOrder _Order;
        DataTable _dtSales;
        public ctrlOrderDetails()
        {
            InitializeComponent();
            
        }

        private void lblTitle_Click(object sender, EventArgs e)
        {

        }

        public void LoadOrderInformation(int OrderID )
        {
            _dtSales = clsSales.GetSalesByOrderID(OrderID);
            dgvSales.DataSource = _dtSales;

            _Order = clsOrder.Find(OrderID);
            if (_Order != null)
            {
                lbOrderID.Text = _Order._OrderID.ToString();
                lbReleasedDate.Text = _Order._ReleaseDate.ToString();
                lbTotalAmount.Text = _Order._TotalAmount.ToString();
                lbReleaseByUsername.Text = clsUser.Find(_Order._ReleasedByUserID).UserName;
            }
            
        }

        private void ctrlOrderDetails_Load(object sender, EventArgs e)
        {
            
        }
    }
}
