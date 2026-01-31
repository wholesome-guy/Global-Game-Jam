using DialogueEditor;
using DG.Tweening;
using TMPro;
using UnityEngine;
using System.Collections;

public class ReputationSystem : MonoBehaviour
{
    [SerializeField] private float Max_Reputation = 1000f;
    private float Current_Reputation;
    public int Current_Reputation_Round;
    private float Ratio_Current_Max_Reputation;

    [SerializeField] private TextMeshProUGUI Reputation_Text;
    [SerializeField] private TextMeshProUGUI Reputation_Change_Text;

    [SerializeField] private Color Increase_Color;
    [SerializeField] private Color Decrease_Color;

    [SerializeField] private float Change_Text_Disappear_Time;
    [SerializeField] private CanvasGroup Reputation_Change_group;

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

        Reputation_Change_Text.text = (change < 0 ? "+" : "-") + (Mathf.Abs(change) * 100f / Max_Reputation).ToString("f2") + "%";

        Reputation_Change_Text.DOColor((change < 0) ? Increase_Color : Decrease_Color, 0);

        Reputation_Change_group.alpha = 1;
        StartCoroutine(Change_Fade_Out());
    }

    private IEnumerator Change_Fade_Out()
    {
        yield return new WaitForSeconds(Change_Text_Disappear_Time+0.5f);

        TransitionManager.UI_Fader_Event.Invoke(Reputation_Change_group, 1, 0, Change_Text_Disappear_Time);

    }


}
