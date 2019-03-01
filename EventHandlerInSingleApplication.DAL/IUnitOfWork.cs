using System;
using System.Collections.Generic;
using System.Text;

namespace EventHandlerInSingleApplication.DAL
{
    public interface IUnitOfWork
    {
        IOrderRepository OrderRepository { get; }

        IShoppingCartRepository ShoppingCartRepository { get; }


        void Save();
    }
}
