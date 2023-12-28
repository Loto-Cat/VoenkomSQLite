using System.Collections.Generic;
public class ServiceSize
{ 
     DB db;
    public ServiceSize()
    {
        db = new DB();
    }
    public int GetNextId()
    {
        var conn = db.GetConnection();
        var maxId = conn.Table<Size>().OrderByDescending(o => o.ID_Size).FirstOrDefault()?.ID_Size;
        return (maxId ?? 0) + 1;
    }
    public Size GetID(int id)
    {
        return db.GetConnection().Table<Size>().Where(x => x.ID_Size == id).FirstOrDefault();
    }
    public IEnumerable<Size> GetVisits(int id)
    {
        return db.GetConnection().Table<Size>().Where(x => x.ID_Size == id);
    }
}
