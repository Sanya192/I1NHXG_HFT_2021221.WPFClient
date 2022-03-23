// <copyright file="RestWorker.cs" company="MSanyi">
// Copyright (c) MSanyi.All rights reserved.
// </copyright>

namespace VegyesBolt.RestWpfUi.Logic
{
    using System;
    using System.Collections.Generic;
    using RestSharp;
    using VegyesBolt.Data;
    using VegyesBolt.Logic;

    /// <summary>
    /// A Rest Implementation of the Logic interface. It communicates with a JSON API.
    /// </summary>
    internal class RestWorker : ILogic
    {
        public RestWorker()
        {
            this.RestClient = new RestClient(new Uri("https://localhost:7207/api/"));
        }

        public bool CreateMegye(Megyek create)
        {
            try
            {
                var request = new RestRequest("Megye");
                request.AddJsonBody(create);
                var response = this.RestClient.PutAsync(request);
                response.Wait();
                var result = response.Result;
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool CreateTermek(Termekek create)
        {
            throw new System.NotImplementedException();
        }

        public bool CreateVasarlasok(Vasarlasok create)
        {
            throw new System.NotImplementedException();
        }

        public bool CreateVasarlo(Vasarlok create)
        {
            throw new System.NotImplementedException();
        }

        public bool DeleteMegyek(Megyek delete)
        {
            var request = new RestRequest($"Megye/{delete.Id}");
            var response = this.RestClient.DeleteAsync(request);
            response.Wait();
            var result = response.Result;
            return true;
        }

        public bool DeleteTermek(Termekek delete)
        {
            var request = new RestRequest($"Termek/{delete.Id}");
            var response = this.RestClient.DeleteAsync(request);
            response.Wait();
            var result = response.Result;
            return true;
        }

        public bool DeleteVasarlasok(Vasarlasok delete)
        {
            var request = new RestRequest($"Vasarlas/{delete.TermekId}/{delete.VasarloId}");
            var response = this.RestClient.DeleteAsync(request);
            response.Wait();
            var result = response.Result;
            return true;
        }

        public bool DeleteVasarlo(Vasarlok delete)
        {
            var request = new RestRequest($"Vasarlo/{delete.Id}");
            var response = this.RestClient.DeleteAsync(request);
            response.Wait();
            var result = response.Result;
            return true;
        }

        public List<Vasarlok> EbbeAMegyebeLakik(Megyek megye)
        {
            throw new System.NotImplementedException();
        }

        public Megyek GetMegye(int id)
        {
            var request = new RestRequest($"Megye/{id}");
            var response = this.RestClient.GetAsync<Megyek>(request);
            response.Wait();
            var result = response.Result;
            return result;
        }

        public List<Megyek> GetMegyek()
        {
            var request = new RestRequest("Megye");
            var response = this.RestClient.GetAsync<List<Megyek>>(request);
            response.Wait();
            var result = response.Result;
            return result;
        }

        public Termekek GetTermek(int id)
        {
            var request = new RestRequest($"Termek/{id}");
            var response = this.RestClient.GetAsync<Termekek>(request);
            response.Wait();
            var result = response.Result;
            return result;
        }

        public List<Termekek> GetTermekek()
        {
            var request = new RestRequest("Termek");
            var response = this.RestClient.GetAsync<List<Termekek>>(request);
            response.Wait();
            var result = response.Result;
            return result;
        }

        public Vasarlasok GetVasarlas(int id)
        {
            var request = new RestRequest($"Vasarlas/{id}");
            var response = this.RestClient.GetAsync<Vasarlasok>(request);
            response.Wait();
            var result = response.Result;
            return result;
        }

        public List<Vasarlasok> GetVasarlasok()
        {
            var request = new RestRequest("Vasarlas");
            var response = this.RestClient.GetAsync<List<Vasarlasok>>(request);
            response.Wait();
            var result = response.Result;
            return result;
        }

        public Vasarlok GetVasarlo(int id)
        {
            var request = new RestRequest($"Vasarlo/{id}");
            var response = this.RestClient.GetAsync<Vasarlok>(request);
            response.Wait();
            var result = response.Result;
            return result;
        }

        public List<Vasarlok> GetVasarlok()
        {
            var request = new RestRequest("Vasarlo");
            var response = this.RestClient.GetAsync<List<Vasarlok>>(request);
            response.Wait();
            var result = response.Result;
            return result;
        }

        public List<Termekek> ListbyOwner(Vasarlok owner)
        {
            throw new System.NotImplementedException();
        }

        public Termekek MostOwnedProduct()
        {
            throw new System.NotImplementedException();
        }

        public bool UpdateMegye(Megyek create)
        {
            try
            {
                var request = new RestRequest("Megye");
                request.AddJsonBody(create);
                var response = this.RestClient.PostAsync<List<Megyek>>(request);
                response.Wait();
                var result = response.Result;
                return true;
            }
            catch (Exception e)
            {
                return false;
            }

        }

        public bool UpdateTermek(Termekek update)
        {
            throw new System.NotImplementedException();
        }

        public bool UpdateVasarlasok(Vasarlasok update)
        {
            throw new System.NotImplementedException();
        }

        public bool UpdateVasarlo(Vasarlok update)
        {
            throw new System.NotImplementedException();
        }

        private RestClient RestClient { get; }
    }
}
