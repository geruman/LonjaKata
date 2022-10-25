using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProductEntity
{
    public ProductsEnum EnumId { private set; get; }
    public decimal Kilograms { private set; get;  }
    private readonly Dictionary<CitiesEnum, int> _cityPrice = new Dictionary<CitiesEnum, int>();
    public ProductEntity(ProductsEnum productEnum, decimal kilograms)
    {
        EnumId=productEnum;
        Kilograms=kilograms;
    }
    public void SetPriceForCity(int price, CitiesEnum city)
    {
        _cityPrice.Add(city, price);
    }
    public int GetPriceForCity(CitiesEnum city)
    {
        _cityPrice.TryGetValue(city, out int returnValue);
        return returnValue;
    }
}
