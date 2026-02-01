using System.Collections;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.Rendering;
using System;
using DG.Tweening;
using UnityEngine.UI;

public class TransitionManager : MonoBehaviour
{
    public static Action<CanvasGroup, float, float, float> UI_Fader_Event;

    public static Action<Texture2D, float, float,float> Transition_Screen_Event;

    private int Transition_Amount_ID = Shader.PropertyToID("_Transition_Amount");
    private int Transition_Texture_ID = Shader.PropertyToID("_Transition_Texture");

    [SerializeField] private Image Transition_Image;
    [SerializeField] private Material Transition_Material;

    private void OnEnable()
    {  
        UI_Fader_Event += UI_Fader_Function;
        Transition_Screen_Event += Transition_Function;
    }
    private void OnDisable()
    {     
        UI_Fader_Event -= UI_Fader_Function;
        Transition_Screen_Event -= Transition_Function;

    }

    private void UI_Fader_Function(CanvasGroup Canvas_Group, float Start_Value, float End_Value, float Duration)
    {
        StartCoroutine(UI_Fader(Canvas_Group, Start_Value, End_Value, Duration));
    }

    private IEnumerator UI_Fader(CanvasGroup Canvas_Group, float Start_Value, float End_Value, float Duration)
    {
        float t = 0;
        Canvas_Group.alpha = Start_Value;
        while (t < Duration)
        {
            t += Time.deltaTime;
            Canvas_Group.alpha = Mathf.Lerp(Start_Value, End_Value, t / Duration);
            yield return null;
        }

        Canvas_Group.alpha = End_Value;
    }

    public void Transition_Function(Texture2D Transition_Texture, float Start, float End, float Duration)
    {
        Transition_Image.gameObject.SetActive(true);
        Transition_Material = Transition_Image.material; 
        Transition_Material.SetTexture(Transition_Texture_ID, Transition_Texture);

        StartCoroutine(Transition_Lerp(Start,End,Duration));
    }

    private IEnumerator Transition_Lerp(float Start,float End,float Duration)
    {
        float t = 0;
        float Lerp_Amount = Start;
        while (t < Duration)
        {
            t += Time.deltaTime;
            Lerp_Amount = Mathf.Lerp(Start, End, t / Duration);
            Transition_Material.SetFloat(Transition_Amount_ID, Lerp_Amount);
            yield return null;
        }
        Transition_Material.SetFloat(Transition_Amount_ID, End);
        yield return new WaitForSeconds(0.5f);
        Transition_Image.gameObject.SetActive(false);

    }
}

