using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PricesView : MonoBehaviour, IPricesView
{
    private UpdatePricesPresenter _presenter;
    public DataScriptableObject _repositoriesLocator;
    public TMP_InputField madridVieira;
    public TMP_InputField madridPulpo;
    public TMP_InputField madridCentollo;
    public TMP_InputField barcelonaVieira;
    public TMP_InputField barcelonaPulpo;
    public TMP_InputField barcelonaCentollo;
    public TMP_InputField lisboaVieira;
    public TMP_InputField lisboaPulpo;
    public TMP_InputField lisboaCentollo;
    void Start()
    {
        _presenter = new UpdatePricesPresenter(this, _repositoriesLocator.ProductRepository);
        InstantiateInpuFieldContentTypes();
        SetInitialPricesInView();
    }

    private void SetInitialPricesInView()
    {
        madridVieira.text = _repositoriesLocator.ProductRepository.Get(ProductsEnum.VIEIRA).GetPriceForCity(CitiesEnum.MADRID).ToString();
        madridPulpo.text = _repositoriesLocator.ProductRepository.Get(ProductsEnum.PULPO).GetPriceForCity(CitiesEnum.MADRID).ToString();
        madridCentollo.text = _repositoriesLocator.ProductRepository.Get(ProductsEnum.CENTOLLO).GetPriceForCity(CitiesEnum.MADRID).ToString();
        barcelonaVieira.text = _repositoriesLocator.ProductRepository.Get(ProductsEnum.VIEIRA).GetPriceForCity(CitiesEnum.BARCELONA).ToString();
        barcelonaPulpo.text = _repositoriesLocator.ProductRepository.Get(ProductsEnum.PULPO).GetPriceForCity(CitiesEnum.BARCELONA).ToString();
        barcelonaCentollo.text = _repositoriesLocator.ProductRepository.Get(ProductsEnum.CENTOLLO).GetPriceForCity(CitiesEnum.BARCELONA).ToString();
        lisboaVieira.text = _repositoriesLocator.ProductRepository.Get(ProductsEnum.VIEIRA).GetPriceForCity(CitiesEnum.LISBOA).ToString();
        lisboaPulpo.text = _repositoriesLocator.ProductRepository.Get(ProductsEnum.PULPO).GetPriceForCity(CitiesEnum.LISBOA).ToString();
        lisboaCentollo.text = _repositoriesLocator.ProductRepository.Get(ProductsEnum.CENTOLLO).GetPriceForCity(CitiesEnum.LISBOA).ToString();
    }

    private void InstantiateInpuFieldContentTypes()
    {
        madridVieira.contentType = (TMP_InputField.ContentType)InputField.ContentType.IntegerNumber;
        madridPulpo.contentType = (TMP_InputField.ContentType)InputField.ContentType.IntegerNumber;
        madridCentollo.contentType = (TMP_InputField.ContentType)InputField.ContentType.IntegerNumber;
        barcelonaVieira.contentType = (TMP_InputField.ContentType)InputField.ContentType.IntegerNumber;
        barcelonaPulpo.contentType = (TMP_InputField.ContentType)InputField.ContentType.IntegerNumber;
        barcelonaCentollo.contentType = (TMP_InputField.ContentType)InputField.ContentType.IntegerNumber;
        lisboaVieira.contentType = (TMP_InputField.ContentType)InputField.ContentType.IntegerNumber;
        lisboaPulpo.contentType = (TMP_InputField.ContentType)InputField.ContentType.IntegerNumber;
        lisboaCentollo.contentType = (TMP_InputField.ContentType)InputField.ContentType.IntegerNumber;
    }

    public void ShowErrorMessage(string message)
    {
        Debug.Log(message);
    }

    public void UpdateMadridVieiraPrice()
    {
        int value;
        if (int.TryParse(madridVieira.text, out value)&&value>=0)
        {
            _presenter.UpdatePriceForProductInCity(value, ProductsEnum.VIEIRA, CitiesEnum.MADRID);
        }
        else
        {
            ShowErrorMessage("El valor de la vieira debe ser un número entero igual o superior a 0");
        }
    }
    public void UpdateMadridPulpoPrice()
    {
        int value = int.Parse(madridPulpo.text);
        _presenter.UpdatePriceForProductInCity(value, ProductsEnum.PULPO, CitiesEnum.MADRID);

    }
    public void UpdateMadridCentolloPrice()
    {
        int value = int.Parse(madridCentollo.text);
        _presenter.UpdatePriceForProductInCity(value, ProductsEnum.CENTOLLO, CitiesEnum.MADRID);
    }
    public void UpdateBarcelonaVieiraPrice()
    {
        int value = int.Parse(barcelonaVieira.text);
        _presenter.UpdatePriceForProductInCity(value, ProductsEnum.VIEIRA, CitiesEnum.BARCELONA);
    }
    public void UpdateBarcelonaPulpoPrice()
    {
        int value = int.Parse(barcelonaPulpo.text);
        _presenter.UpdatePriceForProductInCity(value, ProductsEnum.PULPO, CitiesEnum.BARCELONA);
    }
    public void UpdateBarcelonaCentollaPrice()
    {
        int value = int.Parse(barcelonaCentollo.text);
        _presenter.UpdatePriceForProductInCity(value, ProductsEnum.CENTOLLO, CitiesEnum.BARCELONA);
    }
    public void UpdateLisboaVieiraPrice()
    {
        int value = int.Parse(lisboaVieira.text);
        _presenter.UpdatePriceForProductInCity(value, ProductsEnum.VIEIRA, CitiesEnum.LISBOA);
    }
    public void UpdateLisboaPulpoPrice()
    {
        int value = int.Parse(lisboaPulpo.text);
        _presenter.UpdatePriceForProductInCity(value, ProductsEnum.PULPO, CitiesEnum.LISBOA);
    }
    public void UpdateLisboaCentollaPrice()
    {
        int value = int.Parse(lisboaCentollo.text);
        _presenter.UpdatePriceForProductInCity(value, ProductsEnum.CENTOLLO, CitiesEnum.LISBOA);
    }
}
