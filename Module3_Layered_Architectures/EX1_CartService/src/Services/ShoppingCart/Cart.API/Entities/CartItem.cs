namespace ShoppingCart.API.Entities
{
    public class CartItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Image? Image { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
    public class Image
    {
        public string? URL { get; set; }
        public string? AltText { get; set; }
    }
}
