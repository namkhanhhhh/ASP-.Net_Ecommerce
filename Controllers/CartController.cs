using Microsoft.AspNetCore.Mvc;
using OnlineShop_ASP_MVC.Data;
using OnlineShop_ASP_MVC.ViewModels;
using OnlineShop_ASP_MVC.Helper;

namespace OnlineShop_ASP_MVC.Controllers
{
    public class CartController : Controller
    {
        private readonly Hshop2023Context db;

        public CartController(Hshop2023Context hshop2023Context) {
            db = hshop2023Context;
        }

        const string CART_KEY="MYCART";
        public List<CartItem> GetCart=>HttpContext.Session.Get<List<CartItem>>(CART_KEY)??new List<CartItem>();
        public IActionResult Index()
        {
            return View(GetCart);
        }

        public IActionResult AddToCart(int id, int quantity=1)
        {
            var cart = GetCart;
            var item=cart.SingleOrDefault(x => x.Id == id);
            if (item == null)
            {
                var products = db.HangHoas.SingleOrDefault(p => p.MaHh == id);
                if (products == null)
                {
                    TempData["Message"] = "Cannot find product!!!";
                    return Redirect("/404");
                }
                item = new CartItem
                {
                    Id = products.MaHh,
                    Name = products.TenHh,
                    Price = products.DonGia ?? 0,
                    Img = products.Hinh ?? string.Empty,
                    Quantity = quantity
                };
                cart.Add(item);
            }
            else
            {
                item.Quantity += quantity;
            }
            HttpContext.Session.Set(CART_KEY, cart);
            return RedirectToAction("Index");
        }

        public IActionResult Remove(int id)
        {
            var cart = GetCart;
            var item = cart.SingleOrDefault(x => x.Id == id);
            if(item != null)
            {
                cart.Remove(item);
                HttpContext.Session.Set(CART_KEY, cart);
            }
            
            return RedirectToAction("Index");
        }
    }
}
