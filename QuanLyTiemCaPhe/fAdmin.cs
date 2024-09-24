using QuanLyTiemCaPhe.DAO;
using QuanLyTiemCaPhe.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyTiemCaPhe
{
    public partial class fAdmin : Form
    {
        BindingSource foodlist = new BindingSource();
        public fAdmin()
        {
            InitializeComponent();
       
            LoadListFood();
            //LoadAccountList();
            //LoadFoodList();
            LoadCategoryIntoComboBox(cbFoodCatagory);
            AddFoodBinding();
        }

        private void fAdmin_Load(object sender, EventArgs e)
        {

        }
        void LoadListFood()
        {
            dtgvFood.DataSource = FoodDAO.Instance.GetListFood();
        }
        void AddFoodBinding()
        {
            txbSearchFoodName.DataBindings.Add(new Binding("Text", dtgvFood.DataSource, "Name"));
            txbFoodId.DataBindings.Add(new Binding ("Text", dtgvFood.DataSource, "ID"));
            nmFoodPrice.DataBindings.Add(new Binding ("Value", dtgvFood.DataSource, "price"));
        }
        void LoadCategoryIntoComboBox(ComboBox cb)
        {
           cb.DataSource = CategoryDAO.Instance.GetListCategory();
            cb.DisplayMember = "Name";

        }

        private void txbFoodId_TextChanged(object sender, EventArgs e)
        {
            if(dtgvFood.SelectedCells.Count > 0)
            {
                int id = (int)dtgvFood.SelectedCells[0].OwningRow.Cells["CategoryID"].Value;
                Category category = CategoryDAO.Instance.GetCategoryByID(id);
                cbFoodCatagory.SelectedItem = category;
                int index = -1;
                int i = 0;
                foreach(Category item in cbFoodCatagory.Items)
                {
                    if(item.ID == category.ID)
                    {
                        index = i;
                        break;
                    }
                    i++;
                }
                cbFoodCatagory.SelectedIndex = index;
            }
        }

        private void btnAddFood_Click(object sender, EventArgs e)
        {
            string name = txbSearchFoodName.Text;
            int categoryID = (cbFoodCatagory.SelectedItem as Category).ID;
            float price = (float)nmFoodPrice.Value;
            if(!FoodDAO.Instance.CheckName(name))
            {
               
                if (FoodDAO.Instance.InsertFood(name, categoryID, price))
                {
                    MessageBox.Show("Them mon thanh cong");LoadListFood();
                }
                else
                {
                    MessageBox.Show("Co loi");
                }
            }    
            else
            {
                MessageBox.Show("Ten da ton tai");
            }
        }

        private void btnEditeFood_Click(object sender, EventArgs e)
        {
            string name = txbSearchFoodName.Text;
            int categoryID = (cbFoodCatagory.SelectedItem as Category).ID;
            float price = (float)nmFoodPrice.Value;
            int id = Convert.ToInt32(txbFoodId.Text);
            
            if (FoodDAO.Instance.UpdateFood(id, name, categoryID, price))
            {
               
                MessageBox.Show("Sua mon thanh cong"); LoadListFood();
            }
            else
            {
                MessageBox.Show("Co loi");
            }
        }

        private void btnDeleteFood_Click(object sender, EventArgs e)
        {
            string name = txbSearchFoodName.Text;
            int categoryID = (cbFoodCatagory.SelectedItem as Category).ID;
            float price = (float)nmFoodPrice.Value;
            int id = Convert.ToInt32(txbFoodId.Text);
            if (FoodDAO.Instance.DeleteFood(id, name, categoryID, price))
            {
                MessageBox.Show("Xoa mon thanh cong"); LoadListFood();

            }
            else
            {
                MessageBox.Show("Co loi");
            }
        }

        private void btnShowFood_Click(object sender, EventArgs e)
        {
            AddFoodBinding();
        }

        private void dtgvFood_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

     

        //void LoadFoodList()
        //{
        //    string query = "SELECT * FROM Food";

        //    dtgvFood.DataSource = DataProvider.Instance.ExecuteQuery(query);
        //}

        //void LoadAccountList()
        //{
        //    string query = "EXEC dbo.USP_GetAccountByUserName @userName";

        //    dtgvAccount.DataSource = DataProvider.Instance.ExecuteQuery(query,new object[] {"Cam Tien"});
        //}
    }
}
