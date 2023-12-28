using UnityEngine;

public class Choosing_category : MonoBehaviour
{
    public int ID_Conscript;
    private MonoCategory _visit;
    private void Awake()
    {
    }
    private void Start()
    {
        _visit = GetComponentInParent<MonoCategory>();
    }
    public void GetCategoryID(int id) => ID_Conscript = id;
    public void Choice(int value)
    {
        if (_visit != null)
        {
            value++;
            switch (value)
            {
                case 0:
                    _visit.NotNullCategory(ID_Conscript, value);
                    break;
                case 1:
                    _visit.NotNullCategory(ID_Conscript, value);
                    break;
                case 2:
                    _visit.NotNullCategory(ID_Conscript, value);
                    break;
                case 3:
                    _visit.NotNullCategory(ID_Conscript, value);
                    break;
                case 4:
                    _visit.NotNullCategory(ID_Conscript, value);
                    break;
                case 5:
                    _visit.NotNullCategory(ID_Conscript, value);
                    break;
                case 6:
                    _visit.NotNullCategory(ID_Conscript, value);
                    break;
                case 7:
                    _visit.NotNullCategory(ID_Conscript, value);
                    break;
                case 8:
                    _visit.NotNullCategory(ID_Conscript, value);
                    break;
                case 9:
                    _visit.NotNullCategory(ID_Conscript, value);
                    break;
                case 10:
                    _visit.NotNullCategory(ID_Conscript, value);
                    break;
                default:
                    break;
            }
        }

    }
}
