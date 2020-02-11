using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Modas.Models;
using Modas.ViewModels;

namespace Modas.Controllers
{
    [Route("api/[controller]")]
    public class EventController : Controller
    {
        private readonly int PageSize = 20;
        public IEventRepository repository;
        public EventController(IEventRepository repo) => repository = repo;


        [HttpGet]
        // returns all events (unsorted)
        public IEnumerable<Event> Get() => repository.Events
            .Include(e => e.Location);

        [HttpGet("page{page:int}")]
        // returns all event by page
        public EventListViewModel GetPage(int page = 1) =>
        new EventListViewModel
        {
            Events = repository.Events.Include(e => e.Location)
                .OrderByDescending(e => e.TimeStamp)
                .Skip((page - 1) * PageSize)
                .Take(PageSize),
            PageInfo = new PageInfoViewModel
            {
                CurrentPageNumber = page,
                EventsPerPage = PageSize,
                TotalEvents = repository.Events.Count()
            }
        };

        [HttpGet("{id}")]
        // returns specific event
        public Event Get(int id) => repository.Events
            .Include(e => e.Location)
            .FirstOrDefault(e => e.EventId == id);

        [HttpPost]
        // add event
        public Event Post([FromBody] Event evt) => repository.AddEvent(new Event
        {
            TimeStamp = evt.TimeStamp,
            Flagged = evt.Flagged,
            LocationId = evt.LocationId
        });

        [HttpPut]
        // update an event
        public Event Put([FromBody] Event evt) => repository.UpdateEvent(evt);

        [HttpDelete]
        // delete an event
        public void Delete(int id) => repository.DeleteEvent(id);
    }
}