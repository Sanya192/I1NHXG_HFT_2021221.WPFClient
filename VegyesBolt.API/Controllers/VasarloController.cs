// <copyright file="VasarloController.cs" company="MSanyi">
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
    public class VasarloController : BaseController<Vasarlok>
    {
        public VasarloController(IHubContext<SignalRHub> hub) : base(hub)
        {
        }

        /// <inheritdoc/>.
        public override async Task Delete(int id)
        {
            base.Delete(id);
            Shared.Worker.DeleteVasarlo(new Vasarlok() { Id = id });
        }

        /// <inheritdoc/>.
        public override async Task<IEnumerable<Vasarlok>> Get()
        {
            return Shared.Worker.GetVasarlok();
        }

        /// <inheritdoc/>.
        public override async Task<Vasarlok> Get(int id)
        {
            return Shared.Worker.GetVasarlo(id);
        }

        /// <inheritdoc/>.
        public override async Task Post([FromBody] Vasarlok value)
        {
            base.Post(value);
            Shared.Worker.UpdateVasarlo(value);
        }

        /// <inheritdoc/>.
        public override async Task Put([FromBody] Vasarlok value)
        {
            base.Put(value);
            if (Shared.Worker.CreateVasarlo(value))
            this.Response.StatusCode = 201;
            else
            this.Response.StatusCode = 500;
        }
    }
}
