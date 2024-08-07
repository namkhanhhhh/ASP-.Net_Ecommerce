namespace OnlineShop_ASP_MVC.ViewModels
{
    public class CartItem
    {
        public int Id { get; set; }
        public string Img {  get; set; }
        public string Name { get; set; }
        public double Price {  get; set; }
        public int Quantity {  get; set; }
        public double TotalPrice =>Price*Quantity; 

    }
}
