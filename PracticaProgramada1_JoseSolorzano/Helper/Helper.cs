namespace PracticaProgramada1_JoseSolorzano.Helper
{
    public class RestaurantAPI
    {
        public HttpClient Initial()
        {
            var Client = new HttpClient();
            Client.BaseAddress = new Uri("http://localhost:5145");
            return Client;
        }
    }
}
