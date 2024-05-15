namespace SellWise.Infrastructure.Contracts
{
    public interface IFinalize
    {
        public bool IsFinalized { get; set; }

        public DateTime? FinalizationDateTime { get; set; }
    }
}
