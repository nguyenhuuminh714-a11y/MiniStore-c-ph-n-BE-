using System.Collections.Generic;

namespace MiniStore.Models.ViewModel
{
    public class ProductSearchVM
    {
        public List<MiniStore.Models.Product> Products { get; set; } = new List<MiniStore.Models.Product>();
        public List<MiniStore.Models.Category> Categories { get; set; } = new List<MiniStore.Models.Category>();
        public string SearchTerm { get; set; }
        public decimal? MinPrice { get; set; }
        public decimal? MaxPrice { get; set; }
        public string SortOrder { get; set; }
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 6;
        public int TotalPages { get; set; }
    }
}
