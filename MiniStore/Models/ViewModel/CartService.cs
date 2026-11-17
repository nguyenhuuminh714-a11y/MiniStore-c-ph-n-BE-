using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MiniStore.Models.ViewModel
{
    // Dịch vụ lưu giỏ hàng trong Session theo nội dung slide.
    public class CartService
    {
        private const string SessionKey = "Cart";
        private readonly HttpSessionStateBase session;

        public CartService(HttpSessionStateBase sessionState)
        {
            session = sessionState;
        }

        public List<CartItem> GetItems()
        {
            var items = session[SessionKey] as List<CartItem>;
            if (items == null)
            {
                items = new List<CartItem>();
                session[SessionKey] = items;
            }
            return items;
        }

        public void Add(CartItem newItem)
        {
            var items = GetItems();
            var existing = items.FirstOrDefault(x => x.ProductID == newItem.ProductID);
            if (existing == null) items.Add(newItem);
            else existing.Quantity += newItem.Quantity;
        }

        public void UpdateQuantity(int productId, int quantity)
        {
            var item = GetItems().FirstOrDefault(x => x.ProductID == productId);
            if (item == null) return;
            if (quantity <= 0) GetItems().Remove(item);
            else item.Quantity = quantity;
        }

        public void Remove(int productId)
        {
            var item = GetItems().FirstOrDefault(x => x.ProductID == productId);
            if (item != null) GetItems().Remove(item);
        }

        public void Clear()
        {
            session[SessionKey] = new List<CartItem>();
        }
    }
}
