using UnityEngine;

public abstract class Weapon_Base : MonoBehaviour
{
    public int CurrentLevel;
    public abstract void Init();
    public abstract void Upgrade();
}