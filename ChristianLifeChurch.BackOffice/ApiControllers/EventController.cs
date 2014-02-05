using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
//using ChristianLifeChurch.Core;
using ChristianLifeChurch.CommonEntities;
using ChristianLifeChurch.Core.DbEntities;
using ChristianLifeChurch.Core.Repository;

namespace ChristianLifeChurch.BackOffice.ApiControllers
{
    public class EventController : ApiController
    {
        public List<Event> List = new List<Event>();
        private readonly IEventRepository _eventRepository;

        public EventController(IEventRepository repo)
        {
            _eventRepository = repo;
        }
       
        public IEnumerable<Event> Get(){
          
            return _eventRepository.ToList();
        }

        public Event Get(string id)
        {
            return _eventRepository.GetById(id);
        }

        public HttpResponseMessage Post(HttpRequestMessage request, [FromBody]Event value)
        {
            if (ModelState.IsValid)
            {
                _eventRepository.Add(value);
                var msg = string.Format("Событие {0} успешно добавленно!", value.Title);
                return request.CreateResponse(HttpStatusCode.OK, msg);
            }
            return request.CreateResponse(HttpStatusCode.BadRequest, GetErrorMessages());
        }

        private IEnumerable<string> GetErrorMessages()
        {
            return ModelState.Values.SelectMany(sm => sm.Errors.Select(s => s.ErrorMessage));
        }

        public HttpResponseMessage Put(HttpRequestMessage request, string id, [FromBody]Event value)
        {
            if (ModelState.IsValid)
            {
                //var oldVal = _eventRepository.GetById(id);
                //oldVal.Description = value.Description;
                //oldVal.Start = value.Start;
                //oldVal.End = value.End;
                _eventRepository.Update(value);
                var msg = string.Format("Событие {0} успешно обновленно!", value.Title);
                return request.CreateResponse(HttpStatusCode.OK, msg);
            }
            return request.CreateResponse(HttpStatusCode.BadRequest, GetErrorMessages());
        }

        public HttpResponseMessage Delete(HttpRequestMessage request,string id)
        {
            try
            {
                var value =  _eventRepository.GetById(id);
                _eventRepository.Delete(value);
                return request.CreateResponse(HttpStatusCode.OK, "Удаление события произошло успешно!");
            }
            catch (Exception ex)
            {
                return request.CreateResponse(HttpStatusCode.BadRequest, "Удаление события произошло с ошибкой, попробуйте еще раз!");
            }
            
        }
    }
}
