namespace LoggerProyecto
{
    internal interface ILogger
    {
        void procesarMensaje(string msj);
        void procesarWarning(string msj);
        void procesarError(string msj);
        void Init();
        void Terminate();
    }
}