using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpaceShip : BaseEnemy
{
    [SerializeField] private GameObject enemyProjectile;
    [SerializeField] private float fireRate;

    private void Awake()
    {
        base.Awake();
        StartCoroutine(ShootingCoroutine());
    }

    IEnumerator ShootingCoroutine()
    {
        while (isAlive)
        {
            Instantiate(enemyProjectile, transform.position, transform.rotation);
            yield return new WaitForSeconds(fireRate);
        }
    }
}
