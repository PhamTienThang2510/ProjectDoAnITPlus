using UnityEngine;
public static class WeaponBehaviorFactory
{
    public static BehaviorBase AddBehaviorToWeapon(WeaponMainSO weaponMainSO, GameObject weaponObject)
    {
        switch (weaponMainSO.defaultBehaviorType)
        {
            case WeaponBehaviorType.Straight:
                return weaponObject.AddComponent<StraightBehavior>();
            case WeaponBehaviorType.Boomerang:
                return weaponObject.AddComponent<BoomerangBehavior>();
            case WeaponBehaviorType.Spiral:
                return weaponObject.AddComponent<SpiralBehavior>();
            // Add more cases for new behavior types
            default:
                Debug.LogWarning("Unknown behavior type: " + weaponMainSO.defaultBehaviorType);
                return null;
        }
    }
}

