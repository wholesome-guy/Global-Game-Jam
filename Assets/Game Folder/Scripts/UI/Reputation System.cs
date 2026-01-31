using DialogueEditor;
using TMPro;
using UnityEngine;

public class ReputationSystem : MonoBehaviour
{
    [SerializeField] private float Max_Reputation = 1000f;
    private float Current_Reputation;
    public int Current_Reputation_Round;
    private float Ratio_Current_Max_Reputation;
    [SerializeField] private TextMeshProUGUI Reputation_Text;

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

    }

    
}
