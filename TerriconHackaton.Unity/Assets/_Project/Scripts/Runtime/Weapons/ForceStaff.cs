using UnityEngine;

namespace Project.Weapons
{
    [CreateAssetMenu(fileName = "Forcestaff", menuName = "Weapons/New Forcestaff", order = 0)]
    public class ForceStaff : Weapon
    {
        [SerializeField] private float _projectileSpeed;
        [SerializeField] private Projectile _projectilePrefab;
        public Transform _firePoint;  

        public override void Spawn(Transform parent)
        {
            LastShootTime = 0;
            SpawnedModel = Instantiate(ModelPrefab);
            SpawnedModel.transform.SetParent(parent);
            SpawnedModel.transform.localPosition = SpawnPoint;
            SpawnedModel.transform.eulerAngles = SpawnRotation;
            _firePoint = SpawnedModel.transform.Find("FirePoint");
            SpawnedModel.SetActive(false);
        }

        protected override void Attack(bool useSpecial, Vector3 shootDirection)
        {
            Projectile projectile = Instantiate(_projectilePrefab, _firePoint.position, _firePoint.rotation);
            Rigidbody rb = projectile.GetComponent<Rigidbody>();
            rb.velocity = shootDirection * _projectileSpeed;
        }
    }
}
