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
    public class clsOrders
    {

        DataTable _Sales = new DataTable();
        enMode Mode;
        int _OrderID { get; set; }
        int _ReleasedByUserID { get; set; }
      
        short _TotalAmount { get; set; }
        bool _IsActive { get; set; }
        DateTime _ReleaseDate { get; set; }
      

        public clsOrders()
        {
            _OrderID = 0;
            _ReleasedByUserID = 0;
        
            _TotalAmount = 0;
            
            Mode = enMode.AddNew;


        }

        private clsOrders(int OrderID, int ReleasedByUserID ,short TotalAmount,DateTime ReleaseDate )
        {
            _OrderID = OrderID;
            _ReleasedByUserID = ReleasedByUserID;
            _TotalAmount =TotalAmount ;
            _ReleaseDate = ReleaseDate;
            Mode = enMode.Update;
           


        }
        public clsOrders(int OrderID, int ReleasedByUserID, short TotalAmount, DateTime ReleaseDate ,DataTable Sales)
        {
            _OrderID = OrderID;
            _ReleasedByUserID = ReleasedByUserID;
            _TotalAmount = TotalAmount;
            _ReleaseDate = ReleaseDate;
            Mode = enMode.Update;
            _Sales = Sales;


        }
       
        private bool AddNewOrder()
        {
            if(clsSaleData.AddNewSale(_Sales))
            {
                _OrderID = clsOrderData.AddNewOrder(_TotalAmount, _ReleaseDate, _ReleasedByUserID);
                if (_OrderID != -1)
                {
                    return true;
                }
                
            }
            return false;
           
        }
        

        

      

        public static DataTable GetAllOrders()
        {
            return clsOrderData.GetAllOrders();
        }
        public bool save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                  return  AddNewOrder(); 
             
            }
            return false;




        }



    }
}
