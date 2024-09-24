using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyTiemCaPhe.DTO
{
    public class BillInfo
    {
        public BillInfo(int id, int billID, int foodID, int count) 
        { 
            this.ID = id;
            this.IdBill = billID;
            this.IdFood = foodID;
            this.Count = count;
        }

        public BillInfo(DataRow row) 
        { 
            this.ID = (int)row["id"];
            this.IdBill = (int)row["idBill"];
            this.IdFood = (int)row["idFood"];
            this.Count = (int)row["count"];
        }

        private int idFood;
        private int idBill;
        private int iD;
        private int count;


        public int ID 
        {
            get { return iD;  }
            set {  iD = value; }
        }

        public int IdBill 
        {
            get { return idBill; }
            set { idBill = value; }
        }

        public int IdFood 
        {
            get { return idFood; }
            set { idFood = value; }
        }

        public int Count 
        {
            get {return count; }
            set { count = value; }
        }
    }
}
