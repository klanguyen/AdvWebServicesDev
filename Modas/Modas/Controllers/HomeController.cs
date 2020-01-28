using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Modas.Models;

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

        public ViewResult Index(int page = 1) => View(
            repository.Events.Include(e => e.Location)
                .OrderBy(e => e.TimeStamp)
                .Skip((page - 1) * PageSize)
                .Take(PageSize));
    }
}