using CS_Data_Access_Layer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_BusinessLayer
{
    public class clsItemOptions
    {
        enMode Mode;
        public int OptionID { get; set; }
        public int ItemID { get; set; }
        public string OptionName { get; set; }
        public decimal Price { get; set; }

        public DataTable ItemOptions { get; set; } = new DataTable();

        public clsItemOptions()
            {
            OptionID = 0;
            ItemID = 0;
            OptionName = string.Empty;
            Price = 0;
            Mode = enMode.AddNew;
        }

        public clsItemOptions(int optionID, int itemID, string optionName, decimal price)
        {
            OptionID = optionID;
            ItemID = itemID;
            OptionName = optionName;
            Price = price;
            Mode = enMode.Update;
        }

        public static bool DeleteOptionItem(int optionID)
        {
            return clsOptionItemData.DeleteOptionItem(optionID);
        }
        private bool MergeOptionsItem()
        {
            return clsOptionItemData.MergeOptionItems(ItemOptions , ItemID);
        }
        public static DataTable GetOptionsItemByItemID(int itemID)
        {
            return clsOptionItemData.GetOptionsItemByItemID(itemID);
        }
        public bool Save()
        {
            return MergeOptionsItem();
        }



    }
}
