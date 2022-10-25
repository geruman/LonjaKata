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
    private CalculatePresenter _calculatePresenter;
    public void Start()
    {
        var depretiationUseCase = new DepretiationUseCase();
        var furgonetaLoadPriceUseCase = new FurgonetaLoadPriceUseCase();
        var earningsUseCase = new EarningsForGivenProductAndCityUseCase(depretiationUseCase,furgonetaLoadPriceUseCase);
        var preferredCityUseCase = new FindPreferredCityUseCase(earningsUseCase, repositoriesLocator.CityRepository,repositoriesLocator.ProductRepository);
        _calculatePresenter = new CalculatePresenter(this, preferredCityUseCase);
    }

    public void PerformCalculations()
    {
        _calculatePresenter.CalculatePreferredCities();
    }

    public void UpdateVieiraText(string text)
    {
        vieirasText.text = text;
    }

    public void UpdatePulpoText(string text)
    {
        pulpoText.text = text;
    }

    public void UpdateCentolloText(string text)
    {
        centollaText.text = text;
    }
}
