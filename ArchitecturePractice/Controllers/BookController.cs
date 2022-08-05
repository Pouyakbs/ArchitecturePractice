using ArchitecturePractice.Areas.Admin.Models;
using ArchitecturePractice.Core.Contracts.Facade;
using ArchitecturePractice.Core.Domain.DTOs;
using ArchitecturePractice.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArchitecturePractice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookFacade bookFacade;
        public BookController(IBookFacade bookFacade)
        {
            this.bookFacade = bookFacade;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            ResponseViewModel<IEnumerable<BookDTO>> model = new ResponseViewModel<IEnumerable<BookDTO>>();
            try
            {
                model.Data = bookFacade.GetAll().ToList();
            }
            catch (Exception ex)
            {

                model.AddError(ex.Message);
                return BadRequest(model);
            }
            return Ok(model);
        }
        [HttpGet]
        [Route("Get/{id}")]
        public IActionResult Get(int id)
        {
            ResponseViewModel<BookDTO> model = new ResponseViewModel<BookDTO>();
            try
            {
                model.Data = bookFacade.GetById(id);
            }
            catch (InvalidOperationException ex)
            {
                model.AddError("کتاب وجود ندارد");
                return NotFound(model);
            }
            return Ok(model);
        }
        [HttpPost]
        public IActionResult PostBook(BookDTO book)
        {
            ResponseViewModel<int> model = new ResponseViewModel<int>();
            try
            {
                model.Data = bookFacade.Add(book);
            }
            catch (Exception ex)
            {

                model.AddError(ex.Message);
                return BadRequest(model);
            }

            return Created($"/api/book/{model.Data}", model);
        }
        [HttpPut]
        [Route("Edit/{book}")]
        public IActionResult EditBook(BookDTO book)
        {
            if (book.BookID == 0)
            {
                return BadRequest("ID Not Found");
            }
            bookFacade.Update(book);
            return Ok(book);
        }
        [HttpDelete]
        [Route("Delete/{id}")]
        public IActionResult Delete(int id)
        {
            var book = bookFacade.GetById(id);
            bookFacade.Remove(book);
            return Ok($"/api/book/Delete/{book}");
        }
    }
}