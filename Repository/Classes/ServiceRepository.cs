namespace cb_agent.Repository.Classes;

using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SQLite;
using Dapper;
using cb_agent;
using cb_agent.Repository.Interfaces;

public class ServiceRepository : IService
{
    private readonly ISqlLiteDbContext _dbContext;
    private readonly SQLiteConnection _conn;

    public ServiceRepository(ISqlLiteDbContext dbContext)
    {
        _dbContext = dbContext;
        _conn = _dbContext.ConnectionInit();
    }

    public void Create(Service service)
    {
        using (_conn)
        {
            _conn.Open();
            _conn.Execute(@"INSERT INTO services (name, exe_path, params, status,auto_start) 
                             VALUES (@Name, @ExePath, @Params, @Status,@AutoStart)", service); 
        }
    }

    public void Delete(int id)
    {
        using (_conn)
        {
            _conn.Open();
            _conn.Execute("DELETE FROM services WHERE service_id = @id", new { id });
        }
    }

    public List<Service> ReadAll()
    {
        using (_conn)
        {
            _conn.Open();
            return _conn.Query<Service>("SELECT * FROM services").ToList();
        }
    }

     public List<Service> ReadAllAutoStart()
    {
        using (_conn)
        {
            _conn.Open();
            return _conn.Query<Service>("SELECT * FROM services WHERE auto_start = 1").ToList();
        }
    }

    public Service ReadOneById(int id)
    {
        using (_conn)
        {
            _conn.Open();
            return _conn.QueryFirstOrDefault<Service>("SELECT * FROM services WHERE service_id = @id", new { id });
        }
    }

    public void Update(Service service)
    {
        using (_conn)
        {
            _conn.Open();
            _conn.Execute(@"UPDATE services SET name = @name, exe_path = @exe_path, ""params"" = @params, status = @status 
                             WHERE service_id = @service_id", service);
        }
    }
}