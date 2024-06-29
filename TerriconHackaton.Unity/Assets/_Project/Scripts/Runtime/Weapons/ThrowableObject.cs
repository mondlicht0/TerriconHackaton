using UnityEngine;

namespace Project.Weapons
{
    public class ThrowableObject : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out IDamagable damagable))
            {
                damagable.GetDamage();
            }
        }
    }
}