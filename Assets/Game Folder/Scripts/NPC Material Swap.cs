using UnityEngine;

public class NPCMaterialSwap : MonoBehaviour
{
    [SerializeField] private MeshRenderer Renderer;
    [SerializeField] private Material[] Emotion_Materials;

    public void Material_Swap(int i)
    {
        switch (i)
        {
            case 0:
                Renderer.material = Emotion_Materials[0]; 
                break;
            case 1:
                Renderer.material = Emotion_Materials[1];
                break;
            case 2:
                Renderer.material = Emotion_Materials[2];
                break;
            case 3:
                Renderer.material = Emotion_Materials[3];
                break; 
        }
    }
}
