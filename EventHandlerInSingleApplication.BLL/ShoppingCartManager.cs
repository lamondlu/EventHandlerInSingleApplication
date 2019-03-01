using EventHandlerInSingleApplication.BLL.EventHandlers;
using EventHandlerInSingleApplication.BLL.Events;
using EventHandlerInSingleApplication.DAL;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace EventHandlerInSingleApplication.BLL
{
    public class ShoppingCartManager : IShoppingCartManager
    {
        private IUnitOfWork _unitOfWork = null;
        private EventHandlerContainer _container = null;

        public ShoppingCartManager(IUnitOfWork unitOfWork, EventHandlerContainer container)
        {
            _unitOfWork = unitOfWork;
            _container = container;

            container.Subscribe<ShoppingCartSubmittedEvent>(typeof(ShoppingCartSubmittedEventHandler));
        }

        public void SubmitShoppingCart(string shoppingCartId)
        {
            var shoppingCart = _unitOfWork.ShoppingCartRepository.GetShoppingCart(shoppingCartId);

            _unitOfWork.ShoppingCartRepository.SubmitShoppingCart(shoppingCartId);

            _container.Trigger(new ShoppingCartSubmittedEvent()
            {
                Items = shoppingCart.Items.Select(p => new ShoppingCartSubmittedItem
                {
                    ItemId = p.ItemId,
                    Name = p.Name,
                    Price = p.Price
                }).ToList()
            });

            _unitOfWork.Save();
        }
    }
}
