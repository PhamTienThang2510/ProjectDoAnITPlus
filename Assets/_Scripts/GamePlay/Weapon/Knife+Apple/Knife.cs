using UnityEngine;

public class Knife : Weapon_Main
{
    private Vector2 moveDir;
    private Vector2 lastDir = Vector2.right; // fallback mặc định

    private void Update()
    {
        base.Update();

        // Cập nhật lastDir nếu có input
        Vector2 inputDir = PlayerInput.Instance.Direction;
        if (inputDir != Vector2.zero)
        {
            lastDir = inputDir.normalized;
        }

        transform.position += (Vector3)(moveDir * speed * Time.deltaTime);
    }

    protected override void Attack()
    {
        Vector2 inputDir = PlayerInput.Instance.Direction;

        // Nếu đang đứng yên → dùng lastDir
        moveDir = inputDir != Vector2.zero ? inputDir.normalized : lastDir;

    }
}