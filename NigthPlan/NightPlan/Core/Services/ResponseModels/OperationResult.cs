using System.Collections.Generic;
using System.Linq;

namespace Core.Services.ResponseModels
{
    public class OperationResult<T>
    {
    
    public T ObjectResult {get; set; }
    public string Message => ObjectResult == null 
    ? "La consulta no produjo resultados." : string.Empty;

    }
}

