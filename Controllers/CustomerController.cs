using AutoMapper;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineShop_ASP_MVC.Data;
using OnlineShop_ASP_MVC.Helper;
using OnlineShop_ASP_MVC.ViewModels;
using System.Security.Claims;

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
        public IActionResult Register(RegisterVM model,IFormFile Hinh)
        {
			/*if (ModelState.IsValid)
            {
                try
                {
                    var x = _mapper.Map<KhachHang>(model);
                    x.RandomKey = Util.GenRandomKey();
                    x.MatKhau = model.MatKhau.ToMd5Hash(x.RandomKey);
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
            return View();*/
			if (ModelState.IsValid)
			{
				try
				{
					var khachHang = _mapper.Map<KhachHang>(model);
					khachHang.RandomKey = Util.GenRandomKey();
					khachHang.MatKhau = model.MatKhau.ToMd5Hash(khachHang.RandomKey);
					khachHang.HieuLuc = true;//sẽ xử lý khi dùng Mail để active
					khachHang.VaiTro = 0;

					if (Hinh != null)
					{
						khachHang.Hinh = Util.UploadImg(Hinh, "KhachHang");
					}

					db.Add(khachHang);
					db.SaveChanges();
					return RedirectToAction("Index", "HangHoa");
				}
				catch (Exception ex)
				{
					var mess = $"{ex.Message} shh";
				}
			}
			return View();
		}

        [HttpGet]
        public IActionResult Login(string? StrUrl)
        {
            ViewBag.StrUrl = StrUrl;    
             return View(); 
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginVM model, string? ReturnUrl)
        {
           
            ViewBag.ReturnUrl = ReturnUrl;
            if (ModelState.IsValid)
            {
                var cus = db.KhachHangs.SingleOrDefault(kh => kh.MaKh == model.UserName);
                if (cus == null)
                {
                    ModelState.AddModelError("loi", "not valid customer");
                }
                else
                {
                    if (!cus.HieuLuc)
                    {
                        ModelState.AddModelError("loi", "An account has banned!");
                    }
                    else
                    {
                        if(cus.MatKhau!=model.Password.ToMd5Hash(cus.RandomKey))
                        {
                            ModelState.AddModelError("loi", "Not valid user name or password");
                        }
                        else
                        {
                            var claims = new List<Claim> { 
                            new Claim(ClaimTypes.Email, cus.Email),
                            new Claim(ClaimTypes.Name, cus.HoTen),
                            new Claim("CustomerID", cus.MaKh),
                            new Claim(ClaimTypes.Role, "Customer")
                            };
                            var claimsIdentity= new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                            var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
                            await HttpContext.SignInAsync(claimsPrincipal);
                            if (Url.IsLocalUrl(ReturnUrl))
                            {
                                return Redirect(ReturnUrl);
                            }
                            else
                            {
                                return Redirect("/");
                            }
                        }
                    }
                }
            }
            return View();
        }

        [Authorize]
        public IActionResult Profile()
        {
            return View();
        }
    }
}
