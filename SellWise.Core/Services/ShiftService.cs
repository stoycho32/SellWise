using SellWise.Core.Contracts;
using SellWise.Infrastructure.Repository;

namespace SellWise.Core.Services
{
    public class ShiftService : IShiftService
    {
        private readonly IRepository repository;

        public ShiftService()
        {
            
        }
        public ShiftService(IRepository repository) 
        {
            this.repository = repository;
        }

        public Task StartShift(string userId)
        {

        }

        public Task ContinueShift(string userId)
        {

        }
    }
}
