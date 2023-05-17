namespace UserService.API.Constants.ErrorDetails;

public static class ErrorDetails
{

    // 404 errors
    public const string SecretsNotFound = "Could not read secrets from doppler.";
    public const string UserNotFound = "No user found with the given id in database.";
    public const string UsersNotFound = "There were no users found in database.";

    // 409 errors
    public const string EmailAlreadyExists = "Email address already exists in database.";

    // 500 errors
    public const string CouldNotSaveChanges = "Something went wrong while saving changes in database.";
}
