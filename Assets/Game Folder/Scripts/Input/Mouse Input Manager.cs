using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MouseInputManager : MonoBehaviour
{
    public static MouseInputManager instance;
    private PlayerControls Player_Controls;
    [SerializeField] private SettingsValueHolder Settings_Value;

    private Vector2 Mouse_Raw;
    public Vector2 Mouse_Input;

    public Action Shoot_Event;


    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }

        Player_Controls = new PlayerControls();

    }

    private void OnEnable()
    {
        Player_Controls.Enable();

        Player_Controls.Player.Shoot.performed += Shoot_Function;
    }

    private void OnDisable()
    {
        Player_Controls.Disable();
        Player_Controls.Player.Shoot.performed -= Shoot_Function;

    }

    void FixedUpdate()
    {
        Mouse_Raw = Player_Controls.Player.Mouse.ReadValue<Vector2>();
        Mouse_Input = new Vector2(Mouse_Raw.x*Settings_Value.Mouse_Sensitivity, -Mouse_Raw.y * Settings_Value.Mouse_Sensitivity);
    }

    private void Shoot_Function(InputAction.CallbackContext context)
    {
        Shoot_Event.Invoke();
    }
}
