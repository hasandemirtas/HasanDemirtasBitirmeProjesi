using HasanDemirtasBitirmeProjesi.Admin.Models;
using HasanDemirtasBitirmeProjesi.Business.Concrate;
using HasanDemirtasBitirmeProjesi.Entity.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace HasanDemirtasBitirmeProjesi.Admin.Controllers
{
    public class AdminController : Controller
    {
        private readonly AdminManager _adminManager;
        private readonly CategoryManager _categoryManager;
        private readonly ProductManager _productManager;
        private readonly TagManager _tagManager;

        public AdminController()
        {
            _adminManager = new AdminManager();
            _categoryManager = new CategoryManager();
            _productManager = new ProductManager();
            _tagManager = new TagManager();
        }
        #region Views
        public IActionResult Index()
        {
            List<Product> products = _productManager.ListProduct();

            ProductModel singleProduct;
            List<ProductModel> model = new List<ProductModel>();
            
            foreach(Product p in products)
            {
                singleProduct = new ProductModel();

                singleProduct.Id = p.Id;
                singleProduct.Name = p.Name;
                singleProduct.Description = p.Description;
                singleProduct.Image = p.Image;
                singleProduct.Price = p.Price;

                model.Add(singleProduct);
            }
            
            return View(model);
        }

        public IActionResult AddCategoryView()
        {
            List<Category> categories = _categoryManager.ListCategories();
            return View(categories);
        }

        public IActionResult AddProductView()
        {
            List<Category> categoryList = _categoryManager.ListCategories();

            CategoryModel singleCategory;
            List<CategoryModel> model = new List<CategoryModel>();
            foreach (Category c in categoryList)
            {
                singleCategory = new CategoryModel();
                singleCategory.Name = c.Name;

                model.Add(singleCategory);
            }
            ViewBag.CategoryList = model;
            return View();
        }
        public IActionResult AddTagView()
        {
            List<Tag> tags = _tagManager.ListTags();
            return View(tags);
        }

        #endregion


        #region CRUD Oparations
        public IActionResult AddProduct(ProductModel model)
        {
            Product product = new Product();
            product.Id = model.Id;
            product.Name = model.Name;
            product.Description = model.Description;
            product.Image = model.Image;
            product.Price = model.Price;
            product.CategoryName = model.CategoryName;
            product.Quantity = model.Quantity;
            product.CreateDate = DateTime.Now.Date;

            _productManager.AddProduct(product);

            return RedirectToAction("Index");
        }

        public IActionResult DeleteProduct(int id)
        {
            _productManager.DeleteProduct(id);
            return RedirectToAction("Index");
        }


        public void AddCategory(string name)
        {
            bool result = _categoryManager.AddCategory(name);
            if (!result)
            {
                
            }
        }

        public void AddTag(string name)
        {
            bool result = _tagManager.AddTag(name);
            if (!result)
            {

            }
        }

        #endregion

    }
}