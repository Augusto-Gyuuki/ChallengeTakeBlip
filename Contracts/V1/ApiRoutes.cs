namespace ChallengeTakeBlip.Contracts.V1
{
    public class ApiRoutes
    {
        public const string Root = "api";
        public const string Version = "v1";
        public const string Base = Root + "/" + Version;

        public static class Repositories
        {
            public const string GetRepositories = Base + "/repositories/{userLogin}";
        }
    }
}
