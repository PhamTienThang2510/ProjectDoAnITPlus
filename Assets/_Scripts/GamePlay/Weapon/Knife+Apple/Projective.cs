using MyPooler;
using UnityEngine;

public class Projective : MonoBehaviour, IPooledObject
{
    private KnifeBehavior currentBehavior;

    public void OnRequestedFromPool()
    {
        // Reset state when requested from pool
        currentBehavior = null;
    }

    public void SetBehavior(KnifeBehavior behavior)
    {
        currentBehavior = behavior;
    }

    public KnifeBehavior GetCurrentBehavior()
    {
        return currentBehavior;
    }

    public void DiscardToPool()
    {
        // Return to pool without activation
        ObjectPooler.Instance.ReturnToPool("Weapon", gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Let the behavior handle collision
        if (currentBehavior != null)
        {
            // Forward collision to behavior if needed
            // The behavior's own OnTriggerEnter2D will handle it
        }
    }
}
