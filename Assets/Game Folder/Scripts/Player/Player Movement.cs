using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    [Header("Physics")]
    [SerializeField] private Rigidbody Player_Rigidbody;

    [Header("FPS Camera")]
    [SerializeField] private Transform Player_Orientation;
    [SerializeField] private Transform Player_Camera;

    [Header("Player Values")]
    [SerializeField] private float Walk_Speed = 200f;
    [SerializeField] private float Jump_Force =100f;
    [SerializeField] private float Walking_Friction =1;
    [SerializeField] private float Jumping_Friction =0;
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
    private Vector3 Linear_XZ_Velocity;

    [SerializeField] private AudioSource FootSteps_Audio_Source;
    [SerializeField] private AudioClip[] FootSteps_Audio_Clips;
    private bool Footstep_Heard = false;

    private void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        Move_Speed = Walk_Speed;
    }

    private void Update()
    {
        Linear_XZ_Velocity = new Vector3(Player_Rigidbody.linearVelocity.x, 0, Player_Rigidbody.linearVelocity.z);
        if (!Is_Inputing)
        {
            return;
        }
        Move();
        Inputs();
        Look();
        FootSteps();
    }

    
    
    private void OnEnable()
    {
        InteractionSystem.End_Interaction_Event += End_Interact;
        PlayerCollision.Victory_Event += Game_Over;
        EnergySystem.Energy_Over += Game_Over;
        ReputationSystem.Reputation_Over += Game_Over;
    }
    private void OnDisable()
    {
        InteractionSystem.End_Interaction_Event -= End_Interact;
        PlayerCollision.Victory_Event -= Game_Over;
        EnergySystem.Energy_Over -= Game_Over;
        ReputationSystem.Reputation_Over -= Game_Over;

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

        if (Player_Rigidbody.linearVelocity.y < -1)
        {
            Player_Rigidbody.linearDamping = Jumping_Friction;
        }
        else
        {
            Player_Rigidbody.linearDamping = Walking_Friction;
        }
    }

    public void Jump()
    {
        Player_Rigidbody.AddForce(Player_Orientation.up*Jump_Force,ForceMode.Impulse);
    }
    private void FootSteps()
    {
        if (Linear_XZ_Velocity.sqrMagnitude > 0 && !Footstep_Heard)
        {
            StartCoroutine(Next_FootStep());
        }

    }
    private IEnumerator Next_FootStep()
    {
        Footstep_Heard = true;

        AudioClip Clip = FootSteps_Audio_Clips[Random.Range(0, FootSteps_Audio_Clips.Length)];
        float Pitch = Random.Range(0.8f, 1.2f);
        FootSteps_Audio_Source.clip = Clip;
        FootSteps_Audio_Source.pitch = Pitch;
        FootSteps_Audio_Source.Play();
        float moveSpeed = Linear_XZ_Velocity.magnitude;
        float delay = Mathf.Clamp(3f / moveSpeed, 0.2f, 0.8f);
        yield return new WaitForSeconds(delay);

        Footstep_Heard = false;
    }

    public void Start_Interact()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        Is_Inputing = false;
        Player_Rigidbody.constraints = RigidbodyConstraints.FreezeAll;

    }
    public void End_Interact()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        Is_Inputing = true;
        Player_Rigidbody.constraints = RigidbodyConstraints.None;
        Player_Rigidbody.constraints = RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezeRotationX;
    }

    private void Game_Over()
    {
        Is_Inputing = false;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }



}
