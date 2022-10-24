using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class FurgonetaLoadPriceUseCaseShould
{
    static Tuple<int, int>[] expectedAndDistances = new Tuple<int, int>[]{
        new Tuple<int,int> (5,0),
        new Tuple<int,int> (7,1),
        new Tuple<int,int> (1605,800)
        };
    // A Test behaves as an ordinary method
    [Test]
    public void ExpectExpenseForDistanceKm([ValueSource("expectedAndDistances")]Tuple<int,int> expectedAndDistance)
    {
        FurgonetaLoadPriceUseCase useCase = new FurgonetaLoadPriceUseCase();
        int expectedPrice = expectedAndDistance.Item1;
        int distance = expectedAndDistance.Item2;
        int calculatedPrice = useCase.CalculatePriceForKm(distance);
        Assert.AreEqual(expectedPrice, calculatedPrice);
    }

}
