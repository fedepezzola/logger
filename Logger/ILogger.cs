namespace LoggerProyecto
{
    internal interface ILogger
    {
        void procesarMessage(string msj);
        void procesarWarning(string msj);
        void procesarError(string msj);
        void Init();
        void Terminate();
    }
}