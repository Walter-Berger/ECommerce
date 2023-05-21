﻿namespace ECommerce.Contracts.Requests;

public record CreateUserRequest(
    string FirstName,
    string LastName,
    DateOnly BirthDate);

