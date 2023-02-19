using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasePowerUp : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float speed;
    private void Awake()
    {
        rb.velocity = Vector3.zero;
        rb.AddForce((Vector2.right * speed));
    }

    protected void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(this.gameObject);
    }
}
