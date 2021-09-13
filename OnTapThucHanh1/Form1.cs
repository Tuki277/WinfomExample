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

namespace OnTapThucHanh1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // connect database
        SqlConnection conn;

        private void Form1_Load(object sender, EventArgs e)
        {
            // create connection
            string connString = @"Data Source=ALIENWARE17R5\SQLEXPRESS;Initial Catalog=QuanLyThuVien;Integrated Security=True";

            conn = new SqlConnection(connString);
            HienThiDuLieu();
        }

        private void HienThiDuLieu()
        {
            conn.Open();

            // create cmd to get data from database

            string sqlSelect = "Select * From tblTaiLieu";
            SqlCommand cmd = new SqlCommand(sqlSelect, conn);

            // run command to filter data in database
            SqlDataReader dr = cmd.ExecuteReader();

            // create table chua du lieu doc dc
            DataTable dt = new DataTable();

            // doc du lieu
            dt.Load(dr);

            //Hien thi
            GridDanhSach.DataSource = dt;
            conn.Close();
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            conn.Open();

            // create cmd to get data from database

            string sqlInsert = "Insert into tblTaiLieu values (@ma, @ten, @tacgia, @dongia, @matheloai)";
            SqlCommand cmd = new SqlCommand(sqlInsert, conn);

            //sau khi tao cmd de doc du lieu trong bang
            cmd.Parameters.AddWithValue("ma", txtMa.Text);
            cmd.Parameters.AddWithValue("ten", txtTen.Text);
            cmd.Parameters.AddWithValue("tacgia", txtTacGia.Text);
            cmd.Parameters.AddWithValue("dongia", txtDonGia.Text);
            cmd.Parameters.AddWithValue("matheloai", txtMaTheLoai.Text);

            // insert to database
            cmd.ExecuteNonQuery();

            conn.Close();

            // hien thi du lieu bao gio cung phai sau close
            HienThiDuLieu();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            conn.Open();

            // create cmd to get data from database

            string sqlSelect = "Select * From tblTaiLieu Where MaTaiLieu=@ma";
            SqlCommand cmd = new SqlCommand(sqlSelect, conn);

            //sau khi tao cmd de doc du lieu trong bang
            cmd.Parameters.AddWithValue("ma", txtTim.Text);

            // run command to filter data in database
            SqlDataReader dr = cmd.ExecuteReader();

            // create table chua du lieu doc dc
            DataTable dt = new DataTable();

            // doc du lieu
            dt.Load(dr);

            //Hien thi
            GridDanhSach.DataSource = dt;
            conn.Close();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            conn.Open();

            // create cmd to get data from database

            string sqlUpdate = "Update tblTaiLieu Set TenTaiLieu = @ten, TacGia = @tacgia, DonGia = @dongia, " +
                "MaTheLoai = @matheloai Where MaTaiLieu = @ma and MaTheLoai = @matheloai";
            SqlCommand cmd = new SqlCommand(sqlUpdate, conn);

            //sau khi tao cmd de doc du lieu trong bang
            cmd.Parameters.AddWithValue("ma", txtMa.Text);
            cmd.Parameters.AddWithValue("ten", txtTen.Text);
            cmd.Parameters.AddWithValue("tacgia", txtTacGia.Text);
            cmd.Parameters.AddWithValue("dongia", txtDonGia.Text);
            cmd.Parameters.AddWithValue("matheloai", txtMaTheLoai.Text);

            // insert to database
            cmd.ExecuteNonQuery();

            conn.Close();

            // hien thi du lieu bao gio cung phai sau close
            HienThiDuLieu();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (txtMa.Text == "")
            {
                MessageBox.Show("Ban chua nhap ma", "Hay nhap ma", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            } else
            {
                conn.Open();

                // create cmd to get data from database

                string sqlDelete = "Delete from tblTaiLieu Where MaTaiLieu = @ma";
                SqlCommand cmd = new SqlCommand(sqlDelete, conn);

                //sau khi tao cmd de doc du lieu trong bang
                cmd.Parameters.AddWithValue("ma", txtMa.Text);

                // insert to database
                cmd.ExecuteNonQuery();

                conn.Close();

                // hien thi du lieu bao gio cung phai sau close
                HienThiDuLieu();
            }
        }
    }
}
