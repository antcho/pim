using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Entities;
using PIM.DataContext.Managers;

namespace PIM.Web.Controllers
{
    public class ProductsController : Controller
    {
        private ProductManager _productManager = new ProductManager();

        // GET: Products
        public ActionResult Index(string search)
        {
            List<Product> products;
            if(!string.IsNullOrWhiteSpace(search))
            {
                products = _productManager.Find(p => p.Name.Contains(search) || p.Description.Contains(search) || p.Category.Contains(search));
            }
            else
            {
                products = _productManager.GetAll();
            }

            return View(products);
        }

        // GET: Products/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = _productManager.Get(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: Products/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Products/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Reference,Name,Description,Price,Category,ValidityDate,Image")] Product product)
        {
            if (ModelState.IsValid)
            {
                _productManager.Add(product);

                return RedirectToAction("Index");
            }

            return View(product);
        }

        // GET: Products/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = _productManager.Get(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Products/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Reference,Name,Description,Price,Category,ValidityDate,Image")] Product product)
        {
            if (ModelState.IsValid)
            {
                _productManager.Update(product);
                return RedirectToAction("Index");
            }
            return View(product);
        }

        // GET: Products/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = _productManager.Get(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _productManager.Delete(id);
            return RedirectToAction("Index");
        }

    }
}
