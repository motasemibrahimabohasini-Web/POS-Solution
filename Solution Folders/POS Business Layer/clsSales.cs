using CS_Data_Access_Layer;
using DVLD.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_BusinessLayer
{


    public class clsSales
    {
        int _SaleID { get; set; }
        public int _ItemID { get; set; }
        public int _OrderID { get; set; }
        public string _ItemName { get; set; }
        public int _Quantity { get; set; }
        public short _Total { get; set; }
        clsItemData _ItemData { get; set; }
         public DataTable dtSales { get; set; }
        


        public clsSales(int SaleID, int ItemID, int OrderID, int Quantity, short Total)
        {
            _SaleID = SaleID;
            _ItemID = ItemID;
            _OrderID = OrderID;
            _ItemName = clsItem.Find(_ItemID)._ItemName;
            _Quantity = Quantity;
            _Total = Total;
        }
        public clsSales()
        {
            _SaleID = -1;
            _ItemID = -1;
            _OrderID = -1;
            _ItemName = "";
            _Quantity = 0;
            _Total = 0;
            dtSales = new DataTable();
            
        }
           


        public static DataTable GetAllSales()
        {
            return clsSaleData.GetAllSales();
        }
        public static DataTable GetSalesByItemID(int ItemID)
        {
            return clsSaleData.GetSalesByItemID(ItemID);
        }
        public static DataTable GetSalesByOrderID(int OrderID)
        {
            return clsSaleData.GetSalesByOrderID(OrderID);
        }

        public int AddNewSales()
        {
            return clsSaleData.AddNewSales(dtSales,1025);
        }

        public bool Save()
        {
            _OrderID= AddNewSales() ;
            return _OrderID != -1;
        }



    }
}
