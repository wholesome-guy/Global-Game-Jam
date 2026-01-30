using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody Player_Rigidbody;
    [SerializeField] private Transform Player_Orientation;
    [SerializeField] private Transform Player_Camera;
    [SerializeField] private float Move_Speed =200f;

    private float Horizontal_Movement;
    private float Vertical_Movement;
    private float Rotation_X;
    private float Rotation_Y;

    private Vector3 Move_Direction;

    private Vector3 Linear_XZ_Velocity;

    private KeyboardInputManager KeyboardInputManager;
    private MouseInputManager MouseInputManager;

    private void Update()
    {
       // Linear_XZ_Velocity = new Vector3(Player_Rigidbody.linearVelocity.x, 0, Player_Rigidbody.linearVelocity.z);
        Inputs();
        Look();
        Move();
    }

    private void FixedUpdate()
    {
        Player_Rigidbody.AddForce(Move_Direction.normalized * Move_Speed, ForceMode.Force);
    }
    private void Inputs()
    {
        Horizontal_Movement = KeyboardInputManager.instance.Keyboard_Input.x;
        Vertical_Movement = KeyboardInputManager.instance.Keyboard_Input.y;

        Rotation_X += MouseInputManager.instance.Mouse_Input.y;
        Rotation_Y += MouseInputManager.instance.Mouse_Input.x;

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
    }
}
