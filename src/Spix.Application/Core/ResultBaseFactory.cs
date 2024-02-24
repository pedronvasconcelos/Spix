namespace Spix.Application.Core;

public static class ResultBaseFactory
{
    public static ResultBase<T> Successful<T>( T data, string message = "") where T : class
    {
        return new ResultBase<T>(true, message, data);
    }

    public static ResultBase<T> Failure<T>(string message) where T : class
    {
        return new ResultBase<T>(false, message, null);
    }   
}