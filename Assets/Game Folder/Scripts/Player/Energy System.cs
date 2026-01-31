using DG.Tweening;
using DialogueEditor;
using TMPro;
using UnityEngine;
using System.Collections;


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
    [SerializeField] private Color Decrease_Color;

    [SerializeField] private CanvasGroup Energy_Change_group;
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

        TransitionManager.UI_Fader_Event.Invoke(Energy_Change_group, 0, 1, Change_Text_Disappear_Time);

        StartCoroutine(Change_Fade_Out());
    }

    private IEnumerator Change_Fade_Out()
    {
        yield return new WaitForSeconds(Change_Text_Disappear_Time + 0.5f);

        TransitionManager.UI_Fader_Event.Invoke(Energy_Change_group, 1, 0, Change_Text_Disappear_Time);

    }

    public void Set_Energy_Before_Decision()
    {
        ConversationManager.Instance.SetInt("Energy", Current_Energy_Round);
    }
}
