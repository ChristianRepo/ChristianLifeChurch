using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ChristianLifeChurch.Core.DbEntities;
using ChristianLifeChurch.Core.Repository;

namespace ChristianLifeChurch.BackOffice.ApiControllers
{
    public class MemberController : ApiController
    {
        private readonly IMemberRepository _memberRepository;

        public MemberController(IMemberRepository repo)
        {
            _memberRepository = repo;
        }
       
        public IEnumerable<Member> Get()
        {
            _memberRepository.Add(new Member()
            {
                FirstName = "Александр",
                LastName = "Салфетников",
                MidleName = "Сергеевич",
                DateOfBirth = DateTime.Now,
                Job = "Пастор",
                About = "Очень много всего",
                Foto = "aaron_skonnard.jpg"
            });
            _memberRepository.Add(new Member()
            {
                FirstName = "Александр",
                LastName = "Салфетников",
                MidleName = "Сергеевич",
                DateOfBirth = DateTime.Now,
                Job = "Пастор",
                About = "Очень много всего"
            });
            _memberRepository.Add(new Member()
            {
                FirstName = "Александр",
                LastName = "Салфетников",
                MidleName = "Сергеевич",
                DateOfBirth = DateTime.Now,
                Job = "Пастор",
                About = "Очень много всего"
            });
            _memberRepository.Add(new Member()
            {
                FirstName = "Александр",
                LastName = "Салфетников",
                MidleName = "Сергеевич",
                DateOfBirth = DateTime.Now,
                Job = "Пастор",
                About = "Очень много всего"
            });
            return _memberRepository.ToList();
        }

        public Member Get(string id)
        {
            return _memberRepository.GetById(id);
        }

        public HttpResponseMessage Post(HttpRequestMessage request, [FromBody]Member value)
        {
            if (ModelState.IsValid)
            {
                _memberRepository.Add(value);
                var msg = string.Format("Служитель {0} успешно добавлен!", value.FirstName);
                return request.CreateResponse(HttpStatusCode.OK, msg);
            }
            return request.CreateResponse(HttpStatusCode.BadRequest, GetErrorMessages());
        }

        private IEnumerable<string> GetErrorMessages()
        {
            return ModelState.Values.SelectMany(sm => sm.Errors.Select(s => s.ErrorMessage));
        }

        public HttpResponseMessage Put(HttpRequestMessage request, string id, [FromBody]Member value)
        {
            if (ModelState.IsValid)
            {
                _memberRepository.Update(value);
                var msg = string.Format("Служитель {0} успешно обновлен!", value.FirstName);
                return request.CreateResponse(HttpStatusCode.OK, msg);
            }
            return request.CreateResponse(HttpStatusCode.BadRequest, GetErrorMessages());
        }

        public HttpResponseMessage Delete(HttpRequestMessage request,string id)
        {
            try
            {
                var value = _memberRepository.GetById(id);
                _memberRepository.Delete(value);
                return request.CreateResponse(HttpStatusCode.OK, "Удаление служителя произошло успешно!");
            }
            catch (Exception ex)
            {
                return request.CreateResponse(HttpStatusCode.BadRequest, "Удаление служителя произошло с ошибкой, попробуйте еще раз!");
            }
            
        }
    }
}
