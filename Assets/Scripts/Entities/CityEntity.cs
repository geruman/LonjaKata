public class CityEntity
{
    public CitiesEnum EnumId { private set; get; }
    public int Distance { private set; get; }
    public CityEntity(CitiesEnum name, int distance)
    {
        EnumId=name;
        Distance=distance;
    }
}