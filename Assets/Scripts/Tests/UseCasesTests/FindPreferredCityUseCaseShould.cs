using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class FindPreferredCityUseCaseShould
{
    private FindPreferredCityUseCase _studyUseCase;
    [SetUp]
    public void SetUp()
    {
        //GIVEN
        _studyUseCase = new FindPreferredCityUseCase(null,null);
    }
    [Test]
    public void RespondMadridForVieiras()
    {
        //WHEN
        var preferredCity = _studyUseCase.CalculatePreferredCityFor(ProductsEnum.VIEIRA);
        //THEN
        Assert.AreEqual(CitiesEnum.MADRID, preferredCity);
    }

}
