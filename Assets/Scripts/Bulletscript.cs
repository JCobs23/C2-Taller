using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BulletScrip : MonoBehaviour
{
    public float Speed;
    private Rigidbody2D Rigibody2D;

    private void Start()
    {
        Rigibody2D = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        Rigibody2D.linearVelocity = Vector2.right * Speed;
    }
}
