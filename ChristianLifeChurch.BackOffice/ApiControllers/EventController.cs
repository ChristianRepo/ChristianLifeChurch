using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ChristianLifeChurch.CommonEntities;

namespace ChristianLifeChurch.BackOffice.ApiControllers
{
    public class EventController : ApiController
    {
        public List<Event> List = new List<Event>();

        public EventController()
        {
            List.Add(new Event(){Description = "Some descriptions",Id = 1,End = null, Start = DateTime.Now,Title = "Some title"});
            List.Add(new Event() { Description = "Some descriptions 1", Id = 2, End = null, Start = DateTime.Now, Title = "Some title 1" });
            List.Add(new Event() { Description = "Some descriptions 2", Id = 3, End = null, Start = DateTime.Now, Title = "Some title 2" });
            List.Add(new Event() { Description = "Some descriptions 3", Id = 4, End = null, Start = DateTime.Now, Title = "Some title 3" });
            List.Add(new Event() { Description = "Some descriptions 4", Id = 5, End = null, Start = DateTime.Now, Title = "Some title 4" });
            List.Add(new Event() { Description = "Some descriptions 5", Id = 6, End = null, Start = DateTime.Now, Title = "Some title 5" });
            List.Add(new Event() { Description = "Some descriptions 6", Id = 7, End = null, Start = DateTime.Now, Title = "Some title 6" });
        }
        public IEnumerable<Event> Get()
        {
            return List;
        }
        
        public Event Get(int id)
        {
            return List.First(w => w.Id == id);
        }

        public void Post([FromBody]Event value)
        {
            List.Add(value);
        }
        
        public void Put(int id, [FromBody]Event value)
        {
           var oldVal =  List.First(w => w.Id == id);
            oldVal.Id = value.Id;
            oldVal.Description = value.Description;
            oldVal.Start = value.Start;
            oldVal.End = value.End;
        }

        public void Delete(int id)
        {
           var value = List.First(w => w.Id == id);
            List.Remove(value);
        }
    }
}
