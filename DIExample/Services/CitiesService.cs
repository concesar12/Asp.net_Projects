using ServiceContracts;
namespace Services

{
    public class CitiesService : ICitiesServices, IDisposable
    {
        private List<string> _cities;

        private Guid _serviceInstanceId;

        public Guid ServiceInstanceId { 
            get
            {
                return _serviceInstanceId;
            }
        }

        public CitiesService()
        {
            _serviceInstanceId = Guid.NewGuid();
            _cities = new List<string>()
            {
                "London",
                "Bogota",
                "Oslo",
                "Bangladesh",
                "Cairo"
            };
            //HERE some logic to open the database connection
        }

        public List<string> GetCities()
        {
            return _cities;
        }

        public void Dispose()
        {

        }
    }
}