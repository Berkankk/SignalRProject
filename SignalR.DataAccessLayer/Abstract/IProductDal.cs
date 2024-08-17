using SignalR.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.DataAccessLayer.Abstract
{
    public interface IProductDal : IGenericDal<Product>
    {
        //Product da özgü metot yazma alanı 

        List<Product> GetProductsWithCategories();
        public int ProductCount();
        public int ProductCountCategoryNameHamburger();
        public int ProductCountCategoryNameDrink();
        public decimal ProductPriceAvg();
        public string ProductNameByMaxPrice();  //Geriye ürün adı döneceğimiz için string türde tuttuk
        public string ProductNameByMinPrice();
        public decimal ProductAvgPriceByHamburger();
        decimal ProductPriceBySteakBurger();
        
    }
}
