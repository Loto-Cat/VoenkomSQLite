using SQLite4Unity3d;
public class Size
{
    [PrimaryKey, AutoIncrement]
    public int ID_Size { get; set; }
    public string Headdress_size { get; set; }
    public string Tunic_size { get; set; }
    public string Shoe_size { get; set; }
}
