namespace Services
{
    public class CitiesService
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