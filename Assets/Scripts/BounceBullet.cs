using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class BounceBullet : MonoBehaviour
{
    public float bounceForce = 10f;
    public float bounceOtherForce = 0.5f;
    private Vector2 direction;
    public float speed=10f;

    void Start()
    {
        direction = transform.right;
    }
    void Update()
    {
        transform.position += (Vector3)direction * speed * Time.deltaTime;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            Vector2 normal = collision.contacts[0].normal;
             direction = Vector2.Reflect(direction, normal);
        }
        if (collision.gameObject.CompareTag("Pushable"))
        {
            Rigidbody2D rbPushable = collision.gameObject.GetComponent<Rigidbody2D>();
            if (rbPushable != null)
            {
                Vector2 pushDirection = collision.contacts[0].normal;
                rbPushable.AddForce(-pushDirection * bounceForce, ForceMode2D.Impulse);
            }
        }
    }
}
