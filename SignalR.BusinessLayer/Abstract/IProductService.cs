using SignalR.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.BusinessLayer.Abstract
{
    public interface IProductService : IGenericService<Product>
    {
        List<Product> TGetProductsWithCategories();
        public int TProductCount();
        public int TProductCountCategoryNameHamburger();
        public int TProductCountCategoryNameDrink();
        public decimal TProductPriceAvg();
        public string TProductNameByMaxPrice();  //Geriye ürün adı döneceğimiz için string türde tuttuk
        public string TProductNameByMinPrice();
        public decimal TProductAvgPriceByHamburger();
        decimal TProductPriceBySteakBurger();
    }
}
