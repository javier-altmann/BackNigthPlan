namespace Core.Services.ResponseModels
{
    public class PostResult<T>
    {
    public string MensajePersonalizado { get; set; }    
    public T ObjectResult {get; set; }
    public string Message => ObjectResult == null 
    ? MensajePersonalizado : string.Empty;
        
    }
}