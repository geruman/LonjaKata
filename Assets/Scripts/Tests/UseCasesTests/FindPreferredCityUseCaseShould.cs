using System.Collections;
using System.Collections.Generic;
using NSubstitute;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class FindPreferredCityUseCaseShould
{
    private FindPreferredCityUseCase _findPreferredCityUseCase;
   

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
        var productRepository = Substitute.For<IProductRepository>();
        var vieiraProduct = new ProductEntity(ProductsEnum.VIEIRA, 50);
        vieiraProduct.SetPriceForCity(500, CitiesEnum.MADRID);
        vieiraProduct.SetPriceForCity(450, CitiesEnum.BARCELONA);
        vieiraProduct.SetPriceForCity(600, CitiesEnum.LISBOA);
        var pulpoProduct = new ProductEntity(ProductsEnum.PULPO, 100);
        pulpoProduct.SetPriceForCity(0, CitiesEnum.MADRID);
        pulpoProduct.SetPriceForCity(120, CitiesEnum.BARCELONA);
        pulpoProduct.SetPriceForCity(100, CitiesEnum.LISBOA);
        var centolloProduct = new ProductEntity(ProductsEnum.CENTOLLO, 50);
        centolloProduct.SetPriceForCity(450, CitiesEnum.MADRID);
        centolloProduct.SetPriceForCity(0, CitiesEnum.BARCELONA);
        centolloProduct.SetPriceForCity(500, CitiesEnum.LISBOA);
        productRepository.Get(ProductsEnum.VIEIRA).Returns(vieiraProduct);
        productRepository.Get(ProductsEnum.PULPO).Returns(pulpoProduct);
        productRepository.Get(ProductsEnum.CENTOLLO).Returns(centolloProduct);
        DepretiationUseCase depretiationUseCase = new DepretiationUseCase();
        FurgonetaLoadPriceUseCase furgonetaLoadPriceUseCase = new FurgonetaLoadPriceUseCase();
        EarningsForGivenProductAndCityUseCase earningsForGivenProductAndCityUseCase = new EarningsForGivenProductAndCityUseCase(depretiationUseCase, furgonetaLoadPriceUseCase);
        _findPreferredCityUseCase = new FindPreferredCityUseCase(earningsForGivenProductAndCityUseCase,cityRepository,productRepository);
    }
    [Test]
    public void RespondMadridForVieiras()
    {
        //WHEN
        var preferredCity = _findPreferredCityUseCase.CalculatePreferredCityFor(ProductsEnum.VIEIRA);
        //THEN
        Assert.AreEqual(CitiesEnum.LISBOA, preferredCity);
    }
    [Test]
    public void RespondBarcelonaForPulpo()
    {
        
        //WHEN
        var preferredCity = _findPreferredCityUseCase.CalculatePreferredCityFor(ProductsEnum.PULPO);
        //THEN
        Assert.AreEqual(CitiesEnum.BARCELONA, preferredCity);
    }
    [Test]
    public void RespondLisboaForCentolla()
    {
        
        //WHEN
        var preferredCity = _findPreferredCityUseCase.CalculatePreferredCityFor(ProductsEnum.CENTOLLO);
        //THEN
        Assert.AreEqual(CitiesEnum.LISBOA, preferredCity);
    }

}
