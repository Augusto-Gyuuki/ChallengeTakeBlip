using ChallengeTakeBlip.Contracts.V1;
using ChallengeTakeBlip.Contracts.V1.Responses;
using ChallengeTakeBlip.Integrations.GitHub.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace ChallengeTakeBlip.Controllers.V1
{
    public class RepositoryController : Controller
    {
        private readonly IUserService _userService;

        public RepositoryController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet(ApiRoutes.Repositories.GetRepositories)]
        public IActionResult ListUserRespositories([FromRoute] string userLogin = "takenet")
        {
            var ListRepository = _userService.GetAllRepositoriesFromUser(userLogin);

            if (ListRepository is null)
                return BadRequest();

            var repositoryResponse = ListRepository
                .Where(x => !string.IsNullOrWhiteSpace(x.language) && x.language.ToLower().Equals("c#"))
                .Take(5)
                .Select(x => new RepositoryResponse
                {
                    OwnerAvatar = x.owner.avatar_url,
                    RepositoryDescription = x.description,
                    RepositoryFullName = x.full_name
                })
                .ToList();

            var Response = new Response<RepositoryResponse>
            {
                firstRepository = repositoryResponse[0],
                secondRepository = repositoryResponse[1],
                thirdRepository = repositoryResponse[2],
                fourthRepository = repositoryResponse[3],
                fifthRepository = repositoryResponse[4]
            };

            return Ok(Response);
        }
    }
}
