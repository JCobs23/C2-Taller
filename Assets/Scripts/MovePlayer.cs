using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    public float FuerzaSalto;
    public float VelocidadMovimiento;
    private float longitudRaycast = 0.1f;
    private Rigidbody2D rigiBodyPlayer;
    private float horizontal;
    private bool isGrounded;

    void Start()
    {
        rigiBodyPlayer = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");

        Debug.DrawRay(transform.position, Vector2.down * longitudRaycast, Color.red);
        if (Physics2D.Raycast(transform.position, Vector2.down, longitudRaycast))
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }

        if (Input.inputString == "space" && isGrounded)
        {
            Jump();
        }
    }

    private void Jump()
    {
        rigiBodyPlayer.linearVelocity = new Vector2(rigiBodyPlayer.linearVelocity.x, FuerzaSalto);
    }

    private void FixedUpdate()
    {
        rigiBodyPlayer.linearVelocity = new Vector2(horizontal * VelocidadMovimiento, rigiBodyPlayer.linearVelocity.y);
    }
}
