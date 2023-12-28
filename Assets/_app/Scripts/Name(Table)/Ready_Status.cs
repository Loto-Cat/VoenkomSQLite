using SQLite4Unity3d;
public class Ready_Status
{
    [PrimaryKey, AutoIncrement]
    public int ID_Status { get; set; }
    public string Shelf_life_category { get; set; }
    public string Status_level { get; set; }
}
