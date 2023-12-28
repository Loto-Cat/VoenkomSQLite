using SQLite4Unity3d;
public class Place_of_service
{
    [PrimaryKey, AutoIncrement]
    public int ID_Place_of_service { get; set; }
    public int Part_number { get; set; }
    public string Location { get; set; }
}
