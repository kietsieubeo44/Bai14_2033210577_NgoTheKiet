using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Bai14_2033210577_NgoTheKiet
{
    public partial class Form3 : Form
    {
        private ListBox lstGiaoVien = new ListBox();

        private QLcsdlManager dataManager;

        public Form3()
        {
            InitializeComponent();
            InitCoSoComboBox();
        }

        private void InitCoSoComboBox()
        {
            // Lấy danh sách cơ sở từ cơ sở dữ liệu và gán vào ComboBox
            List<CoSoDaoTao> danhSachCoSo = GetDanhSachCoSo();

            if (danhSachCoSo != null)
            {
                cobxCoSO.DataSource = danhSachCoSo;
                cobxCoSO.DisplayMember = "TenCoSo";
                cobxCoSO.ValueMember = "MaCoSo";
            }
            else
            {
                // Xử lý khi không thể lấy danh sách cơ sở (ví dụ: thông báo lỗi)
                MessageBox.Show("Không thể lấy danh sách cơ sở từ cơ sở dữ liệu.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private List<CoSoDaoTao> GetDanhSachCoSo()
        {
            // Triển khai lấy danh sách cơ sở từ cơ sở dữ liệu
            // Ví dụ:
            // SELECT * FROM COSO
            // và chuyển dữ liệu thành List<CoSoDaoTao>
            return new List<CoSoDaoTao>
            {
                new CoSoDaoTao { MaCoSo = "CS001", TenCoSo = "Cơ sở 1" },
                new CoSoDaoTao { MaCoSo = "CS002", TenCoSo = "Cơ sở 2" },
                new CoSoDaoTao { MaCoSo = "CS003", TenCoSo = "Cơ sở 3" }
            };
        }

        private void cobxCoSO_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Lấy mã cơ sở từ ComboBox đã chọn
            string maCoSo = cobxCoSO.SelectedValue?.ToString();

            // Kiểm tra xem có cơ sở nào được chọn hay không
            if (!string.IsNullOrEmpty(maCoSo))
            {
                // Lấy thông tin đơn vị đào tạo thuộc cơ sở đã chọn
                // và hiển thị thông tin trong ComboBox cobxDonViDaoTao
                List<DonViDaoTao> danhSachDonVi = GetDanhSachDonViTheoCoSo(maCoSo);

                if (danhSachDonVi != null)
                {
                    cobxDonViDaoTao.DataSource = danhSachDonVi;
                    cobxDonViDaoTao.DisplayMember = "TenDonVi";
                    cobxDonViDaoTao.ValueMember = "MaDonVi";
                }
                else
                {
                    // Xử lý khi không thể lấy danh sách đơn vị (ví dụ: thông báo lỗi)
                    MessageBox.Show("Không thể lấy danh sách đơn vị từ cơ sở dữ liệu.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private List<DonViDaoTao> GetDanhSachDonViTheoCoSo(string maCoSo)
        {
            // Triển khai lấy danh sách đơn vị đào tạo thuộc một cơ sở từ cơ sở dữ liệu
            // Ví dụ:
            // SELECT * FROM DONVI WHERE MaCoSo = maCoSo ORDER BY TenDonVi
            // và chuyển dữ liệu thành List<DonViDaoTao>
            return new List<DonViDaoTao>
            {
                new DonViDaoTao { MaDonVi = "DV001", TenDonVi = "Đơn vị 1" },
                new DonViDaoTao { MaDonVi = "DV002", TenDonVi = "Đơn vị 2" },
                new DonViDaoTao { MaDonVi = "DV003", TenDonVi = "Đơn vị 3" }
            };
        }

        private void cobxDonViDaoTao_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Lấy mã đơn vị từ ComboBox cobxDonViDaoTao đã chọn
            string maDonVi = cobxDonViDaoTao.SelectedValue?.ToString();

            // Kiểm tra xem có đơn vị nào được chọn hay không
            if (!string.IsNullOrEmpty(maDonVi))
            {
                // Lấy thông tin giáo viên thuộc đơn vị đã chọn
                // và hiển thị thông tin trong ListBox lstGiaoVien
                List<GiaoVien> danhSachGiaoVien = GetDanhSachGiaoVienTheoDonVi(maDonVi);

                if (danhSachGiaoVien != null)
                {
                    lstGiaoVien.DataSource = danhSachGiaoVien;
                    lstGiaoVien.DisplayMember = "HoTen";
                    lstGiaoVien.ValueMember = "MaGiaoVien";
                }
                else
                {
                    // Xử lý khi không thể lấy danh sách giáo viên (ví dụ: thông báo lỗi)
                    MessageBox.Show("Không thể lấy danh sách giáo viên từ cơ sở dữ liệu.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private List<GiaoVien> GetDanhSachGiaoVienTheoDonVi(string maDonVi)
        {
            // Triển khai lấy danh sách giáo viên thuộc một đơn vị từ cơ sở dữ liệu
            // Ví dụ:
            // SELECT * FROM GV WHERE MaDonVi = maDonVi ORDER BY HoTen
            // và chuyển dữ liệu thành List<GiaoVien>
            return new List<GiaoVien>
            {
                new GiaoVien { MaGiaoVien = "GV001", HoTen = "Nguyễn Văn A" },
                new GiaoVien { MaGiaoVien = "GV002", HoTen = "Trần Thị B" },
                new GiaoVien { MaGiaoVien = "GV003", HoTen = "Lê Văn C" }
            };
        }

        private void gunaDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Kiểm tra xem người dùng đã nhấp vào ô có dữ liệu hay không
            if (e.RowIndex >= 0)
            {
                // Lấy giá trị của ô được chọn
                DataGridViewRow row = gunaDataGridView1.Rows[e.RowIndex];
                string maGiaoVien = row.Cells["magv"].Value.ToString();

                // Thực hiện các hành động tương ứng với ô được chọn, ví dụ: mở form chi tiết hoặc form chỉnh sửa
                // ...

                // Hiển thị thông tin chi tiết hoặc thực hiện các hành động khác
                MessageBox.Show($"Đã chọn dòng có mã giáo viên: {maGiaoVien}");
            }

        }

    }

    public class CoSoDaoTao
    {
        public string MaCoSo { get; set; }
        public string TenCoSo { get; set; }
    }

    public class DonViDaoTao
    {
        public string MaDonVi { get; set; }
        public string TenDonVi { get; set; }
    }

    public class GiaoVien
    {
        public string MaGiaoVien { get; set; }
        public string HoTen { get; set; }
    }
}
