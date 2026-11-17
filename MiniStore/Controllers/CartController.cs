using System.Linq;
using System.Web.Mvc;
using System.Data.Entity;
using PagedList;
using MiniStore.Models;
using MiniStore.Models.ViewModel;

namespace MiniStore.Controllers
{
    public class CartController : Controller
    {
        private CartService GetCartService()
        {
            return new CartService(Session);
        }

        public ActionResult Index()
        {
            var items = GetCartService().GetItems();
            var categoryIds = items.Select(x => x.ProductID).ToList();
            var vm = new CartVM { Items = items };
            if (items.Any())
            {
                using (var db = new StoreDb())
                {
                    var ids = db.Products.Where(p => categoryIds.Contains(p.ProductID))
                        .Select(p => p.CategoryID).Distinct().ToList();
                    vm.SimilarProducts = db.Products.Include(p => p.Category)
                        .Where(p => ids.Contains(p.CategoryID) && !categoryIds.Contains(p.ProductID))
                        .OrderBy(p => p.ProductName).ToPagedList(1, 8);
                }
            }
            return View(vm);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult AddItem(int id, int quantity = 1)
        {
            using (var db = new StoreDb())
            {
                var p = db.Products.Include(x => x.Category).FirstOrDefault(x => x.ProductID == id);
                if (p == null) return HttpNotFound();
                GetCartService().Add(new CartItem {
                    ProductID = p.ProductID, ProductName = p.ProductName,
                    ProductImage = p.ProductImage, UnitPrice = p.ProductPrice,
                    Category = p.Category == null ? "Khác" : p.Category.CategoryName,
                    Quantity = System.Math.Max(1, System.Math.Min(quantity, 99)), IsSelected = true
                });
            }
            TempData["Message"] = "Đã thêm sản phẩm vào giỏ hàng.";
            return RedirectToAction("Index");
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult AddToCart(int id, int quantity = 1)
        {
            return AddItem(id, quantity);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult UpdateQuantity(int id, int quantity)
        {
            GetCartService().UpdateQuantity(id, quantity);
            return RedirectToAction("Index");
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult RemoveItem(int id)
        {
            GetCartService().Remove(id);
            return RedirectToAction("Index");
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult ClearCart()
        {
            GetCartService().Clear();
            return RedirectToAction("Index");
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult SelectItem(int id, bool isSelected)
        {
            var item = GetCartService().GetItems().FirstOrDefault(x => x.ProductID == id);
            if (item != null) item.IsSelected = isSelected;
            return RedirectToAction("Index");
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult UpdateSelection(int[] selectedIds)
        {
            var selected = selectedIds ?? new int[0];
            foreach (var item in GetCartService().GetItems())
                item.IsSelected = selected.Contains(item.ProductID);
            return RedirectToAction("Index");
        }
    }
}
