using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseInputManager : MonoBehaviour
{
    public static MouseInputManager instance;
    private PlayerControls Player_Controls;

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
        Mouse_Input = Player_Controls.Player.Mouse.ReadValue<Vector2>();
    }
}
