using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace LTweb05_bai3.Models
{
    public class KetNoiDuLieu
    {
        static string strconn = "Data Source=DESKTOP-8IKBH23; database=ql_dtdd; User ID=sa; Password=123; TrustServerCertificate=True";
        SqlConnection conn = new SqlConnection(strconn);
        public List<Loai> dsLoaiSP = new List<Loai>();
        public List<SanPham> dsSP = new List<SanPham>();
        //khoi tao
        public KetNoiDuLieu()
        {
            ThietLap_DSLoaiSP();
            ThietLap_DSSanPham();
        }

        public void ThietLap_DSLoaiSP()
        {
            SqlDataAdapter da = new SqlDataAdapter("select maloai, tenloai from loai", conn);
            
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                var cate = new Loai();
                cate.MaLoai = (int)dr["maloai"];
                cate.TenLoai = dr["tenloai"].ToString();

                dsLoaiSP.Add(cate);
            }
        }

        
        // hien thi toan bo san pham
        public void ThietLap_DSSanPham()
        {
            SqlDataAdapter da = new SqlDataAdapter("select masp, tensp, duongdan, gia, mota, maloai from sanpham", conn);

            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                var sp = new SanPham();
                sp.MaSP = (int)dr["masp"];
                sp.TenSP = dr["tensp"].ToString();
                sp.DuongDan = dr["duongdan"].ToString();
                sp.Gia = Convert.ToDouble(dr["gia"]);
                sp.MoTa = dr["mota"].ToString();
                sp.MaLoai = (int)dr["maloai"];

                dsSP.Add(sp);
            }
        }

        public Loai ChiTietLoai(int maloai)
        {
            Loai loai = new Loai();
            string query = String.Format("select * from loai where maloai = {0}", maloai);
            SqlDataAdapter da = new SqlDataAdapter(query, conn);

            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.Rows[0];
                loai = new Loai();
                loai.MaLoai = (int)dr["maloai"];
                loai.TenLoai = dr["tenloai"].ToString();
            }
            return loai;
        }

        // loc san pham theo loai
        public List<SanPham> LayDSSanPhamTheoLoai(int maloai)
        {
            List<SanPham> dsSP = new List<SanPham>();
            string query = String.Format("select * from sanpham where maloai = {0}", maloai);
            SqlDataAdapter da = new SqlDataAdapter(query, conn);

            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                var sp = new SanPham();
                sp.MaSP = (int)dr["masp"];
                sp.TenSP = dr["tensp"].ToString();
                sp.DuongDan = dr["duongdan"].ToString();
                sp.Gia = Convert.ToDouble(dr["gia"]);
                sp.MoTa = dr["mota"].ToString();
                sp.MaLoai = (int)dr["maloai"];

                dsSP.Add(sp);
            }
            return dsSP;
        }

        // tim kiem san pham theo ten gan dung
        public List<SanPham> TimKiemSanPham(string tensp)
        {
            List<SanPham> dsSP = new List<SanPham>();
            string query = "select masp, tensp, duongdan, gia, mota, maloai from sanpham where tensp like @tensp";
            SqlDataAdapter da = new SqlDataAdapter(query, conn);
            da.SelectCommand.Parameters.AddWithValue("@tensp", "%" + tensp + "%");

            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                var sp = new SanPham();
                sp.MaSP = (int)dr["masp"];
                sp.TenSP = dr["tensp"].ToString();
                sp.DuongDan = dr["duongdan"].ToString();
                sp.Gia = Convert.ToDouble(dr["gia"]);
                sp.MoTa = dr["mota"].ToString();
                sp.MaLoai = (int)dr["maloai"];

                dsSP.Add(sp);
            }
            return dsSP;
        }
    }
}