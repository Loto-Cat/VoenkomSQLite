
public class ServiceStatus
{
    DB db;

    public ServiceStatus()
    {
        db = new DB();
    }
    public Ready_Status GetID(int id)
    {
        return db.GetConnection().Table<Ready_Status>().Where(x => x.ID_Status == id).FirstOrDefault();
    }
}
