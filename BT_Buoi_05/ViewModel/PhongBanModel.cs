using BT_Buoi_05.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
namespace BT_Buoi_05.ViewModel
{
    public class PhongBanModel
    {
        public PhongBan PhongBan { get; set; }
        public List<Employee> NhanVien { get; set; }
    }
}