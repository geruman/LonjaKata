using System;

public class EarningsForGivenProductAndCityUseCase
{
    private ICityRepository _cityRepository;
    private DepretiationUseCase _depretiationUseCase;
    private FurgonetaLoadPriceUseCase _furgonetaLoadPriceUseCase;
    public EarningsForGivenProductAndCityUseCase(ICityRepository cityRepository, DepretiationUseCase depretiationUseCase, FurgonetaLoadPriceUseCase furgonetaLoadPriceUseCase)
    {
        _cityRepository = cityRepository;
        _depretiationUseCase=depretiationUseCase;
        _furgonetaLoadPriceUseCase=furgonetaLoadPriceUseCase;
    }
    public decimal CalculateFinalPriceForProductInCity(ProductEntity productEntity, CitiesEnum cityEnum)
    {
        
        decimal productKg = productEntity.Kilograms;
        decimal productPrice = productEntity.GetPriceForCity(cityEnum);
        int cityDistance = _cityRepository.Get(cityEnum).Distance;
        decimal depretiation = _depretiationUseCase.DepretiationPercentageForKm(cityDistance);
        decimal furgonetaPrice = _furgonetaLoadPriceUseCase.CalculatePriceForKm(cityDistance);
        return productKg*(productPrice-productPrice*depretiation)-furgonetaPrice;
    }
}