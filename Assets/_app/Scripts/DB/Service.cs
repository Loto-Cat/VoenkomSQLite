
using System.Collections.Generic;
public class Service
{
    DB db;

    public Service()
    {
        db = new DB();
    }
    public int Add<T>(T entity) where T : class
    {
        var conn = db.GetConnection();
        conn.Insert(entity);
        long lastId = conn.ExecuteScalar<long>("select last_insert_rowid()");
        return (int)lastId;
    }

    public IEnumerable<T> GetAll<T>() where T : class, new()
    {
        return db.GetConnection().Table<T>();
    }
    public int Delete<T>(T entity) where T : class
    {
        return db.GetConnection().Delete(entity);
    }

    public int Update<T>(T entity) where T : class
    {
        return db.GetConnection().Update(entity);
    }
}

