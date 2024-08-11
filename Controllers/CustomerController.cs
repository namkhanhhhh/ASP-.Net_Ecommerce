using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OnlineShop_ASP_MVC.Data;
using OnlineShop_ASP_MVC.Helper;
using OnlineShop_ASP_MVC.ViewModels;

namespace OnlineShop_ASP_MVC.Controllers
{
    public class CustomerController : Controller
    {
        private readonly Hshop2023Context db;
        private readonly IMapper _mapper;

        public CustomerController(Hshop2023Context context, IMapper mapper) {
            db = context;
            _mapper=mapper;
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(RegisterVM model,IFormFile img)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var x = _mapper.Map<KhachHang>(model);
                    x.RandomKey = Util.GenRandomKey();
                    x.MatKhau = model.Password.ToMd5Hash(x.RandomKey);
                    x.HieuLuc = true;
                    x.VaiTro = 0;

                    if (img != null)
                    {
                        x.Hinh = Util.UploadImg(img, "KhachHang");
                    }

                    db.Add(x);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }catch (Exception ex) { }
                
            }
            return View();
        }
    }
}
