using System.Collections;
using UnityEngine;

namespace Project.Weapons
{
    public class ForceStaff : MonoBehaviour
    {
        public GameObject projectilePrefab;
        public Transform firePoint;
        public float fireRate = 1f;     
        private float nextFireTime = 0f;

        void Update()
        {
            if (Input.GetButtonDown("Fire1") && Time.time > nextFireTime)
            {
                nextFireTime = Time.time + 1f / fireRate;
                Shoot();
            }
        }

        void Shoot()
        {
            StartCoroutine(AttackAnimation());
            Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
        }

        private IEnumerator AttackAnimation()
        {
            Vector3 originalPosition = transform.position;
            Vector3 attackPosition = transform.position + new Vector3(0, 0.2f, 0);
        
            float animationTime = 0.1f;
            float elapsedTime = 0f;

            while (elapsedTime < animationTime)
            {
                transform.position = Vector3.Lerp(originalPosition, attackPosition, (elapsedTime / animationTime));
                elapsedTime += Time.deltaTime;
                yield return null;
            }

            transform.position = originalPosition;
        }
    }
}
