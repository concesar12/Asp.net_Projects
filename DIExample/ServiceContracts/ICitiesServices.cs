namespace ServiceContracts
{
    public interface ICitiesServices
    {
        Guid ServiceInstanceId { get; }
        List<string> GetCities();
    }
}