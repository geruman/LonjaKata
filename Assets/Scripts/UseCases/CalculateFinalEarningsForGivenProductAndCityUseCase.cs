using System;

public class EarningsForGivenProductAndCityUseCase
{
    private IProductRepository _productRepository;
    private ICityRepository _cityRepository;
    private DepretiationUseCase _depretiationUseCase;
    private FurgonetaLoadPriceUseCase _furgonetaLoadPriceUseCase;
    public EarningsForGivenProductAndCityUseCase(IProductRepository productRepository,ICityRepository cityRepository, DepretiationUseCase depretiationUseCase, FurgonetaLoadPriceUseCase furgonetaLoadPriceUseCase)
    {
        _productRepository = productRepository;
        _cityRepository = cityRepository;
        _depretiationUseCase=depretiationUseCase;
        _furgonetaLoadPriceUseCase=furgonetaLoadPriceUseCase;
    }
    public decimal CalculateFinalPriceForProductInCity(ProductsEnum productEnum, CitiesEnum cityEnum)
    {
        var product = _productRepository.GetProduct(productEnum);
        decimal productKg = product.Kilograms;
        decimal productPrice = product.GetPriceForCity(cityEnum);
        int cityDistance = _cityRepository.Get(cityEnum).Distance;
        decimal depretiation = _depretiationUseCase.DepretiationPercentageForKm(cityDistance);
        decimal furgonetaPrice = _furgonetaLoadPriceUseCase.CalculatePriceForKm(cityDistance);
        return productKg*(productPrice-productPrice*depretiation)-furgonetaPrice;
    }
}