using CS_Data_Access_Layer;
using System.Data;

namespace CS_BusinessLayer
{
    public class clsItem
    {
        enMode Mode;
        public int _ItemID {  get; set; }
        public int _UserID {  get; set; }
        public string _ItemName {  get; set; }
        public float _Price { get; set; }
        public bool _IsActive { get; set; }
        public string _ImagePath {  get; set; }
        public int _CategoryOfItemID { get; set; }

        public clsItem() 
        { 
            _ItemID = 0;
            _UserID = 0;
            _ItemName = string.Empty;
            _Price = 0;
            _IsActive = false;
            _ImagePath = string.Empty;
            Mode = enMode.AddNew;
        
        
        }

        private clsItem(int ItemsID , int UserID , string ItemName ,float Price , bool IsActive , string ImagePath ,int CategoryID)
        {
            _ItemID= ItemsID;
            _UserID = UserID;
            _ItemName = ItemName;
            _Price = Price;
            _IsActive=IsActive;
            _ImagePath = ImagePath;
            _CategoryOfItemID = CategoryID;
            Mode = enMode.Update;


        }

        public static clsItem Find(int ItemID)
        {
            int UserID = 0;
            string ItemsName = string.Empty;    
            float Price = 0;
            bool IsActive = false;
            string ImagePath = string.Empty;
            int CategoryID = 0;
            if(  clsItemData.GetItemInfoByID(ItemID,ref ItemsName,ref Price,ref IsActive,ref UserID,ref CategoryID))
            {
                return new clsItem(ItemID,UserID,ItemsName,Price,IsActive,ImagePath,CategoryID);
            }
          return null;


        }
        private bool AddNewItems()
        {
            _ItemID = clsItemData.AddNewItem(_ItemName, _Price,_ImagePath,_IsActive,_UserID,_CategoryOfItemID);
            if (_ItemID!=-1)
            {
                return true;
            }
            return false;
        }

        private bool UpdateItems()
        {
            return clsItemData.UpdateItem(_ItemID,_ItemName,_Price,_ImagePath,_IsActive,_UserID,_CategoryOfItemID);
        }

        public bool DesActivateItems()
        {
            return clsItemData.DesactivateItem(_ItemID);
        }

        public bool ActivateItems()
        {  return clsItemData.ActivateItem(_ItemID); }
        public static DataTable GetAllItemss()
        {
            return clsItemData.GetAllItems();
        }
        public static DataTable GetAllItemsByCategory(int CategoryID)
        {
            return clsItemData.GetAllItemsByCategory(CategoryID);
        }
        public static bool Delete(int ItemID)
        {
            return clsItemData.DeleteItem(ItemID);
        }
        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    return AddNewItems();
                case enMode.Update:
                    return UpdateItems();
            }
            return false;




        }



    }
}
