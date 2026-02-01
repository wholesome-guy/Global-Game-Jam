using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffectsManager : MonoBehaviour
{

    public static SoundEffectsManager instance;

    private ObjectPoolManager Object_Pool_Manager;
    private void Awake()
    {

        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }

    }

    private void Start()
    {
        Object_Pool_Manager = ObjectPoolManager.instance;
    }


    public void Play_Multiple_Sound_Effects(AudioClip[] AudioClips, Transform Spawn_Transform, float Spacial_Blend_Value)
    {
        GameObject Audio_Source_Object = Object_Pool_Manager.Instantiate_Sound_Effects_Object();
        Audio_Source_Object.transform.SetPositionAndRotation(Spawn_Transform.position, Quaternion.identity);

        AudioSource Audio_Source = Audio_Source_Object.GetComponent<AudioSource>();

        int Random_Int = Random.Range(0, AudioClips.Length);
        Audio_Source.clip = AudioClips[Random_Int];

        float Random_Pitch = Random.Range(0.8f, 1.2f);
        Audio_Source.pitch = Random_Pitch;

        Audio_Source.spatialBlend = Spacial_Blend_Value;

        Audio_Source.Play();


        float lenght = Audio_Source.clip.length;

        Object_Pool_Manager.Destroy_Sound_Effects_Object(lenght, Audio_Source_Object);
    }

    public void Play_Single_Sound_Effect(AudioClip AudioClip, Transform Spawn_Transform, float Volume, float Spacial_Blend_Value)
    {
        GameObject Audio_Source_Object = Object_Pool_Manager.Instantiate_Sound_Effects_Object();
        Audio_Source_Object.transform.SetPositionAndRotation(Spawn_Transform.position, Quaternion.identity);

        AudioSource Audio_Source = Audio_Source_Object.GetComponent<AudioSource>();

        Audio_Source.clip = AudioClip;

        float Random_Pitch = Random.Range(0.8f, 1.2f);
        Audio_Source.pitch = Random_Pitch;

        Audio_Source.spatialBlend = Spacial_Blend_Value;
        Audio_Source.volume = Volume;

        Audio_Source.Play();


        float lenght = Audio_Source.clip.length;

        Object_Pool_Manager.Destroy_Sound_Effects_Object(lenght, Audio_Source_Object);
    }

    [SerializeField] private AudioClip Hover;
    [SerializeField] private AudioClip UnHover;
    [SerializeField] private AudioClip Click;
 

    public void UI_Hover_SFX()
    {
        Play_Single_Sound_Effect(Hover, transform, 0.6f, 0);
    }
    public void UI_UnHover_SFX()
    {
        Play_Single_Sound_Effect(UnHover, transform, 0.6f, 0);
    }
    public void UI_Click_SFX()
    {
        Play_Single_Sound_Effect(Click, transform, 0.6f, 0);
    }

    
}
