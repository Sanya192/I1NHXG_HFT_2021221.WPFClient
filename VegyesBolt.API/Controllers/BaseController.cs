// <copyright file="BaseController.cs" company="MSanyi">
// Copyright (c) MSanyi.All rights reserved.
// </copyright>

namespace VegyesBolt.API.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.SignalR;
    using VegyesBolt.API.Services;

    /// <summary>
    /// Creates a Base ControllerClass from which the other cruds methods are derived.
    /// </summary>
    /// <typeparam name="T">The type of the Crud.</typeparam>
    [Route("api/[controller]")]
    [ApiController]
    public abstract class BaseController<T> : ControllerBase
    {
        IHubContext<SignalRHub> hub;

        protected BaseController(IHubContext<SignalRHub> hub)
        {
            this.hub = hub;
        }

        /// <summary>
        /// Gets all of the entities of the <typeparamref name="T"/>.
        /// </summary>
        /// <returns>The list of the <typeparamref name="T"/>.</returns>
        [HttpGet]
        public abstract IEnumerable<T> Get();

        /// <summary>
        /// Gets 1 of the entities of the <typeparamref name="T"/>.
        /// </summary>
        /// <param name="id">The id of the id we get.</param>
        /// <returns>The list of the <typeparamref name="T"/>.</returns>
        [HttpGet("{id}")]
        public abstract T Get(int id);

        /// <summary>
        /// Edits 1 of the entities of the <typeparamref name="T"/>.
        /// </summary>
        /// <param name="value">From the messagebody the object we edit. The ID should be the one we edit.</param>
        [HttpPost]
        public virtual void Post([FromBody] T value)
        {
            this.hub?.Clients?.All?.SendAsync("Changed","Hello");
        }

        /// <summary>
        /// Edits 1 of the entities of the <typeparamref name="T"/>.
        /// </summary>
        /// <param name="value">From the messagebody the object we edit. The ID doesn't matter.</param>
        [HttpPut]
        [ProducesResponseType(201)]
        public virtual void Put([FromBody] T value)
        {
            this.hub?.Clients?.All?.SendAsync("Changed", "hello");
        }

        /// <summary>
        /// Deletes 1 of the entities of the <typeparamref name="T"/>.
        /// </summary>
        /// <param name="id"> The ID should be the one we delete.</param>
        [HttpDelete("{id}")]
        public virtual void Delete(int id)
        {
            this.hub?.Clients?.All?.SendAsync("Changed", "hello");
        }
    }
}
