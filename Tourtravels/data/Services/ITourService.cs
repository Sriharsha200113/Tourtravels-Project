using Tourtravels.data.Base;
using Tourtravels.data.ViewModels;
using Tourtravels.Models;

namespace Tourtravels.data.Services
{
    public interface ITourService : IEntityBaseRepository<Tour>
    {
        Task<Tour> GetTourByIdAsync(int id);
        Task<Tourdropdown>  GetTourdropdownValues();
        Task AddNewTourAsync(NewTourvm data);
        Task UpdateTourAsync(NewTourvm data);


    }
}
