using System.Collections.Generic;
public class ServicePlace
{
    DB db;

    public ServicePlace()
    {
        db = new DB();
    }
    public int GetNextId()
    {
        var conn = db.GetConnection();
        var maxId = conn.Table<Place_of_service>().OrderByDescending(o => o.ID_Place_of_service).FirstOrDefault()?.ID_Place_of_service;
        return (maxId ?? 0) + 1;
    }
    public Place_of_service GetID(int id)
    {
        return db.GetConnection().Table<Place_of_service>().Where(x => x.ID_Place_of_service == id).FirstOrDefault();
    }
}
