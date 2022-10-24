using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class DepretiationUseCaseShould
{
    private DepretiationUseCase useCase;
    [SetUp]
    public void SetUp()
    {
        useCase = new DepretiationUseCase();
    }
    static Tuple<decimal, int>[] percentagesPerKm = new Tuple<decimal, int>[] {
        new Tuple<decimal,int>( 0.08m,800),
        new Tuple<decimal,int>( 0.11m,1100),
        new Tuple<decimal,int>( 0.06m, 600),
        new Tuple<decimal, int>(0m,99)
};

    [Test]
    public void ReturnPercentageforKm([ValueSource("percentagesPerKm")] Tuple<decimal, int> percentagePerKm)
    {
        //GIVEN
        decimal expectedDepretiation = percentagePerKm.Item1;
        int kilometers = percentagePerKm.Item2;
        //WHEN
        decimal depretiationPercentage = useCase.DepretiationPercentageForKm(kilometers);
        //useCase.CalculateDepretiationPercentageForKm(kilometers);
        //THEN
        Assert.AreEqual(expectedDepretiation, depretiationPercentage);
    }
    static Tuple<decimal, int, decimal>[] stockPriceDistanceInKmAndExpectedValue = new Tuple<decimal, int, decimal>[]
    {
        new Tuple<decimal, int, decimal>(500,800,460),
        new Tuple<decimal, int, decimal>(500,99,500),
        new Tuple<decimal, int, decimal>(500,0,500),
        new Tuple<decimal, int, decimal>(500,50,500),
        new Tuple<decimal, int, decimal>(500,25,500)

    };
    [Test]
    public void ReturnDepretiationPriceForKm([ValueSource("stockPriceDistanceInKmAndExpectedValue")] Tuple<decimal, int, decimal> stockPriceDistanceKmAndExpectedValue)

    {
        //GIVEN
        decimal productPrice = stockPriceDistanceKmAndExpectedValue.Item1;
        int distance = stockPriceDistanceKmAndExpectedValue.Item2;
        decimal expectedDepretiation = stockPriceDistanceKmAndExpectedValue.Item3;
        //WHEN
        decimal depretiatedPrice = useCase.CalculateDepretiatedPriceForPriceWithDistanceKm(productPrice, distance);
        //THEN
        Assert.AreEqual(expectedDepretiation, depretiatedPrice);
    }

}
