namespace cb_agent.Repository.Interfaces;
using cb_agent;

public interface ILog
{
    public void Create(Log log);
    public List<Log> ReadAll();
    public Log ReadOneById(int id);
    public void Update(Log log);
    public void Delete(int id);
}