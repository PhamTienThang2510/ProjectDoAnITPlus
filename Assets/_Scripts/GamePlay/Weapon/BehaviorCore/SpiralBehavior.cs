using UnityEngine;

public class SpiralBehavior : BehaviorBase
{
    private float angle = 0f;
    private float spiralSpeed = 2f;
    private float radius = 1f;

    public void SetSpiralParameters(float spiralSpd, float rad)
    {
        spiralSpeed = spiralSpd;
        radius = rad;
    }

    public override void UpdateBehavior()
    {
        angle += spiralSpeed * Time.deltaTime;
        
        Vector2 spiralOffset = new Vector2(
            Mathf.Cos(angle) * radius,
            Mathf.Sin(angle) * radius
        );
        
        Vector2 forwardMovement = direction * speed * Time.deltaTime;
        transform.position += (Vector3)(forwardMovement + spiralOffset * Time.deltaTime);
    }
}
