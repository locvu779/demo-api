using API1.Data;
using API1.Models;

namespace API1.Repositories
{
    public interface iBookRepository
    {
        public Task<List<BookModels>> getAllBooksAsync();
        public Task<BookModels> getBooksAsync(int id);
        public Task<int> AddBookAsync(BookModels model);
        public Task UpdateBookAsync(int id, BookModels models);
        public Task deleteBookAsync(int id);
    }
}
