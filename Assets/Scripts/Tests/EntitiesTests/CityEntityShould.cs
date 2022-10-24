using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class CityEntityShould
{
    //GIVEN
    private static Tuple<CityEntity, int>[] citiesAndDistance = new Tuple<CityEntity, int>[]
    {
        new Tuple<CityEntity, int>(new CityEntity(CitiesEnum.MADRID,800),800),
        new Tuple<CityEntity, int>(new CityEntity(CitiesEnum.BARCELONA,1100),1100),
        new Tuple<CityEntity, int>(new CityEntity(CitiesEnum.LISBOA,600),600),
    };
    [Test]
    public void HaveExpectedDestination([ValueSource("citiesAndDistance")] Tuple<CityEntity,int> cityAndExpectedDistance)
    {
        //WHEN
        CityEntity city = cityAndExpectedDistance.Item1;
        int expectedDistance = cityAndExpectedDistance.Item2;
        //THEN
        Assert.AreEqual(expectedDistance, city.Distance);
    }

}
