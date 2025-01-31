using cb_agent.Repository.Interfaces;

namespace cb_agent.Services.Classes;
public class Logs : ILogs
{
    ILog _log;
    public Logs(ILog log)
    {
        _log = log;
    }

    private void LogWrite(string title,string mensage, string logLevel, int programaId)
    {
       Log newLog = new Log
       {
        Date = DateTime.Now,
        Title = title,
        Mensage = mensage,
        Level = logLevel,
        ProgramId = programaId
       };
    
        _log.Create(newLog);

    }

    public void Warning(string title,string mensage,int programaId)
    {
        LogWrite( title, mensage, "Warning",  programaId);
    }
    public void Information(string title,string mensage,int programaId)
    {
        LogWrite( title, mensage, "Information",  programaId);
    }
    public void Critical(string title,string mensage,int programaId)
    {
        LogWrite( title, mensage, "Critical",  programaId);
    }
}