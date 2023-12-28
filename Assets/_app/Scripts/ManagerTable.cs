using System;
using TMPro;
using UnityEngine;

public class ManagerTable : MonoBehaviour
{
    [SerializeField] private GameObject[] _updatedb;
    [SerializeField] private Transform[] _labletransform;
    [Header("Связи")]
    [SerializeField] private GetTable _gettable;
    [SerializeField] private TableRecord _tablerecord;
    [Header("Таблицы")]
    [SerializeField] private string[] visit;
    [SerializeField] private string[] position;
    [SerializeField] private string[] Training;
    [SerializeField] private string[] Vacation;
    [SerializeField] private string[] ParticipationInTraining;
    [Header("Изменение")]
    [SerializeField] private TMP_InputField[] _inputFields;
    private Service _service;
    [Header("Добавления")]
    private Conscript _currentConscript;
    private Place_of_service _currentPlace;
    private Size _currentSize;
    private Service_time _currentServiceTime;

    [Header("Сервис")]
    private ServiceConscript _serviceconscript;
    private ServiceSize _servicesize;
    private ServicePlace _serviceplace;
    private ServiceTime _servicetime;

    [Header("НЕбагАФича")]
    public TMP_Dropdown _dropdowncategory;
    private void Awake()
    {
        _dropdowncategory = GetComponentInChildren<TMP_Dropdown>();
    }
    private void Start()
    {
        _servicetime = new ServiceTime();
        _servicesize = new ServiceSize();
        _serviceconscript = new ServiceConscript();
        _serviceplace = new ServicePlace();
        _service = new Service();
        CreateFieldsdData();
    }
    public void CreateVisitDisplayID(Size size) => _tablerecord.ReceptionTime(size.Shoe_size);
    public void CreateConscriptDisplayID(Conscript conscriptData, Size size, Place_of_service place, Service_time time, Ready_Status status)
    {
        _currentConscript = conscriptData;
        _currentPlace = place;
        _currentSize = size;
        _currentServiceTime = time;
        _inputFields[0].text = conscriptData.Last_name;
        _inputFields[1].text = conscriptData.First_name;
        _inputFields[2].text = conscriptData.Midle_name;
        _inputFields[3].text = conscriptData.Date_of_birth;
        _inputFields[4].text = conscriptData.Passport;
        _inputFields[5].text = conscriptData.Phone;
        string number = Convert.ToString(place.Part_number);
        _inputFields[6].text = number;
        _inputFields[7].text = place.Location;
        _inputFields[8].text = time.Date_Start;
        _inputFields[9].text = time.Date_Ending;
        _inputFields[10].text = size.Headdress_size;
        _inputFields[11].text = size.Tunic_size;
        _inputFields[12].text = size.Shoe_size;
    }
    public void UpdateConscript()
    {
        _currentConscript.Last_name = _inputFields[0].text;
        _currentConscript.First_name = _inputFields[1].text;
        _currentConscript.Midle_name = _inputFields[2].text;
        _currentConscript.Date_of_birth = _inputFields[3].text;
        _currentConscript.Passport = _inputFields[4].text;
        _currentConscript.Phone = _inputFields[5].text;
        if (int.TryParse(_inputFields[6].text, out int cost))
            _currentPlace.Part_number = cost;
        _currentPlace.Location = _inputFields[7].text;
        _currentServiceTime.Date_Start = _inputFields[8].text;
        _currentServiceTime.Date_Ending = _inputFields[9].text;
        _currentSize.Headdress_size = _inputFields[10].text;
        _currentSize.Tunic_size = _inputFields[11].text;
        _currentSize.Shoe_size = _inputFields[12].text;
        _service.Update(_currentConscript);
        _service.Update(_currentPlace);
        _service.Update(_currentServiceTime);
        _service.Update(_currentSize);
        _gettable.OnGetTechniques();
    }
    public void CreateFieldsdData()
    {
        for (int i = 0; i < visit.Length; i++)
        {
                _updatedb[0] = Instantiate(_updatedb[0], _labletransform[i]);
                TextMeshProUGUI textFields = _updatedb[0].GetComponentInChildren<TextMeshProUGUI>();
                textFields.text = visit[i];
                _inputFields[i] = _updatedb[0].GetComponentInChildren<TMP_InputField>();
        }
    }
    public void AddConscript()
    {
        int nextIDC = _serviceconscript.GetNextID();
        int nextIDS = _servicesize.GetNextId();
        int nextIDP = _serviceplace.GetNextId();
        Conscript conscript = new Conscript
        {
            ID_Conscript = nextIDC,
            Size_ID = nextIDS,
            Place_of_service_ID = nextIDP,
            Status_ID = 0,
        };
        _service.Add(conscript);
        Size size = new Size
        {
            ID_Size = nextIDS,
        };
        _service.Add(size);
        Place_of_service place_Of_Service = new Place_of_service
        {
            ID_Place_of_service = nextIDP,
        };
        _service.Add(place_Of_Service);
        Service_time service_Time = new Service_time
        {
            Conscript_ID = nextIDC,
        };
        _service.Add(service_Time);
        _gettable.OnGetTechniques();
    }
    public void DeleteConscript(int conscriptid)
    {
        if(_service != null)
        {
            var con = _serviceconscript.GetID(conscriptid);
            var time = _servicetime.GetID(conscriptid);
            int placeid = con.Place_of_service_ID;
            int sizeid = con.Size_ID;
            var size = _servicesize.GetID(sizeid);
            var place = _serviceplace.GetID(placeid);
            _service.Delete(con);
            _service.Delete(time);
            _service.Delete(place);
            _service.Delete(size);
        }
        _gettable.OnGetTechniques();
    }
}
