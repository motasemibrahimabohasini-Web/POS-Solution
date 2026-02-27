using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CS_Data_Access_Layer;

namespace CS_BusinessLayer
{
    public class clsOrder
    {

        DataTable _Sales = new DataTable();
        enMode Mode;
       public int _OrderID { get; set; }
       public int _ReleasedByUserID { get; set; }
       
       public decimal _TotalAmount { get; set; }
       public bool _IsActive { get; set; }
       public DateTime _ReleaseDate { get; set; }
      

        public clsOrder()
        {
            _OrderID = 0;
            _ReleasedByUserID = 0;
            _TotalAmount = 0;
            Mode = enMode.AddNew;


        }

        private clsOrder(int OrderID, int ReleasedByUserID, decimal TotalAmount,DateTime ReleaseDate )
        {
            _OrderID = OrderID;
            _ReleasedByUserID = ReleasedByUserID;
            _TotalAmount =TotalAmount ;
            _ReleaseDate = ReleaseDate;
            Mode = enMode.Update;
           


        }
    

        //private bool AddNewOrder()
        //{
        //    if(clsSaleData.AddNewSale(_Sales))
        //    {
        //        _OrderID = clsOrderData.AddNewOrder(_TotalAmount, _ReleaseDate, _ReleasedByUserID);
        //        if (_OrderID != -1)
        //        {
        //            return true;
        //        }
                
        //    }
        //    return false;
           
        //}
        

        

      public static clsOrder Find(int OrderID)
        {
            clsOrderData.dtoOrderInfo Order =  clsOrderData.GetOrderInfo(OrderID);
            if (Order != null) {

                return new clsOrder(Order._OrderID, Order._ReleasedByUserID, Order._TotalAmount, Order._ReleaseDate);
            }
            return null;
        }

        public bool Refund()
        {
            return clsOrderData.RefundOrder(_OrderID);
        }
        public static DataTable GetAllOrders()
        {
            return clsOrderData.GetAllOrders();
        }
        //public bool save()
        //{
        //    switch (Mode)
        //    {
        //        case enMode.AddNew:
        //          return  AddNewOrder(); 
             
        //    }
        //    return false;




        //}



    }
}
