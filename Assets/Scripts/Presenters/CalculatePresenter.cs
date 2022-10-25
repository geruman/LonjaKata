using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalculatePresenter
{
    private ICalculateView _calculateView;
    private IFindPreferredCityUseCase _findPreferredCityUseCase;
    

    public CalculatePresenter(ICalculateView calculateView, IFindPreferredCityUseCase findPreferredCityUseCase)
    {
        _calculateView=calculateView;
        _findPreferredCityUseCase=findPreferredCityUseCase;
    }

    public void CalculatePreferredCities()
    {
        var preferredForVieiras = _findPreferredCityUseCase.CalculatePreferredCityFor(ProductsEnum.VIEIRA);
        var preferredForCentollo = _findPreferredCityUseCase.CalculatePreferredCityFor(ProductsEnum.CENTOLLO);
        var preferredForPulpo = _findPreferredCityUseCase.CalculatePreferredCityFor(ProductsEnum.PULPO);
        var textoBase = "La ciudad preferida para ";
        _calculateView.UpdateVieiraText(textoBase+ProductsEnum.VIEIRA+" es: "+preferredForVieiras);
        _calculateView.UpdatePulpoText(textoBase+ProductsEnum.PULPO+" es: "+preferredForPulpo);
        _calculateView.UpdateCentolloText(textoBase+ProductsEnum.CENTOLLO+" es: "+preferredForCentollo);

    }
}
