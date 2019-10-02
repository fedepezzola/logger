namespace Logger
{
    internal interface ILogger
    {
        void procesarMensaje(string msj);
        void procesarWarning(string msj);
        void procesarError(string msj);
    }
}