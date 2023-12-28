using UnityEngine;

public class MonoCategory : MonoBehaviour
{
    private Service _service;
    private ServiceConscript _serviceConscript;
    [SerializeField] private Canvas _canvas;
    [SerializeField] private TableRecord _table;
    [SerializeField] private GetTable _getTable;
    void Start()
    {
        _service = new Service();
        _serviceConscript = new ServiceConscript();
    }
    public void NotNullCategory(int id, int value)
    {
        var conscript = _serviceConscript.GetID(id);
        conscript.Status_ID = value;
        _service.Update(conscript);
        _getTable.OnGetTechniques();
    }
}
