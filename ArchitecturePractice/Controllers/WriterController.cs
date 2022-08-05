using ArchitecturePractice.Core.Contracts.Facade;
using ArchitecturePractice.Core.Domain.DTOs;
using ArchitecturePractice.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ArchitecturePractice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WriterController : ControllerBase
    {
        private readonly IWriterFacade writerFacade;
        public WriterController(IWriterFacade writerFacade)
        {
            this.writerFacade = writerFacade;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            ResponseViewModel<IEnumerable<WriterDTO>> model = new ResponseViewModel<IEnumerable<WriterDTO>>();
            try
            {
                model.Data = writerFacade.GetAll().ToList();
            }
            catch (Exception ex)
            {

                model.AddError(ex.Message);
                return BadRequest(model);
            }
            return Ok(model);
        }
        [HttpGet]
        [Route("{id}")]
        public IActionResult Get(int id)
        {
            ResponseViewModel<WriterDTO> model = new ResponseViewModel<WriterDTO>();
            try
            {
                model.Data = writerFacade.GetById(id);
            }
            catch (InvalidOperationException ex)
            {

                model.AddError("نویسنده ی مورد نظر وجود ندارد");
                return NotFound(model);
            }
            return Ok(model);
        }
        [HttpPost]
        public IActionResult PostWriter(WriterDTO writer)
        {
            ResponseViewModel<int> model = new ResponseViewModel<int>();
            try
            {
                model.Data = writerFacade.Add(writer);
            }
            catch (Exception ex)
            {

                model.AddError(ex.Message);
                return BadRequest(model);
            }
            return Created($"/api/Writer/{model.Data}", model);
        }
        [HttpPut]
        [Route("Edit/{Writer}")]
        public IActionResult EditWriter(WriterDTO writer)
        {
            if (writer.WriterID == 0)
            {
                return BadRequest("ID Not Found");
            }
            writerFacade.Update(writer);
            return Ok(writer);
        }
        [HttpDelete]
        [Route("Delete/{id}")]
        public IActionResult Delete(int id)
        {
            var writer = writerFacade.GetById(id);
            writerFacade.Remove(writer);
            return Ok($"/api/Writer/Delete/{writer}");
        }
    }
}