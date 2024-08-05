namespace OnlineShop_ASP_MVC.ViewModels
{
    public class ProductVM
    {
        public int Id { get; set; }
        public string Name {  get; set; }
        public string Img {  get; set; }
        public double Price {  get; set; }
        public string Description { get; set; }
        public string Cname { get; set; }
    }
    public class ProductDetailVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Img { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public string Cname { get; set; }
        public string Specific { get; set; }
        public int Rate { get; set; }
        public int CQuantity { get; set; }
    }
}
