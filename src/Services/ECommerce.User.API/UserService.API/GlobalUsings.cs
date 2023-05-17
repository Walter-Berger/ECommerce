﻿global using FluentValidation;
global using MediatR;
global using Microsoft.EntityFrameworkCore;
global using Microsoft.EntityFrameworkCore.Metadata.Builders;
global using Serilog;
global using System.Net.Http.Headers;
global using System.Reflection;
global using System.Text;
global using System.Text.Json;
global using System.Text.Json.Serialization;
global using UserService.API.Constants.ApiRoutes;
global using UserService.API.Constants.ErrorDetails;
global using UserService.API.Data;
global using UserService.API.Endpoints;
global using UserService.API.Exceptions;
global using UserService.API.Extensions;
global using UserService.API.Features.CreateUser;
global using UserService.API.Features.DeleteUser;
global using UserService.API.Features.GetAllUsers;
global using UserService.API.Features.GetUser;
global using UserService.API.Features.UpdateUser;
global using UserService.API.Interfaces;
global using UserService.API.Mappers;
global using UserService.API.Middlewares;
global using UserService.API.Models;
global using UserService.API.Services;
global using UserService.API.Validators;
global using UserService.Contracts.Requests;
global using UserService.Contracts.Responses;