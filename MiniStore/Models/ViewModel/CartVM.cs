using System.Collections.Generic;
using System.Linq;
using PagedList;
using MiniStore.Models;

namespace MiniStore.Models.ViewModel
{
    public class CartVM
    {
        public List<CartItem> Items { get; set; } = new List<CartItem>();
        public List<IGrouping<string, CartItem>> GroupedItems
        {
            get { return Items.GroupBy(x => string.IsNullOrWhiteSpace(x.Category) ? "Khác" : x.Category).ToList(); }
        }
        public IPagedList<MiniStore.Models.Product> SimilarProducts { get; set; }
        public decimal SelectedTotal { get { return Items.Where(x => x.IsSelected).Sum(x => x.TotalPrice); } }
        public int SelectedCount { get { return Items.Where(x => x.IsSelected).Sum(x => x.Quantity); } }
    }
}
