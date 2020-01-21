using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Collections;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace ModasSeedData
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // first create Locations list
            List<Location> locations = new List<Location>()
            {
                new Location { LocationId = 1, Name = "Family Room"},
                new Location { LocationId = 2, Name = "Rear Room"},
                new Location { LocationId = 3, Name = "Front Room"}
            };
            // create date object containing current date/time
            DateTime localDate = DateTime.Now;
            // TODO: subtract 6 months from date
            DateTime eventDate = localDate.AddMonths(-6);
            // TODO: instantiate Random class
            Random rnd = new Random();
            // TODO: create list to store events (Events)
            List<Event> events = new List<Event>();
            // loop for each day in the range from 6 months ago to today
            while (eventDate < localDate)
            {
                // TODO: random between 0 and 5 determines the number of events to occur on a given day
                int num = rnd.Next(0, 5);
                // TODO: a sorted list will be used to store daily events sorted by date/time - each time an event is added, the list is re-sorted
                SortedList<DateTime, Event> dailyEvents = new SortedList<DateTime, Event>();
                // TODO: for loop to generate times for each event
                for(int i = 0; i < num; i++)
                    {
                        // TODO: random between 0 and 23 for hour of the day
                        // TODO: random between 0 and 59 for minute of the day
                        // TODO: random between 0 and 59 for seconds of the day
                        // TODO: random location (use Locations)
                        // TODO: create date/time for event
                        // TODO: create event from date/time and location
                        // TODO: add daily event to sorted list

                        int hour = rnd.Next(0, 23);
                        int min = rnd.Next(0, 60);
                        int sec = rnd.Next(0, 60);

                        int location = rnd.Next(0, locations.Count);

                        DateTime d = new DateTime(eventDate.Year, eventDate.Month, eventDate.Day, hour, min, sec);
                        Event e = new Event { Flagged = false, Location = locations[location], LocationId = locations[location].LocationId, TimeStamp = d };

                        dailyEvents.Add(d, e);
                    }


                // TODO: loop thru sorted list for daily events
                foreach(var de in dailyEvents)
                {
                    // add daily event to Events
                    events.Add(de.Value);
                }

                // TODO: add 1 day to eventDate
                eventDate = eventDate.AddDays(1);
            }
            // TODO: loop thru Events
            foreach(Event e in events)
            {
                // TODO: display event at console
                Console.WriteLine($"{e.TimeStamp} - {e.Location.Name}");
            }

        }
    }

    public class Location
    {
        public int LocationId { get; set; }
        public string Name { get; set; }
    }

    public class Event
    {
        public int EventId { get; set; }
        public DateTime TimeStamp { get; set; }
        public bool Flagged { get; set; }
        // foreign key for location 
        public int LocationId { get; set; }
        // navigation property
        public Location Location { get; set; }
    }
}

