using Microsoft.EntityFrameworkCore;
using SImaraMaharramli_Pasha.Domain;
using SImaraMaharramli_Pasha.Domain.Entity;
using SImaraMaharramli_Pasha.Service.DTOS.Category;
using SImaraMaharramli_Pasha.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SImaraMaharramli_Pasha.Service.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly AppDbContext _context;
        //private readonly IMapper _mapper;

        public CategoryService(AppDbContext context /*IMapper mapper*/)
        {
            _context = context;
            //_mapper = mapper;
        }

        public async Task<List<GetAllCategory>> GetAll()
        {
            var ctgs = await _context.Categories.Select(x => new GetAllCategory()
            {
                Id = x.Id,
                Name = x.Name
            }).ToListAsync();
            return ctgs;
        }

        public async Task<Category> GetDetail( int Id)
        {
            var category = await _context.Categories.Select(x => new Category()
            {
                Id = x.Id,
                Name = x.Name,
               

            }).FirstOrDefaultAsync();
            return category;
        }
    }
}
