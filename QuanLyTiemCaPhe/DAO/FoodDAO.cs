using QuanLyTiemCaPhe.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyTiemCaPhe.DAO
{
    public class FoodDAO
    {
        private static FoodDAO instance;

        public static FoodDAO Instance 
        {
            get { if (instance == null) instance = new FoodDAO(); return FoodDAO.instance; }
            private set { FoodDAO.instance = value; }
        }
        public FoodDAO() { }

        public List<Food> GetFoodByCategoryID(int id) 
        { 

            List<Food> List = new List<Food>();
            string query = "select * from Food where idCategory = " + id;

            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                Food food = new Food(item);
                List.Add(food);

            }

            return List;
        }
        public List<Food> GetListFood()
        {
            List<Food> List = new List<Food>();
            string query = "select * from Food ";

            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                Food food = new Food(item);
                List.Add(food);

            }

            return List;
        }
        public bool InsertFood(string name , int id , float price)
        {
            string query = "INSERT INTO dbo.Food( name, idCategory, price ) VALUES ( @name , @idCategory , @price );";
            object[] para = { name, id, price };
            int result = DataProvider.Instance.ExecuteNonQuery(query, para);
            return result > 0;
        }
        public bool UpdateFood(int idFood,string name, int id, float price)
        {
            string query = "update dbo.Food set name = @name , idCategory = @idcategory , price = @prie where id = @id ";
            object[] para = { name, id , price , idFood };
            int result = DataProvider.Instance.ExecuteNonQuery(query, para);
            return result > 0;
        }
        public bool DeleteFood(int idFood, string name, int id, float price)
        {
            string query = "delete dbo.Food where dbo.Food.id = @id";
            object[] para = {idFood};
            int result = DataProvider.Instance.ExecuteNonQuery(query, para);
            return result > 0;
        }
        public bool CheckName (string name)
        {
            string query = "select name from dbo.Food where name = N'" + name + "'";
            return DataProvider.Instance.ExecuteQuery(query).Rows.Count > 0;
        }
    }
}
