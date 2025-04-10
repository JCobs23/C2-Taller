using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BulletScrip : MonoBehaviour
{
    public float Speed = 5f;
    private Rigidbody2D Rigibody2D;
    private Vector2 Direction;

    private void Start()
    {
        Rigibody2D = GetComponent<Rigidbody2D>();
        Destroy(gameObject, 3f); // Destruye la bala despu�s de 3 segundos
    }

    private void FixedUpdate()
    {
        Rigibody2D.linearVelocity = Direction * Speed;
    }

    public void SetDirection(Vector2 direction)
    {
        Direction = direction.normalized;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}

