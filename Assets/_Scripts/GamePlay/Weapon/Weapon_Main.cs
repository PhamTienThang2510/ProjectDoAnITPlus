using MyPooler;
using UnityEngine;

public abstract class Weapon_Main : Weapon_Base
{
    [SerializeField] protected WeaponMainSO weaponData;

    protected float Damage => weaponData.weaponLevels[CurrentLevel].damage;
    protected float Range => weaponData.weaponLevels[CurrentLevel].range;
    protected float Cooldown => weaponData.weaponLevels[CurrentLevel].cooldown;

    protected float speed => weaponData.weaponLevels[CurrentLevel].speed;

    public Transform positionSpawn;

    protected float lastAttackTime;

    protected virtual void Awake()
    {
        positionSpawn = transform.Find("WeaponHolder");
    }
    public override void Init()
    {
        lastAttackTime = 0;
    }

    protected virtual void Update()
    {
        if (Time.time >= lastAttackTime + Cooldown)
        {   
            Attack();
            lastAttackTime = Time.time;
        }
    }
    protected abstract void Attack();

    public override void Upgrade()
    {
        if (CurrentLevel < weaponData.weaponLevels.Count - 1)
            CurrentLevel++;
    }
}