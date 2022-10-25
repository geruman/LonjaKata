using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class ProductRepositoryShould
{

    [Test]
    public void ReturnVieiraWhenAsked()
    {
        InMemoryProductRepository repository = new InMemoryProductRepository();
        Assert.AreEqual(ProductsEnum.VIEIRA, repository.Get(ProductsEnum.VIEIRA).EnumId);
    }
    [Test]
    public void ReturnPulpoWhenAsked()
    {
        InMemoryProductRepository repository = new InMemoryProductRepository();
        Assert.AreEqual(ProductsEnum.PULPO, repository.Get(ProductsEnum.PULPO).EnumId);
    }
    [Test]
    public void ReturnCentollaWhenAsked()
    {
        InMemoryProductRepository repository = new InMemoryProductRepository();
        Assert.AreEqual(ProductsEnum.CENTOLLO, repository.Get(ProductsEnum.CENTOLLO).EnumId);
    }

}
