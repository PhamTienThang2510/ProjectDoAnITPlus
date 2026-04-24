using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WeaponMainSO", menuName = "Scriptable Objects/WeaponMainSO")]
public class WeaponMainSO : ScriptableObject
{
    public string weaponId;
    public List<WeaponLevel> weaponLevels;
    public WeaponSubSO weaponSubs;
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
public enum TypeWeaponSub
{
    speed,
    damage,
    cooldown,
    criticalChance,
    hp
}