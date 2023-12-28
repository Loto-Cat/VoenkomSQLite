public class ServiceConscript
{
    DB db;

    public ServiceConscript()
    {
        db = new DB();
    }
    public int GetNextID()
    {
        var conn = db.GetConnection();
        var maxId = conn.Table<Conscript>().OrderByDescending(o => o.ID_Conscript).FirstOrDefault()?.ID_Conscript;
        return (maxId ?? 0) + 1;
    }
    public Conscript GetID(int id)
    {
        return db.GetConnection().Table<Conscript>().Where(x => x.ID_Conscript == id).FirstOrDefault();
    }
}
