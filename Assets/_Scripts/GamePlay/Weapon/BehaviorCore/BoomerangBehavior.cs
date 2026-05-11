using UnityEngine;

public class BoomerangBehavior : BehaviorBase
{
    private Vector2 returnDirection;
    private bool isReturning = false;
    private float originalRange;
    private Vector2 startPosition;

    public override void UpdateBehavior()
    {
        if (!isReturning)
        {
            transform.position += (Vector3)(direction * speed * Time.deltaTime);
            
            if (Vector2.Distance(startPosition, transform.position) >= originalRange * 0.5f)
            {
                isReturning = true;
            }
        }
        else
        {
            transform.position += (Vector3)(returnDirection * speed * Time.deltaTime);
        }
    }

}
