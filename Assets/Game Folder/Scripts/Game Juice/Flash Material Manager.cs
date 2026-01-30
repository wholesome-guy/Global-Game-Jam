using System;
using System.Collections;
using UnityEngine;

public class FlashMaterialManager : MonoBehaviour
{



    public static Action<Renderer[], Material[], Material, int, float> Object_Array_Flash;
    public static Action<Renderer, Material, Material, int, float> Object_Single_Flash;



    private void OnEnable()
    {
        Object_Array_Flash += Material_Array_Flash;
        Object_Single_Flash += Material_Single_Flash;
    }
    private void OnDisable()
    {
        Object_Array_Flash -= Material_Array_Flash;
        Object_Single_Flash -= Material_Single_Flash;

    }

    #region Material Flash

    private void Material_Single_Flash(Renderer Mesh_Renderer, Material Original_Materials, Material Change, int Iterations, float Duration)
    {
        StartCoroutine(Single_Material_Change(Mesh_Renderer, Original_Materials, Change, Iterations, Duration));
    }
    private void Material_Array_Flash(Renderer[] Mesh_Renderer, Material[] Original_Materials, Material Change, int Iterations, float Duration)
    {
        StartCoroutine(Array_Material_Change(Mesh_Renderer, Original_Materials, Change, Iterations, Duration));
    }
    private IEnumerator Single_Material_Change(Renderer Mesh_Renderer, Material Original_Materials, Material Change, int Iterations, float Duration)
    {

        for (int i = 0; i < Iterations; i++)
        {

            Mesh_Renderer.sharedMaterial = Change;

            yield return new WaitForSeconds(Duration);

            Mesh_Renderer.sharedMaterial = Original_Materials;

            yield return new WaitForSeconds(Duration);


            Duration = Mathf.Max(0.05f, Duration * 0.9f);
        }

    }
    private IEnumerator Array_Material_Change(Renderer[] Mesh_Renderer, Material[] Original_Materials, Material Change, int Iterations, float Duration)
    {

        for (int i = 0; i < Iterations; i++)
        {
            for (int k = 0; k < Mesh_Renderer.Length; k++)
            {
                Mesh_Renderer[k].sharedMaterial = Original_Materials[k];
                Mesh_Renderer[k].sharedMaterial = Change;
            }

            yield return new WaitForSeconds(Duration);

            for (int k = 0; k < Mesh_Renderer.Length; k++)
            {
                Mesh_Renderer[k].sharedMaterial = Original_Materials[k];
            }

            yield return new WaitForSeconds(Duration);

            Duration = Mathf.Max(0.05f, Duration * 0.9f);
        }

    }

    #endregion
}
