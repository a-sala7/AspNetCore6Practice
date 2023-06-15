using AspNetPractice.Models;
using AspNetPractice.ViewModels.Products;
using Microsoft.AspNetCore.Mvc;

namespace AspNetPractice.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;

        public ProductsController(IProductRepository productRepository, 
            ICategoryRepository categoryRepository)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
        }

        public async Task<IActionResult> List()
        {
            IEnumerable<Product> products = await _productRepository.GetAll();
            var vm = new ProductListViewModel(products);
            return View(vm);
        }

        public async Task<IActionResult> Details(int id)
        {
            var product = await _productRepository.GetById(id);
            return View(product);
        }

        [Route("Products/Upsert/{id:int?}")]
        public async Task<IActionResult> Upsert(int? id)
        {
            Dictionary<int, string> categoryDict = await GetCategoriesAsDictionary();

            if (!id.HasValue)
            {
                return View(new UpsertProductViewModel(categoryDict));
            }

            var prod = await _productRepository.GetById(id.Value);
            if (prod is null)
            {
                return View(new UpsertProductViewModel(categoryDict));
            }

            return View(new UpsertProductViewModel(ProductInputModel.FromProduct(prod), categoryDict));
        }

        private async Task<Dictionary<int, string>> GetCategoriesAsDictionary()
        {
            var categories = await _categoryRepository.GetAll();
            var categoryDict = new Dictionary<int, string>();
            foreach (var c in categories)
            {
                categoryDict.Add(c.Id, c.Name);
            }

            return categoryDict;
        }

        [HttpPost]
        [Route("Products/Upsert/{id:int?}")]
        public async Task<IActionResult> Upsert(int? id, [Bind(Prefix = "Product")] ProductInputModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(new UpsertProductViewModel(model, await GetCategoriesAsDictionary()));
            }
            var existingProduct = id == null ? null : await _productRepository.GetById(id.Value);
            if (existingProduct is null)
            {
                await _productRepository.Add(new Product
                {
                    Name = model.Name,
                    CategoryId = model.CategoryId,
                    Description = model.Description,
                    Price = model.Price
                });
            }
            else
            {
                existingProduct.Name = model.Name;
                existingProduct.CategoryId = model.CategoryId;
                existingProduct.Description = model.Description;
                existingProduct.Price = model.Price;
                await _productRepository.Update(existingProduct);
            }
            return RedirectToAction("List");
        }
    }
}
