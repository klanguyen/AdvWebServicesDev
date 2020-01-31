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
    public class HomeController : Controller
    {
        private readonly int PageSize = 10;
        private IEventRepository repository;
        public HomeController(IEventRepository repo)
        {
            repository = repo;
        }

        /*public ViewResult Index(int page = 1) => View(
            repository.Events.Include(e => e.Location)
                .OrderBy(e => e.TimeStamp)
                .Skip((page - 1) * PageSize)
                .Take(PageSize));*/

        public ViewResult Index(int page = 1) => View(new EventListViewModel
        {
            Events = repository.Events
                                .Include(e => e.Location)
                                .OrderByDescending(e => e.TimeStamp)
                                .Skip((page - 1) * PageSize)
                                .Take(PageSize),
            PageInfo = new PageInfoViewModel
            {
                CurrentPageNumber = page,
                EventsPerPage = PageSize,
                TotalEvents = repository.Events.Count()
            }
        });
    }
}