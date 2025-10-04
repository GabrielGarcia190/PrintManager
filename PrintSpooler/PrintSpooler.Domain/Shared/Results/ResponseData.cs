namespace PrintSpooler.Domain.Shared.Results;

public class ResponseData
{
    public bool Success { get; protected set; }
    public string? Message { get; protected set; }

    protected ResponseData() { }

    public static ResponseData Sucesso(string? message = null) =>
        new ResponseData { Success = true, Message = message };

    public static ResponseData Erro(string message) =>
        new ResponseData { Success = false, Message = message };
}

public class ResponseData<T> : ResponseData
{
    public T? Data { get; private set; }

    private ResponseData() { }

    public static ResponseData<T> Sucesso(T data, string? message = null) =>
        new ResponseData<T> { Success = true, Data = data, Message = message };

    public static new ResponseData<T> Erro(string message) =>
        new ResponseData<T> { Success = false, Data = default, Message = message };
}