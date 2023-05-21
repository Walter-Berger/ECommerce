﻿namespace AuthService.API.Interfaces;

public interface ICredentialService
{
    (string, string) ExtractUsernameAndPassword(string authorizationHeader);
}
