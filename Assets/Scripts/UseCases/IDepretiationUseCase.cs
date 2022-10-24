public interface IDepretiationUseCase
{
    public decimal DepretiationPercentageForKm(int kilometers);

    public decimal CalculateDepretiatedPriceForPriceWithDistanceKm(decimal productPrice, int distance);
}