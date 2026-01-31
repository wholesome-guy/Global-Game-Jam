using DialogueEditor;
using DG.Tweening;
using TMPro;
using UnityEngine;

public class ReputationSystem : MonoBehaviour
{
    [SerializeField] private float Max_Reputation = 1000f;
    private float Current_Reputation;
    public int Current_Reputation_Round;
    private float Ratio_Current_Max_Reputation;
    [SerializeField] private TextMeshProUGUI Reputation_Text;
    [SerializeField] private TextMeshProUGUI Reputation_Change_Text;
    [SerializeField] private Color Increase_Color;
    [SerializeField] private Color Transparent_Increase_Color;
    [SerializeField] private Color Decrease_Color;
    [SerializeField] private Color Transparent_Decrease_Color;
    [SerializeField] private float Change_Text_Disappear_Time;

    private void Start()
    {
        Current_Reputation = Max_Reputation/2;
        Reputation_Deplete(0);
    }

    public void Reputation_Deplete(float change)
    {
        Current_Reputation -= change;

        Ratio_Current_Max_Reputation = Current_Reputation / Max_Reputation;

        Reputation_Text.text = (Ratio_Current_Max_Reputation * 100f).ToString("f2") + "%";


        if (Mathf.Abs(change) <= 0.001f) return;

        Reputation_Change_Text.text = (change * 100f / Max_Reputation).ToString("f2") + "%";

        Reputation_Change_Text.color = (change < 0) ? Increase_Color : Decrease_Color;

        Reputation_Change_Text.DOColor((change < 0) ? Transparent_Increase_Color : Transparent_Decrease_Color, Change_Text_Disappear_Time);

    }

    
}
