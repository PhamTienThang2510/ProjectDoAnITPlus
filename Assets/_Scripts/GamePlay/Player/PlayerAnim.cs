using UnityEngine;

public class PlayerAnim : MonoBehaviour
{
    private SpriteRenderer playerSprite;
    private Animator playerAnimation; // Assuming you have an Animation component for handling animations
    private bool IsRunning => playerSprite.flipX; // Assuming running is determined by the flip state of the sprite
    private void Start()
    {
        playerSprite = GetComponent<SpriteRenderer>();
        playerAnimation = GetComponent<Animator>(); // Get the Animator component
    }
    public void FlipSprite(Vector2 direction)
    {
        if (direction.x > 0)
        {
            playerSprite.flipX = true; // Facing right
        }
        else if (direction.x < 0)
        {
            playerSprite.flipX = false; // Facing left
        }
    }

    public void SetRunning(bool isRunning)
    {
        // Here you would set the appropriate animation state based on whether the player is running or not
        // For example, you could use an Animator component and set a boolean parameter to trigger the running animation
        if (playerAnimation != null)
        {
            playerAnimation.SetBool("IsRunning", isRunning);
        }
    }
}
