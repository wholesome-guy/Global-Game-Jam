using UnityEngine;
using System;
using DialogueEditor;

public class InteractionSystem : MonoBehaviour
{
    public static Action End_Interaction_Event;

    public static Action<bool> Press_F_Visible_Event;

    [SerializeField] private GameObject Press_F_Obj;

    private void OnEnable()
    {
        Press_F_Visible_Event += Press_F_Function;
    }
    private void OnDisable()
    {
        Press_F_Visible_Event += Press_F_Function;
    }
    public void End_Interaction_Function()
    {
        End_Interaction_Event.Invoke();
    }

    private void Press_F_Function(bool Should_Be_Visible)
    {
        Press_F_Obj.SetActive(Should_Be_Visible);
    }

   
}
