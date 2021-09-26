using BookShareOnline.WebAPI.Data.Models;
using BookShareOnline.WebAPI.Data.Models.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BookShareOnline.Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private ICartRepository _repository;
        public CartController(ICartRepository repository)
        {
            _repository = repository;
        }
        // GET: api/<CartController>
        [HttpGet]
        public IEnumerable<CartEntry> Get()
        {
            return _repository.Get();
        }

        // GET: api/<CartController>/<userName>
        [HttpGet("{userName}")]
        public IEnumerable<CartEntry> Get(string userName)
        {
            return _repository.Get(userName);
        }

        // GET api/<CartController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST api/<CartController>
        [HttpPost("{userName}/{bookid:int}")]
        public int Post(string userName, int bookid, [FromBody] int quantity)
        {
            CartEntry cartEntry = new CartEntry
            {
                Quantity = quantity,
                Buyer = userName,
            };
            return _repository.Add(cartEntry,bookid);
        }

        // PUT api/<CartController>/5
        [HttpPut("{id:int}")]
        public int Put(int id, [FromBody] CartEntry cartEntry)
        {
            return _repository.Edit(id, cartEntry);
        }

        // PUT api/<CartController>/<userName>/5
        [HttpPut("{userName}/{id:int}")]
        public int Put(int id, string userName, [FromBody] CartEntry cartEntry)
        {
            return _repository.Edit(id, userName, cartEntry);
        }

        // DELETE api/<CartController>/5
        [HttpDelete("{id:int}")]
        public int Delete(int id)
        {
            return _repository.Delete(id);
        }

        // DELETE api/<CartController>/<userName>/5
        [HttpDelete("{userName}/{id:int}")]
        public int Delete(int id, string userName)
        {
            return _repository.Delete(id, userName);
        }
    }
}
