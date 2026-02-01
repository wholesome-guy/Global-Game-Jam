using System;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    [SerializeField] private KeyboardInputManager keyboardInputManager;
    public static Action<ConversationTrigger> Trigger_Conversation_Event;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Interactable"))
        {
            keyboardInputManager.Can_Interact = true;
            InteractionSystem.Press_F_Visible_Event.Invoke(true);
            keyboardInputManager.Conversation_Trigger = other.GetComponent<ConversationTrigger>();

        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Interactable"))
        {
            keyboardInputManager.Can_Interact = false;
            InteractionSystem.Press_F_Visible_Event.Invoke(false);
            keyboardInputManager.Conversation_Trigger = null;

        }
    }
}
