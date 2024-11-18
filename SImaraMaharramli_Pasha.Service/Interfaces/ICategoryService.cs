using SImaraMaharramli_Pasha.Domain.Entity;
using SImaraMaharramli_Pasha.Service.DTOS.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SImaraMaharramli_Pasha.Service.Interfaces
{
    public interface ICategoryService
    {
        Task<List<GetAllCategory>> GetAll();
        Task<Category> GetDetail( int Id);
    }
}
