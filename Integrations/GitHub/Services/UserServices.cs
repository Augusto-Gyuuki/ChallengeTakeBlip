using ChallengeTakeBlip.Integrations.GitHub.Contracts.Responses;
using ChallengeTakeBlip.Integrations.GitHub.Interfaces;
using Newtonsoft.Json;
using RestSharp;
using System.Collections.Generic;

namespace ChallengeTakeBlip.Integrations.GitHub.Controllers
{
    public class UserServices : IUserService
    {
        private string baseUrl = "https://api.github.com/users/";
        public List<Repository> GetAllRepositoriesFromUser(string userLogin)
        {
            var client = new RestClient(string.Concat(baseUrl, userLogin, "/repos"))
            {
                Timeout = -1,
            };

            var request = new RestRequest(Method.GET);
            request.AddHeader("Content-Type", "application/json");
            request.AddQueryParameter("direction", "asc");
            request.AddQueryParameter("sort", "created");
            var response = client.Execute(request);
            if (response.IsSuccessful)
            {
                var listRepository = JsonConvert.DeserializeObject<List<Repository>>(response.Content);
                return listRepository;
            }

            return null;
        }
    }
}
