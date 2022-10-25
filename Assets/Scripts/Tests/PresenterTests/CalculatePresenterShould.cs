using System.Collections;
using System.Collections.Generic;
using NSubstitute;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class CalculatePresenterShould
{
    private CalculatePresenter _presenter;
    private IFindPreferredCityUseCase _findPreferredCityUseCase;
    private IProductRepository _productRepository;
    private string stringBase = "La ciudad preferida para vieiras es ";
    public ICalculateView calculateView { get; private set; }

    [SetUp]
    public void SetUp()
    {
        calculateView = Substitute.For<ICalculateView>();
        
        _findPreferredCityUseCase = Substitute.For<IFindPreferredCityUseCase>();
        _findPreferredCityUseCase.CalculatePreferredCityFor(ProductsEnum.VIEIRA).Returns(CitiesEnum.BARCELONA);
        _findPreferredCityUseCase.CalculatePreferredCityFor(ProductsEnum.PULPO).Returns(CitiesEnum.MADRID);
        _findPreferredCityUseCase.CalculatePreferredCityFor(ProductsEnum.CENTOLLO).Returns(CitiesEnum.LISBOA);
        _presenter = new CalculatePresenter(calculateView, _findPreferredCityUseCase);

    }
    [Test]
    public void CalculatePreferredCityForVieiras()
    {
        _presenter.CalculatePreferredCities();
        calculateView.Received().UpdateVieiraText(stringBase+CitiesEnum.BARCELONA);
    }

    [Test]
    public void CalculatePreferredCityForPulpo()
    {
        _presenter.CalculatePreferredCities();
        calculateView.Received().UpdatePulpoText(stringBase+CitiesEnum.MADRID);
    }

    [Test]
    public void CalculatePreferredCityForCentollo()
    {
        _presenter.CalculatePreferredCities();
        calculateView.Received().UpdateCentolloText(stringBase+CitiesEnum.LISBOA);
    }

}
