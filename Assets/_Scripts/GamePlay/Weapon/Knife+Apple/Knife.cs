using UnityEngine;

public class Knife : Weapon_Main
{
    private KnifeController knifeController;
    private Vector2 lastDir = Vector2.right;

    protected override void Awake()
    {
        base.Awake();
        
        knifeController = GetComponent<KnifeController>();
        
        if (knifeController == null)
        {
            knifeController = gameObject.AddComponent<KnifeController>();
        }
        
        if (weaponData != null)
        {
            knifeController.SetWeaponData(weaponData);
        }
        
        if (positionSpawn != null)
        {
            knifeController.SetSpawnPoint(positionSpawn);
        }
    }

    protected override void Attack()
    {
        Vector2 inputDir = PlayerInput.Instance.Direction;
        Vector2 moveDir = inputDir != Vector2.zero ? inputDir.normalized : lastDir;
        lastDir = moveDir;

        if (knifeController != null)
        {
            knifeController.SpawnKnife(moveDir);
        }
    }

    public override void Init()
    {
        base.Init();
        
        if (weaponData != null && knifeController != null)
        {
            knifeController.SetWeaponData(weaponData);
        }
    }
}
