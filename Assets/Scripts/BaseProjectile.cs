using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseProjectile : MonoBehaviour
{
    [SerializeField] private float projectileSpeed;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private bool playerProjectile;
    private void Awake()
    {
        if (playerProjectile)
            rb.AddForce(Vector2.left * projectileSpeed);
        else
            rb.AddForce(-Vector2.left * projectileSpeed);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(this.gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 7)
            GameManager.Instance.Score++;
        Destroy(this.gameObject);
    }
}
