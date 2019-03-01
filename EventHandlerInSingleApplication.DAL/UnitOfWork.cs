using System;
using System.Collections.Generic;
using System.Text;

namespace EventHandlerInSingleApplication.DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private IOrderRepository _orderRepository = null;
        private IShoppingCartRepository _shoppingCartRepository = null;

        public IOrderRepository OrderRepository
        {
            get
            {
                if (_orderRepository == null)
                {
                    _orderRepository = new OrderRepository();
                }

                return _orderRepository;
            }
        }

        public IShoppingCartRepository ShoppingCartRepository
        {
            get
            {
                if (_shoppingCartRepository == null)
                {
                    _shoppingCartRepository = new ShoppingCartRepository();
                }

                return _shoppingCartRepository;
            }
        }


        public void Save()
        {

        }
    }
}
