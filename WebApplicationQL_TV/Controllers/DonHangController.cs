using PagedList;
using System.Linq;
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
            var query = "select HDM.maHoaDon ,HDM.maPhieuYeuCau,TrangThai,NgayMuon,TV.maThuVien," +
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
        [HttpPost ,ActionName("Create")]
        public ActionResult Create(BangThongTinTatCaHoaDon thongTinHoaDon)
        {
            Model1 db = new Model1();
            
            var obj_Found = db.PhieuYeuCaus.Find(thongTinHoaDon.maPhieuYeuCau);
            if (obj_Found != null) return View();
            var obj_Found_1 = db.Saches.Find(thongTinHoaDon.maSach);
            if (obj_Found_1 == null) return View();
            var obj_Found_2 = db.TheThuViens.Find(thongTinHoaDon.maThe);
            if (obj_Found_2 == null) return View();
            var obj_Found_3 = db.NhanViens.Find(thongTinHoaDon.maNV);
            if (obj_Found_3 == null) return View();
            var obj_Found_4 = db.HoaDonMuons.Find(thongTinHoaDon.maHoaDon);
            if (obj_Found_4 != null) return View();
            var obj_Found_5 = db.TheThuViens.Find(thongTinHoaDon.maThuVien);
            if (obj_Found_5 != null) return View();

            db.Database.ExecuteSqlCommand("insert into YeuCauMuon(maSach, maPhieuYeuCau ,soLuong) " +
                "values ("+ thongTinHoaDon.maSach+" ,"+ thongTinHoaDon.maPhieuYeuCau +" " +
                ", " + thongTinHoaDon.soLuong +")");
            db.Database.ExecuteSqlCommand("insert into PhieuYeuCau(maPhieuYeuCau,maThe,maNV,maThuVien) " +
                "values ( " +thongTinHoaDon.maPhieuYeuCau +" ,"+thongTinHoaDon.maThe + "," 
                +thongTinHoaDon.maNV +","+ thongTinHoaDon.maThuVien +")");
            db.Database.ExecuteSqlCommand("insert into HoaDonMuon(maPhieuYeuCau,maHoaDon,TrangThai,ngayMuon) " +
                "values ({0},{1},{2},{3})", thongTinHoaDon.maPhieuYeuCau,thongTinHoaDon.maHoaDon,thongTinHoaDon.TrangThai,thongTinHoaDon.NgayMuon);
            db.SaveChanges();
            return RedirectToAction("ThongTinTatCaDonHang");
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