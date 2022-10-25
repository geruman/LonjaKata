using System;

public class EarningsForGivenProductAndCityUseCase
{
    private DepretiationUseCase _depretiationUseCase;
    private FurgonetaLoadPriceUseCase _furgonetaLoadPriceUseCase;
    public EarningsForGivenProductAndCityUseCase(DepretiationUseCase depretiationUseCase, FurgonetaLoadPriceUseCase furgonetaLoadPriceUseCase)
    {
        _depretiationUseCase=depretiationUseCase;
        _furgonetaLoadPriceUseCase=furgonetaLoadPriceUseCase;
    }
    public decimal CalculateFinalPriceForProductInCity(ProductEntity productEntity, CityEntity city)
    {
        
        decimal productKg = productEntity.Kilograms;
        decimal productPrice = productEntity.GetPriceForCity(city.EnumId);
        int cityDistance = city.Distance;
        decimal depretiation = _depretiationUseCase.DepretiationPercentageForKm(cityDistance);
        decimal furgonetaPrice = _furgonetaLoadPriceUseCase.CalculatePriceForKm(cityDistance);
        return productKg*(productPrice-productPrice*depretiation)-furgonetaPrice;
    }
}