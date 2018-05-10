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



/*
y en el controller devolverías un 
OperationResult, y en este caso T = List<EstablecimientoDTO> 
o List<EstablecimientoViewModel> sería más correcto

OperationResult<MiDto> _datosDelServicio; 

Adentro del controller:
_datosDelServicio.ObjectResult = elMetodoQueTraeDatos();
if(!_datosDelServicio.ObjectResult){
    return _datosDelServicio.Message;
}
return _datosDelServicio.ObjectResult;

 */