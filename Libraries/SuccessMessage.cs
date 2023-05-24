namespace net_test.Libraries
{
    public class SuccessMessage
    {
        public string Code { get; }
        public string Title { get; }
        public string Message { get; }  

        private SuccessMessage(string Code, string Title, string Message) {
            this.Code = "SUCCESS_" + Code;
            this.Title = Title;
            this.Message = Message;
        }

        // CONEXION
        public static readonly SuccessMessage CONEXION_SUCCESS = new SuccessMessage("CONEXION_SUCCESS", "Conexion al servidor", "Se ha alcanzado al servidor exitozamente.");

        // GENERIC REQUEST SUCCESS
        public static readonly SuccessMessage REQUEST = new SuccessMessage("REQUEST", "Request success", "sincronización exitosa.");

        // ASPNET USER
        public static readonly SuccessMessage ASPNET_USER_LIST = new SuccessMessage("ASPNET_USER_LIST", "Lista de usuarios", "Consulta satisfactoria");
        public static readonly SuccessMessage ASPNET_USER_CREATE = new SuccessMessage("ASPNET_USER_CREATE", "Nuevo usuario", "Se creó el nuevo usuario satisfactoriamente");
        public static readonly SuccessMessage ASPNET_USER_UPDATE = new SuccessMessage("ASPNET_USER_UPDATE", "Modificar usuario", "El usuario ha sido modificado satisfactoriamente");
        public static readonly SuccessMessage ASPNET_USER_ACTIVATE = new SuccessMessage("ASPNET_USER_ACTIVATE", "Activar/desactivar usuario", "El usuario se activo/desactivo satisfactoriamente");
        public static readonly SuccessMessage ASPNET_USER_PASSWORD = new SuccessMessage("ASPNET_USER_PASSWORD", "Modificar password", "Se modifico el password satisfactoriamente");
        public static readonly SuccessMessage ASPNET_USER_PRIVILEGIO = new SuccessMessage("ASPNET_USER_PRIVILEGIO", "Modificar privilegios", "Privilegios modificados satisfactoriamente");

    }
}