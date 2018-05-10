namespace Core.Services.ResponseModels
{
    public class LoginResponseApi
    {
        public string Message { get; set; }
        public bool Succes { get; set; }
        public LoginResponseApi(bool succes,string message = " ") {
            this.Message = message;
            this.Succes = succes;
        }
    }
}