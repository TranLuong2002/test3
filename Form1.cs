using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Microsoft.Win32.SafeHandles;
using System.Security.Cryptography;

namespace bai_kiem_tra_TH8
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        SqlConnection ketnoi = new SqlConnection("Data Source=DESKTOP-KMNS09Q\\SQLEXPRESS;Initial Catalog=QUAN_LY_THUOC;Integrated Security=True");

        private void hienthi()
        {
            SqlDataAdapter sda = new SqlDataAdapter("select * from THUOC", ketnoi);//tạo đối tg dataadapter để lấy dữ liệu từ bảng
            DataTable dt = new DataTable();//tạo bảng
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
        }
       
        private void button1_Click(object sender, EventArgs e)
        {
            // tạo chức năng thêm dữ liệu
            string sqlthem = "insert into THUOC values(@maThuoc,@tenThuoc,@NSX,@HSD,@gia)";
            SqlCommand sc = new SqlCommand(sqlthem, ketnoi);
            sc.Parameters.AddWithValue("maThuoc", textBox1.Text);
            sc.Parameters.AddWithValue("tenThuoc", textBox2.Text);
            sc.Parameters.AddWithValue("NSX", dateTimePicker1.Text);
            sc.Parameters.AddWithValue("HSD", dateTimePicker2.Text);
            sc.Parameters.AddWithValue("gia", textBox3.Text);
            sc.ExecuteNonQuery();
            hienthi();
            MessageBox.Show("thêm thành công");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ketnoi.Open();
            hienthi();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //chức năng sửa dữ liệu
            string sqlsua = "update THUOC set maThuoc = @maThuoc, tenThuoc = @tenThuoc, NSX = @NSX, HSD = @HSD, gia = @gia where maThuoc = @maThuoc";
            SqlCommand sc = new SqlCommand(sqlsua, ketnoi);
            sc.Parameters.AddWithValue("maThuoc", textBox1.Text);
            sc.Parameters.AddWithValue("tenThuoc", textBox2.Text);
            sc.Parameters.AddWithValue("NSX", dateTimePicker1.Text);
            sc.Parameters.AddWithValue("HSD", dateTimePicker2.Text);
            sc.Parameters.AddWithValue("gia", textBox3.Text);
            sc.ExecuteNonQuery();
            hienthi();
            MessageBox.Show("sửa thành công");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //button thoát chương trình
            DialogResult  hoi;
            hoi = MessageBox.Show("bạn có muốn thoát chương trình không?", "thông báo! ",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if(hoi == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //chức năng xóa
            string sqlxoa = "delete from THUOC where maThuoc = @maThuoc";
            SqlCommand sc = new SqlCommand(sqlxoa, ketnoi);
            sc.Parameters.AddWithValue("maThuoc", textBox1.Text);
            sc.Parameters.AddWithValue("tenThuoc", textBox2.Text);
            sc.Parameters.AddWithValue("NSX", dateTimePicker1.Text);
            sc.Parameters.AddWithValue("HSD", dateTimePicker2.Text);
            sc.Parameters.AddWithValue("gia", textBox3.Text);
            sc.ExecuteNonQuery();
            hienthi();
            MessageBox.Show("xóa thành công");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //chức năng tìm kiếm
            string sqltimkiem = "select * from THUOC where maThuoc = @maThuoc";
            SqlCommand sc = new SqlCommand(sqltimkiem, ketnoi);
            sc.Parameters.AddWithValue("maThuoc", textBox4.Text);
            sc.Parameters.AddWithValue("tenThuoc", textBox2.Text);
            sc.Parameters.AddWithValue("NSX", dateTimePicker1.Text);
            sc.Parameters.AddWithValue("HSD", dateTimePicker2.Text);
            sc.Parameters.AddWithValue("gia", textBox3.Text);
            sc.ExecuteNonQuery();
            SqlDataAdapter sda = new SqlDataAdapter(sc);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
        }
    }
}
