// <copyright file="VasarlasController.cs" company="MSanyi">
// Copyright (c) MSanyi.All rights reserved.
// </copyright>

namespace VegyesBolt.API.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.SignalR;
    using VegyesBolt.API.Helper;
    using VegyesBolt.API.Services;
    using VegyesBolt.Data;

    /// <inheritdoc/>.
    public class VasarlasController : BaseController<Vasarlasok>
    {
        public VasarlasController(IHubContext<SignalRHub> hub) : base(hub)
        {
        }

        /// <summary>
        /// Deletes a vasarlas.
        /// </summary>
        /// <param name="termekId">The termekID to be deleted.</param>
        /// <param name="vasarloId">The vasarlasID to be deleted.</param>
        [HttpDelete("{termekId}/{vasarloId}")]
        public void Delete(int termekId, int vasarloId)
        {
            base.Delete(termekId);
            Shared.Worker.DeleteVasarlasok(new Vasarlasok() { TermekId = termekId, VasarloId = vasarloId });
        }

        /// <summary>
        /// Mistakes were made.
        /// </summary>
        /// <param name="id">Does not matter.</param>
        [ProducesResponseType(405)]
        public override void Delete(int id)
        {
            this.Response.StatusCode = 405;
        }

        /// <inheritdoc/>.
        public override IEnumerable<Vasarlasok> Get()
        {
            return Shared.Worker.GetVasarlasok();
        }

        /// <inheritdoc/>.
        public override Vasarlasok Get(int id)
        {
            return Shared.Worker.GetVasarlas(id);
        }

        /// <inheritdoc/>.
        public override void Post([FromBody] Vasarlasok megye)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>.
        public override void Put([FromBody] Vasarlasok value)
        {
            throw new NotImplementedException();
        }
    }
}
