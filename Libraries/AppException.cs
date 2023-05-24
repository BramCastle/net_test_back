using System;

namespace net_test.Libraries
{
    [Serializable()]
    public class AppException : System.Exception
    {
        public string Title { get; }

        override
        public string Message { get; }
        public string Code { get; }

        public AppException(ExceptionMessage objExcepcionMessage) {
            this.Title = objExcepcionMessage.Title;
            this.Message = objExcepcionMessage.Message;
            this.Code = objExcepcionMessage.Code;
        }
    

    }
}