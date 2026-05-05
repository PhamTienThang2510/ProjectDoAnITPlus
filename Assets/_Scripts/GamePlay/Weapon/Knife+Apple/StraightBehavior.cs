using UnityEngine;

public class StraightBehavior : KnifeBehavior
{
    public override void UpdateBehavior()
    {
        transform.position += (Vector3)(direction * speed * Time.deltaTime);
    }
}
