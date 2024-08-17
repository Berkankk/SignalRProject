
namespace SignalR.EntityLayer.Entities
{
    public class Product
    {
        public int ID { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
        public bool ProductStatus { get; set; }

        //İlişkili tablo oluşturma aşaması 

        public int CategoryID { get; set; }
        public Category Category { get; set; }  //Bir e çok ilişki olduğunu söyler
        public List<OrderDetail> OrderDetails { get; set; }
        public List<Basket> Baskets { get; set; }
    }
}
