using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DepretiationUseCase: IDepretiationUseCase
{
    readonly decimal DEPRETIATION_PER_KM = 0.01m;
    public decimal DepretiationPercentageForKm(int kilometers)
    {
        int per100Km = kilometers / 100;
        return per100Km*DEPRETIATION_PER_KM;
    }

    public decimal CalculateDepretiatedPriceForPriceWithDistanceKm(decimal productPrice, int distance)
    {
        return productPrice - (productPrice*DepretiationPercentageForKm(distance));
    }
}
