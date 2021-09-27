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
    public class OrdersController : ControllerBase
    {
        private IOrderRepository _repository;
        public OrdersController(IOrderRepository repository)
        {
            _repository = repository;
        }
        // GET: api/<CartController>
        [HttpGet]
        public IEnumerable<Order> Get()
        {
            return _repository.Get();
        }

        // GET: api/<CartController>/<userName>
        [HttpGet("{userName}")]
        public IEnumerable<Order> Get(string userName)
        {
            return _repository.Get(userName);
        }

        [HttpPost("{userName}/{bookid:int}/{status}")]
        public int Post(string userName, int bookid,string status ,[FromBody] int quantity)
        {
            Order order = new Order
            {
                Quantity = quantity,
                Buyer = userName,
                Status = status
            };
            return _repository.AddNew(order, bookid);
        }
        // GET api/<CartController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST api/<CartController>
        [HttpPost]
        public int Post([FromBody] Order order)
        {
            return _repository.Add(order);
        }

        // PUT api/<CartController>/5
        [HttpPut("{id:int}")]
        public int Put(int id, [FromBody] Order order)
        {
            return _repository.Edit(id, order);
        }

        // PUT api/<CartController>/<userName>/5
        [HttpPut("{userName}/{id:int}")]
        public int Put(int id, string userName, [FromBody] Order order)
        {
            return _repository.Edit(id, userName, order);
        }

        [HttpPut("Cancel/{userName}")]
        public int Put(string userName, [FromBody]  int id)
        {
            return _repository.Edit(id, userName);
        }

        // DELETE api/<CartController>/5
        [HttpDelete("{id:int}")]
        public int Delete(int id)
        {
            return _repository.Delete(id);
        }

        // DELETE api/<CartController>/5
        [HttpDelete("{userName}/{id:int}")]
        public int Delete(int id, string userName)
        {
            return _repository.Delete(id, userName);
        }
    }
}
