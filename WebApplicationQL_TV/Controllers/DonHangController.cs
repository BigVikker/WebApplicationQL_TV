using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplicationQL_TV.Models;
using PagedList.Mvc;
using PagedList;
namespace WebApplicationQL_TV.Controllers
{
    public class DonHangController : Controller
    {
        // GET: DonHang
        public ActionResult ThongTinTatCaDonHang(int? page, string sortBy, string search)
        {
            Model1 db = new Model1();
            var query = "select HDM.maHoaDon ,HDM.maPhieuYeuCau,TrangThai,NgayMuon," +
                "tenThuVien,TTV.maThe,maKH,tenKH,NV.maNV,NV.tenNV,S.maSach,tenSach,soLuong " +
                "from HoaDonMuon HDM  inner join PhieuYeuCau PYC ON HDM.maPhieuYeuCau = PYC.maPhieuYeuCau " +
                "inner join ThuVien TV ON PYC.maThuVien = TV.maThuVien " +
                "inner join YeuCauMuon YCM ON YCM.maPhieuYeuCau = PYC.maPhieuYeuCau " +
                "inner join Sach S ON S.maSach = YCM.maSach " +
                "inner join TheThuVien TTV ON TTV.maThe = PYC.maThe " +
                "inner join KhachHang KH ON KH.maThe = TTV.maThe " +
                "inner join NhanVien NV ON NV.maNV = PYC.maNV ";
            var list = db.Database.SqlQuery<BangThongTinTatCaHoaDon>(query).ToList();
            if (search != null) {
                ViewBag.Current_search = search.ToString();
                list = list.Where(x => x.maHoaDon.StartsWith(ViewBag.Current_search)).ToList();
            }
            if (sortBy == "maHoaDon")
            {
                ViewBag.Current_sortBy = "maHoaDon";
                list = list.OrderBy(x => x.maHoaDon).ToList();
            }
            if (sortBy == "NgayMuon")
            {
                ViewBag.Current_sortBy = "NgayMuon";
                list = list.OrderBy(x => x.NgayMuon).ToList();
            }
            return View(list.ToPagedList(page ?? 1, 5));
        }
        public ActionResult ThongTinDonHangChuaTra(int? page, string sortBy, string search)
        {
            Model1 db = new Model1();
            var query = "select HDM.maHoaDon ,HDM.maPhieuYeuCau,TrangThai,NgayMuon," +
                "tenThuVien,TTV.maThe,maKH,tenKH,NV.maNV,NV.tenNV,S.maSach,tenSach,soLuong " +
                "from HoaDonMuon HDM  inner join PhieuYeuCau PYC ON HDM.maPhieuYeuCau = PYC.maPhieuYeuCau " +
                "inner join ThuVien TV ON PYC.maThuVien = TV.maThuVien " +
                "inner join YeuCauMuon YCM ON YCM.maPhieuYeuCau = PYC.maPhieuYeuCau " +
                "inner join Sach S ON S.maSach = YCM.maSach " +
                "inner join TheThuVien TTV ON TTV.maThe = PYC.maThe " +
                "inner join KhachHang KH ON KH.maThe = TTV.maThe " +
                "inner join NhanVien NV ON NV.maNV = PYC.maNV where TrangThai = 0";
            var list = db.BangThongTinTatCaHoaDons.SqlQuery(query).ToList();
            if (search != null)
            {
                ViewBag.Current_search = search.ToString();
                list = list.Where(x => x.maHoaDon.StartsWith(ViewBag.Current_search)).ToList();
            }
            if (sortBy == "maHoaDon")
            {
                ViewBag.Current_sortBy = sortBy;
                list = list.OrderBy(x => x.maHoaDon).ToList();
            }
            if (sortBy == "NgayMuon")
            {
                ViewBag.Current_sortBy = "NgayMuon";
                list = list.OrderBy(x => x.NgayMuon).ToList();
            }
            return View(list.ToPagedList(page ?? 1, 5));
        }
        public ActionResult Create(string id)
        {
            return View();
        }
        public ActionResult Delete(string id)
        {
            Model1 db = new Model1();
            var DonHang_Found = db.BangThongTinTatCaHoaDons.Find(id);
            return View(DonHang_Found);
        }
        [HttpPost,ActionName("Delete")]
        public ActionResult DeleteConfirm(string id)
        {
            Model1 db = new Model1();
            var DonHang_Found = db.HoaDonMuons
                .SqlQuery("select * from HoaDonMuon where TrangThai = 1 " +
                " and maHoaDon = '" + id + "'").SingleOrDefault();
            if (DonHang_Found == null) return RedirectToAction("ThongTinTatCaDonHang");
            else
            {
                db.Database.ExecuteSqlCommand("delete from YeuCauMuon where " +
                    " maPhieuYeuCau in (select maPhieuYeuCau from PhieuYeuCau where " +
                    "maPhieuYeuCau in ( select maPhieuYeu from HoaDonMuon where maHoaDon = " +
                    "'"+id+"'))");
                db.Database.ExecuteSqlCommand("delete from PhieuYeuCau where " +
                    "maPhieuYeuCau in ( select maPhieuYeu from HoaDonMuon where maHoaDon = " +
                    "'" + id + "')");
                db.Database.ExecuteSqlCommand("delete from HoaDonMuon where maHoaDon = '"+id+"'");
                db.SaveChanges();
            }
            return RedirectToAction("ThongTinTatCaDonHang");
        }
        public ActionResult Details (string id)
        {
            Model1 db = new Model1();
            var find = db.BangThongTinTatCaHoaDons.Find(id);
            return View(find);
        }
        public ActionResult Edit (string id)
        {
            Model1 db = new Model1();
            var find = db.BangThongTinTatCaHoaDons.Find(id);
            return View(find);
        }
        [HttpPost ,ActionName("Edit")]
        public ActionResult Edit (BangThongTinTatCaHoaDon obj)
        {
            Model1 db = new Model1();
            var obj_effected = db.BangThongTinTatCaHoaDons.Find(obj.maHoaDon);
            obj_effected.TrangThai = obj.TrangThai;
            if (TryUpdateModel(obj))
            {
                try {
                    db.SaveChanges();
                    return RedirectToAction("BangThongTinTatCaHoaDon");
                }
                catch
                {
                    return RedirectToAction("BangThongTinTatCaHoaDon");
                }
            }
            return RedirectToAction("BangThongTinTatCaHoaDon");
        }
    }
}