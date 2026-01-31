using DialogueEditor;
using TMPro;
using UnityEngine;

public class EnergySystem : MonoBehaviour
{
    [SerializeField] private float Max_Energy = 1000f;
    private float Current_Energy;
    public int Current_Energy_Round;
    [SerializeField] private float Passive_Energy_Loss = 0.05f;
    private float Ratio_Current_Max_Energy;
    [SerializeField] private TextMeshProUGUI Energy_Text;

    private void Start()
    {
        Current_Energy = Max_Energy;
    }
    private void Update()
    {
        Ratio_Current_Max_Energy = Current_Energy / Max_Energy;

        Energy_Text.text = (Ratio_Current_Max_Energy * 100f).ToString("f2") + "%";

        Current_Energy -= Passive_Energy_Loss * Time.deltaTime;
        Current_Energy_Round = Mathf.RoundToInt(Current_Energy);
    }

    public void Energy_Deplete(float change)
    {
        Current_Energy -= change;
    }

    public void Set_Energy_Before_Decision()
    {
        ConversationManager.Instance.SetInt("Energy", Current_Energy_Round);
    }
}
