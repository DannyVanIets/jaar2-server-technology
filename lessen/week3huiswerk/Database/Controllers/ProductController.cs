using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Database.DAL;
using Database.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Database.Controllers
{
    public class ProductController : Controller
    {
        ProductAcessLayer pal = new ProductAcessLayer();

        // GET: Product
        [HttpGet]
        public ActionResult Index()
        {
            var products = pal.GetProductList();
            return View(products);
        }

        // GET: Product/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Product/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View(new ProductModel());
        }

        // POST: Product/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProductModel productModel)
        {
            if (productModel.ProductName == null)
            {
                productModel.ProductName = string.Empty;
            }

            pal.AddProduct(productModel);
            return RedirectToAction(nameof(Index));
        }

        // GET: Product/Edit/5
        public ActionResult Edit(int id)
        {
            ProductModel productModel = pal.GetProduct(id);
            return View(productModel);
        }

        // POST: Product/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ProductModel productModel)
        {
            if (productModel.ProductName == null)
            {
                productModel.ProductName = string.Empty;
            }

            pal.UpdateProduct(productModel);
            return RedirectToAction(nameof(Index));
        }

        // GET: Product/Delete/5
        public ActionResult Delete(int id)
        {
            ProductModel productModel = pal.GetProduct(id);
            return View(productModel);
        }

        // POST: Product/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            pal.DeleteProduct(id);
            return RedirectToAction(nameof(Index));
        }
    }
}