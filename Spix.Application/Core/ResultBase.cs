namespace Spix.Application.Core;

public class ResultBase<T> where T : class
{
    public bool Success { get; }
    public string Message { get; }
    public T? Data { get; }  

    public ResultBase(bool success, string message, T? data)
    {
        Success = success;
        Message = message;
        Data = data;
    }
    
}
 