using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FurgonetaLoadPriceUseCase :IFurgonetaLoadPriceUseCase
{
    readonly int FIXED_PRICE = 5;
    readonly int VARIABLE_PRICE = 2;
    public int CalculatePriceForKm(int distance)
    {
        return FIXED_PRICE+(VARIABLE_PRICE*distance);
    }
}
