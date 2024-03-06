using Spix.Domain.Core.SeedOfWork;

namespace Spix.Domain.Core.Results;
public class Result
{
     protected Result(bool isSuccess, Error error)
    {
        if (isSuccess && error != Error.None)
        {
            throw new InvalidOperationException();
        }

        if (!isSuccess && error == Error.None)
        {
            throw new InvalidOperationException();
        }

        IsSuccess = isSuccess;
        Error = error;
    }

 
    public bool IsSuccess { get; }

    
    public bool IsFailure => !IsSuccess;

    
    public Error Error { get; }

   
    public static Result Success() => new Result(true, Error.None);

    
    public static Result<TValue> Success<TValue>(TValue value) => new Result<TValue>(value, true, Error.None);

 
    public static Result<TValue> Create<TValue>(TValue value, Error error)
        where TValue : class
        => value is null ? Failure<TValue>(error) : Success(value);
 
    public static Result Failure(Error error) => new Result(false, error);

     
    public static Result<TValue> Failure<TValue>(Error error) => new Result<TValue>(default!, false, error);

    
    public static Result FirstFailureOrSuccess(params Result[] results)
    {
        foreach (Result result in results)
        {
            if (result.IsFailure)
            {
                return result;
            }
        }

        return Success();
    }

    public static Result ValidateRule(IBusinessRule rule)
    {
        if (rule.IsBroken())
        {
            return Result.Failure(new Error(rule.GetType().FullName ?? "None", rule.Message));
        }

        return Result.Success();
    }

    public static Result ValidateRules(params IBusinessRule[] rules)
    {
        foreach (var rule in rules)
        {
            if (rule.IsBroken())
            {
                return Result.Failure(new Error(rule.GetType().FullName ?? "None" , rule.Message));
            }
        }

        return Result.Success();
    }
}


public class Result<TValue> : Result
{
    private readonly TValue _value;

    
    protected internal Result(TValue value, bool isSuccess, Error error)
        : base(isSuccess, error)
        => _value = value;

    public static implicit operator Result<TValue>(TValue value) => Success(value);

 
    public TValue Value => IsSuccess
        ? _value
        : throw new InvalidOperationException("The value of a failure result can not be accessed.");
}
