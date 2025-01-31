namespace cb_agent.Repository.Interfaces;
using cb_agent;

public interface  IConfig
{
    public void Create(Config config);
    public List<Config> ReadAll();
    public Config ReadOneById(int id);
    public void Update(Config config);
    public void Delete(int id);
}