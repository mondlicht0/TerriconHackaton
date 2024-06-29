using UnityEngine;

namespace Project.Weapons
{
    public abstract class Weapon : ScriptableObject
    {
        public GameObject ModelPrefab;
        public float FireRate;
        public Vector3 SpawnPoint;
        public Vector3 SpawnRotation;
        
        protected GameObject SpawnedModel;
        protected float LastShootTime;

        public abstract void Spawn(Transform parent);

        private void BaseAttack(bool useSpecial)
        {
            if (Time.time > FireRate + LastShootTime)
            {
                LastShootTime = Time.time;
                Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
                Vector3 shootDirection = ray.origin - SpawnedModel.transform.forward;
                shootDirection.Normalize();
                Attack(useSpecial, ray.direction);
            }
        }

        public void Tick(bool isAttack, bool useSpecial)
        {
            if (isAttack || useSpecial)
            {
                BaseAttack(useSpecial);
            }
        }
        
        protected abstract void Attack(bool useSpecial, Vector3 shootDirection);
    }
}