using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindPreferredCityUseCase: IFindPreferredCityUseCase
{
    private EarningsForGivenProductAndCityUseCase _earningsForGivenProductAndCityUseCase;
    private ICityRepository _cityRepository;
    private IProductRepository _productRepository;
    

    public FindPreferredCityUseCase(EarningsForGivenProductAndCityUseCase earningsForGivenProductAndCityUseCase, ICityRepository cityRepository, IProductRepository productRepository)
    {
        _earningsForGivenProductAndCityUseCase = earningsForGivenProductAndCityUseCase;
        _cityRepository = cityRepository;
        _productRepository=productRepository;
    }

    public CitiesEnum CalculatePreferredCityFor(ProductsEnum productoEnum)
    {

        var cityMadrid = _cityRepository.Get(CitiesEnum.MADRID);
        var cityBarcelona = _cityRepository.Get(CitiesEnum.BARCELONA);
        var cityLisboa = _cityRepository.Get(CitiesEnum.LISBOA);
        var producto = _productRepository.Get(productoEnum);
        var madridPrice = _earningsForGivenProductAndCityUseCase.CalculateFinalPriceForProductInCity(producto, cityMadrid);
        var barcelonaPrice = _earningsForGivenProductAndCityUseCase.CalculateFinalPriceForProductInCity(producto, cityBarcelona);
        var lisboaPrice = _earningsForGivenProductAndCityUseCase.CalculateFinalPriceForProductInCity(producto, cityLisboa);
        if (madridPrice>=barcelonaPrice&&madridPrice>=lisboaPrice)
        {
            return CitiesEnum.MADRID;
        }
        if (barcelonaPrice>=madridPrice&&barcelonaPrice>=lisboaPrice)
        {
            return CitiesEnum.BARCELONA;
        }
        return CitiesEnum.LISBOA;


    }
}
