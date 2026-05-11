using UnityEngine;

public class WeaponSpawner : MonoBehaviour
{
    [SerializeField] private WeaponMainSO weaponSO;
    [SerializeField] private KnifeController knifePrefab;

    private float timer;

    private void Update()
    {
        timer += Time.deltaTime;

        float cooldown =
            weaponSO.weaponLevels[0].cooldown;

        if (timer >= cooldown)
        {
            timer = 0;

            SpawnKnife();
        }
    }

    private void SpawnKnife()
    {
        KnifeController knife =
            Instantiate(
                knifePrefab,
                transform.position,
                Quaternion.identity);

        Vector2 dir =
            PlayerInput.Instance.Direction.normalized;

        if (dir == Vector2.zero)
            dir = Vector2.right;

        knife.Initialize(weaponSO, dir);
    }
}