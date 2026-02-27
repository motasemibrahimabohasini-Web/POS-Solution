using CS_BusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cash_System
{
    public partial class frmPOSItemSelectorScreen : Form
    {
        Panel centerPanel;
        DataTable _dtInvoice;
        DataTable dtAllItemsByCategory;



        public frmPOSItemSelectorScreen()
        {
            InitializeComponent();

            clsUser User = clsUser.Find(1025);

           LoadCategoriesButtons();

        }

        private void FrmCashScreen_Resize(object sender, EventArgs e)
        {
            clsCommonFormMethods.CenterPanel(centerPanel,this);
        }

      
        private void LoadCategoriesButtons()
        {
            flpCategories.Controls.Clear();
             DataTable dtCategories = clsCategoryOfItem.GetAllCategoryOfItems();
            foreach (DataRow dr in dtCategories.Rows)
            {
                Button btn = new Button();
                btn.Width = 120;
                btn.Height = 50;
                btn.Text = dr["CategoryName"].ToString();
                btn.Tag = dr["ID"];
                btn.BackColor = Color.LightGreen;
                btn.Font = new Font("Arial", 10, FontStyle.Bold);
                btn.Click += CategoryButton_Click;
                flpCategories.Controls.Add(btn);
            }
        }

        private void CategoryButton_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            int categoryID = Convert.ToInt32(btn.Tag);
            LoadItemsByCategory(categoryID);
        }

        private void LoadItemsByCategory(int categoryID)
        {
            flpItems.Controls.Clear();
           dtAllItemsByCategory = clsItem.GetAllItemsByCategory(categoryID);
            foreach (DataRow dr in dtAllItemsByCategory.Rows)
            {
                Button btn = new Button();
                btn.Width = 120;
                btn.Height = 50;
                btn.Text = dr["ItemName"].ToString() +
                    Environment.NewLine +
                    dr["Price"].ToString();
                btn.Tag = dr["ItemID"];
                btn.BackColor = Color.LightBlue;
                btn.Font = new Font("Arial", 10, FontStyle.Bold);
                btn.Click += ItemButton_Click;
                flpItems.Controls.Add(btn);
            }
        }
       
        private void ItemButton_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            int itemID = Convert.ToInt32(btn.Tag);
            string ItemName = dtAllItemsByCategory.AsEnumerable().Where(Row => (int)Row["ItemID"] == itemID).Select(r => r["ItemName"]).FirstOrDefault().ToString();
            Decimal Price =Convert.ToDecimal( dtAllItemsByCategory.AsEnumerable().Where(Row => (int)Row["ItemID"] == itemID).Select(r => r["Price"]).FirstOrDefault());

            AddItemToInvoice(itemID,ItemName,Price);
        }
        private void AddItemToInvoice(int itemID, string itemName, Decimal price)
        {
            DataRow row = _dtInvoice.AsEnumerable()
    .FirstOrDefault(r => r.Field<int>("ItemID") == itemID);


            if (row != null)
            {
                int qty = (int)row["Quantity"] + 1;
                row["Quantity"] = qty;
                row["Total"] = qty * price;

            }
            else
            {
                _dtInvoice.Rows.Add(itemID, itemName, price, 1, price);
            }

            CalculateTotal();
        }
        private void CalculateTotal()
        {
            decimal total = 0;

            foreach (DataRow row in _dtInvoice.Rows)
            {
                total += (decimal)row["Total"];
            }

            lbTotal.Text = total.ToString("0.00 JD");
        }
        private void frmCashScreen_Resize_1(object sender, EventArgs e)
        {

        }
        private void InitializeInvoiceTable()
        {
            _dtInvoice = new DataTable();


            DataGridViewButtonColumn DeletingColumn = new DataGridViewButtonColumn();
            DeletingColumn.Name = "Delete";
            DeletingColumn.Text = "Delete";
            DeletingColumn.HeaderText = "Del";
            DeletingColumn.UseColumnTextForButtonValue = true;
            DeletingColumn.Width = 40;

            DataGridViewButtonColumn IncreaseingColumn = new DataGridViewButtonColumn();
            IncreaseingColumn.Name = "Increase";
            IncreaseingColumn.Text = "+";
            IncreaseingColumn.HeaderText = "Plus";
            IncreaseingColumn.UseColumnTextForButtonValue = true;
            IncreaseingColumn.Width = 40;

            DataGridViewButtonColumn DecreaseingColumn = new DataGridViewButtonColumn();
            DecreaseingColumn.Name = "Decrease";
            DecreaseingColumn.Text = "-";
            DecreaseingColumn.HeaderText = "Minus";
            DecreaseingColumn.UseColumnTextForButtonValue = true;
            DecreaseingColumn.Width = 40;

            dgvInvoice.Columns.Add(DeletingColumn);
            dgvInvoice.Columns.Add(DecreaseingColumn);
            dgvInvoice.Columns.Add(IncreaseingColumn);


            _dtInvoice.Columns.Add("ItemID", typeof(int));
            _dtInvoice.Columns.Add("ItemName", typeof(string));
            _dtInvoice.Columns.Add("Price", typeof(decimal));
            _dtInvoice.Columns.Add("Quantity", typeof(int));
            _dtInvoice.Columns.Add("Total", typeof(decimal));

            dgvInvoice.DataSource = _dtInvoice;
            dgvInvoice.Columns["ItemName"].Width = 200;
            dgvInvoice.Columns["Price"].Width = 70;
            dgvInvoice.Columns["Quantity"].Width = 50;
            dgvInvoice.Columns["ItemID"].Visible = false;

           








        }
        private void dgvInvoice_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
          
            if (e.RowIndex < 0)
                return;
            int qty = 0;


            if (dgvInvoice.Columns[e.ColumnIndex].Name == "Increase")
            {
                 qty = Convert.ToInt32(dgvInvoice.Rows[e.RowIndex].Cells["Quantity"].Value);
                decimal price = Convert.ToDecimal(dgvInvoice.Rows[e.RowIndex].Cells["Price"].Value);

                qty++;

                dgvInvoice.Rows[e.RowIndex].Cells["Quantity"].Value = qty;
                dgvInvoice.Rows[e.RowIndex].Cells["Total"].Value = qty * price;
                CalculateTotal();
                return;
            }
            if (dgvInvoice.Columns[e.ColumnIndex].Name == "Decrease" )
            {
                 qty = Convert.ToInt32(dgvInvoice.Rows[e.RowIndex].Cells["Quantity"].Value);
                decimal price = Convert.ToDecimal(dgvInvoice.Rows[e.RowIndex].Cells["Price"].Value);

                if (qty > 1 ) 
                {
                    qty--;
                    dgvInvoice.Rows[e.RowIndex].Cells["Quantity"].Value = qty;
                    dgvInvoice.Rows[e.RowIndex].Cells["Total"].Value = qty * price;
                    CalculateTotal();
                    return;
                }
               

                
                
                
            }
             
            if(qty==1 || dgvInvoice.Columns[e.ColumnIndex].Name == "Delete")
            { 

                dgvInvoice.Rows.RemoveAt(e.RowIndex);
                CalculateTotal();
            }
               

            
        }

        private void frmMainCashScreen_Load(object sender, EventArgs e)
        {
            InitializeInvoiceTable();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            
            if (dgvInvoice.RowCount < 1)
            {
                MessageBox.Show("There is no items in the cart");
                return;
            }
            clsSales Sales = new clsSales();
            DataTable dtCpoy = new DataTable();
            dtCpoy = (DataTable)dgvInvoice.DataSource;
            Sales.dtSales = dtCpoy.Copy();
            Sales.dtSales.Columns.Remove("Price");
            Sales.dtSales.Columns.Remove("ItemName");
            Sales.Save();
           
            
            lbTotal.Text ="0.00 JD";
            _dtInvoice.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dgvInvoice.RowCount >0)
            {
                if(MessageBox.Show("There is an items in the Schedule Are you sure you want to Exit the Form" , "Check the order",MessageBoxButtons.YesNo,MessageBoxIcon.Warning)==DialogResult.Yes)
                {
                    this.Close();
                }
                
                
            }
            
        }

        private void manageOrdersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            frmOrders orders = new frmOrders();
            orders.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            orders.ShowDialog(); 
            
        }
    }
}
