using AutoMapper;
using BookStore.Entities;
using BookStore.Models;

namespace BookStore.Mappers
{
    public class MappingProfile : Profile
    {
        
        public MappingProfile()
        {
            CreateMap<BookEntity, BookViewModel>();
            CreateMap<BookViewModel, BookEntity>();
        }

    }
}
