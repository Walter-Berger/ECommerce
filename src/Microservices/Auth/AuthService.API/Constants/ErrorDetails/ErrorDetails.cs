namespace AuthService.API.Constants.ErrorDetails;

public static class ErrorDetails
{
    // 400 errors
    public const string EmptyAuthHeader = "Authorization header must not be empty.";
    public const string InvalidAuthHeaderFormat = "Invalid Authorization header format. Must start with Basic: ";
    public const string InvalidCredentialsFormat = "Invalid credentials format. Must only contain username and password credentials";

    // 404 errors
    public const string UserNotFound = "No user found with the given id in database.";
}