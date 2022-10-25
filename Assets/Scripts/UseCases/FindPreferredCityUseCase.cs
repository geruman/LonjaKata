using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindPreferredCityUseCase
{
    private EarningsForGivenProductAndCityUseCase _earningsForGivenProductAndCityUseCase;

    public FindPreferredCityUseCase(EarningsForGivenProductAndCityUseCase earningsForGivenProductAndCityUseCase)
    {
        _earningsForGivenProductAndCityUseCase = earningsForGivenProductAndCityUseCase;
    }

    public CitiesEnum CalculatePreferredCityFor(ProductEntity producto)
    {

        var madridPrice = _earningsForGivenProductAndCityUseCase.CalculateFinalPriceForProductInCity(producto, CitiesEnum.MADRID);
        var barcelonaPrice = _earningsForGivenProductAndCityUseCase.CalculateFinalPriceForProductInCity(producto, CitiesEnum.BARCELONA);
        var lisboaPrice = _earningsForGivenProductAndCityUseCase.CalculateFinalPriceForProductInCity(producto, CitiesEnum.LISBOA);
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
