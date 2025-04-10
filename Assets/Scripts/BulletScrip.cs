using UnityEngine;

public class BulletScrip : MonoBehaviour
{
    public float Speed = 5f;
    private Rigidbody2D Rigibody2D;
    private Vector2 Direction;
    private string shooterTag;

    private void Start()
    {
        Rigibody2D = GetComponent<Rigidbody2D>();
        Destroy(gameObject, 3f);
    }

    private void FixedUpdate()
    {
        Rigibody2D.linearVelocity = Direction * Speed;
    }

    public void SetDirection(Vector2 direction)
    {
        Direction = direction.normalized;
    }

    public void SetShooterTag(string tag)
    {
        shooterTag = tag;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (shooterTag == "Enemy" && other.CompareTag("Player"))
        {
            MovemPlayer player = other.GetComponent<MovemPlayer>();
            if (player != null)
            {
                player.RecibirDaño(1);
            }
            Destroy(gameObject);
        }
        else if (shooterTag == "Player" && other.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
