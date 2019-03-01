using EventHandlerInSingleApplication.BLL.EventHandlers;
using EventHandlerInSingleApplication.BLL.Events;
using EventHandlerInSingleApplication.DAL;
using System;
using System.Collections.Generic;
using System.Text;

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

        public void SubmitShoppingCart()
        {
            _unitOfWork.ShoppingCartRepository.AddShoppingCart();

            _container.Trigger(new ShoppingCartSubmittedEvent());

            _unitOfWork.Save();
        }
    }
}
