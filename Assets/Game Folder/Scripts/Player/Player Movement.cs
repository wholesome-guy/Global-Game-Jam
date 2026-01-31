using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [Header("Physics")]
    [SerializeField] private Rigidbody Player_Rigidbody;

    [Header("FPS Camera")]
    [SerializeField] private Transform Player_Orientation;
    [SerializeField] private Transform Player_Camera;

    [Header("Player Values")]
    [SerializeField] private float Walk_Speed = 200f;
    private float Move_Speed;


    [Header("Input Scripts")]
    [SerializeField] private KeyboardInputManager KeyboardInputManager;
    [SerializeField] private MouseInputManager MouseInputManager;

    private float Horizontal_Movement;
    private float Vertical_Movement;
    private float Rotation_X;
    private float Rotation_Y;

    private Vector3 Move_Direction;
    private bool Is_Inputing = true;

    private void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        Move_Speed = Walk_Speed;
    }

    private void Update()
    {
        if (!Is_Inputing)
        {
            return;
        }
        Inputs();
        Look();
        Move();
    }

    
    
    private void OnEnable()
    {
        InteractionSystem.End_Interaction_Event += End_Interact;
    }
    private void OnDisable()
    {
        InteractionSystem.End_Interaction_Event -= End_Interact;
    }

    private void FixedUpdate()
    {
        Player_Rigidbody.AddForce(Move_Direction.normalized * Move_Speed, ForceMode.Force);
    }
    private void Inputs()
    {
        Horizontal_Movement = KeyboardInputManager.Keyboard_Input.x;
        Vertical_Movement = KeyboardInputManager.Keyboard_Input.y;

        Rotation_X += MouseInputManager.Mouse_Input.y;
        Rotation_Y += MouseInputManager.Mouse_Input.x;

        Rotation_X = Mathf.Clamp(Rotation_X, -90f, 90f);
    }

    private void Look()
    {
        Player_Orientation.rotation = Quaternion.Euler(0, Rotation_Y, 0);
        Player_Camera.rotation = Quaternion.Euler(Rotation_X, Rotation_Y, 0);
    }

    private void Move()
    {
        Move_Direction = Player_Orientation.forward * Vertical_Movement + Player_Orientation.right * Horizontal_Movement;
        Speed_Control();
    }
    private void Speed_Control()
    {
        Vector3 Velocity = new Vector3(Player_Rigidbody.linearVelocity.x, 0, Player_Rigidbody.linearVelocity.z);

        if (Velocity.magnitude > Move_Speed)
        {
            Vector3 Max_Velocity = Velocity.normalized * Move_Speed;

            Player_Rigidbody.linearVelocity = new Vector3(Max_Velocity.x, Player_Rigidbody.linearVelocity.y, Max_Velocity.z);
        }
    }

    public void Start_Interact()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        Is_Inputing = false;    
    }
    public void End_Interact()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        Is_Inputing = true;
    }



}
