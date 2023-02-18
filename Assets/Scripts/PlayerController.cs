using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private enum Eprojectiles
    {
        standart,
        powered
    }
    [SerializeField] private GameObject[] projectiles;
    [SerializeField] private GameObject projectileParent;
    [SerializeField, Tooltip("The time between each shoot that is fired in seconds")] private float fireRate;
    private bool isAlive;
    private Eprojectiles currentProjectile;
    [SerializeField] private int playerHealth = 3;
    [SerializeField] private float bulletUpgradeOffset;

    private void Awake()
    {
        isAlive = true;
        StartCoroutine(ShootingCoroutine());
    }
    private void OnMouseDrag()
    {
        transform.position = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (playerHealth < 0)
        {
            isAlive = false;
            GameManager.Instance.IsRunning = false;
            SaveLoadManager.Instance.SaveScore(GameManager.Instance.Score);
            SceneSwitcher.Instance.LoadScene(SceneSwitcher.EScene.Score);
        }
        else
            playerHealth--;
    }

    IEnumerator ShootingCoroutine()
    {
        while (isAlive)
        {
            switch (currentProjectile)
            {
                case Eprojectiles.standart:
                    Instantiate(projectiles[0], transform.position, transform.rotation, projectileParent.transform);
                    yield return new WaitForSeconds(fireRate);
                    break;
                case Eprojectiles.powered:
                    Instantiate(projectiles[0], transform.position, transform.rotation, projectileParent.transform);
                    Instantiate(projectiles[0], new Vector3(transform.position.x + bulletUpgradeOffset, transform.position.y + bulletUpgradeOffset, transform.position.z), transform.rotation, projectileParent.transform);
                    Instantiate(projectiles[0], new Vector3(transform.position.x - bulletUpgradeOffset, transform.position.y - bulletUpgradeOffset, transform.position.z), transform.rotation, projectileParent.transform);
                    yield return new WaitForSeconds(fireRate);
                    break;
                default:
                    break;
            }

        }
    }
}