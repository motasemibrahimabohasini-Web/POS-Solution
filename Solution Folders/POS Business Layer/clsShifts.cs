using CS_Data_Access_Layer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_BusinessLayer
{
    public class clsShifts
    {
        enMode Mode;

        public int _ShiftID { get; set; }
        public int _EmpID { get; set; }
        public DateTime _ComingDate { get; set; }
        public DateTime _LeavingDAte { get; set; }
        public bool _IsInVAcation { get; set; }

        public clsShifts()
        {
            Mode = enMode.Update;
            _ShiftID = 0;
            _EmpID = 0;
            _ComingDate = DateTime.MinValue;
            _LeavingDAte = DateTime.MinValue;
            _IsInVAcation = false;
        }

        public clsShifts(int ShiftID, int EmpID, DateTime ComingDate, DateTime LeavingDAte, bool IsInVacation)
        {
            _ShiftID = ShiftID;
            _EmpID = EmpID;
            _ComingDate = ComingDate;
            _LeavingDAte = LeavingDAte;
            _IsInVAcation = IsInVacation;
            Mode = enMode.Update;

        }

        private bool AddNewShift()
        {
            _ShiftID = clsShiftData.AddNewShift(_EmpID, _ComingDate, _LeavingDAte, _IsInVAcation);
            if (_ShiftID != -1)
            {
                return true;
            }

            return false;

        }
        private bool updateshift()
        {

            return clsShiftData.UpdateShift(_ShiftID, _EmpID, _ComingDate, _LeavingDAte, _IsInVAcation);

        }

        public bool DeleteShift(int ShiftID)
        {
            return clsShiftData.DeleteShift(ShiftID);
        }
        public static clsShifts Find(int ShiftID)
        {
            int EmpID = -1;
            DateTime ComingDate = DateTime.MinValue;
            DateTime LeavingDAte = DateTime.MinValue;
            bool IsInVacation = false;
            if (clsShiftData.GetShiftInfoByID(ShiftID, ref EmpID, ref ComingDate, ref LeavingDAte, ref IsInVacation))
            {
                return new clsShifts(ShiftID, EmpID, ComingDate, LeavingDAte, IsInVacation);
            }
            return null;
        }

        public static DataTable GetAllShifts()
        {
            return clsShiftData.GetAllShifts();
        }

        public bool save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                   return AddNewShift(); 
                case enMode.Update:
                    return updateshift(); 
            }
            return false;




        }
    }
}
