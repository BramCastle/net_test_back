using System;

namespace net_test.Libraries
{
    public class ExceptionMessage
    {
        
        public string Code { get; }
        public string Title { get; }
        public string Message { get; }  

        private ExceptionMessage(string Code, string Title, string Message) {
            this.Code = "EXCEPTION_" + Code;
            this.Title = Title;
            this.Message = Message;
        }

        public static ExceptionMessage RawException(Exception exception) {
            ExceptionMessage objExceptionMessage = null;

            if(exception != null) {
                objExceptionMessage = new ExceptionMessage("GRAL", "Error inesperado", exception.Message);
            }

            return objExceptionMessage; 
        }


        // ASP NET USER
        public static readonly ExceptionMessage ASP_NET_USER_CREATE_001 = new ExceptionMessage("ASP_NET_USER_CREATE_001", "Nuevo usuario", "El objeto AspNetUser es Nulo. Póngase en contacto con el administrador.");

    }
}