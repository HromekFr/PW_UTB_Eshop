using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UTB.Eshop.Web.Models.Database;
using UTB.Eshop.Web.Models.Entity;
using UTB.Eshop.Web.Models.ViewModels;

namespace UTB.Eshop.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly ILogger<ProductController> _logger;
        readonly EshopDbContext eshopDbContext;

        public ProductController(ILogger<ProductController> logger, EshopDbContext eshopDb)
        {
            _logger = logger;
            eshopDbContext = eshopDb;
        }

        public IActionResult Detail(int ID)
        {
            DetailViewModel detailVM = new DetailViewModel();
            detailVM.Product = eshopDbContext.Products.FirstOrDefault(prod => prod.ID == ID);
            detailVM.Ratings = eshopDbContext.Ratings.Where(rating => rating.ProductID == ID).ToList();
            detailVM.Users = eshopDbContext.Users.ToList();
            if (detailVM.Ratings.Count != 0)
            {
                detailVM.Stars = (int)detailVM.Ratings.Average(rating => rating.Stars);
            }
            


            if (detailVM.Product != null)
            {
                return View(detailVM);
            }

            return NotFound();
        }
    }
}
