using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindPreferredCityUseCase
{
    IDepretiationUseCase _depretiationUseCase;
    IFurgonetaLoadPriceUseCase _furgonetaUseCase;
    public FindPreferredCityUseCase(IDepretiationUseCase depretiationUseCase, IFurgonetaLoadPriceUseCase furgonetaUseCase)
    {
        _depretiationUseCase = depretiationUseCase;
        _furgonetaUseCase = furgonetaUseCase;
    }

    public CitiesEnum CalculatePreferredCityFor(ProductsEnum producto)
    {

        return CitiesEnum.MADRID;

    }
}
