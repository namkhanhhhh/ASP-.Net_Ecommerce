using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

        public IActionResult Detail(int id)
        {
            var data=db.HangHoas
                .Include(p=>p.MaLoaiNavigation)
                .SingleOrDefault(p=>p.MaHh==id);
            if (data == null)
            {
                TempData["Message"] = "Not found!";
                return Redirect("/404");
            }
            var result = new ProductDetailVM
            {
                Id = data.MaHh,
                Name = data.TenHh,
                Price = data.DonGia ?? 0,
                Specific = data.MoTa ?? string.Empty,
                Rate = 5,
                Img=data.Hinh??string.Empty,
                Description=data.MoTaDonVi??string.Empty,
                CQuantity=10,
                Cname=data.MaLoaiNavigation.TenLoai
            };
            return View(result);
        }
    }
}
