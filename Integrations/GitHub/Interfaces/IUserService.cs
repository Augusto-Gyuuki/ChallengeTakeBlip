using ChallengeTakeBlip.Integrations.GitHub.Contracts.Responses;
using System.Collections.Generic;

namespace ChallengeTakeBlip.Integrations.GitHub.Interfaces
{
    public interface IUserService
    {
        List<Repository> GetAllRepositoriesFromUser(string userLogin);
    }
}
