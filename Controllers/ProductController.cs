﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using VyTrongQuy_5405_Tuan2.Models;

namespace VyTrongQuy_5405_Tuan2.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;
        public ProductController(IProductRepository productRepository,
        ICategoryRepository categoryRepository)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
        }
        public IActionResult Add()
        {
            var categories = _categoryRepository.GetAllCategories();
            ViewBag.Categories = new SelectList(categories, "Id", "Name");
            return View();
        }
        [HttpPost]
        public IActionResult Add(Product product)
        {
            if (ModelState.IsValid)
            {
                _productRepository.Add(product);
                return RedirectToAction("Index"); // Chuyển hướng tới trang danh 
            }
            return View(product);
        }
        // Các actions khác như Display, Update, Delete
        // Display a list of products
        // Display a single product
        public IActionResult Display(int id)
        {
            var categories = _categoryRepository.GetAllCategories();
            ViewBag.Categories = new SelectList(categories, "Id", "Name");
            var product = _productRepository.GetById(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }
        // Show the product update form
        public IActionResult Update(int id)
        {
            var categories = _categoryRepository.GetAllCategories();
            ViewBag.Categories = new SelectList(categories, "Id", "Name");
            var product = _productRepository.GetById(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }
        // Process the product update
        [HttpPost]
        public IActionResult Update(Product product)
        {
            var categories = _categoryRepository.GetAllCategories();
            ViewBag.Categories = new SelectList(categories, "Id", "Name");
            if (ModelState.IsValid)
            {
                _productRepository.Update(product);
                return RedirectToAction("Index");
            }
            return View(product);
        }
        // Show the product delete confirmation
        public IActionResult Delete(int id)
        {
            var categories = _categoryRepository.GetAllCategories();
            ViewBag.Categories = new SelectList(categories, "Id", "Name");
            var product = _productRepository.GetById(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }
        // Process the product deletion
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            _productRepository.Delete(id);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> Add(Product product, IFormFile imageUrl)
        {
            // Xử lý khi dữ liệu hợp lệ
            if (ModelState.IsValid)
            {
                // Kiểm tra và xử lý ảnh
                if (imageUrl != null && imageUrl.Length > 0)
                {
                    // Xử lý việc lưu trữ ảnh
                }

                // Thêm sản phẩm vào repository
                _productRepository.Add(product);
                return RedirectToAction("Index");
            }
            // Nếu dữ liệu không hợp lệ, trả về view Add với model đã nhập
            var categories = _categoryRepository.GetAllCategories();
            ViewBag.Categories = new SelectList(categories, "Id", "Name");
            return View(product);
        }


        public IActionResult Index()
        {
            var products = _productRepository.GetAll();
            return View(products);
        }
    }
}
