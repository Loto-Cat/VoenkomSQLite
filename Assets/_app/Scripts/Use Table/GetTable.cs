
using System.Linq;
using UnityEngine;

public class GetTable : MonoBehaviour
{
    [SerializeField] private TableDisplay _tabledisplay;
    private Service _service;
    private void Start()
    {
        _service = new Service();
        OnGetTechniques();
    }
    public void OnGetTechniques()
    {

        _tabledisplay.ClearTable();
        var conscripts = _service.GetAll<Conscript>();
        var status = _service.GetAll<Ready_Status>();
        foreach (var conscript in conscripts)
        {

            Ready_Status ConscriptStatus = status.FirstOrDefault(p => p.ID_Status == conscript.Status_ID);
            if (ConscriptStatus != null)
            {

                _tabledisplay.CreateDisplay(conscript, ConscriptStatus);
            }
        }
    }
}
