using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace BT_Buoi_05.Models
{
    public class DuLieu
    {
        static string strcon = "Data Source=DESKTOP-TQRHRTT\\SQLEXPRESS; database=QL_NhanSu;Trusted_Connection=True;";
        SqlConnection con = new SqlConnection(strcon);
        public List<Employee> dsNV = new List<Employee>();
        public List<PhongBan> DSPB = new List<PhongBan>();
        public DuLieu()
        {
            ThietLap_DSNV();
            ThietLap_DSPB();
        }
        public void ThietLap_DSNV()
        {
            SqlDataAdapter da = new SqlDataAdapter("select * from dbo.employee ", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                var en = new Employee();
                en.MaNv = int.Parse(dr["ID"].ToString());
                en.Ten = dr["Name"].ToString();
                en.GioiTinh = dr["Gender"].ToString();
                en.Tinh = dr["City"].ToString();
                en.MaPg = (int)dr["Deptid"];
                dsNV.Add(en);
            }
        }
        public void ThietLap_DSPB()
        {
            SqlDataAdapter da = new SqlDataAdapter("select * from dbo.department ", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                var en = new PhongBan();
                en.MaPhong = int.Parse(dr["Deptid"].ToString());
                en.TenPhong = dr["Name"].ToString();
                DSPB.Add(en);
            }
        }
        public PhongBan ChiTietPhongBan(int maphong)
        {
            PhongBan ds = new PhongBan();
            string sqlScript = string.Format("select * from dbo.department where deptid ={0}", maphong);
            SqlDataAdapter da = new SqlDataAdapter(sqlScript, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            ds.MaPhong = int.Parse(dt.Rows[0]["deptid"].ToString());
            ds.TenPhong = dt.Rows[0]["name"].ToString();
            return ds;
        }
        public List<Employee> DanhSachNhanVienTheoMaPhong(int maphong)
        {
            List<Employee> em = new List<Employee>();
            string sqlscript = string.Format("select * from dbo.employee where deptid={0}", maphong);
            SqlDataAdapter da = new SqlDataAdapter(sqlscript, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                var en = new Employee();
                en.MaNv = int.Parse(dr["ID"].ToString());
                en.Ten = dr["Name"].ToString();
                en.GioiTinh = dr["Gender"].ToString();
                en.Tinh = dr["City"].ToString();
                en.MaPg = (int)dr["Deptid"];
                em.Add(en);
            }
            return em;
        }
        public bool ThemPhongBan(PhongBan pb)
        {
            bool result = false;
            string sqlscript = "insert into dbo.department values (@mapb,@tenpb)";
            try
            {
                SqlCommand cmd = new SqlCommand(sqlscript, con);
                cmd.Parameters.AddWithValue("@mapb", pb.MaPhong);
                cmd.Parameters.AddWithValue("@tenpb", pb.TenPhong);
                try
                {
                    con.Open();
                    cmd.ExecuteNonQuery();
                    result = true;
                }
                catch (Exception ex)
                {

                }
                finally
                {
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return result;
        }
        public bool CapNhatPhongBan(PhongBan pb)
        {
            bool result = false;
            string sqlscript = "update dbo.department set name= @tenpb where deptid =@mapb";

            try
            {
                SqlCommand cmd = new SqlCommand(sqlscript, con);
                cmd.Parameters.AddWithValue("@mapb", pb.MaPhong);
                cmd.Parameters.AddWithValue("@tenpb", pb.TenPhong);
                try
                {
                    con.Open();
                    cmd.ExecuteNonQuery();
                    result = true;
                }
                catch (Exception ex)
                {

                }
                finally
                {
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return result;
        }
        public bool XoaPhongBan(int maphong)
        {
            bool result = false;
            string sqlscript = string.Format("delete from dbo.department where deptid ={0}", maphong);
            try
            {
                SqlCommand cmd = new SqlCommand(sqlscript, con);
                try
                {
                    con.Open();
                    cmd.ExecuteNonQuery();
                    result = true;
                }
                catch (Exception ex)
                {

                }
                finally
                {
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return result;
        }
    }
}