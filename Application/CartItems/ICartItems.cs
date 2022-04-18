using Domain.Entities;

namespace Application.CartItems
{
    public interface ICartItemsService
    {
        CartItem GetCartItems(int CartId);
        CartItem AddCartLineItems(LineItem lineItem, int CartId);
        CartItem RemoveCartLineItems(int CartId, int ProductId);
        CartItem CheckOut(int CartId);
    }
}
