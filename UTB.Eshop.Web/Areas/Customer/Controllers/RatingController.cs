using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using UTB.Eshop.Web.Models.ApplicationServices.Abstraction;
using UTB.Eshop.Web.Models.Database;
using UTB.Eshop.Web.Models.Entity;
using UTB.Eshop.Web.Models.Identity;
using UTB.Eshop.Web.Models.ViewModels;

namespace UTB.Eshop.Web.Controllers
{
    [Area("Customer")]
    [Authorize(Roles = nameof(Roles.Customer))]
    public class RatingController : Controller
    {
        readonly EshopDbContext eshopDbContext;
        ISecurityApplicationService iSecure;

        public RatingController(EshopDbContext eshopDB, ISecurityApplicationService iSecure)
        {
            eshopDbContext = eshopDB;
            this.iSecure = iSecure;
        }

        public IActionResult Create(int ID)
        {
            RatingViewModel ratingVM = new RatingViewModel();
            DbSet<Product> products = eshopDbContext.Products;

            ratingVM.Product = products.Where(product => product.ID == ID).FirstOrDefault();
            return View(ratingVM);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Rating rating)
        {
            if (rating != null)
            {
                rating.IsVisible = true;

                ModelState.Clear();
                TryValidateModel(rating);
                if (ModelState.IsValid)
                {
                    eshopDbContext.Ratings.Add(rating);

                    await eshopDbContext.SaveChangesAsync();

                    return RedirectToAction("Detail", "Product", new { ID = rating.ProductID, area = "" });
                }
            }


            return RedirectToAction("Detail", "Product", new { ID = rating.ProductID, area = "" });

        }
    }
}
