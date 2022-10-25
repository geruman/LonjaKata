using System.Collections;
using System.Collections.Generic;
using NSubstitute;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class FindPreferredCityUseCaseShould
{
    private FindPreferredCityUseCase _studyUseCase;
   

    [SetUp]
    public void SetUp()
    {
        //GIVEN
        
        var cityRepository = Substitute.For<ICityRepository>();
        
        var cityMadrid = new CityEntity(CitiesEnum.MADRID, 800);
        cityRepository.Get(CitiesEnum.MADRID).Returns(cityMadrid);
        var cityBarcelona = new CityEntity(CitiesEnum.BARCELONA, 1100);
        cityRepository.Get(CitiesEnum.BARCELONA).Returns(cityBarcelona);
        var cityLisboa = new CityEntity(CitiesEnum.LISBOA, 600);
        cityRepository.Get(CitiesEnum.LISBOA).Returns(cityLisboa);
        DepretiationUseCase depretiationUseCase = new DepretiationUseCase();
        FurgonetaLoadPriceUseCase furgonetaLoadPriceUseCase = new FurgonetaLoadPriceUseCase();
        EarningsForGivenProductAndCityUseCase earningsForGivenProductAndCityUseCase = new EarningsForGivenProductAndCityUseCase(cityRepository, depretiationUseCase, furgonetaLoadPriceUseCase);
        _studyUseCase = new FindPreferredCityUseCase(earningsForGivenProductAndCityUseCase);
    }
    [Test]
    public void RespondMadridForVieiras()
    {
        //GIVEN
        var productVieira = new ProductEntity(ProductsEnum.VIEIRA, 50);
        productVieira.SetPriceForCity(500, CitiesEnum.MADRID);
        productVieira.SetPriceForCity(450, CitiesEnum.BARCELONA);
        productVieira.SetPriceForCity(600, CitiesEnum.LISBOA);
        //WHEN
        var preferredCity = _studyUseCase.CalculatePreferredCityFor(productVieira);
        //THEN
        Assert.AreEqual(CitiesEnum.LISBOA, preferredCity);
    }
    [Test]
    public void RespondBarcelonaForPulpo()
    {
        //GIVEN
        var productPulpo = new ProductEntity(ProductsEnum.PULPO, 100);
        productPulpo.SetPriceForCity(0, CitiesEnum.MADRID);
        productPulpo.SetPriceForCity(120, CitiesEnum.BARCELONA);
        productPulpo.SetPriceForCity(100, CitiesEnum.LISBOA);
        //WHEN
        var preferredCity = _studyUseCase.CalculatePreferredCityFor(productPulpo);
        //THEN
        Assert.AreEqual(CitiesEnum.BARCELONA, preferredCity);
    }
    [Test]
    public void RespondLisboaForCentolla()
    {
        //GIVEN
        var productCentolla = new ProductEntity(ProductsEnum.PULPO, 50);
        productCentolla.SetPriceForCity(450, CitiesEnum.MADRID);
        productCentolla.SetPriceForCity(0, CitiesEnum.BARCELONA);
        productCentolla.SetPriceForCity(500, CitiesEnum.LISBOA);
        //WHEN
        var preferredCity = _studyUseCase.CalculatePreferredCityFor(productCentolla);
        //THEN
        Assert.AreEqual(CitiesEnum.LISBOA, preferredCity);
    }

}
