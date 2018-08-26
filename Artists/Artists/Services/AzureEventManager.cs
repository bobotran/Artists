using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Artists.DTOs;
using Artists.Models;
using AutoMapper;
using Marvin.JsonPatch;
using Newtonsoft.Json;

[assembly: Xamarin.Forms.Dependency(typeof(Artists.Services.AzureEventManager))]
namespace Artists.Services
{
    public class AzureEventManager : IDataStore<Event>
    {
        private HttpClient client = new HttpClient();
        public async Task<bool> AddItemAsync(Event item)
        {
            var eventForCreation = Mapper.Map<EventForCreationDto>(item);
            var eventForCreationJson = JsonConvert.SerializeObject(eventForCreation);
            var content = new StringContent(eventForCreationJson, Encoding.Unicode, "application/json");
            var response = await client.PostAsync(Constants.DevelopmentUrl + "events", content);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteItemAsync(int id)
        {
            var response = await client.DeleteAsync(Constants.DevelopmentUrl + $"events/{id}");
            return response.IsSuccessStatusCode;
        }

        public async Task<Event> GetItemAsync(int id)
        {
            var response = await client.GetAsync(Constants.DevelopmentUrl + $"events/{id}");
            var eventsJson = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Event>(eventsJson);
        }

        public async Task<IEnumerable<Event>> GetItemsAsync(bool forceRefresh = false)
        {
            var response = await client.GetAsync(Constants.DevelopmentUrl + "events");
            var eventsJson = await response.Content.ReadAsStringAsync();
            var events = JsonConvert.DeserializeObject<IEnumerable<Event>>(eventsJson);
            return events;
        }

        public async Task<bool> UpdateItemAsync(Event updatedEvent)
        {
            Event eventFromDataStore = await GetItemAsync(updatedEvent.Id);
            JsonPatchDocument<Event> patchDoc = Event.GetJsonPatchDocument(eventFromDataStore, updatedEvent);
            // serialize
            var serializedPatchDoc = JsonConvert.SerializeObject(patchDoc);
            // create the patch request
            var method = new HttpMethod("PATCH");
            var request = new HttpRequestMessage(method, Constants.DevelopmentUrl + $"events/{updatedEvent.Id}")
            {
                Content = new StringContent(serializedPatchDoc, Encoding.Unicode, "application/json")
            };

            // send it, using an HttpClient instance
            var response = await client.SendAsync(request);
            return response.IsSuccessStatusCode;
        }
    }
}
