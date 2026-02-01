using UnityEngine;

public class NPCMaterialSwap : MonoBehaviour
{
    [SerializeField] private MeshRenderer Renderer;
    [SerializeField] private Material[] Emotion_Materials;

    [SerializeField] private AudioClip c_Happy;
    [SerializeField] private AudioClip c_Sad;
    [SerializeField] private AudioClip c_Angry;

    public void Material_Swap(int i)
    {
        switch (i)
        {
            case 0:
                Renderer.material = Emotion_Materials[0];
                SoundEffectsManager.instance.Play_Single_Sound_Effect(c_Happy, transform,1, 0.5f);
                ParticlesManager.Health_Particles_Event.Invoke(transform.position);
                break;
            case 1:
                Renderer.material = Emotion_Materials[1];

                break;
            case 2:
                Renderer.material = Emotion_Materials[2];
                SoundEffectsManager.instance.Play_Single_Sound_Effect(c_Sad, transform, 1, 0.5f);
                ParticlesManager.Capture_Particles_Event.Invoke(transform.position);


                break;
            case 3:
                Renderer.material = Emotion_Materials[3];
                SoundEffectsManager.instance.Play_Single_Sound_Effect(c_Angry, transform, 1, 0.5f);
                ParticlesManager.Hit_Particles_Event.Invoke(transform.position);
                CameraManager.Camera_Shake_Event.Invoke();


                break; 
        }
    }
}
