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

        public ShoppingCartManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void SubmitShoppingCart()
        {
            _unitOfWork.ShoppingCartRepository.AddShoppingCart();

            EventHandlerContainer.Current.Trigger(new ShoppingCartSubmittedEvent());

            _unitOfWork.Save();
        }
    }
}
