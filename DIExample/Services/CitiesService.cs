using ServiceContracts;
namespace Services

{
    public class CitiesService : ICitiesServices
    {
        private List<string> _cities;

        public CitiesService()
        {
            _cities = new List<string>()
            {
                "London",
                "Bogota",
                "Oslo",
                "Bangladesh",
                "Cairo"
            };
        }

        public List<string> GetCities()
        {
            return _cities;
        }
    }
}