namespace SellWise.Infrastructure.Contracts
{
    public interface IFinalized
    {
        public bool IsFinalized { get; set; }

        public DateTime? FinalizationDateTime { get; set; }
    }
}
