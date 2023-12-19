using Guna.UI.WinForms;
using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Bai14_2033210577_NgoTheKiet
{
    public partial class Form1 : Form
    {


        private QLcsdlManager dataManager;

        public Form1()
        {
            InitializeComponent();

            // Khởi tạo đối tượng QLcsdlManager với chuỗi kết nối của bạn
            dataManager = new QLcsdlManager("Data Source=LAPTOP_KIET;Initial Catalog=QLcsdl;Integrated Security=True;");

        }
        // btn kết thúc 
        private void button2_Click(object sender, EventArgs e)
        {
            // Hiển thị hộp thoại hỏi người dùng
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn thoát chương trình không?", "Xác nhận thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            // Kiểm tra kết quả từ hộp thoại
            if (result == DialogResult.Yes)
            {
                // Nếu người dùng chọn Yes, thoát khỏi chương trình
                Application.Exit();
            }
            else
            {
                // Nếu người dùng chọn No, không làm gì cả
            }
        }
        private void txtTenMay_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtUser_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtTenCSDL_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPassWord_TextChanged(object sender, EventArgs e)
        {

        }


        private void btnKetNoi_Click(object sender, EventArgs e)
        {
            // Lấy thông tin từ các ô nhập liệu
            string tenMay = txtTenMay.Text;
            string userName = txtUser.Text;
            string tenCSDL = txtTenCSDL.Text;
            string passWord = txtPassWord.Text;

            // Kiểm tra xem có nhập đầy đủ thông tin không
            if (string.IsNullOrEmpty(tenMay) || string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(tenCSDL) || string.IsNullOrEmpty(passWord))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin kết nối.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Tạo chuỗi kết nối từ thông tin người dùng
            string connectionString = $"Data Source={tenMay};Initial Catalog={tenCSDL};User Id={userName};Password={passWord};";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Thử kết nối cơ sở dữ liệu
                if (dataManager.ConnectDatabase())
                {
                    // Kết nối thành công, kiểm tra thông tin đăng nhập
                    if (dataManager.CheckLogin(userName, passWord))
                    {
                        MessageBox.Show("Đăng nhập thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Mở Form 3 hoặc thực hiện các hành động cần thiết sau khi đăng nhập thành công
                        // Ví dụ:
                        Form3 form3 = new Form3();
                        form3.Show();
                        
                        
                    }
                    else
                    {
                        MessageBox.Show("Đăng nhập thất bại. Vui lòng kiểm tra lại thông tin đăng nhập.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Không thể kết nối đến cơ sở dữ liệu. Vui lòng kiểm tra lại thông tin kết nối.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }





    }
}
