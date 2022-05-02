using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using VegyesBolt.API.Helper;
using VegyesBolt.API.Services;
using VegyesBolt.Data;

namespace VegyesBolt.API.Controllers
{
    /// <inheritdoc/>.
    public class TermekController : BaseController<Termekek>
    {
        public TermekController(IHubContext<SignalRHub> hub) : base(hub)
        {
        }

        /// <inheritdoc/>.
        public override async Task Delete(int id)
        {
            base.Delete(id);
            Shared.Worker.DeleteTermek(new Termekek() { Id = id });
        }

        /// <inheritdoc/>.
        public override async Task<IEnumerable<Termekek>> Get()
        {
            return Shared.Worker.GetTermekek();
        }

        /// <inheritdoc/>.
        public override async Task<Termekek> Get(int id)
        {
            return Shared.Worker.GetTermek(id);

        }

        /// <inheritdoc/>.
        public override async Task Post([FromBody] Termekek value)
        {
            base.Post(value);
            Shared.Worker.UpdateTermek(value);
        }

        /// <inheritdoc/>.
        public override async Task Put([FromBody] Termekek value)
        {
            base.Put(value);
            Shared.Worker.CreateTermek(value);
        }
    }
}
