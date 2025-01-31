public interface ILogs
{
    public void Warning(string title, string mensage, int programaId);
    public void Information(string title, string mensage, int programaId);
    public void Critical(string title, string mensage, int programaId);
}