using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Joke_App.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Joke_App.Models;
// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Joke_App.Controllers
{
    public class JokeController : Controller
    {
        private readonly ApplicationDbContext _dbConext;
        public JokeController(ApplicationDbContext dbContext)
        {
            _dbConext = dbContext;
        }
        // GET: /<controller>/
        public async Task<ActionResult<List<Joke>>>  Index()
        {
            var Jokes = _dbConext.Jokes.ToList();

            return View(Jokes);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]

        public IActionResult addJoke(Joke newJoke)
        {
            _dbConext.Jokes.Add(newJoke);
            _dbConext.SaveChanges();

            return View();
        }
    }
}

