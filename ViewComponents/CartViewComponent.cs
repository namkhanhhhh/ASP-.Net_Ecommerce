using Microsoft.AspNetCore.Mvc;
using OnlineShop_ASP_MVC.Helper;
using OnlineShop_ASP_MVC.ViewModels;

namespace OnlineShop_ASP_MVC.ViewComponents
{
    public class CartViewComponent:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var cart=HttpContext.Session.Get <List<CartItem>>(Setting.CART_KEY) ?? new List<CartItem>();
            return View("CartPanel",new CartModel
            {
                Quantity=cart.Sum(x => x.Quantity),
                Total=cart.Sum(x=>x.TotalPrice)
            });
        }
    }
}
