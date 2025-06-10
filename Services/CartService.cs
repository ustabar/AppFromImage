using EShopApp.Models;

namespace EShopApp.Services
{
    public class CartService
    {
        private List<CartItem> _cartItems = new();
        
        public event Action? CartChanged;
        
        public List<CartItem> GetCartItems() => _cartItems;
        
        public int GetCartItemCount() => _cartItems.Sum(x => x.Quantity);
        
        public decimal GetCartTotal() => _cartItems.Sum(x => x.TotalPrice);
        
        public void AddToCart(Product product)
        {
            var existingItem = _cartItems.FirstOrDefault(x => x.ProductId == product.Id);
            
            if (existingItem != null)
            {
                existingItem.Quantity++;
            }
            else
            {
                _cartItems.Add(new CartItem
                {
                    ProductId = product.Id,
                    ProductName = product.Name,
                    Price = product.Price,
                    ImageUrl = product.ImageUrl,
                    Quantity = 1
                });
            }
            
            CartChanged?.Invoke();
        }
        
        public void RemoveFromCart(int productId)
        {
            var item = _cartItems.FirstOrDefault(x => x.ProductId == productId);
            if (item != null)
            {
                _cartItems.Remove(item);
                CartChanged?.Invoke();
            }
        }
        
        public void UpdateQuantity(int productId, int quantity)
        {
            var item = _cartItems.FirstOrDefault(x => x.ProductId == productId);
            if (item != null)
            {
                if (quantity > 0)
                {
                    item.Quantity = quantity;
                }
                else
                {
                    _cartItems.Remove(item);
                }
                CartChanged?.Invoke();
            }
        }
        
        public void ClearCart()
        {
            _cartItems.Clear();
            CartChanged?.Invoke();
        }
    }
}