using BookStore.Entities;

namespace BookStore.Interfaces
{
    public interface IBookRepository
    {
        Task<IEnumerable<BookEntity>> GetAllBooksAsync();
        Task<BookEntity> GetBookByIdAsync(int id);
        Task<int> CreateBookAsync(BookEntity Product);
        Task<bool> UpdateBookAsync(BookEntity Product);
        Task<bool> DeleteBookAsync(int id);
    }
}
