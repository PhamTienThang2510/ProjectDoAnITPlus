using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private PlayerInput playerInput;
    private PlayerAnim playerAnim;
    [SerializeField]
    private float moveSpeed = 5f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        playerAnim = GetComponent<PlayerAnim>();
    }

    // Update is called once per frame
    void Update()
    {
        if(playerInput.Direction != Vector2.zero)
        {
            playerAnim.SetRunning(true);
        }
        else
        {
            playerAnim.SetRunning(false);
        }

        playerAnim.FlipSprite(playerInput.Direction);

        // Move the player
        transform.Translate(new Vector3(playerInput.Direction.x, playerInput.Direction.y, 0) * Time.deltaTime * moveSpeed);
    }
}
