using DG.Tweening;
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
    [SerializeField] private TextMeshProUGUI Energy_Change_Text;
    [SerializeField] private Color Increase_Color;
    [SerializeField] private Color Transparent_Increase_Color;
    [SerializeField] private Color Decrease_Color;
    [SerializeField] private Color Transparent_Decrease_Color;
    [SerializeField] private float Change_Text_Disappear_Time;

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

        if (Mathf.Abs(change) <= Passive_Energy_Loss) return;

        Energy_Change_Text.text = (change < 0 ? "+" : "-") + (Mathf.Abs(change) * 100f / Max_Energy).ToString("f2") + "%";

        Energy_Change_Text.DOColor((change < 0) ? Increase_Color : Decrease_Color, 0);

        Energy_Change_Text.DOColor((change < 0) ? Transparent_Increase_Color : Transparent_Decrease_Color, Change_Text_Disappear_Time);
    }

    public void Set_Energy_Before_Decision()
    {
        ConversationManager.Instance.SetInt("Energy", Current_Energy_Round);
    }
}
