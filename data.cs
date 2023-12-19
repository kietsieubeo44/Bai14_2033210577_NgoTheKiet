using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using static Bai14_2033210577_NgoTheKiet.Form3;

public class QLcsdlManager
{
    private readonly string connectionString;

    public QLcsdlManager(string connectionString)
    {
        this.connectionString = connectionString;
    }

    public bool ConnectDatabase()
    {
        try
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                return true;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Không thể kết nối đến cơ sở dữ liệu: {ex.Message}");
            return false;
        }
    }

    public bool CreateDatabase()
    {
        try
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("CREATE DATABASE QLcsdl;", connection))
                {
                    command.ExecuteNonQuery();
                }
            }

            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Lỗi khi tạo cơ sở dữ liệu: {ex.Message}");
            return false;
        }
    }

    // ... (other methods)

    public bool CheckLogin(string userName, string password)
    {
        try
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Kiểm tra thông tin đăng nhập từ bảng NGUOIDUNG
                using (SqlCommand command = new SqlCommand($"SELECT COUNT(*) FROM NGUOIDUNG WHERE tendangnhap = @userName AND matkhau = @password", connection))
                {

                    command.Parameters.AddWithValue("@userName", userName);
                    command.Parameters.AddWithValue("@password", password);

                    int count = (int)command.ExecuteScalar();
                    return count > 0;
                }
            }
        }
        
        catch (Exception ex)
        {
            Console.WriteLine($"Lỗi khi kiểm tra đăng nhập: {ex.Message}");
            return false;
        }
    }   


}
