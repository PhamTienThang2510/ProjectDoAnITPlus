using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public Vector2 Direction { get; private set; }
    private int horizontalInput;
    private int verticalInput;
    private void Update()
    {
        horizontalInput = (int)Input.GetAxisRaw("Horizontal");
        verticalInput = (int)Input.GetAxisRaw("Vertical");
        Direction = new Vector2(horizontalInput, verticalInput).normalized;
    }
}
