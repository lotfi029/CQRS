namespace CQRS_V00.Abstracts;

public class Result(bool IsSuccess, Error Error)
{
    
    public bool IsSuccess { get; } = IsSuccess;
    public bool IsFailuer { get; } = !IsSuccess;
    public Error Error { get; } = Error;


    public static Result Success() => new(true, Error.Non);
    public static Result Failuer(Error error) => new(false, error);
    public static Result<TValue> Success<TValue>(TValue value) => new (value, true, Error.Non);
    public static Result<TValue> Failuer<TValue>(Error error) => new(default, false, error);
}
public class Result<TValue>(TValue? Value, bool IsSuccess, Error Error) : Result(IsSuccess, Error)
{
    private readonly TValue? _value = Value;

    public TValue? Value => 
        IsSuccess 
        ? _value 
        : throw new InvalidOperationException();
}
