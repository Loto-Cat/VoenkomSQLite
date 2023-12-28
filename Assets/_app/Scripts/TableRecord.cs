using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class TableRecord : MonoBehaviour
{
    [SerializeField] private GameObject _customerprefabs;
    [SerializeField] Transform _contentpanel;
    private GameObject[] Conscript = new GameObject[99];
    private int _index;
    private string _time;
    private IEnumerable<Service_time> _allVisitings;
    public void ReceptionTime(string time)
    {
        _time = time;
    }
    public void SetAllVisitings(IEnumerable<Service_time> allVisitings)
    {
        _allVisitings = allVisitings;
    }
    public void AddRecord(Conscript owner, Size sick)
    {
        GameObject newOwner = Instantiate(_customerprefabs, _contentpanel);
        Conscript[_index] = newOwner;
        _index++;
        TextMeshProUGUI[] textFields = newOwner.GetComponentsInChildren<TextMeshProUGUI>();
        textFields[0].text = owner.ID_Conscript.ToString();
        textFields[1].text = owner.First_name;
        textFields[2].text = owner.Phone;
        textFields[4].text = _time;
    }
    public void CreateRecords(Conscript owner, Size size)
    {
        GameObject newOwner = Instantiate(_customerprefabs, _contentpanel);
        Conscript[_index] = newOwner;
        _index++;
        TextMeshProUGUI[] textFields = newOwner.GetComponentsInChildren<TextMeshProUGUI>();
        textFields[0].text = owner.ID_Conscript.ToString();
        textFields[1].text = owner.First_name;
        textFields[2].text = owner.Phone;
        var visiting = _allVisitings.FirstOrDefault(v => v.ID_Place == size.ID_Size);
        if (visiting != null)
        {
            textFields[4].text = visiting.Date_Start;
        }

    }
}
