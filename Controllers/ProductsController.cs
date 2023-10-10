using API1.Models;
using API1.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly iBookRepository _bookRepo;

        public ProductsController(iBookRepository repo) 
        {
            _bookRepo = repo;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllBooks()
        {
            try
            {
                return Ok(await _bookRepo.getAllBooksAsync());
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBookById(int id)
        {
            var book = await _bookRepo.getBooksAsync(id);
            return book == null ? NotFound() : Ok(book);
        }
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> AddNewBook(BookModels models)
        {
            try
            {
                var newBookId = await _bookRepo.AddBookAsync(models);
                var book = await _bookRepo.getBooksAsync(newBookId);
                return book == null? NotFound() : Ok(book);
            }catch 
            {
                return BadRequest();
            }
        }
        [HttpPut("{id}")]
        [Authorize ]
        public async Task<IActionResult> UpdateBook(int id, [FromBody]BookModels models)
        {
            if(id != models.Id)
            {
                return NotFound();
            }
            await _bookRepo.UpdateBookAsync(id, models);
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook([FromRoute]int id)
        {
            await _bookRepo.deleteBookAsync(id);
            return Ok();
        }
    }
}
