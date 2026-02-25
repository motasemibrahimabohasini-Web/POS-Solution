using CS_Data_Access_Layer;
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
        
        public clsSales(int SaleID , int ItemID , int OrderID  , int Quantity , short Total )
        {
            _SaleID = SaleID;
            _ItemID = ItemID;
            _OrderID = OrderID;
            _ItemName = clsItem.Find(_ItemID)._ItemName;
            _Quantity = Quantity;
            _Total = Total;
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

    }
        
    
  
}
