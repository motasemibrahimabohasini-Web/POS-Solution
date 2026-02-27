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
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        
        private void guna2CircleButton1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string HashPassword = CS_BusinessLayer.clsUtil.HashingPassword(tbPassword.Text.Trim());
           if( clsUser.Login(tbUsername.Text.Trim(), HashPassword))
            {
                this.Hide();
                frmMainScreen frmMainScreen = new frmMainScreen();
                frmMainScreen.ShowDialog();
                this.Show();
                
            }
        }
    }
}
