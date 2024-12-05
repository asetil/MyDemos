using Aware.BL.Model;
using Aware.Search;
using Aware.Util.Constants;
using Microsoft.AspNetCore.Mvc;
using TicketSales.WebApi.BusinessLogic.Services;
using TicketSales.WebApi.Model.Dto;

namespace TicketSales.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EventController : ControllerBase
    {
        private readonly IEventService _eventService;
        public EventController(IEventService eventService)
        {
            _eventService = eventService;
        }

        [HttpGet]
        public SearchResult<EventItemDto> Get()
        {
            var result = _eventService.Search();
            return result;
        }

        [HttpPost("save")]
        public OperationResult<EventItemDto> Save(EventItemDto model)
        {
            if (model == null || !ModelState.IsValid)
                return OperationResult<EventItemDto>.Error(ResultCodes.Error.OperationFailed, model);

            var result = _eventService.Save(model);
            return result;
        }

        [HttpPost("delete")]
        public OperationResult<EventItemDto> Delete(long id)
        {
            if (id <= 0)
                return OperationResult<EventItemDto>.Error(ResultCodes.Error.OperationFailed);

            var result = _eventService.Delete(id);
            return result;
        }
    }
}
