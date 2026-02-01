using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering.Universal;

public class KeyboardInputManager : MonoBehaviour
{
    private PlayerControls Player_Controls;

    public Vector2 Keyboard_Input;

    public bool Can_Interact = false;
    private bool Can_Jump = true;

    public ConversationTrigger Conversation_Trigger;

    [SerializeField] private PlayerMovement Player_Movement;

    private void Awake()
    {  
        Player_Controls = new PlayerControls();
    }

    private void OnEnable()
    {
        Player_Controls.Enable();

        Player_Controls.Player.Interact.performed += Interact_Function;
        Player_Controls.Player.Jump.performed += Jump_Function;
    }

    private void OnDisable()
    {
        Player_Controls.Disable();


        Player_Controls.Player.Interact.performed -= Interact_Function;
        Player_Controls.Player.Jump.performed -= Jump_Function;

    }

    void FixedUpdate()
    {
        Keyboard_Input = Player_Controls.Player.Keyboard.ReadValue<Vector2>();
    }

    
    private void Interact_Function(InputAction.CallbackContext context)
    {
        if(!Can_Interact)
        {
            return;
        }
        Conversation_Trigger.Interaction_Function();
        InteractionSystem.Press_F_Visible_Event.Invoke(false);
        Player_Movement.Start_Interact();
    }

    private void Jump_Function(InputAction.CallbackContext context)
    {
        if (!Can_Jump)
        {
            return;
        }
        Player_Movement.Jump();
        Can_Jump = false;
        StartCoroutine(Delay_Jump());
    }
    private IEnumerator Delay_Jump()
    {
        yield return new WaitForSeconds(1f);
        Can_Jump = true;
    }
}
