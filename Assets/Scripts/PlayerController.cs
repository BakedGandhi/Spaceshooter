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
    [SerializeField] private int playerHealth = 3;
    [SerializeField] private float bulletUpgradeOffset;
    private bool isAlive;
    private Eprojectiles currentProjectile;

    public int GetPlayerHealth => playerHealth;

    private void Awake()
    {
        isAlive = true;
        EventManager.Instance.OnStartGameScene();
        StartCoroutine(ShootingCoroutine());
    }

    private void Start()
    {
        currentProjectile = Eprojectiles.standart;
        GameManager.Instance.StartGame();
    }
    private void OnMouseDrag()
    {
        transform.position = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 7)
        {
            playerHealth--;
            if (playerHealth < 0)
            {
                isAlive = false;
                EventManager.Instance.OnStopGameScene();
            }
            else
            {
                EventManager.Instance.OnUpdateHealth();
            }
        }
        else if (collision.gameObject.layer == 8)
        {
            currentProjectile = Eprojectiles.powered;
        }
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
