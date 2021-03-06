﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Artists.Models;

[assembly: Xamarin.Forms.Dependency(typeof(Artists.Services.MockDataStore))]
namespace Artists.Services
{
    public class MockDataStore : IDataStore<Event>
    {
        List<Event> items;

        public static List<string> SuggestedPartNames { get; set; } = new List<string> { "Violin", "Viola", "Cello", "Bass","Piano" };
        public MockDataStore()
        {
            items = new List<Event>();
            var mockItems = new List<Event>
            {
                new Event { Id = 0, Nickname = "Lakeview", StartTime = new DateTime(2018, 6, 15) },
                new Event { Id = 1, Nickname = "Laguna Woods Village", StartTime = new DateTime(2018, 6, 17, 19, 0, 0),
                 EndTime = new DateTime(2018, 6, 17, 21, 0, 0), Address = new Address{ AddressLine = "24232 Calle Aragon",
                     City = "Laguna Woods", Building = "Clubhouse #1", FloorLevel = 13 },
                 Performances = new List<Performance>{
                     new Performance
                     {
                         Title = "Dance Macabre",
                         Host = "Ryan Tran",
                         Parts = new List<Part>{ new Part { PartName = "Violin", Performer = new User{ Username = "Kevin Tran" } },
                             new Part{ PartName = "Piano", Performer = new User{ Username = "Ryan Tran"} } },
                         Composer = "Camille Saint-Saëns",
                         Minutes = 3,
                         Description = "Three days before",
                         //Performers = new List<Performer>{new Performer{Name = "Ryan Tran" },
                         //    new Performer{Name = "Kevin Tran" } }
                     },
                     new Performance
                     {
                         Title = "Cello Suite No.1",
                         Host = "Megan Wei",
                         Parts = new List<Part>{ new Part { PartName = "Cello", Performer = new User { Username = "Megan Wei"} } },
                         Composer = "Bach",
                         Minutes = 4,
                         Description = "Played at every frickin senior center",
                         //Performers = new List<Performer>{ new Performer { Name = "Megan Wei" } }
                     }
                 }
                },
                new Event { Id = 2, Nickname = "Irvine", StartTime=new DateTime(2018, 7, 5)  },
                new Event { Id = 3, Nickname = "Tustin Rehabilitation", StartTime=new DateTime(2018, 8, 21)  },
                new Event { Id = 4, Nickname = "Towers", StartTime=new DateTime(2018, 9, 1)  },
                new Event { Id = 5, Nickname = "Tiffany's", StartTime=new DateTime(2018, 9, 7)  },
            };

            foreach (var item in mockItems)
            {
                items.Add(item);
            }
        }

        public async Task<bool> AddItemAsync(Event item)
        {
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Event item)
        {
            var _item = items.Where((Event arg) => arg.Id == item.Id).FirstOrDefault();
            items.Remove(_item);
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(int id)
        {
            var _item = items.Where((Event arg) => arg.Id == id).FirstOrDefault();
            items.Remove(_item);

            return await Task.FromResult(true);
        }

        public async Task<Event> GetItemAsync(int id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Event>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }
    }
}