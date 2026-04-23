using UnityEngine;

public abstract class Weapon_Sub : Weapon_Base
{
    [SerializeField] protected WeaponSubSO subData;

    protected WeaponSub CurrentSub => subData.weaponSubLevels[CurrentLevel];

    public override void Init()
    {
        ApplyBonus();
    }

    public override void Upgrade()
    {
        if (CurrentLevel < subData.weaponSubLevels.Count - 1)
        {
            CurrentLevel++;
            ApplyBonus();
        }
    }

    protected abstract void ApplyBonus();
}