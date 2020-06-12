using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PagedList;
using System.Web.Mvc;
using WebApplicationQL_TV.Models;
namespace WebApplicationQL_TV.Controllers
{
    public class DonHangController : Controller
    {
        // GET: DonHang
        public ActionResult ThongTinTatCaDonHang(int? page, string sortBy, string search)
        {
            Model1 db = new Model1();
            var query = "select HDM.maHoaDon ,HDM.maPhieuYeuCau,TrangThai,NgayMuon,TV.maThuVien," +
                "tenThuVien,TTV.maThe,maKH,tenKH,NV.maNV,NV.tenNV,S.maSach,tenSach,soLuong " +
                "from HoaDonMuon HDM  inner join PhieuYeuCau PYC ON HDM.maPhieuYeuCau = PYC.maPhieuYeuCau " +
                "inner join ThuVien TV ON PYC.maThuVien = TV.maThuVien " +
                "inner join YeuCauMuon YCM ON YCM.maPhieuYeuCau = PYC.maPhieuYeuCau " +
                "inner join Sach S ON S.maSach = YCM.maSach " +
                "inner join TheThuVien TTV ON TTV.maThe = PYC.maThe " +
                "inner join KhachHang KH ON KH.maThe = TTV.maThe " +
                "inner join NhanVien NV ON NV.maNV = PYC.maNV ";
            var list = db.BangThongTinTatCaHoaDons.SqlQuery(query).ToList();
            if (search != null)
            {
                ViewBag.Current_search = search;
                query = query + " and maHoaDon like N'%" + search + "%'";
                list = db.BangThongTinTatCaHoaDons.SqlQuery(query).ToList();
            }
            if (sortBy == "maHoaDon")
            {
                ViewBag.Current_sortBy = sortBy;
                list = db.BangThongTinTatCaHoaDons.SqlQuery(query + " order by maHoaDon").ToList();
            }
            if (sortBy == "NgayMuon")
            {
                ViewBag.Current_sortBy = "NgayMuon";
                list = db.BangThongTinTatCaHoaDons.SqlQuery(query + " order by NgayMuon ").ToList();
            }
            return View(list.ToPagedList(page ?? 1, 5));
        }
        public ActionResult ThongTinDonHangChuaTra(int? page, string sortBy, string search)
        {
            Model1 db = new Model1();
            var query = "select HDM.maHoaDon ,HDM.maPhieuYeuCau,TrangThai,NgayMuon,TV.maThuVien," +
                "tenThuVien,TTV.maThe,maKH,tenKH,NV.maNV,NV.tenNV,S.maSach,tenSach,soLuong " +
                "from HoaDonMuon HDM  inner join PhieuYeuCau PYC ON HDM.maPhieuYeuCau = PYC.maPhieuYeuCau " +
                "inner join ThuVien TV ON PYC.maThuVien = TV.maThuVien " +
                "inner join YeuCauMuon YCM ON YCM.maPhieuYeuCau = PYC.maPhieuYeuCau " +
                "inner join Sach S ON S.maSach = YCM.maSach " +
                "inner join TheThuVien TTV ON TTV.maThe = PYC.maThe " +
                "inner join KhachHang KH ON KH.maThe = TTV.maThe " +
                "inner join NhanVien NV ON NV.maNV = PYC.maNV where TrangThai = 0";
            List<BangThongTinTatCaHoaDon> list = db.BangThongTinTatCaHoaDons.SqlQuery(query).ToList();
            if (search != null)
            {
                ViewBag.Current_search = search;
                query = query + " and maHoaDon like N'%"+search+"%'"; 
                list = db.BangThongTinTatCaHoaDons.SqlQuery(query).ToList();
            }
            if (sortBy == "maHoaDon")
            {
                ViewBag.Current_sortBy = sortBy;
                list = db.BangThongTinTatCaHoaDons.SqlQuery(query + " order by maHoaDon").ToList();
            }
            if (sortBy == "NgayMuon")
            {
                ViewBag.Current_sortBy = "NgayMuon";
                list = db.BangThongTinTatCaHoaDons.SqlQuery(query + " order by NgayMuon ").ToList();
            }
            return View(list.ToPagedList(page ?? 1, 5));
        }
        public ActionResult Create(string id)
        {
            return View();
        }
        [HttpPost ,ActionName("Create")]
        public ActionResult CreateConfirm(BangThongTinTatCaHoaDon thongTinHoaDon)
        {
            Model1 db = new Model1();
            
            var obj_Found = db.PhieuYeuCaus.Find(thongTinHoaDon.maPhieuYeuCau);
            if (obj_Found != null) return Redirect("Create");
            var obj_Found_1 = db.Saches.Find(thongTinHoaDon.maSach);
            if (obj_Found_1 == null) return Redirect("Create");
            var obj_Found_2 = db.TheThuViens.Find(thongTinHoaDon.maThe);
            if (obj_Found_2 == null) return Redirect("Create");
            var obj_Found_3 = db.NhanViens.Find(thongTinHoaDon.maNV);
            if (obj_Found_3 == null) return Redirect("Create");
            var obj_Found_4 = db.HoaDonMuons.Find(thongTinHoaDon.maHoaDon);
            if (obj_Found_4 != null) return Redirect("Create");
            var obj_Found_5 = db.TheThuViens.Find(thongTinHoaDon.maThuVien);
            if (obj_Found_5 != null) return Redirect("Create");

            db.Database.ExecuteSqlCommand("insert into PhieuYeuCau(maPhieuYeuCau,maThe,maNV,maThuVien) " +
                "values ( '" + thongTinHoaDon.maPhieuYeuCau + "' ,'" + thongTinHoaDon.maThe + "','"
                + thongTinHoaDon.maNV + "','" + thongTinHoaDon.maThuVien + "')");
            db.Database.ExecuteSqlCommand("insert into YeuCauMuon(maSach, maPhieuYeuCau ,soLuong) " +
                "values ('"+ thongTinHoaDon.maSach+"' ,'"+ thongTinHoaDon.maPhieuYeuCau +"' " +
                ", '" + thongTinHoaDon.soLuong +"')");
            var TrangThai1 = 0;

            if (thongTinHoaDon.TrangThai == true)  TrangThai1 = 1;
            else TrangThai1 = 0;

            db.Database.ExecuteSqlCommand("insert into HoaDonMuon(maPhieuYeuCau,maHoaDon,TrangThai,ngayMuon) " +
                "values ('"+ thongTinHoaDon.maPhieuYeuCau + "','"+ thongTinHoaDon.maHoaDon + "','"+TrangThai1+"','"+ thongTinHoaDon.NgayMuon + "')");
            db.SaveChanges();
            return RedirectToAction("ThongTinTatCaDonHang");
        }
        public ActionResult Delete(string id)
        {
            Model1 db = new Model1();
            var query = "select HDM.maHoaDon ,HDM.maPhieuYeuCau,TrangThai,NgayMuon,TV.maThuVien," +
                "tenThuVien,TTV.maThe,maKH,tenKH,NV.maNV,NV.tenNV,S.maSach,tenSach,soLuong " +
                "from HoaDonMuon HDM  inner join PhieuYeuCau PYC ON HDM.maPhieuYeuCau = PYC.maPhieuYeuCau " +
                "inner join ThuVien TV ON PYC.maThuVien = TV.maThuVien " +
                "inner join YeuCauMuon YCM ON YCM.maPhieuYeuCau = PYC.maPhieuYeuCau " +
                "inner join Sach S ON S.maSach = YCM.maSach " +
                "inner join TheThuVien TTV ON TTV.maThe = PYC.maThe " +
                "inner join KhachHang KH ON KH.maThe = TTV.maThe " +
                "inner join NhanVien NV ON NV.maNV = PYC.maNV where maHoaDon = '"+ id +"'" ;
            var DonHang_Found = db.BangThongTinTatCaHoaDons.SqlQuery(query).SingleOrDefault();
            return View(DonHang_Found);
        }
        [HttpPost,ActionName("Delete")]
        public ActionResult DeleteConfirm(string id)
        {
            Model1 db = new Model1();
            var DonHang_Found = db.HoaDonMuons
                .SqlQuery("select * from HoaDonMuon where TrangThai = 1 " +
                " and maHoaDon = '" + id + "'").SingleOrDefault();
            if (DonHang_Found == null) return RedirectToAction("Delete");
            else
            {
                db.Database.ExecuteSqlCommand("delete from YeuCauMuon where " +
                    " maPhieuYeuCau in (select maPhieuYeuCau from PhieuYeuCau where " +
                    "maPhieuYeuCau in ( select maPhieuYeuCau from HoaDonMuon where maHoaDon = " +
                    "'"+id+"'))");
                db.Database.ExecuteSqlCommand("delete from HoaDonMuon where maHoaDon = '" + id + "'");
                db.Database.ExecuteSqlCommand("delete from PhieuYeuCau where " +
                    "maPhieuYeuCau in ( select maPhieuYeuCau from HoaDonMuon where maHoaDon = " +
                    "'" + id + "')");
                db.SaveChanges();
            }
            return RedirectToAction("ThongTinTatCaDonHang");
        }
        public ActionResult Details (string id)
        {
            Model1 db = new Model1();
            var query = "select HDM.maHoaDon ,HDM.maPhieuYeuCau,TrangThai,NgayMuon,TV.maThuVien," +
                "tenThuVien,TTV.maThe,maKH,tenKH,NV.maNV,NV.tenNV,S.maSach,tenSach,soLuong " +
                "from HoaDonMuon HDM  inner join PhieuYeuCau PYC ON HDM.maPhieuYeuCau = PYC.maPhieuYeuCau " +
                "inner join ThuVien TV ON PYC.maThuVien = TV.maThuVien " +
                "inner join YeuCauMuon YCM ON YCM.maPhieuYeuCau = PYC.maPhieuYeuCau " +
                "inner join Sach S ON S.maSach = YCM.maSach " +
                "inner join TheThuVien TTV ON TTV.maThe = PYC.maThe " +
                "inner join KhachHang KH ON KH.maThe = TTV.maThe " +
                "inner join NhanVien NV ON NV.maNV = PYC.maNV where maHoaDon = '"+ id + "'";
            var find = db.BangThongTinTatCaHoaDons.SqlQuery(query).SingleOrDefault();
            return View(find);
        }
        public ActionResult Edit (string id)
        {
            Model1 db = new Model1();
            var query = "select HDM.maHoaDon ,HDM.maPhieuYeuCau,TrangThai,NgayMuon,TV.maThuVien," +
                "tenThuVien,TTV.maThe,maKH,tenKH,NV.maNV,NV.tenNV,S.maSach,tenSach,soLuong " +
                "from HoaDonMuon HDM  inner join PhieuYeuCau PYC ON HDM.maPhieuYeuCau = PYC.maPhieuYeuCau " +
                "inner join ThuVien TV ON PYC.maThuVien = TV.maThuVien " +
                "inner join YeuCauMuon YCM ON YCM.maPhieuYeuCau = PYC.maPhieuYeuCau " +
                "inner join Sach S ON S.maSach = YCM.maSach " +
                "inner join TheThuVien TTV ON TTV.maThe = PYC.maThe " +
                "inner join KhachHang KH ON KH.maThe = TTV.maThe " +
                "inner join NhanVien NV ON NV.maNV = PYC.maNV where maHoaDon = '" + id + "'";
            var find = db.BangThongTinTatCaHoaDons.SqlQuery(query).SingleOrDefault();
            return View(find);
        }
        [HttpPost ,ActionName("Edit")]
        public ActionResult EditConfirm (BangThongTinTatCaHoaDon obj)
        {
            Model1 db = new Model1();
            var obj_effected = db.BangThongTinTatCaHoaDons.Find(obj.maHoaDon);
            obj_effected.TrangThai = obj.TrangThai;
            var trangThai = 0;
            if (obj_effected.TrangThai == true) trangThai = 1;
            db.Database.ExecuteSqlCommand("update HoaDonMuon set TrangThai =" +
                " {0} where maHoaDon = '{1}' ",trangThai,obj_effected.maHoaDon);
            return RedirectToAction("BangThongTinTatCaHoaDon");
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