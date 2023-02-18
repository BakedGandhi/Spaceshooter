using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseEnemy : MonoBehaviour
{
    [SerializeField] protected private float speed;
    [SerializeField] protected Rigidbody2D rb;
    protected bool isAlive;
    // Start is called before the first frame update

    protected void Awake()
    {
        isAlive = true;
        rb.velocity = Vector3.zero;
        rb.AddForce((Vector2.right * speed));
    }

    protected void OnTriggerEnter2D(Collider2D collision)
    {
        isAlive = false;
        Destroy(this.gameObject);
    }

}
