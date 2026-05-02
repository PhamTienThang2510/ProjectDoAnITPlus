using MyPooler;
using UnityEngine;

public class Projective : MonoBehaviour, IPooledObject
{
    private Vector2 direction;
    private float speed;
    private float damage;

    public void Init(Vector2 dir, float dmg, float spd)
    {
        direction = dir;
        damage = dmg;
        speed = spd;
    }

    public void OnRequestedFromPool()
    {
        // reset nếu cần
    }

    void Update()
    {
        transform.position += (Vector3)(direction * speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // gây damage

        ObjectPooler.Instance.ReturnToPool("Weapon", gameObject);
    }

    public void DiscardToPool()
    {
        throw new System.NotImplementedException();
    }
}