using Artists.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Artists.Services
{
    public class AzurePerformanceManager : IDataStore<Performance>
    {
        private HttpClient client;
        public Task<bool> AddItemAsync(Performance item)
        {
            var eventForCreation = Mapper.Map<EventForCreationDto>(item);
            var eventForCreationJson = JsonConvert.SerializeObject(eventForCreation);
            var content = new StringContent(eventForCreationJson, Encoding.Unicode, "application/json");
            var response = await client.PostAsync(Constants.DevelopmentUrl + "events", content);
            return response.IsSuccessStatusCode;
        }

        public Task<bool> DeleteItemAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Performance> GetItemAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Performance>> GetItemsAsync(bool forceRefresh = false)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateItemAsync(Performance item)
        {
            throw new NotImplementedException();
        }
    }
}
