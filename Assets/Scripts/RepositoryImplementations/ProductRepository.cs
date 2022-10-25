using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class ProductRepository : IProductRepository
{
    private Dictionary<ProductsEnum, ProductEntity> _products;

    public ProductRepository()
    {
        _products = new Dictionary<ProductsEnum,ProductEntity>();
        var vieira = new ProductEntity(ProductsEnum.VIEIRA, 50);
        vieira.SetPriceForCity(500, CitiesEnum.MADRID);
        vieira.SetPriceForCity(450, CitiesEnum.BARCELONA);
        vieira.SetPriceForCity(600, CitiesEnum.LISBOA);
        var pulpo = new ProductEntity(ProductsEnum.PULPO, 100);
        pulpo.SetPriceForCity(0, CitiesEnum.MADRID);
        pulpo.SetPriceForCity(120, CitiesEnum.BARCELONA);
        pulpo.SetPriceForCity(100, CitiesEnum.LISBOA);
        var centolla = new ProductEntity(ProductsEnum.CENTOLLA, 50);
        centolla.SetPriceForCity(0, CitiesEnum.MADRID);
        centolla.SetPriceForCity(120, CitiesEnum.BARCELONA);
        centolla.SetPriceForCity(100, CitiesEnum.LISBOA);
        _products.Add(ProductsEnum.VIEIRA, vieira);
        _products.Add(ProductsEnum.CENTOLLA, centolla);
        _products.Add(ProductsEnum.PULPO, pulpo);

    }
    public ProductEntity Get(ProductsEnum productEnum)
    {
        return _products.ContainsKey(productEnum) ? _products[productEnum] : null;
    }
}
