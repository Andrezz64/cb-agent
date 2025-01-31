namespace cb_agent.Repository.Classes;

using System.Data.SQLite;
using Dapper;
using cb_agent;
using cb_agent.Repository.Interfaces;

public class ConfigRepositoy : IConfig
{
    private readonly ISqlLiteDbContext _dbContext;
    private readonly SQLiteConnection _conn;

    public ConfigRepositoy(ISqlLiteDbContext dbContext)
    {
        _dbContext = dbContext;
        _conn = _dbContext.ConnectionInit();
    }

    public void Create(Config config)
    {
        using (_conn)
        {
            _conn.Open();
            _conn.Execute(@"INSERT INTO configs (""first-run"", ""admin-server"", ""api-key"") VALUES (@firstRun, @adminServer, @apiKey);", config);
        }
    }

    public void Update(Config config)
    {
        using (_conn)
        {
            _conn.Open();
            _conn.Execute(@"UPDATE configs SET ""first-run"" = @first_run, ""admin-server"" = @admin_server, ""api-key"" = @api_key WHERE config_id = @config_id", config);
        }

    }

    public void Delete(int id)
    {
        using (_conn)
        {
            _conn.Open();
            _conn.Execute(@"DELETE FROM configs WHERE config_id = @config_id;", new { config_id = id });
        }
    }

    public List<Config> ReadAll()
    {
        using (_conn)
        {
            _conn.Open();
            return _conn.Query<Config>(@"SELECT * FROM configs").ToList();
        }
    }

    public Config ReadOneById(int id)
    {
        using (_conn)
        {
            _conn.Open();
            return _conn.QueryFirstOrDefault<Config>(@"SELECT * FROM configs WHERE config_id = @config_id", new { config_id = id })
            ?? throw new ArgumentOutOfRangeException(nameof(id));
        }
    }
}