namespace AccountService.Constants.ApiRoutes;

public class EndpointRoutes
{
    public class User
    {
        public const string Base = "/api/users";

        public const string Create = Base;
        public const string GetAll = Base;
        public const string Get = $"{Base}/{{id:Guid}}";
        public const string Update = $"{Base}/{{id:Guid}}";
        public const string Delete = $"{Base}/{{id:Guid}}";
    }
}