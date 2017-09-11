using System.Collections.Generic;
using System.Threading.Tasks;
using CA.Business.DTOs;

namespace CA.Business.Services
{
    public interface ICarAdvertService
    {
        Task<int> Add(CarAdvertDto obj);
        Task Delete(int id);
        Task<List<CarAdvertDto>> GetAll(string sortBy = null);
        Task<CarAdvertDto> GetById(int id);
        Task Update(CarAdvertDto obj);
    }
}