using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class SettingsButton : MonoBehaviour
{
    [SerializeField] private Transform Settings_Button_Object;
    [SerializeField] private Image Settings_Button_Image;

    [Header("Rotation")]
    [SerializeField] private Vector3 Rotate_Unhover;
    [SerializeField] private Vector3 Rotate_Hover;

    [Header("Position")]
    [SerializeField] private Vector2 Hover_Position;
    [SerializeField] private Vector2 UnHover_Position;

    [Header("Scale and Duration")]
    [SerializeField] private float Hover_Scale = 1.5f;
    [SerializeField] private float UnHover_Scale = 1.0f;
    [SerializeField] private float Duration = 0.25f;

    [Header("Colour")]
    [SerializeField] private Color Hover_Colour;
    [SerializeField] private Color UnHover_Colour;

    public void On_Hover_Settings_Button()
    {
        Settings_Button_Object.DOScale(Hover_Scale, Duration);
        Settings_Button_Object.DOLocalMove(Hover_Position, Duration);
        Settings_Button_Image.transform.DOLocalRotate(Rotate_Hover, Duration);
        Settings_Button_Image.color = Hover_Colour;
        SoundEffectsManager.instance.UI_Hover_SFX();
    }

    public void On_Unhover_Settings_Button()
    {
        Settings_Button_Object.DOScale(UnHover_Scale, Duration);
        Settings_Button_Object.DOLocalMove(UnHover_Position, Duration);
        Settings_Button_Image.transform.DOLocalRotate(Rotate_Unhover, Duration);
        Settings_Button_Image.color = UnHover_Colour;
        SoundEffectsManager.instance.UI_UnHover_SFX();

    }
}
