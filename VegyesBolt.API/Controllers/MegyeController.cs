// <copyright file="MegyeController.cs" company="MSanyi">
// Copyright (c) MSanyi.All rights reserved.
// </copyright>

namespace VegyesBolt.API.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using VegyesBolt.API.Helper;
    using VegyesBolt.Data;

    /// <inheritdoc/>
    public class MegyeController : BaseController<Megyek>
    {
        /// <inheritdoc/>.
        public override IEnumerable<Megyek> Get()
        {
            return Shared.Worker.GetMegyek();
        }

        /// <inheritdoc/>.
        public override Megyek Get(int id)
        {
            return Shared.Worker.GetMegye(id);
        }

        /// <inheritdoc/>.
        public override void Post([FromBody] Megyek megye)
        {
            base.Post(megye);
            Shared.Worker.UpdateMegye(megye);
        }

        /// <inheritdoc/>.
        public override void Put([FromBody] Megyek value)
        {
            base.Put(value);
            if (Shared.Worker.CreateMegye(value))
                this.Response.StatusCode = 201;
            else
                this.Response.StatusCode = 500;
        }

        /// <inheritdoc/>.
        public override void Delete(int id)
        {
            base.Delete(id);
            Shared.Worker.DeleteMegyek(new Megyek() { Id = id });
        }
    }
}
