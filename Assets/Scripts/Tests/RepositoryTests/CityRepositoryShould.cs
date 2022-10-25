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
        InMemoryCityRepository repo = new InMemoryCityRepository();
        Assert.AreEqual(CitiesEnum.MADRID, repo.Get(CitiesEnum.MADRID).EnumId);
    }
    [Test]
    public void ReturnBarcelonaWhenAsked()
    {
        InMemoryCityRepository repo = new InMemoryCityRepository();
        Assert.AreEqual(CitiesEnum.BARCELONA, repo.Get(CitiesEnum.BARCELONA).EnumId);
    }
    [Test]
    public void ReturnLisboaWhenAsked()
    {
        InMemoryCityRepository repo = new InMemoryCityRepository();
        Assert.AreEqual(CitiesEnum.LISBOA, repo.Get(CitiesEnum.LISBOA).EnumId);
    }

}
