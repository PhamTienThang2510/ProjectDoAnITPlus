using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WeaponMainSO", menuName = "Scriptable Objects/WeaponMainSO")]
public class WeaponMainSO : ScriptableObject
{
    public string weaponId;
    public List<WeaponLevel> weaponLevels;
    public WeaponSubSO weaponSubs;
    public WeaponEvo weaponEvo;
    public Rate rate;
    
    // New: Specify which behavior to use for this weapon
    public KnifeBehaviorType defaultBehaviorType = KnifeBehaviorType.Straight;
}

[CreateAssetMenu(fileName = "WeaponLevel", menuName = "Scriptable Objects/WeaponLevel")]
public class WeaponLevel : ScriptableObject
{
    public int level;
    public float speed;
    public float damage;
    public float cooldown;
    public float range;
}

[CreateAssetMenu(fileName = "WeaponSub", menuName = "Scriptable Objects/WeaponSub")]
public class WeaponSub : ScriptableObject
{
    public int level;
    public TypeWeaponSub typeWeaponSub;
    public float bonus;
}

[CreateAssetMenu(fileName = "WeaponSubSO", menuName = "Scriptable Objects/WeaponSubSO")]
public class WeaponSubSO : ScriptableObject
{
    public List<WeaponSub> weaponSubLevels;
}

[CreateAssetMenu(fileName = "WeaponEvo", menuName = "Scriptable Objects/WeaponEvo")]
public class WeaponEvo : ScriptableObject
{
    public int requiredLevel;
    public WeaponMainSO evolvedForm;
}

public enum TypeWeaponSub
{
    speed,
    damage,
    cooldown,
    criticalChance,
    hp
}

public enum Rate
{
    Common,
    Rare,
    Epic
}

// New enum for behavior types
public enum KnifeBehaviorType
{
    Straight,
    Boomerang,
    Spiral
}
