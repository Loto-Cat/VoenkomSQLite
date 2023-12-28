using SQLite4Unity3d;
public class Service_time
{
    [PrimaryKey, AutoIncrement]
    public int ID_Place { get; set; }
    public string Date_Start { get; set; }
    public string Date_Ending { get; set; }
    public int Conscript_ID { get; set; }
}
