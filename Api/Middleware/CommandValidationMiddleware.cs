using Crosscutting.Extensions;
using Domain._Base.Interfaces;
using Domain._Base.Models;
using FluentValidation;
using MediatR;

namespace MinhaDieta.Middleware;

/// <summary>
/// Middleware to validate commands triggered by the mediator
/// </summary>
/// <typeparam name="TRequest"></typeparam>
/// <typeparam name="TResponse"></typeparam>
public class CommandValidationMiddleware<TRequest, TResponse> 
    : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
        where TResponse : ICommandResult
{
    private readonly IEnumerable<IValidator<TRequest>> _validators;

    /// <summary>
    /// Contrutor
    /// </summary>
    /// <param name="validators"></param>
    public CommandValidationMiddleware(IEnumerable<IValidator<TRequest>> validators)
    {
        _validators = validators;
    }

    /// <summary>
/// Intercepts the request and validates the command
    /// </summary>
    /// <param name="request"></param>
    /// <param name="next"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<TResponse> Handle(
        TRequest request,
        RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
        if (_validators is null || _validators.IsEmpty())
            return await next();

        var context = new ValidationContext<TRequest>(request);
        var validationResults = (await Task.WhenAll(_validators.Select(v => v.ValidateAsync(context, cancellationToken)))).ToList();
        
        if (validationResults.TrueForAll(v => v.IsValid))
            return await next();
        
        var failures = validationResults
            .Where(v => !v.IsValid)
            .SelectMany(r => r.Errors).Where(f => f != null)
            .ToList();

        var errors = failures.Select(f => new CommandError(f.PropertyName, f.ErrorMessage)).ToList();
        
        var dataType = typeof(TResponse).GetGenericArguments().FirstOrDefault();
        if (dataType == typeof(Guid))
            return (dynamic) CommandResult<Guid>.ValidationFailure(errors);
        
        if (dataType == typeof(Guid))
            return (dynamic) CommandResult<Guid>.ValidationFailure(errors);
        
throw new InvalidOperationException($"Unsupported type in validator: {dataType}");
    }
}