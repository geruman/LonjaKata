using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
[CreateAssetMenu(fileName = "RepositoriesScriptable", menuName = "ScriptableObjects/RepositoriesScriptable", order = 1)]
public class DataScriptableObject : ScriptableObject
{
    public ICityRepository CityRepository = new InMemoryCityRepository();
    public IProductRepository ProductRepository = new InMemoryProductRepository();
    
}
