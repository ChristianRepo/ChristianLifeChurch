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
       
        public IEnumerable<Event> Get()
        {
            _eventRepository.Add(new Event()
            {
                Description = "Some descriptions",
                End = null,
                Start = DateTime.Now,
                Title = "Some title"
            });
            _eventRepository.Add(new Event()
            {
                Description = "Some descriptions",
                End = null,
                Start = DateTime.Now,
                Title = "Some title"
            });
            _eventRepository.Add(new Event()
            {
                Description = "Some descriptions",
                End = null,
                Start = DateTime.Now,
                Title = "Some title"
            });
            _eventRepository.Add(new Event()
            {
                Description = "Some descriptions",
                End = null,
                Start = DateTime.Now,
                Title = "Some title"
            });
            return _eventRepository.ToList();
            
        }

        public Event Get(int id)
        {
            return null;
        }

        public HttpResponseMessage Post(HttpRequestMessage request, [FromBody]Event value)
        {
            if (ModelState.IsValid)
            {
                List.Add(value);
                var msg = string.Format("Событие {0} успешно добавленно!", value.Title);
                return request.CreateResponse(HttpStatusCode.OK, msg);
            }
            return request.CreateResponse(HttpStatusCode.BadRequest, GetErrorMessages());
        }

        private IEnumerable<string> GetErrorMessages()
        {
            return ModelState.Values.SelectMany(sm => sm.Errors.Select(s => s.ErrorMessage));
        }

        public HttpResponseMessage Put(HttpRequestMessage request, int id, [FromBody]Event value)
        {
            if (ModelState.IsValid)
            {
                var oldVal = List.First(w => w.Title == value.Title);
                oldVal.Id = value.Id;
                oldVal.Description = value.Description;
                oldVal.Start = value.Start;
                oldVal.End = value.End;
                var msg = string.Format("Событие {0} успешно обновленно!",oldVal.Title);
                return request.CreateResponse(HttpStatusCode.OK, msg);
            }
            return request.CreateResponse(HttpStatusCode.BadRequest, GetErrorMessages());
        }

        public HttpResponseMessage Delete(HttpRequestMessage request,int id)
        {
            try
            {
                //var value = List.First(w => w.Title);
                //List.Remove(value);
                return request.CreateResponse(HttpStatusCode.OK, "Удаление события произошло успешно!");
            }
            catch (Exception ex)
            {
                return request.CreateResponse(HttpStatusCode.BadRequest, "Удаление события произошло с ошибкой, попробуйте еще раз!");
            }
            
        }
    }
}
