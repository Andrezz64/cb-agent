namespace cb_agent.Repository.Interfaces;
using cb_agent;

public interface IService
{   
    public void Create(Service service);
    public List<Service> ReadAll();
    public Service ReadOneById(int id);
    public void Update(Service Service);
    public void Delete(int id);
    public List<Service> ReadAllAutoStart();
}