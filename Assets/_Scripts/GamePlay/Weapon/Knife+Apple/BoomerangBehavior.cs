using UnityEngine;

public class BoomerangBehavior : KnifeBehavior
{
    private Vector2 returnDirection;
    private bool isReturning = false;
    private float originalRange;

    public override void Init(Vector2 dir, float dmg, float spd, float rng)
    {
        base.Init(dir, dmg, spd, rng);
        originalRange = rng;
        returnDirection = -dir;
    }

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

    protected override void CheckRange()
    {
        if (isReturning)
        {
            if (Vector2.Distance(startPosition, transform.position) <= 0.5f)
            {
                OnRangeReached();
            }
        }
        else
        {
            base.CheckRange();
        }
    }
}
