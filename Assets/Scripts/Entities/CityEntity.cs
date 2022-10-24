public class CityEntity
{
    public CitiesEnum Name { private set; get; }
    public int Distance { private set; get; }
    public CityEntity(CitiesEnum name, int distance)
    {
        Name=name;
        Distance=distance;
    }
}