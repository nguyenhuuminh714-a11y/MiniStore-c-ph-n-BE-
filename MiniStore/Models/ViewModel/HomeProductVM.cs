using System.Collections.Generic;

namespace MiniStore.Models.ViewModel
{
    public class HomeProductVM
    {
        public List<MiniStore.Models.Product> FeaturedProducts { get; set; } = new List<MiniStore.Models.Product>();
        public List<MiniStore.Models.Product> NewProducts { get; set; } = new List<MiniStore.Models.Product>();
        public List<MiniStore.Models.Category> Categories { get; set; } = new List<MiniStore.Models.Category>();
        public string SearchTerm { get; set; }
    }
}
