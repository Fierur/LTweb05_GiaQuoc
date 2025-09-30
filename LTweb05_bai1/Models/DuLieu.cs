using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using LTweb05_bai1.Models;

namespace LTweb05_Bai1.Models
{
    public class DuLieu
    {
        //thuộc tính                      //A110PC35\\CSSQL08
        static string strcon = "Data Source=DESKTOP-8IKBH23;database=ql_nhansu;User ID=sa;Password=123;TrustServerCertificate=True";
        SqlConnection con = new SqlConnection(strcon);
        public List<Bai1> dsNV = new List<Bai1>();
        public List<Department> dsPB = new List<Department>();

        //pt khởi tạo
        public DuLieu()
        {
            ThietLap_DSNV();
            ThietLap_PB();
        }
        public void ThietLap_DSNV()
        {
            //cau truy van select
            //tao du lieu cho danh sach nhan vien
            SqlDataAdapter da = new SqlDataAdapter("select * from employee", con);

            DataTable dt = new DataTable();
            da.Fill(dt);
            //ket qua thuc hien
            foreach (DataRow dr in dt.Rows)
            {
                var em = new Bai1();
                em.MaNV = int.Parse(dr["id"].ToString());
                em.Ten = dr["fname"].ToString();
                em.GioiTinh = dr["gender"].ToString();
                em.Tinh = dr["city"].ToString();
                em.MaPg = (int)dr["deptid"];

                dsNV.Add(em);
            }
        }

        public void ThietLap_PB()
        {
            //cau truy van select
            //tao du lieu cho danh sach nhan vien
            SqlDataAdapter da = new SqlDataAdapter("Select * from department", con);

            DataTable dt = new DataTable();
            da.Fill(dt);
            //ket qua thuc hien
            foreach (DataRow dr in dt.Rows)
            {
                var em = new Department();
                em.Id = int.Parse(dr["deptid"].ToString());
                em.Name = dr["dname"].ToString();

                dsPB.Add(em);
            }
        }
        public Department ChiTietPB(int maPhong)
        {
            Department department = new Department();
            string sqlScript = String.Format("select*from department where deptid = {0}", maPhong);
            SqlDataAdapter da = new SqlDataAdapter(sqlScript, con);

            DataTable dt = new DataTable();
            da.Fill (dt);

            //có 1 dòng không cần dùng foreach
            department.Id = int.Parse(dt.Rows[0]["deptid"].ToString());
            department.Name = dt.Rows[0]["dname"].ToString();

            return department;
        }
        public List<Bai1> DSNVTheoMaPhong(int maPhong)
        {
            List<Bai1> employee = new List<Bai1>();
            string sqlScript = String.Format("select*from employee where deptid = {0}", maPhong);
            SqlDataAdapter da = new SqlDataAdapter(sqlScript, con);
            
            DataTable dt = new DataTable();
            da.Fill (dt);

            foreach (DataRow dr in dt.Rows)
            {
                var em = new Bai1();
                em.MaNV = int.Parse(dr["id"].ToString());
                em.Ten = dr["fname"].ToString();
                em.GioiTinh = dr["gender"].ToString();
                em.Tinh = dr["city"].ToString();
                em.MaPg = (int)dr["deptid"];

                employee.Add (em);
            }
            return employee;
        }
    }
}