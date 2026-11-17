using System.Linq;
using System.Web.Mvc;
using MiniStore.Models;

namespace MiniStore.Controllers
{
    public class CategoryController : Controller
    {
        public PartialViewResult Menu()
        {
            using (var db = new StoreDb())
            {
                return PartialView("_CategoriesPV", db.Categories.OrderBy(x => x.CategoryName).ToList());
            }
        }
    }
}
