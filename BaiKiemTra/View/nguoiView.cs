using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BaiKiemTra.Model;

namespace BaiKiemTra.View
{

    public class nguoiView
    {
        public int ID { get; set; }

        public string TenGoi { get; set; }

        public string Email { get; set; }

        public string DiaChi { get; set; }

        public string SDT { get; set; }

        public int? IDNhom { get; set; }

        public static List<nguoiView> GetListByID(int ID)
        {

            var db = new Model1();
            var rs = db.Nguois.Where(e => e.IDNhom == ID).Select(e => new nguoiView
            {
                ID = e.ID,
                TenGoi = e.TenGoi,
                Email = e.Email,
                SDT = e.SDT,
                DiaChi = e.DiaChi,
                IDNhom = e.IDNhom,
            }).ToList();
            return rs;
        }
        public static List<nguoiView> GetListAll()
        {

            var db = new Model1();
            var rs = db.Nguois.Select(e => new nguoiView
            {
                ID = e.ID,
                TenGoi = e.TenGoi,
                Email = e.Email,
                SDT = e.SDT,
                DiaChi = e.DiaChi,
                IDNhom = e.IDNhom,
            }).ToList();
            return rs;
        }

        public static void ThemNguoi(Nguoi nguoi)
        {
            var db = new Model1();
            var rs = db.Nguois.Add(nguoi);
            db.SaveChanges();
        }

        public static void XoaNguoi(int id)
        {
            var db = new Model1();
            var nguoi = db.Nguois.Where(e => e.ID == id).FirstOrDefault();
            var rs = db.Nguois.Remove(nguoi);
            db.SaveChanges();
        }
    }
}
