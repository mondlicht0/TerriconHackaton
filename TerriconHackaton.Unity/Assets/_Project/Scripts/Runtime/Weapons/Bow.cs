using UnityEngine;

namespace Project.Weapons
{
    [CreateAssetMenu(fileName = "Bow", menuName = "Weapons/New Bow", order = 0)]
    public class Bow : Weapon
    {
        [SerializeField] private Arrow _arrowPrefab;
        [SerializeField] private float _shootForce;
        [SerializeField] private Vector3 _spawnOffset;
        
        // 0.5 1.2 0.13
        public override void Spawn(Transform parent)
        {
            LastShootTime = 0;
            SpawnedModel = Instantiate(ModelPrefab);
            SpawnedModel.transform.SetParent(parent);
            SpawnedModel.transform.localPosition = SpawnPoint;
            SpawnedModel.transform.eulerAngles = SpawnRotation;
        }

        protected override void Attack(bool useSpecial, Vector3 shootDirection)
        {
            Arrow arrow = Instantiate(_arrowPrefab, SpawnedModel.transform);
            Rigidbody rb = arrow.GetComponent<Rigidbody>();
            rb.velocity = shootDirection * _shootForce;
        }
    }
}