using Business;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class BaseController : ControllerBase
    {
        protected IEventBus _eventBus;

        public BaseController(IEventBus eventBus) 
        {
            _eventBus = eventBus;
        }
    }
}
