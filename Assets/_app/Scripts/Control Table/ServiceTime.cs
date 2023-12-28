public class ServiceTime
{
    DB db;

    public ServiceTime()
    {
        db = new DB();
    }
    public Service_time GetID(int id)
    {
        return db.GetConnection().Table<Service_time>().Where(x => x.Conscript_ID == id).FirstOrDefault();
    }
}
