using UnityEngine.UI;
using UnityEngine;

public class SettingsManager : MonoBehaviour
{
    [SerializeField] private GameObject Settings_Screen;

    [SerializeField] private Slider Sensitivity_Slider;
    [SerializeField] private Slider Master_Slider;
    [SerializeField] private Slider Music_Slider;
    [SerializeField] private Slider SFX_Slider;
    [SerializeField] private SettingsValueHolder Settings_Value;
    private void Start()
    {
        Sensitivity_Slider.value = Settings_Value.Mouse_Sensitivity;
        Master_Slider.value = Settings_Value.Master;
        Music_Slider.value = Settings_Value.Music;
        SFX_Slider.value = Settings_Value.SFX;
    }

    public void Click_Back()
    {
        Settings_Screen.SetActive(false);
        SoundEffectsManager.instance.UI_Click_SFX();
    }
}
