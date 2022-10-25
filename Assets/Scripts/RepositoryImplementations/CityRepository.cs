using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CityRepository : ICityRepository
{
    private Dictionary<CitiesEnum, CityEntity> _cities;

    public CityRepository()
    {
        _cities = new Dictionary<CitiesEnum, CityEntity>();
        var madrid = new CityEntity(CitiesEnum.MADRID, 800);
        var barcelona = new CityEntity(CitiesEnum.BARCELONA, 1100);
        var lisboa = new CityEntity(CitiesEnum.LISBOA, 600);
        _cities.Add(madrid.EnumId, madrid);
        _cities.Add(barcelona.EnumId,barcelona);
        _cities.Add(lisboa.EnumId, lisboa);

    }
    public CityEntity Get(CitiesEnum citiesEnum)
    {
        return _cities.ContainsKey(citiesEnum) ? _cities[citiesEnum] : null;
    }
}
