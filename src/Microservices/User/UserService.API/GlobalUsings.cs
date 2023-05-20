﻿global using FluentValidation;
global using MediatR;
global using Microsoft.EntityFrameworkCore;
global using Microsoft.EntityFrameworkCore.Metadata.Builders;
global using Serilog;
global using System.Reflection;
global using UserService.API.Constants.ApiRoutes;
global using UserService.API.Constants.ErrorDetails;
global using UserService.API.Data;
global using UserService.API.Domain;
global using UserService.API.Endpoints;
global using UserService.API.Exceptions;
global using UserService.API.Extensions;
global using UserService.API.Features.CreateUser;
global using UserService.API.Features.DeleteUser;
global using UserService.API.Features.GetAllUsers;
global using UserService.API.Features.GetUser;
global using UserService.API.Features.UpdateUser;
global using UserService.API.Interfaces;
global using UserService.API.Middlewares;
global using UserService.API.Services;
global using UserService.API.Validators;
global using UserService.Dto.Requests;
global using UserService.Dto.Responses;
