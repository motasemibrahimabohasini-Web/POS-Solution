using CS_Data_Access_Layer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace CS_BusinessLayer
{
    public class clsCategoryOfItem
    {
        enMode Mode;
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
       

        public clsCategoryOfItem()
        {
            CategoryID = 0;
            CategoryName = string.Empty;
          
            Mode = enMode.AddNew;


        }

        private clsCategoryOfItem(int CategoryOfItemsID, string CategoryOfItemName)
        {
            CategoryID = CategoryOfItemsID;
            CategoryName = CategoryOfItemName;
          
            Mode = enMode.Update;


        }

        public static clsCategoryOfItem Find(int CategoryOfItemID)
        { 
            string CategoryOfItemsName = string.Empty;
        
            string ImagePath = string.Empty;
            if (clsCategoryOFItemData.GetCategoryOfItemInfoByID(CategoryOfItemID, ref CategoryOfItemsName))
            {
                return new clsCategoryOfItem(CategoryOfItemID, CategoryOfItemsName);
            }
            return null;


        }
        private bool AddNewCategoryOfItems()
        {
            CategoryID = clsCategoryOFItemData.AddNewCategoryOfItem(CategoryName);
            if (CategoryID != -1)
            {
                return true;
            }
            return false;
        }

        private bool UpdateCategoryOfItems()
        {
            return clsCategoryOFItemData.UpdateCategoryOfItem(CategoryID, CategoryName);
        }

  
        
        public static DataTable GetAllCategoryOfItems()
        {
            return clsCategoryOFItemData.GetAllCategoryOfItems();
        }
        public static bool Delete(int CategoryOfItemID)
        {
            return clsCategoryOFItemData.DeleteCategoryOfItem(CategoryOfItemID);
        }
        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    return AddNewCategoryOfItems();
                case enMode.Update:
                    return UpdateCategoryOfItems();
            }
            return false;




        }


    }
}
