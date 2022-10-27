using System.Collections;
using System.Collections.Generic;
using NSubstitute;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class UpdatePricesPresenterShould
{
    private IProductRepository _productRepository;
    private IPricesView _view;
    private ProductEntity _vieira;

    [SetUp]
    public void SetUp()
    {
        _productRepository = Substitute.For<IProductRepository>();
        _view = Substitute.For<IPricesView>();
        _vieira = Substitute.For<ProductEntity>(ProductsEnum.VIEIRA,50m);

    }
    [Test]
    public void UpdateMadridPriceInVieiraProductFromRepository()
    {
        //GIVEN

        _productRepository.Get(ProductsEnum.VIEIRA).Returns(_vieira);
        UpdatePricesPresenter presenter = new UpdatePricesPresenter(_view,_productRepository);
        int PRICE_TO_SET = 500;
        //WHEN
        presenter.UpdatePriceForProductInCity(PRICE_TO_SET, ProductsEnum.VIEIRA, CitiesEnum.MADRID);
        _productRepository.Received().Get(ProductsEnum.VIEIRA);
        _vieira.Received().SetPriceForCity(PRICE_TO_SET, CitiesEnum.MADRID);
        _view.DidNotReceive().ShowErrorMessage(Arg.Any<string>()); 
    }

    [Test]
    public void ErrorOnUpdateMadridPriceInVieiraProductFromRepository()
    {
        //GIVEN

        _productRepository.Get(ProductsEnum.VIEIRA).Returns(_vieira);
        UpdatePricesPresenter presenter = new UpdatePricesPresenter(_view, _productRepository);
        int PRICE_TO_SET = -500;
        //WHEN
        presenter.UpdatePriceForProductInCity(PRICE_TO_SET, ProductsEnum.VIEIRA, CitiesEnum.MADRID);
        _productRepository.DidNotReceive().Get(ProductsEnum.VIEIRA);
        _vieira.DidNotReceive().SetPriceForCity(PRICE_TO_SET, CitiesEnum.MADRID);
        _view.Received().ShowErrorMessage(Arg.Any<string>());
    }

}
