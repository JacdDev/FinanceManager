using ErrorOr;
using FluentValidation;
using MediatR;
using System.Reflection;

namespace FinanceManager.Application.Behaviours
{

    public class ValidationBehaviour<TRequest, TResponse> :
         IPipelineBehavior<TRequest, TResponse>
         where TRequest : IRequest<TResponse>
         where TResponse : IErrorOr
    {
        private readonly IValidator<TRequest>? _validator;

        public ValidationBehaviour(IValidator<TRequest>? validator)
        {
            _validator = validator;
        }

        public async Task<TResponse> Handle(
            TRequest request,
            CancellationToken cancellationToken,
            RequestHandlerDelegate<TResponse> next)
        {
            if (_validator is null)
            {
                return await next();
            }

            var validatonResult = await _validator.ValidateAsync(request, cancellationToken);

            if (validatonResult.IsValid)
            {
                return await next();
            }

            var errors = validatonResult.Errors
                .ConvertAll(validationFailure => Error.Validation(
                    validationFailure.PropertyName,
                    validationFailure.ErrorMessage));

            //workaround to not use return (dynamic)errors
            var response = (TResponse?)typeof(TResponse)
            .GetMethod(
                name: nameof(ErrorOr<object>.From),
                bindingAttr: BindingFlags.Static | BindingFlags.Public,
                types: new[] { typeof(List<Error>) })?
            .Invoke(null, new[] { errors })!;

            return response;
        }
    }
}