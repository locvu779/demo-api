using API1.Data;
using API1.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace API1.Repositories
{
    public class BookReposity : iBookRepository
    {
        private readonly BookStoreContext _context;
        private readonly IMapper _mapper;

        public BookReposity(BookStoreContext context,IMapper mapper) 
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<int> AddBookAsync(BookModels model)
        {
            var newBook = _mapper.Map<Book>(model);
            _context.Books!.Add(newBook);
            await _context.SaveChangesAsync();
            return newBook.Id;
        }

        public async Task deleteBookAsync(int id)
        {
            var deleteBook  = _context.Books!.SingleOrDefault(b =>b.Id == id);
            if(deleteBook != null)
            {
                _context.Books!.Remove(deleteBook);
                await _context.SaveChangesAsync() ;
            }

        }

        public async Task<List<BookModels>> getAllBooksAsync()
        {
            var books = await _context.Books!.ToListAsync();
            return _mapper.Map<List<BookModels>>(books);
        }

        public async Task<BookModels> getBooksAsync(int id)
        {
            
            var book = await _context.Books!.FindAsync(id);
            return _mapper.Map<BookModels>(book);
        }

        public async Task UpdateBookAsync(int id, BookModels models)
        {
            if(id == models.Id)
            {
                var updatebook = _mapper.Map<Book>(models);
               _context.Books!.Update(updatebook);
                await _context.SaveChangesAsync();
            }

        }
    }
}
