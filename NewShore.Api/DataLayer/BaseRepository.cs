using DataLayer.Common;
using Entities;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;

namespace DataLayer
{
    public class BaseRepository : IBaseRepository
    {
        private static string flightsUrl;

        public BaseRepository(string flightUrl)
        {
            flightsUrl = flightUrl;
        }
        public BaseRepository()
        {
        }

        public IList<T> GetFlights<T>(int category)
        {
            List<T> flights = new List<T>();

            var client = new RestClient($"{flightsUrl}/flights/{category}");
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                flights = JsonConvert.DeserializeObject<List<T>>(response.Content);
            }

            return flights;
        }
    }
}
