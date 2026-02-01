using System;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    [SerializeField] private KeyboardInputManager keyboardInputManager;
    public static Action<ConversationTrigger> Trigger_Conversation_Event;
    [SerializeField] private PlayerMovement Player_Movement;

    [SerializeField] private NPCManager Colleague;
    [SerializeField] private NPCManager Crush;
    [SerializeField] private NPCManager Neighbour;

    [SerializeField] private AudioClip Encounter;
    [SerializeField] private AudioClip Home;

    public bool Returned_Wallet = false;
    public static Action Victory_Event;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Interactable"))
        {
            keyboardInputManager.Can_Interact = true;
            InteractionSystem.Press_F_Visible_Event.Invoke(true);
            keyboardInputManager.Conversation_Trigger = other.GetComponent<ConversationTrigger>();

            SoundEffectsManager.instance.Play_Single_Sound_Effect(Encounter, transform, 0.3f , 0);

            if (other.gameObject.CompareTag("Colleague"))
            {
                Player_Movement.Start_Interact();
                Colleague.Move_to_Player(transform);

                keyboardInputManager.Can_Interact = false;
                InteractionSystem.Press_F_Visible_Event.Invoke(false);
                keyboardInputManager.Conversation_Trigger = null;
            }
            if (other.gameObject.CompareTag("Crush"))
            {
                Player_Movement.Start_Interact();
                Crush.Move_to_Player(transform);

                keyboardInputManager.Can_Interact = false;
                InteractionSystem.Press_F_Visible_Event.Invoke(false);
                keyboardInputManager.Conversation_Trigger = null;
            }
            if (other.gameObject.CompareTag("Neighbour"))
            {
                Player_Movement.Start_Interact();
                Neighbour.Move_to_Player(transform);

                keyboardInputManager.Can_Interact = false;
                InteractionSystem.Press_F_Visible_Event.Invoke(false);
                keyboardInputManager.Conversation_Trigger = null;
            }
            
             if (other.gameObject.CompareTag("Wallet"))
             {
                Player_Movement.Start_Interact();
                keyboardInputManager.Conversation_Trigger.Interaction_Function();
                keyboardInputManager.Can_Interact = false;
                InteractionSystem.Press_F_Visible_Event.Invoke(false);
             }

        }

        if (other.gameObject.CompareTag("Home"))
        {
            if (!Returned_Wallet)
            {
                ReputationSystem.Reputation_Over.Invoke();
                return;
            }
            Victory_Event.Invoke();
            SoundEffectsManager.instance.Play_Single_Sound_Effect(Home, transform, 1, 0.5f);
        }
    }

    public void Wallet_Lock()
    {
        Returned_Wallet = true;
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
