using QuanLyTiemCaPhe.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace QuanLyTiemCaPhe
{
    public partial class fLogin : Form
    {
        public fLogin()
        {
            InitializeComponent();
        }

        private void fLogin_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Ban có muốn thoat", "Thông báo", MessageBoxButtons.OKCancel);
            if (result == DialogResult.OK)
            {
                Application.Exit();
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string userName = txbUserName.Text;
            string passWord = txbPassWord.Text;
            if (Login(userName,passWord))
            {
                fTableManager f = new fTableManager();
                this.Hide();
                f.ShowDialog();
                this.Show();
            }
            else
            {
                //if (userName == "")
                //{
                //    MessageBox.Show("Tên đăng nhập không được để trống");
                //    txbUserName.Focus();
                //}
                //else if (passWord == "")
                //{
                //    MessageBox.Show("Mật khẩu không được để trống");
                //    txbPassWord.Focus();
                //}
                //else
                //{
                //}
                    MessageBox.Show("Tên Đăng Nhập Hoặc Mật Khẩu Sai");
            }    

        }

        bool Login(string userName, string passWord)
        {

            return AccountDAO.Instance.Login(userName, passWord);
        }

        private void cbxHienAnMatKhau_CheckedChanged(object sender, EventArgs e)
        {
            bool btn = cbxHienAnMatKhau.Checked;
            if (btn)
            {
                txbPassWord.UseSystemPasswordChar = false;
                cbxHienAnMatKhau.Text = "Ẩn mật khẩu";
            }
            else
            {
                txbPassWord.UseSystemPasswordChar = true;
                cbxHienAnMatKhau.Text = "Hiện mật khẩu";
            }
        }

        private void txbPassWord_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
