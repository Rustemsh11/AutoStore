using AutoStore.Domain.Entities;

namespace AutoStore.Domain.Abstract
{
    public interface IOrderProcessor
    {
        void ProcessOrder(Cart cart, ShopingDetails shopingDetails);
    }
}
