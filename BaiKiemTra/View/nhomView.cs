using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BaiKiemTra.Model;

namespace BaiKiemTra.View
{
    public class nhomView
    {
        public int ID { get; set; }
        public string TenNhom { get; set; }

        public static void ThemNhom(Nhom nhom)
        {
            var db = new Model1();
            var rs = db.Nhoms.Add(nhom);
            db.SaveChanges();
        }

        public static List<nhomView> GetList()
        {
            var db = new Model1();
            var rs = db.Nhoms.Select(e => new nhomView
            {
                ID = e.ID,
                TenNhom = e.TenNhom,
            }).ToList();
            return rs;
        }

        public static void XoaNhom(int id)
        {
            var db = new Model1();
            var lienlac = db.Nhoms.Where(e => e.ID == id).FirstOrDefault();
            var rs = db.Nhoms.Remove(lienlac);
            db.SaveChanges();
        }
    }
}
