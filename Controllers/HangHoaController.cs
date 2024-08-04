using Microsoft.AspNetCore.Mvc;
using OnlineShop_ASP_MVC.Data;
using OnlineShop_ASP_MVC.ViewModels;

namespace OnlineShop_ASP_MVC.Controllers
{
    public class HangHoaController : Controller
    {
        public readonly Hshop2023Context db;
        public HangHoaController(Hshop2023Context context) {
            db=context;
        }
        public IActionResult Index(int? type)
        {
            var products=db.HangHoas.AsQueryable();
            if (type.HasValue)
            {
                products=products.Where(p=>p.MaLoai==type.Value);
            }
            var res = products.Select(p => new ProductVM
            {
                Id = p.MaHh,
                Name = p.TenHh,
                Price = p.DonGia ?? 0,
                Img = p.Hinh ?? "",
                Description = p.MoTaDonVi ?? "",
                Cname = p.MaLoaiNavigation.TenLoai
            });
            return View(res);
        }
        public IActionResult Search(string query)
        {
            var products = db.HangHoas.AsQueryable();
            if (query!=null)
            {
                products = products.Where(p => p.TenHh.Contains(query));
            }
            var res = products.Select(p => new ProductVM
            {
                Id = p.MaHh,
                Name = p.TenHh,
                Price = p.DonGia ?? 0,
                Img = p.Hinh ?? "",
                Description = p.MoTaDonVi ?? "",
                Cname = p.MaLoaiNavigation.TenLoai
            });
            return View(res);
        }
    }
}
