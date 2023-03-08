using System.Net.Http.Json;

namespace SwapiProjectForRocketMortgage
{
    public class SwapiClient : INameClient
    {
        private readonly HttpClient httpClient;

        public SwapiClient(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<List<string>> GetNames()
        {
            var pageNumber = 1;
            SwapiResponse planetsResponse;
            List<string> planetNames = new List<string>();
            do
            {
                var response = httpClient.GetAsync($"https://swapi.dev/api/planets/?page={pageNumber}").Result;

                planetsResponse = await response.Content.ReadFromJsonAsync<SwapiResponse>();

                var count = planetsResponse.Count;

                //I know there are only 60 planets so this is safer
                if (count > 60)
                {
                    break;
                }
                pageNumber++;
                planetNames.AddRange(planetsResponse.Results.Select(r => r.Name));
            } while (planetsResponse.Next != null);
            return planetNames;
        }
    }
}
