using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TableDisplay : MonoBehaviour
{
    public GameObject ConscriptPrefab;
    public Transform contentPanel;
    public GameObject[] Visit = new GameObject[1000];
    private Service _service;
    private void Awake()
    {
        _service = new Service();
    }
    public void CreateDisplay(Conscript conscript, Ready_Status status)
    {
        GameObject newConscript = Instantiate(ConscriptPrefab, contentPanel);
        Visit[conscript.ID_Conscript] = newConscript;
        newConscript.GetComponent<TaibleID>().GetConscriptID(conscript.ID_Conscript);
        TextMeshProUGUI[] textFields = newConscript.GetComponentsInChildren<TextMeshProUGUI>();
        TMP_Dropdown dropdown = newConscript.GetComponentInChildren<TMP_Dropdown>();
        dropdown.GetComponent<Choosing_category>().GetCategoryID(conscript.ID_Conscript);
        textFields[0].text = conscript.ID_Conscript.ToString();
        textFields[1].text = conscript.Last_name;
        textFields[2].text = conscript.First_name;
        textFields[3].text = conscript.Midle_name;
        textFields[4].text = conscript.Date_of_birth;
        textFields[5].text = status.Shelf_life_category;
        OnGetDropdown(dropdown, status.ID_Status);
    }
    public void OnGetDropdown(TMP_Dropdown dropdown, int active)
    {
        dropdown.ClearOptions();
        active--;
        var status = _service.GetAll<Ready_Status>();
        List<string> shelfLifeCategories = new List<string>();
        foreach (var statu in status)
        {
            shelfLifeCategories.Add(statu.Shelf_life_category);
        }
        dropdown.AddOptions(shelfLifeCategories);
        dropdown.value = active;
    }
    public void ClearTable()
    {
        foreach (GameObject e in Visit)
        {
            Destroy(e);
        }
    }
}