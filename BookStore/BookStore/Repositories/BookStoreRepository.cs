using AutoMapper;
using BookStore.Entities;
using BookStore.Interfaces;
using Dapper;
using Microsoft.AspNetCore.Components.Forms;
using System.Data;
using System.Net;

namespace BookStore.Repositories
{
    public class BookStoreRepository : IBookRepository
    {
        private readonly IDapperDbConnection _dapperDbConnection;
        //private readonly IMapper _mapper;

        public BookStoreRepository(IMapper mapper, IDapperDbConnection dapperDbConnection) 
        {
            _dapperDbConnection = dapperDbConnection;
            //_mapper = mapper;
        }

        public async Task<int> CreateBookAsync(BookEntity book)
        {
            using (IDbConnection db = _dapperDbConnection.CreateConnection())
            {
                const string query = "INSERT INTO BooksTbl (Title, Description, AuthorName, Publish, Category, Edition)" +
                    "VALUES (@Title, @Description, @AuthorName, @Publish, @Category, @Edition);";

                return await db.ExecuteScalarAsync<int>(query, book);
            }
        }

        public async Task<bool> DeleteBookAsync(int id)
        {
            using (IDbConnection db = _dapperDbConnection.CreateConnection())
            {
                const string query = "DELETE FROM BooksTbl WHERE Id = @Id";
                int rowsAffected = await db.ExecuteAsync(query, new { Id = id });
                return rowsAffected > 0;
            }
        }


        public async Task<IEnumerable<BookEntity>> GetAllBooksAsync()
        {
            using (IDbConnection db = _dapperDbConnection.CreateConnection())
            {
                return await db.QueryAsync<BookEntity>("SELECT * FROM BooksTbl");
            }
        }

        public async Task<BookEntity> GetBookByIdAsync(int id)
        {
            using (IDbConnection db = _dapperDbConnection.CreateConnection())
            {
                return await db.QueryFirstOrDefaultAsync<BookEntity>("SELECT * FROM BooksTbl");
            }
        }

        public async Task<bool> UpdateBookAsync(BookEntity book)
        {
            using (IDbConnection db = _dapperDbConnection.CreateConnection())
            {
                string sqlQuery = @"
            UPDATE BooksTbl
            SET 
                Title = @Title,
                Description = @Description,
                AuthorName = @AuthorName,
                Publish = @Publish,
                Category = @Category,
                Edition = @Edition
            WHERE Id = @Id;
        ";

                // Define the parameters
                var parameters = new
                {
                    Id = book.Id,
                    Title = book.Title,
                    Description = book.Description,
                    AuthorName = book.AuthorName,
                    Publish = book.Publish,
                    Category = book.Category,
                    Edition = book.Edition
                };
                int rowsAffected = await db.ExecuteAsync(sqlQuery, parameters);
                return rowsAffected > 0;
            }
        }
    }
}
