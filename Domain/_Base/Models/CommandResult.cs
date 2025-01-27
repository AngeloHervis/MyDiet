using Crosscutting.Constants;
using Domain._Base.Interfaces;
using Microsoft.AspNetCore.Http;

namespace Domain._Base.Models;

public class CommandResult<TValue> : ICommandResult<TValue>
{
    public bool IsError { get; private init; }
    public int StatusCode { get; private init; }
    public List<CommandError> Errors { get; private init; }
    public TValue Data { get; private init; }

    public static CommandResult<TValue> Success(TValue data)
        => new()
        {
            IsError = false,
            StatusCode = StatusCodes.Status200OK,
            Data = data
        };

    public static ICommandResult<TValue> ValidationFailure(List<CommandError> errors)
        => new CommandResult<TValue>
        {
            IsError = true,
            StatusCode = StatusCodes.Status422UnprocessableEntity,
            Errors = errors
        };

    public static CommandResult<TValue> NotFound(string message)
        => new()
        {
            IsError = true,
            StatusCode = StatusCodes.Status404NotFound,
            Errors = [new CommandError(ErrorCodes.NotFound, message)]
        };

    public static CommandResult<TValue> InvalidRequest(string message)
        => new()
        {
            IsError = true,
            StatusCode = StatusCodes.Status422UnprocessableEntity,
            Errors = [new CommandError(ErrorCodes.ValidationFailure, message)]
        };

    public static CommandResult<TValue> InternalError(string message)
        => new()
        {
            IsError = true,
            StatusCode = StatusCodes.Status500InternalServerError,
            Errors = [new CommandError(ErrorCodes.UnknownError, message)]
        };
}