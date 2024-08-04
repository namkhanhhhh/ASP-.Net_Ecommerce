using Microsoft.AspNetCore.Mvc;
using OnlineShop_ASP_MVC.Data;
using OnlineShop_ASP_MVC.ViewModels;
namespace OnlineShop_ASP_MVC.ViewComponents
{
    public class MenuTypeViewComponent : ViewComponent
    {
        private readonly Hshop2023Context db;

        public MenuTypeViewComponent(Hshop2023Context context) => db = context;

        public IViewComponentResult Invoke()
        {
            var data = db.Loais.Select(lo => new MenuTypeVM
            {
                Id=lo.MaLoai,
                Name=lo.TenLoai,
                Quantity = lo.HangHoas.Count
            }).OrderBy(p=>p.Name);
            return View(data);
        }
    }
}
