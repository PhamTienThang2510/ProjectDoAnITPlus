using MyPooler;
using UnityEngine;

public class Knife : Weapon_Main
{
    private Vector2 moveDir;
    private Vector2 lastDir = Vector2.right; // fallback mặc định

    private void Update()
    {
        base.Update();
    }

    protected override void Attack()
    {
        Vector2 inputDir = PlayerInput.Instance.Direction;

        // Nếu đang đứng yên → dùng lastDir
        moveDir = inputDir != Vector2.zero ? inputDir.normalized : lastDir;

        SpawnKnife(moveDir);
    }

    private void SpawnKnife(Vector2 dir)
    {
        GameObject obj = ObjectPooler.Instance.GetFromPool(
            weaponData.weaponId,   // ví dụ: "Knife"
            positionSpawn.position,
            Quaternion.identity
        );

        Projective knife = obj.GetComponent<Projective>();
        knife.Init(dir, Damage, speed);
    }
}