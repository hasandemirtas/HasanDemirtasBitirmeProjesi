using HasanDemirtasBitirmeProjesi.Business.Concrate;
using HasanDemirtasBitirmeProjesi.Entity.Entities;
using HasanDemirtasBitirmeProjesi.Presentation.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace HasanDemirtasBitirmeProjesi.Presentation.Controllers
{
    public class HomeController : Controller
    {
        private readonly ProductManager _productManager;
        public HomeController()
        {
            _productManager = new ProductManager();
        }

        public IActionResult Index()
        {
            List<Product> products = _productManager.ListProduct();

            ProductModel singleProduct;
            List<ProductModel> model = new List<ProductModel>();

            foreach (Product p in products)
            {
                singleProduct = new ProductModel();

                singleProduct.Id = p.Id;
                singleProduct.Name = p.Name;
                singleProduct.Description = p.Description;
                singleProduct.Image = p.Image;
                singleProduct.Quantity = p.Quantity;
                singleProduct.Price = p.Price;
                

                model.Add(singleProduct);
            }

            return View(model);
        }

        public void BuyProduct(int id)
        {
            _productManager.BuyProduct(id);
        }
    }
}