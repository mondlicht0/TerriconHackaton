using UnityEngine;

namespace Project.Weapons
{
    public class ThrowableObject : MonoBehaviour
    {
        [SerializeField] protected int Damage = 7;
        
        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out IDamagable damagable))
            {
                damagable.GetDamage(Damage);
            }
        }
    }
}