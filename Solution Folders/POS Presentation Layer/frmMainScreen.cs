using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cash_System
{
    public partial class frmMainScreen : Form
    {
        frmPOSItemSelectorScreen frmCashScreen;
        frmUsers frmListUsers ;
        frmOrders frmOrders ;
        frmItems frmProducts ;
        frmEmployees frmEmployees ;
        frmCategories frmCategories;
        frmShifts FrmShifts;
        public frmMainScreen()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (frmProducts == null)
            {
                frmProducts = new frmItems();
                frmProducts.FormClosed += FrmProducts_FormClosed;
                frmProducts.MdiParent = this;
                frmProducts.Dock = DockStyle.Fill;
                frmProducts.Show();
            }
            else
            {
                frmProducts.Activate();
            }
        }

        private void FrmProducts_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmProducts = null;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (frmOrders == null)
            {
                frmOrders = new frmOrders();
                frmOrders.FormClosed += FrmOrders_FormClosed;
                frmOrders.MdiParent = this;
                frmOrders.Dock = DockStyle.Fill;
                frmOrders.Show();
            }
            else
            {
                frmOrders.Activate();
            }
        }

        private void FrmOrders_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmOrders = null;
        }

        bool SidebarExpand = true;
        private void SideParTransition_Tick(object sender, EventArgs e)
        {
            if (SidebarExpand)
            {
                Sidebar.Width -= 10;
                if(Sidebar.Width <= 65)
                {
                    SidebarExpand = false;
                    SideParTransition.Stop();
               

                }
            }
            else
            {
                Sidebar.Width += 10; 
                if(Sidebar.Width>= 262)
                {
                    SidebarExpand= true;
                    SideParTransition.Stop();
             
                }
            }
            
        }

        private void btnHam_Click(object sender, EventArgs e)
        {
            SideParTransition.Start();
        }

        private void Sidebar_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnCashScreen_Click(object sender, EventArgs e)
        {
            if (frmCashScreen == null)
            {
                frmCashScreen = new frmPOSItemSelectorScreen();
                frmCashScreen.FormClosed += FrmCashScreen_FormClosed;
                frmCashScreen.ShowDialog();
            }
            else
            {
                frmCashScreen.Activate();
            }
        }

        private void FrmCashScreen_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmCashScreen = null;
        }

        private void btnUser_Click(object sender, EventArgs e)
        {
            if (frmListUsers == null)
            {
                frmListUsers = new frmUsers();
                frmListUsers.FormClosed += FrmListUsers_FormClosed;
                frmListUsers.MdiParent = this;
                frmListUsers.Dock = DockStyle.Fill;
                frmListUsers.Show();
            }
            else
            {
                frmListUsers.Activate();
            }

        }

        private void FrmListUsers_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmListUsers = null;
        }

        private void btnEmployees_Click(object sender, EventArgs e)
        {
            if (frmEmployees == null)
            {
                frmEmployees = new frmEmployees();
                frmEmployees.FormClosed += FrmEmployees_FormClosed;
                frmEmployees.MdiParent = this;
                frmEmployees.Dock = DockStyle.Fill;
                frmEmployees.Show();
            }
            else
            {
                frmEmployees.Activate();
            }
        }

        private void FrmEmployees_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmEmployees = null;
        }
        private void FrmCategories_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmCategories = null;
        }
        private void FrmShifts_FormClosed(object sender, FormClosedEventArgs e)
        {
            FrmShifts = null;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (frmCategories == null)
            {
                frmCategories = new frmCategories();
                frmCategories.FormClosed += FrmCategories_FormClosed;
                frmCategories.MdiParent = this;
                frmCategories.Dock = DockStyle.Fill;
                frmCategories.Show();
            }
            else
            {
                frmCategories.Activate();
            }
        }

        private void frmMainScreen_Load(object sender, EventArgs e)
        {
            btnEmployees_Click(null, null);
            SideParTransition.Start();
        }

        private void guna2CircleButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            if (frmCategories == null)
            {
                FrmShifts = new frmShifts();
                FrmShifts.FormClosed += FrmCategories_FormClosed;
                FrmShifts.MdiParent = this;
                FrmShifts.Dock = DockStyle.Fill;
                FrmShifts.Show();
            }
            else
            {
                frmCategories.Activate();
            }
        }
    }
}
