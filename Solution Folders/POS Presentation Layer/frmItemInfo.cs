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
    public partial class frmItemInfo : Form
    {
        private clsItem _Item;
        public frmItemInfo(int ItemID)
        {
            InitializeComponent();
            LoadItemInfo(ItemID);
        }

        private void LoadItemInfo(int ItemID)
        {
            _Item = clsItem.Find(ItemID);
            if (_Item == null)
            {
                
                MessageBox.Show("No Item with ItemID = " + ItemID.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _FillUserInfo();
        }

        private void _FillUserInfo()
        {
           
          
           lbItemID.Text = _Item._ItemID.ToString();
           lbItemName.Text = _Item._ItemName.ToString();
            lbPrice.Text = _Item._Price.ToString();
            lbCreatedByUser.Text = clsUser.Find(_Item._UserID).UserName;
            if(_Item._ImagePath==""||_Item._ImagePath == null)
            {
                pbItemPicture.Image = null;
            }
            else
            {
                pbItemPicture.ImageLocation = _Item._ImagePath;
            }
              lbIsActive.Text = _Item._IsActive ? "Yes" : "No";
            lbCategoryName.Text = clsCategoryOfItem.Find(_Item._CategoryOfItemID).CategoryName;


                

        }
    }
}
