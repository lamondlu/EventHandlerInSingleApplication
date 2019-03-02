using EventHandlerInSingleApplication.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace EventHandlerInSingleApplication.BLL
{
    public interface IOrderManager
    {
        string CreateNewOrder(CreateOrderDTO dto);
    }
}
