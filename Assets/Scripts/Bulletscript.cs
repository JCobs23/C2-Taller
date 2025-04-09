using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BulletScrip : MonoBehaviour
{
    public float Speed;
    private Rigidbody2D Rigibody2D;
    private Vector2 Direction;  

    private void Start()
    {
        Rigibody2D = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        Rigibody2D.linearVelocity = Direction * Speed;
    }

    public void SetDirection(Vector2 direction)
    {
        Direction = direction;
        
    }   
}
