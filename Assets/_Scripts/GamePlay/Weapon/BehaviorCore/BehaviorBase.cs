using UnityEngine;
public abstract class BehaviorBase : MonoBehaviour
{
    public Vector2 direction;
    public float speed;
    public abstract void UpdateBehavior();

    protected virtual void Update()
    {
        UpdateBehavior();
    }
}
