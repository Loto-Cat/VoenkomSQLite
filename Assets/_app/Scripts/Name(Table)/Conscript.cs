using SQLite4Unity3d;

public class Conscript
{
    [PrimaryKey, AutoIncrement]
    public int ID_Conscript { get; set; }
    public string Last_name { get; set; }
    public string First_name { get; set; }
    public string Midle_name { get; set; }
    public string Date_of_birth { get; set; }
    public string Passport { get; set; }
    public string Phone { get; set; }
    public int Status_ID { get; set; }
    public int Size_ID { get; set; }
    public int Place_of_service_ID { get; set; }

}
