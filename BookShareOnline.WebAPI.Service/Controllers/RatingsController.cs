using BookShareOnline.WebAPI.Data.Models;
using BookShareOnline.WebAPI.Data.Models.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BookShareOnline.WebAPI.Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RatingsController : ControllerBase
    {
        private IRatingRepository _repository;
        public RatingsController(IRatingRepository repository)
        {
            this._repository = repository;
        }
        // GET: api/<RatingsController>
        [HttpGet]
        public IEnumerable<Rating> Get()
        {
            return _repository.Get();
        }

        // POST api/<RatingsController>
        [HttpPost("{username}/{bookid:int}")]
        public void Post(string username, int bookid, [FromBody] int score)
        {
            _repository.AddRating(username, bookid, score);
        }


        // DELETE api/<RatingsController>/5
        [HttpDelete("{id}")]
        public int Delete(int id)
        {
            return _repository.Delete(id);
        }
    }
}
