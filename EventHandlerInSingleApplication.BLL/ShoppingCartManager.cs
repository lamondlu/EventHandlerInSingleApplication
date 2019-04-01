using EventHandlerInSingleApplication.BLL.EventHandlers;
using EventHandlerInSingleApplication.BLL.Events;
using EventHandlerInSingleApplication.DAL;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using EventHandlerInSingleApplication.Models.ViewModels;
using EventHandlerInSingleApplication.Models.DTOs;
using MediatR;

namespace EventHandlerInSingleApplication.BLL
{
    public class ShoppingCartManager : IShoppingCartManager
    {
        private IUnitOfWork _unitOfWork = null;
        private EventHandlerContainer _container = null;
        private IMediator _mediator = null;

        public ShoppingCartManager(IUnitOfWork unitOfWork, EventHandlerContainer container, IMediator mediator)
        {
            _unitOfWork = unitOfWork;
            _container = container;
            _mediator = mediator;
        }

        public void AddItemToShoppingCart(string shoppingCartId, string itemId)
        {
            _unitOfWork.ShoppingCartRepository.AddItemToShippingCart(shoppingCartId, itemId);
            _unitOfWork.Save();
        }

        public string CreateShoppingCart()
        {
            var shoppingCartId = _unitOfWork.ShoppingCartRepository.CreateShoppingCart();
            _unitOfWork.Save();

            return shoppingCartId;
        }

        public void SubmitShoppingCart(string shoppingCartId)
        {
            var shoppingCart = _unitOfWork.ShoppingCartRepository.GetShoppingCart(shoppingCartId);

            _unitOfWork.ShoppingCartRepository.SubmitShoppingCart(shoppingCartId);

            _mediator.Publish(new ShoppingCartSubmittedEvent()
            {
                Items = shoppingCart.Items.Select(p => new ShoppingCartSubmittedItem
                {
                    ItemId = p.ItemId,
                    Name = p.Name,
                    Price = p.Price
                }).ToList()
            });

            //_container.Publish(new ShoppingCartSubmittedEvent()
            //{
            //    Items = shoppingCart.Items.Select(p => new ShoppingCartSubmittedItem
            //    {
            //        ItemId = p.ItemId,
            //        Name = p.Name,
            //        Price = p.Price
            //    }).ToList()
            //});

            //_unitOfWork.OrderRepository.CreatOrder(new CreateOrderDTO
            //{
            //    Items = shoppingCart.Items.Select(p => new NewOrderItemDTO
            //    {
            //        ItemId = p.ItemId,
            //        Name = p.Name,
            //        Price = p.Price
            //    }).ToList()
            //});

            //Console.WriteLine("Confirm Email Sent.");

            _unitOfWork.Save();
        }

        public List<ItemViewModel> GetAllItems()
        {
            return _unitOfWork.ShoppingCartRepository.GetAllItems();
        }
    }
}
