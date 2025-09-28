using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bai_03.Models
{
    public class SanPham
    {
        public int masp { get; set; }
        public string tensp {  get; set; }
        public string duongdan { get; set; }
        public decimal gia { get; set; }
        public string mota { get; set; }
        public int maloai { get; set; }
    }
}