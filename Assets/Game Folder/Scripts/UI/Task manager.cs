using System.Linq.Expressions;
using TMPro;
using UnityEngine;

public class Taskmanager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI Task_text;

    public void New_Task(int i)
    {
        switch (i)
        {
            case 0:
                Task_text.text = "Current Task : " + "Get Bread";
                break;

            case 1:
                Task_text.text = "Current Task : " + "Buy a Book";
                break;

            case (2):
                Task_text.fontSize = 32;
                Task_text.text = "Current Task : " + "Return the Wallet to Police";
                break;

            case (3):
                Task_text.text = "Current Task : " + "Walk Home";
                break;
        }
    }
    [SerializeField] private AudioClip Task_Complete_clip;
    public void Task_Complete()
    {
        SoundEffectsManager.instance.Play_Single_Sound_Effect(Task_Complete_clip,transform,0.2f,0f);
    }
}
