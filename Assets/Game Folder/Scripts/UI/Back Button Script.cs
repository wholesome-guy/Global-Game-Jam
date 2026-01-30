using DG.Tweening;
using UnityEngine.UI;
using UnityEngine;

public class BackButtonScript : MonoBehaviour
{
    [SerializeField] private Transform Back_Button;
    [SerializeField] private Image Back_Image;

    public void Hover_Back_Button()
    {
        Back_Button.DOScale(3f, 0.25f);
        Back_Image.color = Color.white;
        SoundEffectsManager.instance.UI_Hover_SFX();

    }
    public void Unhover_Back_Button()
    {
        Back_Button.DOScale(2f, 0.25f);
        Back_Image.color = Color.black;
        SoundEffectsManager.instance.UI_UnHover_SFX();

    }
   
}
