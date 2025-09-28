using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Bai_03.Models;
namespace Bai_03.ViewModel
{
    public class SanPham_Loai_Model
    {
        public List<Loai> loai { get; set; }
        public List<SanPham> sanPham { get; set; }
        public int SelectedMaLoai { get; set; } // Thêm thuộc tính để lưu loại đang chọn
    }
}