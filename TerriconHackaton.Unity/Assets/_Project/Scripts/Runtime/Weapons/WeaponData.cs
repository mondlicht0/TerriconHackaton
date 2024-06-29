using UnityEngine;

namespace Project.Weapons
{
    public class WeaponData : ScriptableObject
    {
        [field: SerializeField] public float Damage { get; private set; }
        [field: SerializeField] public float FireRate { get; private set; }
    }
}