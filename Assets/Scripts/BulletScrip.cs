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
        Destroy(gameObject, 3f); // ← Aquí se destruye la bala automáticamente después de 3 segundos
    }

    private void FixedUpdate()
    {
        Rigibody2D.linearVelocity = Direction * Speed;
    }

    public void SetDirection(Vector2 direction)
    {
        Direction = direction.normalized;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject); // Se destruye también si toca al jugador
            // Aquí podrías poner: other.GetComponent<VidaJugador>().RecibirDaño(1);
        }
    }
}
