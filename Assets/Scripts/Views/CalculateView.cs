using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class CalculateView : MonoBehaviour, ICalculateView
{
    [SerializeField]
    private Text vieirasText;
    [SerializeField]
    private Text pulpoText;
    [SerializeField]
    private Text centollaText;
    [SerializeField]
    private DataScriptableObject repositoriesLocator;
    private FindPreferredCityUseCase _preferredCityUseCase;
    public void Start()
    {
        var depretiationUseCase = new DepretiationUseCase();
        var furgonetaLoadPriceUseCase = new FurgonetaLoadPriceUseCase();
        var earningsUseCase = new EarningsForGivenProductAndCityUseCase(depretiationUseCase,furgonetaLoadPriceUseCase);
        _preferredCityUseCase = new FindPreferredCityUseCase(earningsUseCase, repositoriesLocator.CityRepository,repositoriesLocator.ProductRepository);
    }

    public void PerformCalculations()
    {
        //vieirasText.text = repositoriesLocator.ProductRepository.Get(productEnum.);
    }

    public void UpdateVieiraText(string text)
    {
        throw new System.NotImplementedException();
    }

    public void UpdatePulpoText(string text)
    {
        throw new System.NotImplementedException();
    }

    public void UpdateCentolloText(string text)
    {
        throw new System.NotImplementedException();
    }
}
