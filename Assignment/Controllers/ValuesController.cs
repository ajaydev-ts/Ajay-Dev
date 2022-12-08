using Assignment.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Assignment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly ShopContext _shopContext;
        public ValuesController(ShopContext shopContext)
        {
            _shopContext = shopContext;
        }
        [HttpGet("getallCategory")]
        public List<Category> getcat()
        {
            var data = this._shopContext.Categories.ToList();
            return data;
        }
        [HttpGet("getallSubcategory")]
        public List<Subcategory> getsubcat()
        {
            var data = this._shopContext.Subcategories.ToList();
            return data;
        }
        [HttpGet("getallProducts")]
        public List<Product> getprod()
        {
            var data = this._shopContext.Products.ToList();
            return data;
        }
        [HttpGet("getallCustomer")]
        public List<Customer> getcus()
        {
            var data = this._shopContext.Customers.ToList();
            return data;
        }
      
        [HttpGet("getallOrders")]
        public List<Order> getorders()
        {
            var data = this._shopContext.Orders.ToList();
            return data;
        }
        [HttpPost("postallCategory")]
        public string postcat(Category cat)
        {
            this._shopContext.Add(cat);
            this._shopContext.SaveChanges();
            return "Success";
        }
        [HttpPost("postallSubcategory")]
        public string postsubcat(Subcategory subcat)
        {
            this._shopContext.Add(subcat);
            this._shopContext.SaveChanges();
            return "Success";
        }
        [HttpPost("postallCustomer")]
        public string postcus(Customer cus)
        {
            this._shopContext.Add(cus);
            this._shopContext.SaveChanges();
            return "Success";
        }
        [HttpPost("postallProduct")]
        public string postprod(Product prod)
        {
            this._shopContext.Add(prod);
            this._shopContext.SaveChanges();
            return "Success";
        }
        [HttpPost("postallorders")]
        public string postorder(Order order)
        {
            this._shopContext.Add(order);
            this._shopContext.SaveChanges();
            return "Success";
        }
        [HttpPut("putCategory")]
        public string catup(Category cat)
        {
            this._shopContext.Categories.Update(cat);
            this._shopContext.SaveChanges();
            return "Updated";
        }
        [HttpPut("putSubCategory")]
        public string subcatup(Subcategory cat)
        {
            this._shopContext.Subcategories.Update(cat);
            this._shopContext.SaveChanges();
            return "Updated";
        }
        [HttpPut("putcustomer")]
        public string cusup(Customer cat)
        {
            this._shopContext.Customers.Update(cat);
            this._shopContext.SaveChanges();
            return "Updated";
        }
        [HttpPut("putorder")]
        public string orderup(Order cat)
        {
            this._shopContext.Orders.Update(cat);
            this._shopContext.SaveChanges();
            return "Updated";
        }
        [HttpPut("putProduct")]
        public string produp(Product cat)
        {
            this._shopContext.Products.Update(cat);
            this._shopContext.SaveChanges();
            return "Updated";
        }
        [HttpDelete("delcategory")]
        public string deletecat(Category em)
        {
            this._shopContext.Categories.Remove(em);
            this._shopContext.SaveChanges();
            return "Success";
        }
        [HttpDelete("delsubcategory")]
        public string deletesubcat(Subcategory em)
        {
            this._shopContext.Subcategories.Remove(em);
            this._shopContext.SaveChanges();
            return "Success";
        }
        [HttpDelete("delcustomer")]
        public string deletecus(Customer em)
        {
            this._shopContext.Customers.Remove(em);
            this._shopContext.SaveChanges();
            return "Success";
        }
        [HttpDelete("delorder")]
        public string deleteorder(Order em)
        {
            this._shopContext.Orders.Remove(em);
            this._shopContext.SaveChanges();
            return "Success";
        }
        [HttpDelete("delproduct")]
        public string deleteproduct(Product em)
        {
            this._shopContext.Products.Remove(em);
            this._shopContext.SaveChanges();
            return "Success";
        }




    }
}
