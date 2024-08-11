using AutoMapper;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;
using OnlineShop_ASP_MVC.Data;
using OnlineShop_ASP_MVC.ViewModels;

namespace OnlineShop_ASP_MVC.Helper
{
    public class AutoMapperProfile:Profile
    {
        public AutoMapperProfile() {
            CreateMap<RegisterVM, KhachHang>().ForMember(c=>c.HoTen, op=>op.MapFrom(RegisterVM=>RegisterVM.Name)).ReverseMap();
        }
    }
}
