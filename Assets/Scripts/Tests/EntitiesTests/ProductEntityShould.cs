using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class ProductEntityShould
{
    private ProductEntity product;
    [SetUp]
    public void SetUp()
    {
        product = new ProductEntity(ProductsEnum.VIEIRA,50);
        product.SetPriceForCity(500, CitiesEnum.MADRID);
        product.SetPriceForCity(450, CitiesEnum.BARCELONA);
        product.SetPriceForCity(600, CitiesEnum.LISBOA);
    }
    static Tuple<CitiesEnum, int>[] citiAndPrice = new Tuple<CitiesEnum, int>[]
    {
        new Tuple<CitiesEnum,int>(CitiesEnum.MADRID,500),
        new Tuple<CitiesEnum,int>(CitiesEnum.BARCELONA,450),
        new Tuple<CitiesEnum, int>(CitiesEnum.LISBOA,600)
    };

    [Test]
    public void ReturnExpectedPriceForGivenCity([ValueSource("citiAndPrice")] Tuple<CitiesEnum,int> citiAndPrice)
    {
        //GIVEN
        CitiesEnum searchCity = citiAndPrice.Item1;
        int expectedPrice = citiAndPrice.Item2;
        //WHEN
        int actualPrice = product.GetPriceForCity(searchCity);
        //THEN
        Assert.AreEqual(expectedPrice, actualPrice);
        
    }

}
