namespace Core.Services.ResponseModels
{
    public class CrearGrupoResponseApi
    {
        public string Message { get; set; }
        public bool Succes { get; set; }
       
        public CrearGrupoResponseApi(bool succes,string message = " ") {
            this.Message = message;
            this.Succes = succes;
        }

    }
}