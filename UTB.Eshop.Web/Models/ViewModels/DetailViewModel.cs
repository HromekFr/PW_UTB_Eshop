using System.Collections.Generic;
using UTB.Eshop.Web.Models.Entity;
using UTB.Eshop.Web.Models.Identity;

namespace UTB.Eshop.Web.Models.ViewModels
{
    public class DetailViewModel
    {
        public Product Product { get; set; }

        public IList<Rating> Ratings { get; set; }

        public IList<User> Users { get; set; }

        public int Stars { get; set; }
    }
}
