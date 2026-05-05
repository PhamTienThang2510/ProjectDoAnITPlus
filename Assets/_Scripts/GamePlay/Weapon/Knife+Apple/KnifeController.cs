using MyPooler;
using UnityEngine;

public class KnifeController : MonoBehaviour
{
    [SerializeField] private WeaponMainSO weaponData;
    [SerializeField] private Transform spawnPoint;
    
    private int CurrentLevel => 0; // TODO: Get from weapon level system
    
    public void SpawnKnife(Vector2 direction)
    {
        if (weaponData == null)
        {
            Debug.LogWarning("WeaponData is not assigned in KnifeController");
            return;
        }

        string weaponId = weaponData.weaponId;
        GameObject obj = ObjectPooler.Instance.GetFromPool(
            weaponId,
            spawnPoint.position,
            Quaternion.identity
        );

        if (obj == null) return;

        // Remove any existing KnifeBehavior components
        KnifeBehavior[] existingBehaviors = obj.GetComponents<KnifeBehavior>();
        foreach (var b in existingBehaviors)
        {
            if (Application.isPlaying)
                Destroy(b);
            else
                DestroyImmediate(b);
        }

        // Add the appropriate behavior component based on configuration
        KnifeBehavior behavior = AddBehaviorByType(obj, weaponData.defaultBehaviorType);
        
        if (behavior != null)
        {
            float damage = weaponData.weaponLevels[CurrentLevel].damage;
            float speed = weaponData.weaponLevels[CurrentLevel].speed;
            float range = weaponData.weaponLevels[CurrentLevel].range;
            
            behavior.Init(direction, damage, speed, range);
        }
    }

    private KnifeBehavior AddBehaviorByType(GameObject obj, KnifeBehaviorType behaviorType)
    {
        switch (behaviorType)
        {
            case KnifeBehaviorType.Straight:
                return obj.AddComponent<StraightBehavior>();
            case KnifeBehaviorType.Boomerang:
                return obj.AddComponent<BoomerangBehavior>();
            case KnifeBehaviorType.Spiral:
                return obj.AddComponent<SpiralBehavior>();
            default:
                return obj.AddComponent<StraightBehavior>();
        }
    }

    public void SetWeaponData(WeaponMainSO data)
    {
        weaponData = data;
    }

    public void SetSpawnPoint(Transform point)
    {
        spawnPoint = point;
    }
}
