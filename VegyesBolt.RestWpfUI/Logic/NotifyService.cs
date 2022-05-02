// <copyright file="RestCollection.cs" company="MSanyi">
// Copyright (c) MSanyi.All rights reserved.
// </copyright>

namespace VegyesBolt.RestWpfUi.Logic
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Collections.Specialized;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows;
    using Microsoft.AspNetCore.SignalR.Client;
    class NotifyService
    {
        private HubConnection conn;

        public NotifyService(string url)
        {
            conn = new HubConnectionBuilder()
                .WithUrl(url)
                .Build();

            conn.Closed += async (error) =>
            {
                await Task.Delay(new Random().Next(0, 5) * 1000);
                await conn.StartAsync();
            };
        }

        public void AddHandler<T>(string methodname, Action<T> value)
        {
            conn.On<T>(methodname, value);
        }

        public async void Init()
        {
            await conn.StartAsync();
        }

    }
}