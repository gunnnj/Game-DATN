using System.Threading.Tasks;
using Script.Event;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SpItemUI : MonoBehaviour
{
    public Button heal;
    public Button drone;
    public TMP_Text amoutHeal;
    public GameObject droneSp;
    public MissionSO medicine;

    void OnEnable()
    {
        
    }
    void Start()
    {
        heal.onClick.AddListener(Heal);
        drone.onClick.AddListener(Drone);
    }
    public async void Heal(){
        ArmyEvent.heal?.Invoke();
        heal.interactable = false;
        await Task.Delay(30000);
        heal.interactable = true;
    }
    public async void Drone(){
        droneSp.SetActive(true);
        drone.interactable = false;
        await Task.Delay(10000);
        droneSp.SetActive(false);
        await Task.Delay(40000);
        drone.interactable = true;
    }
}
