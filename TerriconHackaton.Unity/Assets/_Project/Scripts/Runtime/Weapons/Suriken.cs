using DG.Tweening;
using UnityEngine;

namespace Project.Weapons
{
    [CreateAssetMenu(fileName = "Suriken", menuName = "Weapons/New Suriken", order = 0)]
    public class Suriken : Weapon
    {
        private Rigidbody _rigidbody;
        public Vector3 SpawnPoint;
        public Vector3 SpawnRotation;

        private float _lastShootTime;

        public override void Spawn(Transform parent)
        {
            LastShootTime = 0;
            SpawnedModel = Instantiate(ModelPrefab);
            SpawnedModel.transform.SetParent(parent);
            SpawnedModel.transform.localPosition = SpawnPoint;
            SpawnedModel.transform.eulerAngles = SpawnRotation;

            if (SpawnedModel.TryGetComponent(out Rigidbody rb))
            {
                rb.useGravity = false;
            }
        }

        protected override void Attack(bool useSpecial)
        {
            GameObject shuriken = Instantiate(ModelPrefab, SpawnedModel.transform.position, SpawnedModel.transform.rotation);
            
            if (!shuriken.TryGetComponent(out Rigidbody shurikenRb)) return;
            
            shurikenRb.useGravity = false;
            shurikenRb.velocity = SpawnedModel.transform.forward * 15;

            if (useSpecial)
            {
                Vector3 leftDirection = Quaternion.Euler(0, -45, 0) * SpawnedModel.transform.forward;
                Vector3 rightDirection = Quaternion.Euler(0, 45, 0) * SpawnedModel.transform.forward;

                GameObject leftShuriken = Instantiate(ModelPrefab, SpawnedModel.transform.position, SpawnedModel.transform.rotation);
                Rigidbody leftRb = leftShuriken.GetComponent<Rigidbody>();
                leftRb.velocity = leftDirection * 15;

                GameObject rightShuriken = Instantiate(ModelPrefab, SpawnedModel.transform.position, SpawnedModel.transform.rotation);
                Rigidbody rightRb = rightShuriken.GetComponent<Rigidbody>();
                rightRb.velocity = rightDirection * 15;
            }
        }
    }
}