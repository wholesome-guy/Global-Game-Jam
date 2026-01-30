using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ButtonScript : MonoBehaviour
{
    [SerializeField] private Transform Button_Object;
    [SerializeField] private TextMeshProUGUI Button_Text;
    [SerializeField] private Image Button_BackGround;


    [Header("Colour")]
    public Color Hover_Colour;
    public Color Unhover_Colour;
    [SerializeField] private Color Background_Colour;

    [Header("Scale and Duration")]
    [SerializeField] private float Hover_Scale = 1.5f;
    [SerializeField] private float UnHover_Scale = 1.0f;
    [SerializeField] private float Duration = 0.25f;

    [Header("Position")]
    [SerializeField] private Vector2 Hover_Position;
    [SerializeField] private Vector2 Unhover_Position;

    private void Start()
    {
        Button_Text.color = Unhover_Colour;
        Button_BackGround.color = Background_Colour;
        Button_BackGround.gameObject.SetActive(false);

    }

    public void On_Hover_Button()
    {
        Button_Object.transform.DOScale(Hover_Scale, Duration);
        Button_Object.transform.DOLocalMove(Hover_Position, Duration);
        Button_Text.color = Hover_Colour;
        Button_BackGround.gameObject.SetActive(true);
        SoundEffectsManager.instance.UI_Hover_SFX();
    }

    public void On_Unhover_Button()
    {
        Button_Object.transform.DOScale(UnHover_Scale, 0.25f);
        Button_Object.transform.DOLocalMove(Unhover_Position, Duration);

        Button_Text.color = Unhover_Colour;
        Button_BackGround.gameObject.SetActive(false);
        SoundEffectsManager.instance.UI_UnHover_SFX();

    }
}
