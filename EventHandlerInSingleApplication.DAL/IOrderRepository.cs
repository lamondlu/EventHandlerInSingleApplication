using EventHandlerInSingleApplication.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace EventHandlerInSingleApplication.DAL
{
    public interface IOrderRepository
    {
        void CreatOrder(CreateOrderDTO dto);
    }
}
