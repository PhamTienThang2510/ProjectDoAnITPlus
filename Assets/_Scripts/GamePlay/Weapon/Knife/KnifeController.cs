using UnityEngine;

public class KnifeController : MonoBehaviour
{
    private BehaviorBase currentBehavior;

    public void Initialize(
        WeaponMainSO weaponSO,
        Vector2 direction)
    {
        currentBehavior =
            WeaponBehaviorFactory.AddBehaviorToWeapon(
                weaponSO,
                gameObject);

        currentBehavior.direction = direction;
        currentBehavior.speed =
            weaponSO.weaponLevels[0].speed;
    }
}