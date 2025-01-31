namespace cb_agent.Repository.Classes;

using System;
using System.Collections.Generic;
using System.Data.SQLite;
using Dapper;
using cb_agent;
using cb_agent.Repository.Interfaces;

public class LogRepository : ILog
{
    private readonly ISqlLiteDbContext _dbContext;
    private readonly SQLiteConnection _conn;

    public LogRepository(ISqlLiteDbContext dbContext)
    {
        _dbContext = dbContext;
        _conn = _dbContext.ConnectionInit();
    }

    public void Create(Log log)
    {
        if (log == null)
        {
            throw new ArgumentNullException(nameof(log), "The log object cannot be null.");
        }

        using (_conn)
        {
            _conn.Open();
            _conn.Execute(@"INSERT INTO logs (program_id, level, title, mensage, date) VALUES (@ProgramId, @Level, @Title, @Mensage, @Date)",log); // Use an anonymous object to be explicit
        }
    }

    public void Delete(int id)
    {
        using (_conn)
        {
            _conn.Open();
            _conn.Execute("DELETE FROM logs WHERE log_id = @id", new { id });
        }
    }

    public List<Log> ReadAll()
    {
        using (_conn)
        {
            _conn.Open();
            return _conn.Query<Log>("SELECT * FROM logs").ToList();
        }
    }

    public Log ReadOneById(int id)
    {
        using (_conn)
        {
            _conn.Open();
            return _conn.QueryFirstOrDefault<Log>("SELECT * FROM logs WHERE log_id = @id", new { id });
        }
    }

    public void Update(Log log)
    {
        using (_conn)
        {
            _conn.Open();
            _conn.Execute(@"UPDATE logs SET program_id = @program_id, level = @level, title = @title, mensage = @mensage, date = @date 
                             WHERE log_id = @log_id", log);
        }
    }
}