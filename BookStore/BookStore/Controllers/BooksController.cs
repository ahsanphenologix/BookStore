using AutoMapper;
using BookStore.Entities;
using BookStore.Interfaces;
using BookStore.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
    public class BooksController : Controller
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;

        public BooksController(IBookRepository bookRepository, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
        }


        public async Task<IActionResult> Index()
        {
            try
            {
                var booksEntity = await _bookRepository.GetAllBooksAsync();
                var booksList = booksEntity.ToList();
                var booksVM = _mapper.Map<IList<BookViewModel>>(booksEntity);

                return View(booksVM);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }

        public IActionResult Insert() 
        {
            try
            {
                return View();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [HttpPost]
        public async Task<IActionResult> Insert(BookViewModel bookViewModel) 
        {
            try
            {
                var entity = _mapper.Map<BookEntity>(bookViewModel);
                
                var affectedRows = await _bookRepository.CreateBookAsync(entity);

                

                return RedirectToAction("Index", "Books");
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        
        public async Task<IActionResult> Edit(int id) 
        {
            try
            {
                var entity = await _bookRepository.GetBookByIdAsync(id);

                var model = _mapper.Map<BookViewModel>(entity);

                return View(model);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(BookViewModel bookViewModel) 
        {
            try
            {
                var entity = _mapper.Map<BookEntity>(bookViewModel);
                
                var affectedRows = await _bookRepository.UpdateBookAsync(entity);

                return RedirectToAction("Index", "Books");
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var book = await _bookRepository.DeleteBookAsync(id);

                return RedirectToAction("Index", "Books");
            }
            catch (Exception ex)
            {
                throw ex;
            
            }
        }
    }
}
