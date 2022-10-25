using System;
using System.Collections;
using System.Collections.Generic;
using NSubstitute;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class EarningsForGivenProductAndCityUseCaseShould
{

    static private Tuple<CitiesEnum, decimal>[] values = new Tuple<CitiesEnum, decimal>[]{
        new Tuple< CitiesEnum, decimal>(CitiesEnum.MADRID, 21395m),
         new Tuple< CitiesEnum, decimal>(CitiesEnum.BARCELONA,17820m),
         new Tuple< CitiesEnum, decimal>(CitiesEnum.LISBOA,26995m),
    };
    [Test]
    public void CheckFinalEarningsForVieira([ValueSource("values")] Tuple<CitiesEnum, decimal> cityAndPrice)
    {
        //GIVEN dado circunstancias
        var productRepository = Substitute.For<IProductRepository>();
        var cityRepository = Substitute.For<ICityRepository>();
        var productVieira = new ProductEntity(ProductsEnum.VIEIRA, 50);
        productVieira.SetPriceForCity(500, CitiesEnum.MADRID);
        productVieira.SetPriceForCity(450, CitiesEnum.BARCELONA);
        productVieira.SetPriceForCity(600, CitiesEnum.LISBOA);
        productRepository.Get(ProductsEnum.VIEIRA).Returns(productVieira);
        var cityMadrid = new CityEntity(CitiesEnum.MADRID, 800);
        cityRepository.Get(CitiesEnum.MADRID).Returns(cityMadrid);
        var cityBarcelona = new CityEntity(CitiesEnum.BARCELONA, 1100);
        cityRepository.Get(CitiesEnum.BARCELONA).Returns(cityBarcelona);
        var cityLisboa = new CityEntity(CitiesEnum.LISBOA, 600);
        cityRepository.Get(CitiesEnum.LISBOA).Returns(cityLisboa);

        EarningsForGivenProductAndCityUseCase useCase = new EarningsForGivenProductAndCityUseCase(productRepository, cityRepository, new DepretiationUseCase(), new FurgonetaLoadPriceUseCase());

        CitiesEnum citiesEnum = cityAndPrice.Item1;
        decimal expectedFinalPrice = cityAndPrice.Item2;
        //WHEN cuando pasan x cosas
        decimal finalPrice = useCase.CalculateFinalPriceForProductInCity(productVieira, citiesEnum);
        //THEN el resultado deberiá
        Assert.AreEqual(expectedFinalPrice, finalPrice);

    }



}
