using System.Collections.Generic;
using Manager.API.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Manager.API.Controllers
{
    [ApiController]
    [Authorize]
    public abstract class BaseController : ControllerBase
    {
        protected static ResultViewModel NotFoundResponse() => new()
        {
            Message = "The Resource was not found.",
            Success = false,
            Data = null
        };

        protected static ResultViewModel NotFoundResponse(string resourceName) => new()
        {
            Message = $"The {resourceName} was not found.",
            Success = false,
            Data = null
        };

        protected static ResultViewModel ApplicationErrorResponse() => new()
        {
            Message = "Something went wrong trying to process your request, please, try again.",
            Success = false,
            Data = null
        };

        protected static ResultViewModel DomainErrorResponse(string message) => new()
        {
            Message = message,
            Success = false,
            Data = null
        };

        protected static ResultViewModel DomainErrorResponse(string message, IReadOnlyCollection<string> errors) => new()
        {
            Message = message,
            Success = false,
            Data = errors
        };

        protected static ResultViewModel UnauthorizedErrorMessage() => new()
        {
            Message = "Unauthorizad",
            Success = false,
            Data = null
        };
    }
}
