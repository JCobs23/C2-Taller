using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gruentscrip : MonoBehaviour
{
    public GameObject Player;
    public GameObject BulletPrefab;
    public float moveSpeed = 2f;
    public float shootingDistance = 5f;
    public float followDistance = 7f;

    private float LastShoot;
    private Vector3 originalScale;
    private Rigidbody2D rb;

    private void Start()
    {
        originalScale = transform.localScale;
        rb = GetComponent<Rigidbody2D>(); // Necesita Rigidbody2D  
    }

    private void Update()
    {
        if (Player == null) return;

        Vector3 direction = Player.transform.position - transform.position;

        // Volteo del sprite solo si el jugador está a la derecha  
        if (direction.x > 0.0f)
            transform.localScale = new Vector3(-Mathf.Abs(originalScale.x), originalScale.y, originalScale.z);
        else
            transform.localScale = new Vector3(Mathf.Abs(originalScale.x), originalScale.y, originalScale.z);

        float distance = direction.magnitude;

        // Disparar si el jugador está cerca  
        if (distance < shootingDistance && Time.time > LastShoot + 1.0f)
        {
            Shoot(direction);
            LastShoot = Time.time;
        }

        // Seguir al jugador si está a cierta distancia  
        if (distance < followDistance)
        {
            Vector2 moveDirection = direction.normalized;
            rb.linearVelocity = new Vector2(moveDirection.x * moveSpeed, rb.linearVelocity.y);
        }
        else
        {
            rb.linearVelocity = new Vector2(0, rb.linearVelocity.y); // detenerse  
        }
    }

    private void Shoot(Vector3 direction)
    {
        Vector2 bulletDirection = direction.normalized;

        GameObject bullet = Instantiate(BulletPrefab, transform.position + (Vector3)(bulletDirection * 0.5f), Quaternion.identity);
        BulletScrip bulletScript = bullet.GetComponent<BulletScrip>();
        bulletScript.SetDirection(bulletDirection);
        bulletScript.SetShooterTag("Enemy");

        // Asegurarse de que la rotación de la bala apunte en la dirección correcta  
        float angle = Mathf.Atan2(bulletDirection.y, bulletDirection.x) * Mathf.Rad2Deg;
        bullet.transform.rotation = Quaternion.Euler(0, 0, angle);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            MovemPlayer player = collision.GetComponent<MovemPlayer>();
            if (player != null)
            {
                player.RecibirDaño(1);
            }
        }
    }
}
