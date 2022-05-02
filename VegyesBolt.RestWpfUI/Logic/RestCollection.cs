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
    public class RestExceptionInfo
    {
        public RestExceptionInfo()
        {

        }
        public string Msg { get; set; }
    }

    public class RestCollection<T> : INotifyCollectionChanged, IEnumerable<T>
    {
        public event NotifyCollectionChangedEventHandler? CollectionChanged;

        NotifyService notify;
        RestService rest;
        List<T> items;
        bool hasSignalR;
        Type type = typeof(T);

        public RestCollection(string baseurl, string endpoint, string hub = null)
        {
            hasSignalR = hub != null;
            this.rest = new RestService(baseurl, endpoint);
            if (hub != null)
            {
                this.notify = new NotifyService(baseurl + hub);
                this.notify.AddHandler<T>(type.Name + "Created", (T item) =>
                {
                    items.Add(item);
                    CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
                });
                this.notify.AddHandler<T>(type.Name + "Deleted", (T item) =>
                {
                    var element = items.FirstOrDefault(t => t.Equals(item));
                    if (element != null)
                    {
                        items.Remove(item);
                        CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
                    }
                    else
                    {
                        Init();
                    }

                });
                this.notify.AddHandler<T>(type.Name + "Updated", (T item) =>
                {
                    Init();
                });

                this.notify.Init();
            }
            Init();
        }

        private async Task Init()
        {
            items = await rest.GetAsync<T>(typeof(T).Name);
            CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
        }

        public IEnumerator<T> GetEnumerator()
        {
            if (items != null)
            {
                return items.GetEnumerator();
            }
            else return new List<T>().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            if (items != null)
            {
                return items.GetEnumerator();
            }
            else return new List<T>().GetEnumerator();
        }

        public void Add(T item)
        {
            if (hasSignalR)
            {
                this.rest.PostAsync(item, typeof(T).Name);
            }
            else
            {
                this.rest.PostAsync(item, typeof(T).Name).ContinueWith((t) =>
                {
                    Init().ContinueWith(z =>
                    {
                        Application.Current.Dispatcher.Invoke(() =>
                        {
                            CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
                        });
                    });
                });
            }

        }

        public void Update(T item)
        {
            if (hasSignalR)
            {
                this.rest.PutAsync(item, typeof(T).Name);
            }
            else
            {
                this.rest.PutAsync(item, typeof(T).Name).ContinueWith((t) =>
                {
                    Init().ContinueWith(z =>
                    {
                        Application.Current.Dispatcher.Invoke(() =>
                        {
                            CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
                        });
                    });
                });
            }
        }

        public void Delete(int id)
        {
            if (hasSignalR)
            {
                this.rest.DeleteAsync(id, typeof(T).Name);
            }
            else
            {
                this.rest.DeleteAsync(id, typeof(T).Name).ContinueWith((t) =>
                {
                    Init().ContinueWith(z =>
                    {
                        Application.Current.Dispatcher.Invoke(() =>
                        {
                            CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
                        });
                    });
                });
            }

        }


    }
}