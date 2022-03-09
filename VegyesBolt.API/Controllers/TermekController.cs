using Microsoft.AspNetCore.Mvc;
using VegyesBolt.API.Helper;
using VegyesBolt.Data;

namespace VegyesBolt.API.Controllers
{
    public class TermekController : BaseController<Termekek>
    {
        public override void Delete(int id)
        {
            Shared.Worker.DeleteTermek(new Termekek() { Id = id });
        }

        public override IEnumerable<Termekek> Get()
        {
            return Shared.Worker.GetTermekek();
        }

        public override Termekek Get(int id)
        {
            return Shared.Worker.GetTermek(id);

        }

        public override void Post([FromBody] Termekek value)
        {
            Shared.Worker.UpdateTermek(value);
        }

        public override void Put([FromBody] Termekek value)
        {
            Shared.Worker.CreateTermek(value);
        }
    }
}
