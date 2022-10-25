using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class CityRepositoryShould
{

    [Test]
    public void ReturnMadridWhenAsked()
    {
        CityRepository repo = new CityRepository();
        Assert.AreEqual(CitiesEnum.MADRID, repo.Get(CitiesEnum.MADRID).EnumId);
    }
    [Test]
    public void ReturnBarcelonaWhenAsked()
    {
        CityRepository repo = new CityRepository();
        Assert.AreEqual(CitiesEnum.BARCELONA, repo.Get(CitiesEnum.BARCELONA).EnumId);
    }
    [Test]
    public void ReturnLisboaWhenAsked()
    {
        CityRepository repo = new CityRepository();
        Assert.AreEqual(CitiesEnum.LISBOA, repo.Get(CitiesEnum.LISBOA).EnumId);
    }

}
