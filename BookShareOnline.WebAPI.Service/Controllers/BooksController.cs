using BookShareOnline.WebAPI.Data.Models;
using BookShareOnline.WebAPI.Data.Models.Repository;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BookShareOnline.Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private IBookRepository _repository;
        private readonly IWebHostEnvironment _env;

       
        public BooksController(IBookRepository repository, IWebHostEnvironment env)
        {
            this._repository = repository;
            _env = env;
        }

        // GET: api/<BooksController>
        [HttpGet("home")]
        public IEnumerable<Book> Get()
        {
            return _repository.Get();
        }

        // GET api/<BooksController>/5
        [HttpGet("{id}")]
        public Book Get(string bookName)
        {
            return _repository.Get(bookName);
        }

        // POST api/<BooksController>
        [HttpPost]
        public int Post([FromBody] Book book)
        {
            return _repository.Add(book);
        }

        // PUT api/<BooksController>/5
        [HttpPut("{id}")]
        public int Put(int id, [FromBody] Book book)
        {
            return _repository.Edit(id, book);
        }

        // DELETE api/<BooksController>/5
        [HttpDelete("{id}")]
        public int Delete(int id)
        {
            return _repository.Delete(id);
        }

        [Route("SaveFile")]
        [HttpPost]
        public JsonResult SaveFile()
        {
            try
            {
                var httpRequest = Request.Form;
                var postedFile = httpRequest.Files[0];
                string filename = postedFile.FileName;
                var physicalPath = _env.ContentRootPath + "/Photos/" + filename;

                using (var stream = new FileStream(physicalPath, FileMode.Create))
                {
                    postedFile.CopyTo(stream);
                }

                return new JsonResult(filename);
            }
            catch (Exception)
            {

                return new JsonResult("anonymous.png");
            }
        }
    }
}
