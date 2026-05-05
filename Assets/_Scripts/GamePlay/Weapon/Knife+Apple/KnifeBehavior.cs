using UnityEngine;

public abstract class KnifeBehavior : MonoBehaviour
{
    protected Vector2 direction;
    protected float speed;
    protected float damage;
    protected float range;
    protected Vector2 startPosition;
    protected bool isActive = false;

    public virtual void Init(Vector2 dir, float dmg, float spd, float rng)
    {
        direction = dir.normalized;
        damage = dmg;
        speed = spd;
        range = rng;
        startPosition = transform.position;
        isActive = true;
    }

    public abstract void UpdateBehavior();

    protected virtual void Update()
    {
        if (!isActive) return;
        UpdateBehavior();
        CheckRange();
    }

    protected virtual void CheckRange()
    {
        if (Vector2.Distance(startPosition, transform.position) >= range)
        {
            OnRangeReached();
        }
    }

    protected virtual void OnRangeReached()
    {
        isActive = false;
        ReturnToPool();
    }

    protected virtual void OnTriggerEnter2D(Collider2D other)
    {
        if (!isActive) return;
        
        // Handle damage logic here
        ReturnToPool();
    }

    protected virtual void ReturnToPool()
    {
        isActive = false;
        ObjectPooler.Instance.ReturnToPool("Weapon", gameObject);
    }
}
