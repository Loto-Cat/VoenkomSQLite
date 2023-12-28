
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SearchManager : MonoBehaviour
{
    [SerializeField] public TMP_InputField _searchInputField;
    [SerializeField]private GetTable _employee;
    private void Start()
    {
       
    }
    public void OnSearch()
    {
        string searchText = _searchInputField.text;
        Debug.Log(searchText);
        //_employee.OnGetEmployeesByName(searchText);
        Debug.Log(searchText);
    }
}
