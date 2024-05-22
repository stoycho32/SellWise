namespace SellWise.Core.Contracts
{
    public interface IShiftService
    {
        public Task StartShift();

        public Task ContinueShift();
    }
}
