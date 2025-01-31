using System.Data.SQLite;

namespace cb_agent.Repository;

public class SqlLiteDbContext(IConfiguration configuration) : ISqlLiteDbContext
{
    private IConfiguration _configuration = configuration;
    public SQLiteConnection ConnectionInit()
    {
       string connString = _configuration.GetConnectionString("DbConnString");
       return  new SQLiteConnection(connString);
    }
}