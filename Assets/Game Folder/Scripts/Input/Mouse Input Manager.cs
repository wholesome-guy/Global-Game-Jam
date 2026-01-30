using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseInputManager : MonoBehaviour
{
    public static MouseInputManager instance;
    private PlayerControls Player_Controls;
    [SerializeField] private SettingsValueHolder Settings_Value;

    private Vector2 Mouse_Raw;
    public Vector2 Mouse_Input;


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
    }

    private void OnDisable()
    {
        Player_Controls.Disable();
    }

    void FixedUpdate()
    {
        Mouse_Raw = Player_Controls.Player.Mouse.ReadValue<Vector2>();
        Mouse_Input = new Vector2(Mouse_Raw.x*Settings_Value.Mouse_Sensitivity, -Mouse_Raw.y * Settings_Value.Mouse_Sensitivity);
    }
}
