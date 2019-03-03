using System;
using System.Collections.Generic;
using System.Text;

namespace EventHandlerInSingleApplication.BLL.Events
{
    public class EventBase
    {
        public EventBase()
        {
            OccuredOn = DateTime.Now;
        }

        protected DateTime OccuredOn
        {
            get;
            set;
        }
    }
}
