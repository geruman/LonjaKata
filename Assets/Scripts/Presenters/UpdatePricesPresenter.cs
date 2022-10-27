using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdatePricesPresenter
{
    private IPricesView _view;
    private IProductRepository _productRepository;

    public UpdatePricesPresenter(IProductRepository productRepository)
    {
        _productRepository=productRepository;
    }

    public UpdatePricesPresenter(IPricesView view, IProductRepository productRepository)
    {
        _view=view;
        _productRepository=productRepository;
    }

    public void UpdatePriceForProductInCity(int newPrice, ProductsEnum product, CitiesEnum city)
    {
        if (newPrice > 0)
        {
            _productRepository.Get(product).SetPriceForCity(newPrice, city);
        }
        else
        {
            _view.ShowErrorMessage("El precio para "+product+" en la ciudad "+city+ "debe ser mayor a 0");
        }
    }

}
