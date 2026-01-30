using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardInputManager : MonoBehaviour
{
    public static KeyboardInputManager instance;
    private PlayerControls Player_Controls;

    public Vector2 Keyboard_Input;


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
        Keyboard_Input = Player_Controls.Player.Keyboard.ReadValue<Vector2>();
    }
}
