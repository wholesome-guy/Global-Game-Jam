using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

[CreateAssetMenu(fileName = "Scriptable Objects",menuName = "Settings Values")]
public class SettingsValueHolder : ScriptableObject
{
    public float Mouse_Sensitivity;

    public float Master = 0.5F;
    public float Music = 0.5F;
    public float SFX = 0.5F;

    [SerializeField] private AudioMixer Audio_Mixer;
    private const string Master_Volume_ID = "Master_Volume";
    private const string Music_Volume_ID = "Music_Volume";
    private const string SFX_Volume_ID = "Music_Volume";

    private const string MOUSE_KEY = "Mouse_Sensitivity";
    private const string MASTER_KEY = "Master_Volume";
    private const string MUSIC_KEY = "Music_Volume";
    private const string SFX_KEY = "SFX_Volume";

    public void LoadSettings()
    {
        Mouse_Sensitivity = PlayerPrefs.GetFloat(MOUSE_KEY, 1f);
        Master = PlayerPrefs.GetFloat(MASTER_KEY, 0.5f);
        Music = PlayerPrefs.GetFloat(MUSIC_KEY, 0.5f);
        SFX = PlayerPrefs.GetFloat(SFX_KEY, 0.5f);

        // Apply to mixer immediately
        ApplyAudio();
    }

    public void SaveSettings()
    {
        PlayerPrefs.SetFloat(MOUSE_KEY, Mouse_Sensitivity);
        PlayerPrefs.SetFloat(MASTER_KEY, Master);
        PlayerPrefs.SetFloat(MUSIC_KEY, Music);
        PlayerPrefs.SetFloat(SFX_KEY, SFX);
        PlayerPrefs.Save();
    }

    public void Sensitivity_Function(float Level)
    {
        Mouse_Sensitivity = Level;
        PlayerPrefs.SetFloat(MOUSE_KEY, Mouse_Sensitivity);
    }

    public void Master_Volume(float Level)
    {
        Level = Mathf.Clamp(Level, 0.0001f, 1f);
        Master = Level;
        SetMixerVolume(Master_Volume_ID, Level);
        PlayerPrefs.SetFloat(MASTER_KEY, Master);
    }

    public void Music_Volume(float Level)
    {
        Level = Mathf.Clamp(Level, 0.0001f, 1f);
        Music = Level;
        SetMixerVolume(Music_Volume_ID, Level);
        PlayerPrefs.SetFloat(MUSIC_KEY, Music);
    }

    public void Sound_Effect_Volume(float Level)
    {
        Level = Mathf.Clamp(Level, 0.0001f, 1f);
        SFX = Level;
        SetMixerVolume(SFX_Volume_ID, Level);
        PlayerPrefs.SetFloat(SFX_KEY, SFX);
    }

    private void SetMixerVolume(string parameter, float linearLevel)
    {
        float dB = Mathf.Log10(linearLevel) * 80;
        Audio_Mixer.SetFloat(parameter, dB);
    }

    private void ApplyAudio()
    {
        SetMixerVolume(Master_Volume_ID, Master);
        SetMixerVolume(Music_Volume_ID, Music);
        SetMixerVolume(SFX_Volume_ID, SFX);
    }

}
