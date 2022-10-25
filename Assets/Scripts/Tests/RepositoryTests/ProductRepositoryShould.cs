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
        ProductRepository repository = new ProductRepository();
        Assert.AreEqual(ProductsEnum.VIEIRA, repository.Get(ProductsEnum.VIEIRA).EnumId);
    }
    [Test]
    public void ReturnPulpoWhenAsked()
    {
        ProductRepository repository = new ProductRepository();
        Assert.AreEqual(ProductsEnum.PULPO, repository.Get(ProductsEnum.PULPO).EnumId);
    }
    [Test]
    public void ReturnCentollaWhenAsked()
    {
        ProductRepository repository = new ProductRepository();
        Assert.AreEqual(ProductsEnum.CENTOLLA, repository.Get(ProductsEnum.CENTOLLA).EnumId);
    }

}
