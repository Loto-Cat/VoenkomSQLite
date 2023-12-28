using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class TaibleID : MonoBehaviour, IPointerClickHandler
{
    [Header("Связи")]
    [SerializeField] private ManagerTable _managerTable;
    private ServiceConscript _serviceconscript;
    private ServiceSize _servicesize;
    private ServicePlace _serviceplace;
    private ServiceTime _servicetime;
    private ServiceStatus _servicestatus;
    public int ID_conscript;
    private GameObject _canvas;
    private Conscript _conscript;
    private void Start()
    {
        _canvas = GameObject.Find("Visit");
        _serviceconscript = new ServiceConscript();
        _servicesize = new ServiceSize();
        _serviceplace = new ServicePlace();
        _servicetime = new ServiceTime();
        _servicestatus = new ServiceStatus();
        _managerTable = FindObjectOfType<ManagerTable>();
        _conscript = _serviceconscript.GetID(ID_conscript);
    }
    public void GetConscriptID(int id) => ID_conscript = id;
    public void GetRowConscript()
    {
        if (_conscript != null)
        {
            int sizeid = _conscript.Size_ID;
            int placeid = _conscript.Place_of_service_ID;
            int statusid = _conscript.Status_ID;
            var status = _servicestatus.GetID(statusid);
            var place = _serviceplace.GetID(placeid);
            var size = _servicesize.GetID(sizeid);
            var time = _servicetime.GetID(ID_conscript);
            _managerTable.CreateConscriptDisplayID(_conscript, size, place, time, status);
            var canvas = _canvas.GetComponent<Canvas>();
            canvas.enabled = true;
        }
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            DeleteObject();
        }
    }
    private void DeleteObject()
    {
        _managerTable.DeleteConscript(ID_conscript);
        Destroy(gameObject);
    }

}
