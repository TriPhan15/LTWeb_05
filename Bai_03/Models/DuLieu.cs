using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;
namespace Bai_03.Models
{
    public class DuLieu
    {
        static string strcon = "Data Source =DESKTOP-TQRHRTT\\SQLEXPRESS; database=QL_DTDD1;Trusted_Connection=True";
        SqlConnection con = new SqlConnection(strcon);
        public List<Loai> DSLoai = new List<Loai>();
        public List<SanPham> DSSanPham = new List<SanPham>();
        public DuLieu()
        {
            ThietLap_DSLoai();
            ThietLap_DSSanPham();
        }
        public void ThietLap_DSLoai()
        {
            SqlDataAdapter da = new SqlDataAdapter("select * from loai",con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach(DataRow dr in dt.Rows)
            {
                var en = new Loai();
                en.maloai = int.Parse(dr["MaLoai"].ToString());
                en.tenloai = dr["TenLoai"].ToString();
                DSLoai.Add(en);
            }
        }
        public void ThietLap_DSSanPham()
        {
            SqlDataAdapter da = new SqlDataAdapter("select * from sanpham", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach(DataRow dr in dt.Rows)
            {
                var m = new SanPham();
                m.masp = int.Parse(dr["MaSP"].ToString());
                m.tensp = dr["TenSP"].ToString();
                m.duongdan = dr["DuongDan"].ToString();
                m.gia = decimal.Parse(dr["Gia"].ToString());
                m.mota = dr["MoTa"].ToString();
                m.maloai = int.Parse(dr["MaLoai"].ToString());
                DSSanPham.Add(m);
            }
        }
        public List<Loai> DanhSachLoai(int ma)
        {
            List<Loai> em = new List<Loai>();
            string sqlscript = string.Format("select * from loai where MaLoai={0}", ma);
            SqlDataAdapter da = new SqlDataAdapter(sqlscript, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach(DataRow dr in dt.Rows)
            {
                var en = new Loai();
                en.maloai = int.Parse(dr["MaLoai"].ToString());
                en.tenloai = dr["TenLoai"].ToString();
                em.Add(en);
            }
            return em;
        }
        public List<SanPham> DanhSachSanPham(int ma)
        {
            List<SanPham> em = new List<SanPham>();
            string sqlscript = string.Format("select * from sanpham where MaLoai={0}", ma);
            SqlDataAdapter da = new SqlDataAdapter(sqlscript, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                var m = new SanPham();
                m.masp = int.Parse(dr["MaSP"].ToString());
                m.tensp = dr["TenSP"].ToString();
                m.duongdan = dr["DuongDan"].ToString();
                m.gia = decimal.Parse(dr["Gia"].ToString());
                m.mota = dr["MoTa"].ToString();
                m.maloai = int.Parse(dr["MaLoai"].ToString());
                em.Add(m);
            }
            return em;
        }
        public List<SanPham> TimKiemSanPham(string ten)
        {
            List<SanPham> em = new List<SanPham>();
            string sqlscript = "select * from sanpham where TenSP LIKE @ten";
            SqlCommand cmd= new SqlCommand(sqlscript, con);
            cmd.Parameters.AddWithValue("@ten","%" + ten +  "%");
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                var m = new SanPham();
                m.masp = int.Parse(dr["MaSP"].ToString());
                m.tensp = dr["TenSP"].ToString();
                m.duongdan = dr["DuongDan"].ToString();
                m.gia = decimal.Parse(dr["Gia"].ToString());
                m.mota = dr["MoTa"].ToString();
                m.maloai = int.Parse(dr["MaLoai"].ToString());
                em.Add(m);
            }
            return em;
        }
        public List<SanPham> TimKiemTheoLoai(int maloai)
        {
            List<SanPham> em = new List<SanPham>();
            string sqlscript = "select * from sanpham where MaLoai = @MaLoai";
            SqlCommand cmd = new SqlCommand(sqlscript, con);
            cmd.Parameters.AddWithValue("@MaLoai", maloai);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                var m = new SanPham();
                m.masp = int.Parse(dr["MaSP"].ToString());
                m.tensp = dr["TenSP"].ToString();
                m.duongdan = dr["DuongDan"].ToString();
                m.gia = decimal.Parse(dr["Gia"].ToString());
                m.mota = dr["MoTa"].ToString();
                m.maloai = int.Parse(dr["MaLoai"].ToString());
                em.Add(m);
            }
            return em;
        }
    }
}