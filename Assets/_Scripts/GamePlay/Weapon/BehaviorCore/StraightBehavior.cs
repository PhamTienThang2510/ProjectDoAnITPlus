using UnityEngine;

public class StraightBehavior : BehaviorBase
{
    private void Start()
    {
        HandleRotation();
    }

    public override void UpdateBehavior()
    {
        transform.position += (Vector3)(direction * speed * Time.deltaTime);
    }

    private void HandleRotation()
    {
        float angle =
            Mathf.Atan2(direction.y, direction.x)
            * Mathf.Rad2Deg;

        transform.rotation =
            Quaternion.Euler(0, 0, angle);
    }
}
