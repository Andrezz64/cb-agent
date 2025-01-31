using System.Data.SQLite;

public interface ISqlLiteDbContext
{
    public SQLiteConnection ConnectionInit();
}