using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using Domain.Abstract;
using WebUI.Models;

namespace WebUI.Controllers
{
    public class ProductController : Controller
    {
        //
        // GET: /Product/
        public int PageSize = 4;//Мы изменим это позднее
        private IProductRepository repository;

        public ProductController(IProductRepository productRepository)
        {
            repository = productRepository;
        }

        public ViewResult List(int page = 1)
        {
            ProductListViewModel viewModel = new ProductListViewModel
            {
                Products = repository.Products.OrderBy(p => p.ProductID).
                    Skip((page - 1)*PageSize).
                    Take(PageSize),

                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = repository.Products.Count()
                }
            };
            return View(viewModel);
        }

        

    }
}
