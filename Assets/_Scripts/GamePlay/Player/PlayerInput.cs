using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    public Vector2 Direction { get; private set; }
    private float horizontalInput;
    private float verticalInput;
    public Joystick joystick;

    private void Awake()
    {
    }

    private void Update()
    {
        if (joystick != null)
        {
            horizontalInput = joystick.Horizontal;
            verticalInput = joystick.Vertical;
            Direction = new Vector2(horizontalInput, verticalInput).normalized;
        }
        else
        {
            horizontalInput = Input.GetAxis("Horizontal");
            verticalInput = Input.GetAxis("Vertical");
            Direction = new Vector2(horizontalInput, verticalInput).normalized;
        }
    }
}
