namespace SellWise.Core.Contracts
{
    public interface IShiftService
    {
        public Task StartShift(string userId);
    }
}
